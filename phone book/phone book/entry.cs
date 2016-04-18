using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phone_book
{
    public partial class entry : Form
    {
        public entry()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            entry en = new entry();
            
           // Form1 ff = new Form1();
//this.Hide();
          //  ff.Show();
           textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            button1.Hide();
           // entry f1 = new entry();
            
          //  f1.Size = new System.Drawing.Size(452, 806);
          //  f1.Width = 452;
          //  f1.Height = 806;
            Width = 800;
            Height = 440;
            DataGridView dt = new DataGridView();
            dt.Location = new Point(12, 55);
            dt.Height = 350;
            dt.Width = 770;
            dt.Visible = true;
            dt.Margin = new Padding(3, 3, 3, 3);
            this.Controls.Add(dt);
            dt.ColumnCount = 4;
            dt.Columns[0].Name = "NAME";
            dt.Columns[1].Name = "CITY";
            dt.Columns[2].Name = "PNONE NO.";
            dt.Columns[3].Name = "ADDRESS";
            dt.Columns[0].Width = 180;
            dt.Columns[1].Width = 180;
            dt.Columns[2].Width = 180;
            dt.Columns[3].Width = 180;
            
        }

        private void entry_Load(object sender, EventArgs e)
        {
            Width = 587;
            Height = 297;
        }
    }
}
