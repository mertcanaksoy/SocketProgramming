using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Ortak
{
    [Serializable]
    public class Kisi
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Meslegi { get; set; }
        public int DYili { get; set; }
        
        public Kisi(string _adi,string _soyadi, string _meslegi, int _dyili)
        {
            Adi = _adi;
            Soyadi = _soyadi;
            Meslegi = _meslegi;
            DYili = _dyili;
        }
    }

    public enum Komutlar : ushort
    {
        Mesaj,
        Nesne,
        Resim
    }

    public class PaketYazici : BinaryWriter
    {
        MemoryStream ms;
        BinaryFormatter bf;
        public PaketYazici() : base()
        {
            ms = new MemoryStream();
            bf = new BinaryFormatter();
            OutStream = ms;
        }

        public byte[] ByteGetir()
        {
            Close();
            return ms.ToArray();
        }

        public void YazResim(byte[] data)
        {
            Write(data.Length);
            Write(data);
        }

        public void YazNesne(object o)
        {
            bf.Serialize(ms, o);

        }
    }

    public class PaketOkuyucu :BinaryReader
    {
        BinaryFormatter bf;
        public PaketOkuyucu(MemoryStream ms) : base(ms)
        {
            bf = new BinaryFormatter();
        }

        public Image OkuResim()
        {
            int i = ReadInt32();
            byte[] data = ReadBytes(i);
            MemoryStream ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        public T OkuNesne<T>()
        {
            return (T)bf.Deserialize(BaseStream);
        }

    }

    public struct Hafizalama
    {
        public int GelenDataBoyutu;
        public byte[] GelenData;
        public MemoryStream GelenDataStream;

        public Hafizalama(int _gelendataboyutu)
        {
            GelenDataBoyutu = _gelendataboyutu;
            GelenData = new byte[1024];
            GelenDataStream = new MemoryStream(_gelendataboyutu);
        }

        public void Yaz(int gelen)
        {
            GelenDataStream.Write(GelenData, 0, gelen);
            Array.Clear(GelenData, 0, GelenData.Length);
            GelenDataBoyutu -= gelen;
        }

        public void Dispose()
        {
            GelenDataBoyutu = 0;
            GelenData = null;
            Close(); //Close metodu çağırıldı
            if (GelenDataStream != null)
            {
                GelenDataStream.Dispose();
            }
        }

        public void Close()
        {
            if (GelenDataStream != null && GelenDataStream.CanWrite)
            {
                GelenDataStream.Close();
            }
        }

    }

    public class Client
    {
        public delegate void BaglantiKesildiH(Client sender);
        public delegate void VeriTransferiTamamlandiH(Client sender, Hafizalama e);
        public event BaglantiKesildiH BaglantiKesildi;
        public event VeriTransferiTamamlandiH VeriTransferiTamamlandi;

        byte[] gelenBoyut;
        Hafizalama hafiza;
        Socket soket;
        public IPEndPoint EndPoint
        {
            get
            {
                if (soket != null && soket.Connected)
                {
                    return (IPEndPoint)soket.RemoteEndPoint;
                }
                return new IPEndPoint(IPAddress.None, 0);
            }
        }

        public Client(Socket s)
        {
            soket = s;
            gelenBoyut = new byte[4];
        }

        public void Kapat()
        {
            if (soket != null)
            {
                soket.Disconnect(false);
                soket.Close();
            }
            hafiza.Dispose();
            soket = null;
            gelenBoyut = null;
            BaglantiKesildi = null;
            VeriTransferiTamamlandi = null;
        }

        public void AsenkronVeriTransferiniBaslat()
        {
            soket.BeginReceive(gelenBoyut, 0, gelenBoyut.Length, SocketFlags.None, GelenDataBoyutu, null);
        }

        private void GelenDataBoyutu(IAsyncResult ar)
        {
            try
            {
                int i = soket.EndReceive(ar);
                if (i == 0)
                {
                    if (BaglantiKesildi != null)
                    {
                        BaglantiKesildi(this);
                        return;
                    }
                    if (i != 4)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                if (BaglantiKesildi != null)
                {
                    BaglantiKesildi(this);
                    return;
                }
            }
            hafiza = new Hafizalama(BitConverter.ToInt32(gelenBoyut, 0));
            soket.BeginReceive(hafiza.GelenData, 0, hafiza.GelenData.Length, SocketFlags.None, VeriTransferi, null);
        }

        private void VeriTransferi(IAsyncResult ar)
        {
            try
            {
                int i = soket.EndReceive(ar);
                if (i <= 0)
                {
                    return;
                }
                hafiza.Yaz(i);
                if (hafiza.GelenDataBoyutu > 0)
                {
                    soket.BeginReceive(hafiza.GelenData, 0, hafiza.GelenData.Length, SocketFlags.None, VeriTransferi, null);
                    return;
                }
                if (VeriTransferiTamamlandi != null)
                {
                    hafiza.GelenDataStream.Position = 0;
                    VeriTransferiTamamlandi(this, hafiza);
                }
                hafiza.Dispose();
                AsenkronVeriTransferiniBaslat();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class Sunucu
    {
        public delegate void BaglantiGeldiH(Socket s);
        public event BaglantiGeldiH BaglantiGeldi;
        Socket soket;
        int port;

        public bool BaglantiDurumu
        {
            get;
            private set;
        }

        public Sunucu(int _port)
        {
            port = _port;
        }

        public void Baslat(IPAddress ip)
        {
            if (BaglantiDurumu)
            {
                return;
            }
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soket.Bind(new IPEndPoint(ip, port));
            soket.Listen(0);
            soket.BeginAccept(BaglantiGeldiginde, null);
        }

        private void BaglantiGeldiginde(IAsyncResult ar)
        {
            try
            {
                Socket s = soket.EndAccept(ar);
                if (BaglantiGeldi != null)
                {
                    BaglantiGeldi(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (BaglantiDurumu)
            {
                soket.BeginAccept(BaglantiGeldiginde, null);
            }
        }

        public void Durdur()
        {
            if (!BaglantiDurumu)
            {
                return;
            }
            soket.Close();
            BaglantiDurumu = false;
        }
    }

    public class Terminal
    {
        public delegate void BaglantiSaglandiH(Terminal sender, bool baglantiDurum);
        public delegate void BaglantiKesildiH(Terminal sender);
        public delegate void VeriGonderildiH(Terminal sender, int gonderilen);
        public event BaglantiSaglandiH BaglantiSaglandi;
        public event BaglantiKesildiH BaglantiKesildi;
        public event VeriGonderildiH VeriGonderildi;

        Socket soket;
        public bool BaglantiDurumu
        {
            get
            {
                if (soket!=null)
                {
                    return soket.Connected;
                }
                return false;
            }
        }

        public Terminal()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Baglan(string ip, int port)
        {
            if (soket == null)
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            soket.BeginConnect(ip, port, Baglandiginda, null);
        }

        private void Baglandiginda(IAsyncResult ar)
        {
            try
            {
                soket.EndConnect(ar);
                if (BaglantiSaglandi != null)
                {
                    BaglantiSaglandi(this, BaglantiDurumu);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Gonder(byte[] data, int boyut)
        {
            soket.BeginSend(BitConverter.GetBytes(boyut), 0, 4, SocketFlags.None, Gonderildiginde, null);
            soket.BeginSend(data, 0, data.Length, SocketFlags.None, Gonderildiginde, null);
        }

        private void Gonderildiginde(IAsyncResult ar)
        {
            try
            {
                int gonderilen = soket.EndSend(ar);
                if (VeriGonderildi!=null)
                {
                    VeriGonderildi(this, gonderilen);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BaglantiyiKes()
        {
            try
            {
                if (soket.Connected)
                {
                    soket.Close();
                    if (BaglantiKesildi!=null)
                    {
                        BaglantiKesildi(this);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
