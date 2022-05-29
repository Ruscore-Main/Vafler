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
radioButton-1 Директор
 radioButton-2 Сотрудник
linkLabel1- регистрация
textBox3 - логин сотрудник
textBox4 - пароль сотрудник
button2 - войти сотрудник
button1 - войти директор

 */
namespace ArmREST
{
    public partial class Form1 : Form
    {
        string currentUser = "Employee";
        Model1Container _db = new Model1Container();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (_db.CafeSet.Count() == 0)
            {
                Cafe cafe1 = new Cafe()
                {
                    Address = "г. Казань, ул. Вишневского, д. 32",
                    Name = "KFC №1",
                    Schedule = "8:00 - 22:00"
                };

                Cafe cafe2 = new Cafe()
                {
                    Address = "г. Москва, ул. Новый-Арбат, д. 13",
                    Name = "KFC №1",
                    Schedule = "8:00 - 23:00"
                };

                _db.CafeSet.Add(cafe1);
                _db.CafeSet.Add(cafe2);

                _db.SaveChanges();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2(_db, this);
            this.Hide();
            form2.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (currentUser == "Admin")
            {
                Admin admin = _db.AdminSet.FirstOrDefault(el => el.Login == textBox3.Text && el.Password == textBox4.Text);
                if (admin != null)
                {
                    Form3 form3 = new Form3(_db, this, admin); // Admin
                    this.Hide();
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Директор не найден!");
                }

            }
            else
            {
                Employee employee = _db.EmployeeSet.FirstOrDefault(el => el.Login == textBox3.Text && el.Password == textBox4.Text);
                if (employee != null)
                {
                    Form8 form8 = new Form8(_db, this, employee); // Employee
                    this.Hide();
                    form8.Show();
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден!");
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currentUser = "Admin";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currentUser = "Employee";
        }
    }
}
