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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Size = new System.Drawing.Size(452,806);
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
            entry f2 = new entry();
            string[] row = new string[] {};
            
            

            
        }
    }
}
