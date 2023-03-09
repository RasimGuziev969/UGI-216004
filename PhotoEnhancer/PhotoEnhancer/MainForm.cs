using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public partial class MainForm : Form
    {
        Photo originalPhoto;
        Photo resultPhoto;
         
        Panel parametersPanel;

        public MainForm()
        {
            InitializeComponent();

            var bmp = (Bitmap)Image.FromFile("cat.jpg");
            orginalPictureBox.Image = bmp;
            originalPhoto = Convertors.BitmapToPhoto(bmp);

            filtersComboBox.Items.Add("Осветление/затемнение");
        }

        private void filtersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyButton.Visible = true;

            if(parametersPanel != null)
                this.Controls.Remove(parametersPanel);

            parametersPanel = new Panel();

            parametersPanel.Left = filtersComboBox.Left;
            parametersPanel.Top = filtersComboBox.Bottom + 10;
            parametersPanel.Width = filtersComboBox.Width;
            parametersPanel.Height = applyButton.Top - filtersComboBox.Bottom - 20;

            this.Controls.Add(parametersPanel);

            if(filtersComboBox.SelectedItem.ToString() == "Осветление/затемнение")
            {
                var label = new Label();
                label.Left = 0;
                label.Top = 0;
                label.Width = parametersPanel.Width - 50;
                label.Height = 28;
                label.Text = "Коэффициент";
                label.Font = new Font(label.Font.FontFamily, 10);
                parametersPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right;
                inputBox.Top = label.Top;
                inputBox.Width = parametersPanel.Width - label.Width;
                inputBox.Height = label.Height;
                inputBox.Font = new Font(inputBox.Font.FontFamily, 10);
                inputBox.Minimum = 0;
                inputBox.Maximum = 10;
                inputBox.Increment = (decimal)0.05;
                inputBox.DecimalPlaces = 2;
                inputBox.Value = 1;
                inputBox.Name = "coefficient";
                parametersPanel.Controls.Add(inputBox);
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);

            if (filtersComboBox.SelectedItem.ToString() == "Осветление/затемнение")
            {
                var k = (double)((NumericUpDown)parametersPanel.Controls["coefficient"]).Value;
                
                for(var x = 0; x < originalPhoto.Width; x++)
                    for(var y = 0; y < originalPhoto.Height; y++)
                        newPhoto[x, y] = k * originalPhoto[x, y];
            }

            resultPhoto = newPhoto;
            resultPictureBox.Image = Convertors.PhotoToBitmap(resultPhoto);
        }
    }
}
