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
        Bitmap originalBmp;
        Bitmap resultBmp;
         
        Panel parametersPanel;

        public MainForm()
        {
            InitializeComponent();

            originalBmp = (Bitmap)Image.FromFile("cat.jpg");
            orginalPictureBox.Image = originalBmp;

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
            //parametersPanel.BackColor = Color.Gray;

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
            var newBmp = new Bitmap(originalBmp.Width, originalBmp.Height);

            if (filtersComboBox.SelectedItem.ToString() == "Осветление/затемнение")
            {
                var k = (double)((NumericUpDown)parametersPanel.Controls["coefficient"]).Value;
                
                for(var x = 0; x < originalBmp.Width; x++)
                    for(var y = 0; y < originalBmp.Height; y++)
                    {
                        var pixelColor = originalBmp.GetPixel(x, y);
                        
                        var newR = (int)(pixelColor.R * k);
                        if(newR > 255)
                            newR = 255; 

                        var newG = (int)(pixelColor.G * k);
                        if (newG > 255)
                            newG = 255;

                        var newB = (int)(pixelColor.B * k);
                        if (newB > 255)
                            newB = 255;

                        newBmp.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                    }
            }

            resultBmp = newBmp;
            resultPictureBox.Image = resultBmp;
        }
    }
}
