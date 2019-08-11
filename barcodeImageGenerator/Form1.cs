using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barcodeImageGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {

                Barcode barcode = new Barcode();
                Color foreColor = Color.Black;
                Color backColor = Color.Transparent;
                Image image = barcode.Encode(TYPE.UPCA, txtBarcode.Text, foreColor, backColor, (int)(picBarcode.Width * 0.8), (int)(picBarcode.Height * 0.8));
                picBarcode.Image = image;
            }
            catch (Exception)
            {

                MessageBox.Show("Length must be 11 or 12 numbers!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save=new SaveFileDialog() { Filter="PNG|*.png" } )
            {
                if (save.ShowDialog()==DialogResult.OK)
                {
                    if (picBarcode.Image == null)
                        return;
                    picBarcode.Image.Save(save.FileName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
