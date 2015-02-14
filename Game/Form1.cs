using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.IO;

namespace Game
{
    
    public partial class Form1 : Form
    {
        int Exp=0;
        int countBoss = 2;

       
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int B=0, U=0;
            B = Int32.Parse(label2.Text);
            U = rnd.Next(0, 30);
            label3.Text = U.ToString();
            label2.Text = (B-U).ToString();
            if ((B - U) < 0) { 
                label2.Text = "0";
                
                label4.Text = "ПОБЕДИЛИ !!!!!!!!!!";
                pictureBox1.Visible = false;
           }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();


            int Lvl = Int32.Parse(label5.Text);
            int U = (10 + Lvl * 2) + rnd.Next(-5, 5);

            label3.Font = new Font(label3.Font.Name, 15,
                label3.Font.Style);
            label3.ForeColor = Color.Lime;
            if (rnd.Next(0, 100) <= 15)
            {
                U *= 3;
                label3.ForeColor = Color.Red;
                label3.Font = new Font(label3.Font.Name, 35,
                label3.Font.Style);
            }

            label3.Text = U.ToString();

            if ((progressBar1.Value - U) >= 0)
            {

                progressBar1.Value -= U;
                label2.Text = progressBar1.Value.ToString();
            }
            else
            {
                progressBar1.Value = 0;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                label3.Text = "0";

                Application.DoEvents();
                //  System.Threading.Thread.Sleep(100);
                if (countBoss == 1) { Exp += 30; }
                else { Exp += 6; }

                countBoss++;
                if (countBoss == 5)
                {
                    countBoss = 1;
                    pictureBox2.Visible = true;
                    progressBar1.Maximum = 300;
                }
                else
                {
                    pictureBox1.Visible = true;
                    progressBar1.Maximum = 100;

                }
                progressBar1.Value = progressBar1.Maximum;


                if (Exp > 100) { Exp -= 100; label5.Text = (Int32.Parse(label5.Text) + 1).ToString(); }
                progressBar2.Value = Exp;
                label6.Text = Exp.ToString();
                label2.Text = progressBar1.Value.ToString();




            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*foreach (Control control in Controls)
            {
                control.Visible = false;
            }
            button2.Visible = true;*/
            label5.Text = "1";  //LVL
            label6.Text = "0";  // EXP
            label2.Text = "100"; //HP Mob
            label3.Text = "0"; // Damage
            
            progressBar2.Value = 0;
            progressBar1.Value = 100;
            progressBar1.Maximum = 100;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            countBoss = 2;
            Exp = 0;
            
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            File.WriteAllLines(@"D:\text.txt", new string[] { Exp.ToString(), label5.Text });

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Exp = Convert.ToInt32(File.ReadAllLines(@"D:\text.txt")[0]);
            label5.Text = File.ReadAllLines(@"D:\text.txt")[1];
            progressBar2.Value = Exp;
            label6.Text = Exp.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(@"D:\text.txt", new string[] { Exp.ToString(), label5.Text });
        }

        private void picUmen3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();


            int Lvl = Int32.Parse(label5.Text);
            int U = (30 + Lvl * 2) + rnd.Next(-5, 5);

            label3.Font = new Font(label3.Font.Name, 15,
                label3.Font.Style);
            label3.ForeColor = Color.Lime;
            if (rnd.Next(0, 100) <= 15)
            {
                U *= 3;
                label3.ForeColor = Color.Red;
                label3.Font = new Font(label3.Font.Name, 35,
                label3.Font.Style);
            }

            label3.Text = U.ToString();

            if ((progressBar1.Value - U) >= 0)
            {

                progressBar1.Value -= U;
                label2.Text = progressBar1.Value.ToString();
            }
            else
            {
                progressBar1.Value = 0;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                label3.Text = "0";

                Application.DoEvents();
                //  System.Threading.Thread.Sleep(100);
                if (countBoss == 1) { Exp += 30; }
                else { Exp += 6; }

                countBoss++;
                if (countBoss == 5)
                {
                    countBoss = 1;
                    pictureBox2.Visible = true;
                    progressBar1.Maximum = 300;
                }
                else
                {
                    pictureBox1.Visible = true;
                    progressBar1.Maximum = 100;

                }
                progressBar1.Value = progressBar1.Maximum;


                if (Exp > 100) { Exp -= 100; label5.Text = (Int32.Parse(label5.Text) + 1).ToString(); }
                progressBar2.Value = Exp;
                label6.Text = Exp.ToString();
                label2.Text = progressBar1.Value.ToString();




            }
        }
            

        }

      
  }

