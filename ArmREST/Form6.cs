using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArmREST
{
    public partial class Form6 : Form
    {
        Model1Container _db;
        Form4 form4;
        public Form6(Model1Container db, Form4 backForm)
        {
            InitializeComponent();
            this._db = db;
            this.form4 = backForm;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Employee newEmployee = new Employee()
                {
                    FIO = textBox1.Text,
                    PhoneNumber = textBox4.Text,
                    Salary = Convert.ToInt32(textBox5.Text),
                    Cafe = comboBox1.SelectedItem as Cafe,
                    Post = textBox2.Text,
                    Login = textBox3.Text,
                    Password = textBox7.Text
                };

                _db.EmployeeSet.Add(newEmployee);

                _db.SaveChanges();
                form4.UpdateList();
                MessageBox.Show("Успешно добавлено!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неправильный формат данных!");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            foreach (Cafe cafe in _db.CafeSet)
            {
                comboBox1.Items.Add(cafe);
            }
        }
    }
}
