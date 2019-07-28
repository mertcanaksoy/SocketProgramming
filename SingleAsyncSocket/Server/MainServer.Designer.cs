namespace Server
{
    partial class MainServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMesajlar = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDYili = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMeslegi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoyadi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSunucu = new System.Windows.Forms.GroupBox();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNetworks = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pcbResim = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpSunucu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbResim)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMesajlar);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gelen Text Mesajları";
            // 
            // lstMesajlar
            // 
            this.lstMesajlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMesajlar.FormattingEnabled = true;
            this.lstMesajlar.Location = new System.Drawing.Point(3, 16);
            this.lstMesajlar.Name = "lstMesajlar";
            this.lstMesajlar.Size = new System.Drawing.Size(282, 132);
            this.lstMesajlar.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDYili);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMeslegi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSoyadi);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAdi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 139);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gelen Nesne Özellikleri";
            // 
            // txtDYili
            // 
            this.txtDYili.Location = new System.Drawing.Point(53, 103);
            this.txtDYili.Name = "txtDYili";
            this.txtDYili.ReadOnly = true;
            this.txtDYili.Size = new System.Drawing.Size(226, 20);
            this.txtDYili.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "D.Yili";
            // 
            // txtMeslegi
            // 
            this.txtMeslegi.Location = new System.Drawing.Point(53, 77);
            this.txtMeslegi.Name = "txtMeslegi";
            this.txtMeslegi.ReadOnly = true;
            this.txtMeslegi.Size = new System.Drawing.Size(226, 20);
            this.txtMeslegi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mesleği :";
            // 
            // txtSoyadi
            // 
            this.txtSoyadi.Location = new System.Drawing.Point(53, 51);
            this.txtSoyadi.Name = "txtSoyadi";
            this.txtSoyadi.ReadOnly = true;
            this.txtSoyadi.Size = new System.Drawing.Size(226, 20);
            this.txtSoyadi.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SoyAdı :";
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(53, 25);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.ReadOnly = true;
            this.txtAdi.Size = new System.Drawing.Size(226, 20);
            this.txtAdi.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Adı :";
            // 
            // grpSunucu
            // 
            this.grpSunucu.Controls.Add(this.btnBaslat);
            this.grpSunucu.Controls.Add(this.lblDurum);
            this.grpSunucu.Controls.Add(this.label6);
            this.grpSunucu.Controls.Add(this.cmbNetworks);
            this.grpSunucu.Location = new System.Drawing.Point(3, 302);
            this.grpSunucu.Name = "grpSunucu";
            this.grpSunucu.Size = new System.Drawing.Size(288, 122);
            this.grpSunucu.TabIndex = 2;
            this.grpSunucu.TabStop = false;
            this.grpSunucu.Text = "Sunucu İşlemleri";
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(6, 67);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(276, 23);
            this.btnBaslat.TabIndex = 6;
            this.btnBaslat.Text = "Sunucuyu Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(12, 105);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(44, 13);
            this.lblDurum.TabIndex = 4;
            this.lblDurum.Text = "Durum :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Network Adapter";
            // 
            // cmbNetworks
            // 
            this.cmbNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetworks.FormattingEnabled = true;
            this.cmbNetworks.Location = new System.Drawing.Point(6, 39);
            this.cmbNetworks.Name = "cmbNetworks";
            this.cmbNetworks.Size = new System.Drawing.Size(276, 21);
            this.cmbNetworks.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pcbResim);
            this.groupBox4.Location = new System.Drawing.Point(297, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(567, 418);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gelen Resim";
            // 
            // pcbResim
            // 
            this.pcbResim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbResim.Location = new System.Drawing.Point(3, 16);
            this.pcbResim.Name = "pcbResim";
            this.pcbResim.Size = new System.Drawing.Size(561, 399);
            this.pcbResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbResim.TabIndex = 0;
            this.pcbResim.TabStop = false;
            // 
            // MainServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 426);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpSunucu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainServer";
            this.Text = "Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpSunucu.ResumeLayout(false);
            this.grpSunucu.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstMesajlar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDYili;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMeslegi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoyadi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpSunucu;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNetworks;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pcbResim;
    }
}

