using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.PlotStyles;

namespace DIP
{
    public partial class contract_and_brightness: Form
    {
        [DllImport("togray.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void contrast_and_brightness(int* f, int w, int h, int* g, double a, int b);
        int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }

        unsafe int* f;
        unsafe int* g;
        int w,h,a=1,b=128;
        Bitmap bmp;

        public contract_and_brightness()
        {
            InitializeComponent();
        }
        unsafe public contract_and_brightness(int* f0,int w,int h,int* g0)
        {
            InitializeComponent(); // 建議放最前面初始化元件

            this.h = h;
            this.w = w;
            this.f = f0;
            this.g = g0;

            ShowImage(f, w, h);
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
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            a = hScrollBar1.Value;
            unsafe
            {
                contrast_and_brightness(f, w, h, g, a, b);
                ShowImage(g, w, h);
            }
        }
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            b = hScrollBar2.Value;
            unsafe
            {
                contrast_and_brightness(f, w, h, g, a, b);
                ShowImage(g, w, h);
            }
        }
        private void contract_and_brightness_Load(object sender, EventArgs e)
        {
        }
    }
}
