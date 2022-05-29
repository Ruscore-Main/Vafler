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
textBox1 - логин директор
textBox2 - Фио директор
textBox3 - Пароль директор
textBox4 - пароль сотрудник
textBox5 - Фио сотрудник
textBox6 - Логин сотрудник
button1 - зарегестрировать
groupBox1 - Employee
groupBox2 - Admin
    */
namespace ArmREST
{
    public partial class Form2 : Form
    {

        string currentUser = "Employee";
        Form1 form1;
        Model1Container _db;

        public Form2(Model1Container db, Form1 backForm)
        {
            InitializeComponent();
            this._db = db;
            this.form1 = backForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            foreach (Cafe cafe in _db.CafeSet)
            {
                comboBox1.Items.Add(cafe);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currentUser = "Employee";
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currentUser = "Admin";
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentUser == "Employee")
                {
                    string resValidation = ValidateTest.ValidateRegistration(textBox1.Text, textBox3.Text, textBox2.Text);
                    if (resValidation == "Успешно")
                    {
                        Employee employee = new Employee()
                        {
                            Login = textBox1.Text,
                            Password = textBox3.Text,
                            FIO = textBox2.Text,
                            Post = "Официант",
                            Salary = 25000,
                            PhoneNumber = textBox7.Text,
                            Cafe = comboBox1.SelectedItem as Cafe
                        };
                        _db.EmployeeSet.Add(employee);
                    }

                    else
                    {
                        MessageBox.Show(resValidation);
                        return;
                    }


                }

                else
                {
                    string resValidation = ValidateTest.ValidateRegistration(textBox6.Text, textBox4.Text, textBox5.Text);
                    if (resValidation == "Успешно")
                    {
                        Admin admin = new Admin()
                        {
                            Login = textBox6.Text,
                            Password = textBox4.Text,
                            FIO = textBox5.Text,
                            Post = "Администратор"
                        };

                        _db.AdminSet.Add(admin);

                    }
                    else
                    {
                        MessageBox.Show(resValidation);
                        return;
                    }

                }

                _db.SaveChanges();
                MessageBox.Show("Успешно зарегистрировано!");
                this.Close();
            }

            catch
            {
                MessageBox.Show("Неправильный формат данных!");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
