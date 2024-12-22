﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sqlite
{
    public partial class frmListele : Form
    {
        public frmListele()
        {
            InitializeComponent();
            Listele();
        }
        void Listele()
        {
            string sql = "Select Id,AdSoyad,Telefon,Cast(Maaş as varchar) as Maaş,Tarih from Bilgiler ";
            dataGridView1.DataSource = CRUD.Listele(sql);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            frmKaydet frm=new frmKaydet();
            frm.ShowDialog();
            if (frm.Kaydedildi)
            {
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            int seciliid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            frmKaydet frm=new frmKaydet(seciliid);
            frm.txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
            frm.txtTelefon.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            frm.txtMaas.Text= dataGridView1.CurrentRow.Cells["Maaş"].Value.ToString();
            frm.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["Tarih"].Value.ToString();
            frm.ShowDialog();
            if (frm.Kaydedildi)
            {
                Listele();
            }
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili kayıt silinecek.Onaylıyor musunuz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
            int seciliid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            string sql = "Delete from Bilgiler Where Id='"+seciliid + "'";
                if (CRUD.ESG(sql))
                {
                    Listele();
                }
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
