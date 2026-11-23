using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ed2026bogdan
{
    public partial class Form1 : Form
    {
        DataTable podaci;
        int br_red;

        public Form1()
        {
            InitializeComponent();
        }

        private void prikaz()
        {
            textBox1.Text = podaci.Rows[br_red]["id"].ToString();
            textBox2.Text = podaci.Rows[br_red]["ime"].ToString();
            textBox3.Text = podaci.Rows[br_red]["prezime"].ToString();
            textBox4.Text = podaci.Rows[br_red]["jmbg"].ToString();
            textBox5.Text = podaci.Rows[br_red]["email"].ToString();
            textBox6.Text = podaci.Rows[br_red]["pass"].ToString();
            textBox7.Text = podaci.Rows[br_red]["adresa"].ToString();
            textBox8.Text = podaci.Rows[br_red]["uloga"].ToString();

            if (br_red == 0)
            {
                btnPrev.Enabled = false;
            } 
            else 
            {
                btnPrev.Enabled = true;
            }
            if (br_red == podaci.Rows.Count - 1)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            podaci = new DataTable();
            string CS = "Data source=DESKTOP-USO4G6P\\SQLEXPRESS; Initial catalog=ed2026b; Integrated security=true";
            SqlConnection veza = new SqlConnection(CS);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ucenik", veza);
            adapter.Fill(podaci);
            br_red = 0;
            prikaz();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            br_red++;
            prikaz();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            br_red--;
            prikaz();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            br_red = 0;
            prikaz();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            br_red = podaci.Rows.Count;
            prikaz();
        }
    }
}
