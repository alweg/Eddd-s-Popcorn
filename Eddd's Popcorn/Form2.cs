using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperEd
{
    public partial class Form2 : Form
    {
        public readonly Form1 Form1 = null;


        public Form2(Form1 f)
        {
            InitializeComponent();
            Form1 = f as Form1;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.Dispose();
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Hide();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Size = new Size(424, 136);
                this.ShowInTaskbar = true;
                this.MinimizeBox = true;
                this.ControlBox = true;
                if (!checkBox2.Checked) { this.Location = new Point(this.Location.X - 7, this.Location.Y + 487); }
                else { this.Location = new Point(this.Location.X + 1, this.Location.Y + 518); }
                panel13.Visible = false;
                panel8.Visible = false;
                panel15.Visible = false;
                panel10.Visible = false;
                panel24.Visible = false;
                panel1.Visible = false;
                panel4.Visible = false;
                panel21.Visible = false;
                panel5.Location = new Point(0, 0);
                panel20.Location = new Point(0, 21);
                Form1.Visible = false;
                this.Show();
            }
            else
            {
                this.Hide();
                this.Size = new Size(442, 655);
                if (!checkBox2.Checked)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.ShowInTaskbar = false;
                    this.MinimizeBox = false;
                    this.ControlBox = false;
                    Form1.Visible = true;
                    Form1.Location = new Point(this.Location.X - 765, Form1.Location.Y + 120);                    
                    this.Size = new Size(426, 616);
                }
                panel13.Visible = true;
                panel8.Visible = true;
                panel15.Visible = true;
                panel10.Visible = true;
                panel24.Visible = true;
                panel1.Visible = true;
                panel4.Visible = true;
                panel21.Visible = true;
                panel5.Location = new Point(1, 518);
                panel20.Location = new Point(1, 539);
                this.Show();
            }
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                Form1.Hide();
                this.Hide();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ShowInTaskbar = true;
                this.MinimizeBox = true;
                this.ControlBox = true;
                this.Location = new Point(this.Location.X - 9, this.Location.Y - 35);
                this.Show();
            }
            else
            {
                Form1.Location = new Point(this.Location.X - 765, this.Location.Y + 120);
                Form1.Show();
                this.Hide();
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
                this.MinimizeBox = false;
                this.ControlBox = false;
                this.Show();
            }
        }
        public void SetMonitorValues(string o, string v)
        {
            switch (o)
            {
                case "CurrentLevel": { label9.Text = v; break; }
                case "CurrentSaveGame": { label10.Text = v; break; }
                case "Springs": { label11.Text = v; break; }
                case "Pinwheels": { label13.Text = v; break; }
                case "JumpingStones": { label15.Text = v; break; }
                case "Feathers": { label17.Text = v; break; }
                case "Dominoes": { label18.Text = v; break; }
                case "PiggyBanks": { label19.Text = v; break; }
                case "Stick": { label5.Text = v; break; }
                case "Blowpipe": { label22.Text = v; break; }
                case "BowTie": { label12.Text = v; break; }
                case "DivingHelmet": { label21.Text = v; break; }
                case "ChameleonBelt": { label7.Text = v; break; }
                case "PogoStick": { label24.Text = v; break; }
                case "PosX": { label2.Text = v; break; }
                case "PosY": { label3.Text = v; break; }
                case "PosZ": { label4.Text = v; break; }
                case "RedSpadesCurrent": { label20.Text = v; break; }
                case "RedSpadesMax": { label25.Text = v; break; }
                case "SilverSpades": { label6.Text = v; break; }
            }
        }
    }
}
