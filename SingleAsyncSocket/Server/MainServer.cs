using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Ortak;

namespace Server
{
    public partial class MainServer : Form
    {
        Sunucu sunucu; //Nesneler
        Client client;

        public MainServer()
        {
            InitializeComponent();
            KartlariListele();
            btnBaslat.Click += BtnBaslat_Click;
        }

        private void BtnBaslat_Click(object sender, EventArgs e)
        {
            sunucu = new Sunucu(8899);
            sunucu.BaglantiGeldi += Sunucu_BaglantiGeldi;
            sunucu.Baslat((IPAddress)cmbNetworks.SelectedValue);
            this.Text = "Server - " + ((IPAddress)cmbNetworks.SelectedValue).ToString();
            grpSunucu.Enabled = false;
        }

        private void Sunucu_BaglantiGeldi(Socket s)
        {
            if (client!=null)
            {
                s.Close();
                return;
            }
            client = new Client(s);
            client.BaglantiKesildi += Client_BaglantiKesildi;
            client.VeriTransferiTamamlandi += Client_VeriTransferiTamamlandi;
            client.AsenkronVeriTransferiniBaslat();
            Invoke((MethodInvoker)delegate
            {
                lblDurum.Text = "Durum: Bağlandı - " + client.EndPoint.ToString();
            });
        }

        private void Client_VeriTransferiTamamlandi(Client sender, Hafizalama e)
        {
            PaketOkuyucu po = new PaketOkuyucu(e.GelenDataStream);
            Komutlar k = (Komutlar)po.ReadUInt16();

            switch (k)
            {
                case Komutlar.Mesaj:
                    Invoke((MethodInvoker)delegate
                    {
                        lstMesajlar.Items.Add(po.ReadString());
                    });
                    break;
                case Komutlar.Nesne:
                    Kisi kisi = (Kisi)po.OkuNesne<Kisi>();
                    Invoke((MethodInvoker)delegate
                    {
                        txtAdi.Text = kisi.Adi;
                        txtDYili.Text = kisi.DYili.ToString();
                        txtMeslegi.Text = kisi.Meslegi;
                        txtSoyadi.Text = kisi.Soyadi;
                    });
                    break;
                case Komutlar.Resim:
                    Invoke((MethodInvoker)delegate
                    {
                        pcbResim.Image = po.OkuResim();
                    });
                    break;
                default:
                    break;
            }
        }

        private void Client_BaglantiKesildi(Client sender)
        {
            client.Kapat();
            client = null;
        }

        void KartlariListele()
        {
            Dictionary<string, IPAddress> cmbKaynak = new Dictionary<string, IPAddress>();
            foreach (NetworkInterface NI in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation IP in NI.GetIPProperties().UnicastAddresses)
                {
                    if (IP.Address.AddressFamily==AddressFamily.InterNetwork)
                    {
                        cmbKaynak.Add(IP.Address.ToString() + " - " + NI.Description, IP.Address);
                    }
                }
            }

            cmbNetworks.DataSource = new BindingSource(cmbKaynak, null);
            cmbNetworks.DisplayMember = "Key";
            cmbNetworks.ValueMember = "Value";


        }

    }
}
