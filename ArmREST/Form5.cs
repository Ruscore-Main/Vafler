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
 listBox1 - меню
textBox1 - название
textBox2 - цена
textBox3 - калорийность
pictureBox1- изображение
button1 - удалить
button2- изменить
button3- добавить
linkLabel1 - назад
 */
namespace ArmREST
{
    public partial class Form5 : Form
    {
        Model1Container _db;
        Form3 form3;
        Cafe currentCafe;
        Product currentProduct;
        public Form5(Model1Container db, Form3 backForm, Cafe cafe)
        {
            InitializeComponent();
            this._db = db;
            this.form3 = backForm;
            this.currentCafe = cafe;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(_db, this, currentCafe);
            this.Hide();
            form7.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            UpdateList();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Product product in currentCafe.Product)
            {
                listBox1.Items.Add(product);
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            form3.Show(); 
        }

        private void button1_Click(object sender, EventArgs e) // Удаление
        {
            _db.ProductSet.Remove(currentProduct);
            _db.SaveChanges();
            UpdateList();
            MessageBox.Show("Успешно удалено!");
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
                    button1.Enabled = true;
                    button2.Enabled = true;
                    
                }
            }
            catch { }
        }
    }
}
