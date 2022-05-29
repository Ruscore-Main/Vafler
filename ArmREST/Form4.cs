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
 button1 - удалить
button2- изменить
button3 - добавить
textBox1- Имя
textBox2- фамилия
textBox3 - Отчество
textBox4 - телефон
textBox5- зарплата
textBox6 - место работы
linklabel1 - назад
listbox1 - сотрудники
 */
namespace ArmREST
{
    public partial class Form4 : Form
    {
        Model1Container _db;
        Form3 form3;
        Cafe currentCafe;
        Employee currentEmployee;
        public Form4(Model1Container db, Form3 backForm, Cafe cafe)
        {
            InitializeComponent();
            this._db = db;
            this.form3 = backForm;
            this.currentCafe = cafe;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form3.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(_db, this);
            this.Hide();
            form6.Show();
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Employee employee in _db.EmployeeSet)
            {
                listBox1.Items.Add(employee);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Cafe cafe in _db.CafeSet)
            {
                comboBox1.Items.Add(cafe);
            }
            button1.Enabled = false;
            button2.Enabled = false;
            UpdateList();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentEmployee = listBox1.SelectedItem as Employee;
                if (currentEmployee != null)
                {
                    textBox1.Text = currentEmployee.FIO;
                    textBox4.Text = currentEmployee.PhoneNumber;
                    textBox5.Text = Convert.ToString(currentEmployee.Salary);
                    textBox6.Text = currentEmployee.Post;
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(currentEmployee.Cafe);
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentEmployee.FIO = textBox1.Text;
            currentEmployee.PhoneNumber = textBox4.Text;
            currentEmployee.Salary = Convert.ToInt32(textBox5.Text);
            currentEmployee.Post = textBox6.Text;
            currentEmployee.Cafe = comboBox1.SelectedItem as Cafe;

            _db.SaveChanges();
            UpdateList();
            MessageBox.Show("Успешно изменено!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _db.EmployeeSet.Remove(currentEmployee);
            _db.SaveChanges();
            UpdateList();
            MessageBox.Show("Успешно удалено!");
        }
    }
}
