using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        
        Point[] points = new Point[50];      
        List<Cvor> lista;
        Graf graf;
        Dictionary<(String prvi, String drugi), int> dict;


        public Form1(Graf graf)
        {
            this.graf = graf;
            this.lista = graf.listaCvorova;
            this.dict = graf.dict;
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            
            InitializeComponent();
            this.Text = "Aplikacija za poučavanje Dijkstrinog algoritma";
            this.Load += new EventHandler(this.Form1_Load);
            g = this.CreateGraphics();
            p = new Pen(Color.Black, 2);
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            this.Size = new Size(1536, 824);
            this.Location = new Point(0, 0);
            //this.StartPosition = FormStartPosition.CenterScreen;
            

        }
       

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            //graf.nacrtajGraf(g);
            foreach (Cvor cvor in lista)
            {
                g.FillEllipse(Brushes.Black, cvor.koordinate.X - 3, cvor.koordinate.Y - 3, 12, 12);
                Label namelabel = new Label();
                namelabel.Location = new Point(cvor.koordinate.X + 15, cvor.koordinate.Y );
                namelabel.Text = cvor.ime;
                namelabel.Font = new Font("Arial", 12, FontStyle.Regular);
                namelabel.AutoSize = true;
                namelabel.BackColor = Color.Transparent;
                this.Controls.Add(namelabel);


                //graf.NadiPuteve1("Čakovec", "Požega", g, textBox1);
            //g.DrawCurve(p, points);
            
            }
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Jeste li sigurni da želite izaći?", "Izađi", MessageBoxButtons.YesNo);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // gumb Izracunaj
            graf.OcistiTekst();
            graf.refreshDijkstra(graf.listaCvorova); // refreshati listu cvorova dok se dijkstra izvada vise puta
            Console.WriteLine("Stanje cvorova: ");
            foreach(Cvor cvor in graf.listaCvorova)
            {
                Console.WriteLine("Cvor: " + cvor.ime + cvor.prijasnji + cvor.status);
            }
            string prvi = comboBox1.Text;
            string drugi = comboBox2.Text;
            graf.NadiPuteve1(prvi, drugi, g, textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //gumb Ocisti
            this.Refresh();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //gumb Objasni algoritam
            StringBuilder tekst;
            tekst = graf.vratiTekst();
            string tekstic = tekst.ToString();
            Form2 forma2 = new Form2(tekstic);
            forma2.ShowDialog();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            graf.nacrtajGraf(g);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //gumb Dijkstrino stablo
            string prvi = comboBox1.Text;
            graf.NacrtajStablo(prvi, g);
        }
    }
}
