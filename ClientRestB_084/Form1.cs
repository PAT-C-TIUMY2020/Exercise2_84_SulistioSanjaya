using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRestB_084
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //TampilData();
        }
        
        public void SearchData()
        {
            var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            string nim = textBoxNIM.Text;
            if (nim == null || nim == "")
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                var item = data.Where(x => x.nim == textBoxNIM.Text).ToList();

                dataGridView1.DataSource = item;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNama.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBoxNIM.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            textBoxProdi.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            textBoxAngkatan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }

        private void buttonTotal_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            int length = data.Count();
            txtJumlah.Text = Convert.ToString(length);
        }
        public class Mahasiswa
        {
            private string _nama, _nim, _prodi, _angkatan;
            public string nama
            {
                get { return _nama; }
                set { _nama = value; }
            }

            public string nim
            {
                get { return _nim; }
                set { _nim = value; }
            }

            public string prodi
            {
                get { return _prodi; }
                set { _prodi = value; }
            }

            public string angkatan
            {
                get { return _angkatan; }
                set { _angkatan = value; }
            }
        }

        private void txtJumlah_Click(object sender, EventArgs e)
        {

        }
    }
}
