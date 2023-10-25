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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form novahra = new Form();
        Form nastaveni = new Form();
        Form nacisthru = new Form();
        Form ukoncithru = new Form();
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox jmeno = new TextBox();
            jmeno.Location = new Point(50, 0);
            Button ulozit = new Button();
            ulozit.Size = new Size(100, 50);
            ulozit.Location = new Point(50, 30);
            ulozit.Text = "Uložit";
            ulozit.DialogResult = DialogResult.OK;
            novahra.Controls.Add(jmeno);
            novahra.Controls.Add(ulozit);
            novahra.ShowDialog();
            if (ulozit.DialogResult == DialogResult.OK)
            {
                FileStream textak = new FileStream("hra.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter zapisovac = new StreamWriter(textak);
                string jmenoxd = jmeno.Text;
                zapisovac.Write("Jméno: " + jmenoxd + ", datum a čas vytvoření: " + DateTime.Now);
                zapisovac.Close();
                MessageBox.Show("Jméno bylo uloženo :D");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckBox fullscreen = new CheckBox();
            fullscreen.Location = new Point(10, 100);
            fullscreen.Text = "Režim celé obrazovky";
            RadioButton cervena = new RadioButton();
            cervena.Location = new Point(10, 10);
            cervena.Text = "Červená";
            RadioButton zelena = new RadioButton();
            zelena.Location = new Point(10, 40);
            zelena.Text = "Zelená";
            RadioButton modra = new RadioButton();
            modra.Location = new Point(10, 70);
            modra.Text = "Modrá";
            Button ulozit = new Button();
            ulozit.Size = new Size(100, 50);
            ulozit.Location = new Point(50, 200);
            ulozit.Text = "Uložit nastavení";
            ulozit.DialogResult = DialogResult.OK;
            Button zpet = new Button();
            zpet.Size = new Size(100, 50);
            zpet.Location = new Point(152, 200);
            zpet.Text = "Zpět do menu";
            zpet.DialogResult = DialogResult.Cancel;

            nastaveni.Controls.Add(zpet);
            nastaveni.Controls.Add(ulozit);
            nastaveni.Controls.Add(cervena);
            nastaveni.Controls.Add(zelena);
            nastaveni.Controls.Add(modra);
            nastaveni.Controls.Add(fullscreen);

            nastaveni.ShowDialog();
            if (ulozit.DialogResult == DialogResult.OK)
            {
                if(cervena.Checked == true)
                {
                    BackColor = Color.Red;
                    novahra.BackColor = Color.Red;
                    nastaveni.BackColor = Color.Red;
                    nacisthru.BackColor = Color.Red;
                    ukoncithru.BackColor = Color.Red;

                }
                else if(zelena.Checked == true)
                {
                    BackColor = Color.Green;
                    novahra.BackColor = Color.Green;
                    nastaveni.BackColor = Color.Green;
                    nacisthru.BackColor = Color.Green;
                    ukoncithru.BackColor = Color.Green;
                }
                else if (modra.Checked == true)
                {
                    BackColor = Color.Blue;
                    novahra.BackColor = Color.Blue;
                    nastaveni.BackColor = Color.Blue;
                    nacisthru.BackColor = Color.Blue;
                    ukoncithru.BackColor = Color.Blue;
                }
                if(fullscreen.Checked == true)
                {
                    Size = new Size(1920, 1080);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream textak = new FileStream("hra.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader ctenar = new StreamReader(textak);
            if (!ctenar.EndOfStream)
            {                          
                Label label = new Label();
                label.Location = new Point(50, 50);
                label.Size = new Size(500, 20);
                label.Text = "Načtená hra: " + ctenar.ReadLine();
                nacisthru.Controls.Add(label);
            }
            ctenar.Close();
            
            nacisthru.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Location = new Point(50, 50);
            label.Size = new Size(200, 20);
            label.Text = "Opravdu chcete ukončit hru?";
            Button ano = new Button();
            ano.Size = new Size(100, 50);
            ano.Location = new Point(50, 200);
            ano.Text = "Ano";
            ano.DialogResult = DialogResult.OK;
            Button ne = new Button();
            ne.Size = new Size(100, 50);
            ne.Location = new Point(152, 200);
            ne.Text = "Ne";
            ne.DialogResult = DialogResult.Cancel;
            ukoncithru.Controls.Add(ano);
            ukoncithru.Controls.Add(ne);
            ukoncithru.Controls.Add(label);
            ukoncithru.ShowDialog();
            if (ano.DialogResult == DialogResult.OK)
            {
                 this.Close();
            }
        }
    }
}
