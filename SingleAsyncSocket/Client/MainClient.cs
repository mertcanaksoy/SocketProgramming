using System;
using System.Windows.Forms;
using System.IO;
using Ortak;

namespace Client
{
    public partial class MainClient : Form
    {
        Terminal trm;

        public MainClient()
        {
            InitializeComponent();
            btnMesaj.Click += BtnMesaj_Click;
            btnNesne.Click += BtnNesne_Click;
            btnResim.Click += BtnResim_Click;
            btnSunucuyaBaglan.Click += BtnSunucuyaBaglan_Click;

            trm = new Terminal();
            trm.BaglantiSaglandi += Trm_BaglantiSaglandi;
            trm.BaglantiKesildi += Trm_BaglantiKesildi;
            trm.VeriGonderildi += Trm_VeriGonderildi;

        }

        private void Trm_VeriGonderildi(Terminal sender, int gonderilen)
        {
            Invoke((MethodInvoker)delegate
            {
                lblDurum.Text = "Durum: Data iletildi - " + gonderilen.ToString();
            });
        }

        private void Trm_BaglantiKesildi(Terminal sender)
        {
            Invoke((MethodInvoker)delegate
            {
                lblDurum.Text = "Durum: Bağlantı Kesildi";
            });
        }

        private void Trm_BaglantiSaglandi(Terminal sender, bool baglantiDurum)
        {
            Invoke((MethodInvoker)delegate
            {
                if (trm.BaglantiDurumu)
                {
                    lblDurum.Text = "Durum: Bağlantı Sağlandı";
                }
            });
        }

        private void BtnSunucuyaBaglan_Click(object sender, EventArgs e)
        {
            if (!trm.BaglantiDurumu)
            {
                trm.Baglan(txtSunucuIP.Text, 8899);
                grpTerminal.Enabled = false;
            }
        }

        private void BtnResim_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog o =new OpenFileDialog())
            {
                if (o.ShowDialog()==DialogResult.OK)
                {
                    PaketYazici py = new PaketYazici();
                    py.Write((ushort)Komutlar.Resim);
                    py.YazResim(File.ReadAllBytes(o.FileName));
                    byte[] data = py.ByteGetir();
                    trm.Gonder(data, data.Length);
                }               
            }
        }

        private void BtnNesne_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text.Length != 0 && txtSoyadi.Text.Length != 0 && txtMesaj.Text.Length != 0 && txtDYili.Text.Length != 0)
            {
                Kisi k = new Kisi(txtAdi.Text, txtSoyadi.Text, txtMeslegi.Text, int.Parse(txtDYili.Text));
                PaketYazici py = new PaketYazici();
                py.Write((ushort)Komutlar.Nesne);
                py.YazNesne(k);
                byte[] data = py.ByteGetir();
                trm.Gonder(data, data.Length);
            }
            else
            {
                MessageBox.Show("Lütfen tüm nesne kısımlarını doldurunuz.");
            }
        }

        private void BtnMesaj_Click(object sender, EventArgs e)
        {
            if (txtMesaj.Text.Length != 0)
            {
                PaketYazici py = new PaketYazici();
                py.Write((ushort)Komutlar.Mesaj);
                py.Write(txtMesaj.Text);
                byte[] data = py.ByteGetir();
                trm.Gonder(data, data.Length);
            }
            else
            {
                MessageBox.Show("Lütfen tüm mesaj kısmını doldurunuz.");
            }
        }
    }
}
