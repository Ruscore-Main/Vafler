using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
  linkLabel1 - назад
button1 - меню
button2- сотрудники
comboBox1 - выберите ресторан
 
 */
namespace ArmREST
{
    public partial class Form3 : Form
    {
        Form1 form1;
        Model1Container _db;
        Admin currentAdmin;
        Cafe currentCafe;
        public Form3(Model1Container db, Form1 backForm, Admin admin)
        {
            InitializeComponent();
            this._db = db;
            this.form1 = backForm;
            this.currentAdmin = admin;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e) // Меню
        {
            Form5 form5 = new Form5(_db, this, currentCafe);
            this.Hide();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Сотрудники
        {
            Form4 form4 = new Form4(_db, this, currentCafe);
            this.Hide();
            form4.Show();
        }

        private void Form3_Load(object sender, EventArgs e) 
        {
            foreach (Cafe cafe in _db.CafeSet)
            {
                comboBox1.Items.Add(cafe);
            }
            label3.Text = currentAdmin.FIO;
            label4.Text = currentAdmin.Login;
            button1.Enabled = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCafe = comboBox1.SelectedItem as Cafe;
            button1.Enabled = true;
        }
    }
}
