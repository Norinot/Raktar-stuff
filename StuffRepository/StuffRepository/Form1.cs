using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StuffRepository
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            dataBox.Visible = false;
            button1.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            StreamReader userread = new StreamReader("users.txt", Encoding.UTF8);
            bool siker = false;
            userread.ReadLine();
            while (!userread.EndOfStream)
            {
                string[] split = userread.ReadLine().Split(';');
                if (textBox1.Text == split[0]&&textBox2.Text== split[1])
                {
                    siker = true;
                }
                else
                {
                    MessageBox.Show("Helytelen jelszó!");
                }
            }
            userread.Close();
            if (siker)
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                dataBox.Visible = true;
                button1.Visible = true;
                username_label.Visible = false;
                password_label.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                login_button.Visible = false;
            }
            Read();
            for (int i = 0; i < asd.Count; i++)
            {
                dataBox.Text += asd[i]+"\n";
            }
            
        }
        public static List<string> asd = new List<string>();
        private void Read()
        {
            asd.Clear();
            StreamReader readBooks = new StreamReader("konyvek.txt", Encoding.UTF8);
            while (!readBooks.EndOfStream)
            {
                // string[] splitting = readBooks.ReadLine().Split(';');
                asd.Add(readBooks.ReadLine());
            }
            readBooks.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter wrtIn = new StreamWriter("konyvek.txt", true, Encoding.UTF8);
            wrtIn.WriteLine(textBox3.Text + ";" + textBox4.Text + ";" + textBox5.Text);
            wrtIn.Close();
        }
    }
}
