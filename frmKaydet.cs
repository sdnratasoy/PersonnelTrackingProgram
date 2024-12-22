using System;
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
    public partial class frmKaydet : Form
    {
        int ? id=null;
        public bool Kaydedildi = false;
        public frmKaydet(int? Id=null)
        {
            InitializeComponent();
            if (Id != null)
            {
                this.id = Id;
                 
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                string sql = "Insert into Bilgiler(AdSoyad, Telefon, Maaş, Tarih) " +"Values('" + txtAdSoyad.Text + "', '" + txtTelefon.Text + "', '" + txtMaas.Text + "', '" + dateTimePicker1.Value + "')";

                if (CRUD.ESG(sql)) 
                {
                    Kaydedildi=true;
                    MessageBox.Show("Ekleme işlemi başarıyla gerçekleşti.");
                }
                this.Close();

                
            }
            else
            {
                string sql = "Update Bilgiler set AdSoyad='" + txtAdSoyad.Text + "', Telefon= '" + txtTelefon.Text + "',Maaş= '" + txtMaas.Text + "',Tarih= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' Where Id='"+id+"'";

                if (CRUD.ESG(sql))
                {
                    Kaydedildi = true;
                    MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.");
                    this.Close();
                }
            }
        }
    }
}
