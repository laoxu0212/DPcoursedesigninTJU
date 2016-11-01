using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datebass
{
    public partial class ClientManage : Form
    {
        public ClientManage()
        {
            InitializeComponent();
        }

        private void ClientManage_Load(object sender, EventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    SelectClientID frm2 = new SelectClientID();
        //    frm2.Show();
        //    this.Hide();
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            usermainpage fm = new usermainpage();
            fm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            if (client.insertClient(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("客户编号为'" + client.checkClient(textBox1.Text, textBox2.Text) + "'");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Client client = new Client();
            if (textBox7.Text != "" && textBox7.Text != null)
            {
                bool result = client.showClient(textBox7.Text);
                if (result)
                {
                    textBox10.Text = client.client_id;
                    textBox6.Text = client.phone_number;
                    textBox4.Text = client.name;
                }
                else
                {
                  
                    return;
                }
            }
            else
            {
                MessageBox.Show("客户编号为'" + client.checkClient(textBox5.Text, textBox3.Text) + "'");
                bool result = client.showClient(textBox5.Text, textBox3.Text);
                if (result)
                {
                    textBox10.Text = client.client_id;
                    textBox6.Text = client.phone_number;
                    textBox4.Text = client.name;
                }
                else
                {
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.update_client(textBox10.Text, textBox4.Text, textBox6.Text);
        }
    }
}
