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
        public int counter;

        public static List<string> asd = new List<string>();

        public Form1()
        {
            
            InitializeComponent();
            dataBox.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
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
                button2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                username_label.Visible = false;
                password_label.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                login_button.Visible = false;
            }
            GoForth();
        }
        private void GoForth()
        {
            Read();
            for (int i = 1; i < asd.Count; i++)
            {
                string[] dsa = asd[i].Split(';');
                for (int x = 0; x != 3; x++)
                {
                    dataBox.Text += dsa[x] + ";";
                }
                dataBox.Text += "\n";
            }
        }
        private void Read()
        {
            asd.Clear();
            StreamReader readBooks = new StreamReader("konyvek.txt", Encoding.UTF8);
            while (!readBooks.EndOfStream)
            {
                asd.Add(readBooks.ReadLine());
            }
            readBooks.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            counter = asd.Count;
            StreamWriter wrtIn = new StreamWriter("konyvek.txt", true, Encoding.UTF8);
            wrtIn.WriteLine(counter +";"+ textBox3.Text + ";" + textBox4.Text + ";");
            wrtIn.Close();
            dataBox.Text = null;
            GoForth();
        }

        private void dataBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
