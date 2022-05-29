using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 textBox1 - название
textBox2 - цена
textBox3 - калорийность
pictureBox1 - изображение
button1 - добавить товар
button2 обзор
linkLabel1 - назад
 */
namespace ArmREST
{
    public partial class Form7 : Form
    {
        Model1Container _db;
        Form5 form5;
        Cafe currentCafe;
        byte[] imageBytes;
        public Form7(Model1Container db, Form5 backForm, Cafe cafe)
        {
            InitializeComponent();
            this._db = db;
            this.form5 = backForm;
            this.currentCafe = cafe;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Добавление товара
        {
            try
            {
                Product newProduct = new Product()
                {
                    Name = textBox1.Text,
                    Price = Convert.ToInt32(textBox2.Text),
                    Calories = Convert.ToInt32(textBox3.Text),
                    Cafe = currentCafe,
                    Photo = this.imageBytes
                };
                _db.ProductSet.Add(newProduct);
                _db.SaveChanges();
                form5.UpdateList();
                MessageBox.Show("Успешно добавлено!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неравильный формат данных!");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Открытие картинки
        {
            OpenFileDialog open_dialog = new OpenFileDialog();

            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.imageBytes = File.ReadAllBytes(open_dialog.FileName);
                    pictureBox1.Image = (Image)((new ImageConverter()).ConvertFrom(imageBytes));
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            form5.Show();
        }
    }
}
