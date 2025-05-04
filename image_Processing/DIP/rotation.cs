using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.PlotStyles;
using SkiaSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DIP
{
    public partial class rotation: Form
    {
        int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }

        public int[] OutputArray { get; private set; }
        public int OutputWidth { get; private set; }
        public int OutputHeight { get; private set; }
        unsafe int* f;
        unsafe int* g;
        int w, h;
        unsafe double* thet;
        int[] f0;
        Bitmap bmp;
        public rotation()
        {
            InitializeComponent();
        }
        [DllImport("direction.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void rota(int* f0, int w, int h, int* g0, double theta_deg, int* out_w, int* out_h);
        unsafe public rotation(int* f0, int w, int h, int* g0, double* theta)
        {
            InitializeComponent();

            this.f = f0;
            this.g = g0;
            this.w = w;
            this.h = h;
            this.thet = theta;
            this.f0 = new int[w * h];

            // 顯示結果
            ShowImage(f, w, h);
            bmp = new Bitmap(pictureBox1.Image);
        }

        unsafe private Bitmap GetImageFromG(int* g, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int val = g[y * width + x];

                    val = Clamp(val, 0, 255);
                    Color gray = Color.FromArgb(val, val, val);
                    bmp.SetPixel(x, y, gray);
                }
            }

            return bmp;
        }

        unsafe private void ShowImage(int* data, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int val = data[y * width + x];
                    val = Clamp(val, 0, 255); // 或用自訂的 Clamp 函數
                    Color gray = Color.FromArgb(val, val, val);
                    bmp.SetPixel(x, y, gray);
                }
            }

            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        unsafe private void RotateImage(double theta_deg)
        {
            int new_w = 0, new_h = 0;

            // 建立一個新的足夠大的陣列來存旋轉結果（避免原本 g 陣列不足）
            int maxSize = (int)Math.Ceiling(Math.Sqrt(w * w + h * h));
            int[] newG = new int[maxSize * maxSize];

            fixed (int* newGPtr = newG)
            {
                rota(this.f, w, h, newGPtr, theta_deg, &new_w, &new_h);

                // 建立影像顯示
                Bitmap resultBmp = GetImageFromG(newGPtr, new_w, new_h);
                pictureBox1.Image = resultBmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                // 儲存結果
                this.OutputArray = newG;
                this.OutputWidth = new_w;
                this.OutputHeight = new_h;
            }
        }

        private void rotation_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double theta = double.Parse(textBox1.Text);
            hScrollBar2.Value = (int)theta;
            RotateImage(theta);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            double theta = hScrollBar2.Value;
            textBox1.Text = hScrollBar2.Value.ToString();
            RotateImage(theta);
        }
    }
}
