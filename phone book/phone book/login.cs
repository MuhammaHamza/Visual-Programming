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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "hamza" && textBox2.Text == "12345")
            {
                pictureBox2.Visible = true;
                DialogResult dt = MessageBox.Show("Welcome My Friend", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dt == DialogResult.OK)
                {
                    entry f2 = new entry();
                    f2.Show();
                    this.Hide();
                }
            }
                else
                {
                    pictureBox1.Visible = true;
                    DialogResult dd = MessageBox.Show("Sorry You Enter Your Credentials Wrong---.Try Again", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dd == DialogResult.Yes)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        login l = new login();
                        l.ResetText();
                    }
                    else if(dd==DialogResult.No)
                    {
                        
                        login l1 = new login();
                        l1.Close();
                    }
                }
            }
        }
    }
