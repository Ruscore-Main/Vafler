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
 textBox1 - название
textBox2 цена
textBox3 - калорийность
pictureBox1- изображение
listBox1 - меню
linkLabel1 - Назад
 */
namespace ArmREST
{
    public partial class Form8 : Form
    {
        Form1 form1;
        Model1Container _db;
        Employee currentEmployee;
        Product currentProduct;
        public Form8(Model1Container db, Form1 backForm, Employee employee)
        {
            InitializeComponent();
            this.form1 = backForm;
            this._db = db;
            this.currentEmployee = employee;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label3.Text = currentEmployee.FIO;
            label4.Text = currentEmployee.Login;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

            foreach (Product product in currentEmployee.Cafe.Product)
            {
                listBox1.Items.Add(product);
            }
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentProduct = listBox1.SelectedItem as Product;
                if (currentProduct != null)
                {
                    textBox1.Text = currentProduct.Name;
                    textBox2.Text = Convert.ToString(currentProduct.Price);
                    textBox3.Text = Convert.ToString(currentProduct.Calories);

                    pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(currentProduct.Photo));
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
            catch { }
        }
    }
}
