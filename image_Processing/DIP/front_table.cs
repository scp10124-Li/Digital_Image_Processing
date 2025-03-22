using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;



namespace DIP
{

    public partial class front_table : Form
    {
        public front_table()
        {
            InitializeComponent();
        }
        [DllImport("togray.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void toGray(int* f0, int w, int h, int* g0);
        [DllImport("direction.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void Vertical_Flip(int* f0, int w, int h, int* g0);
        [DllImport("direction.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void Horizontal_Flip(int* f0, int w, int h, int* g0);
        [DllImport("direction.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void clockwise_Rotation(int* f0, int w, int h, int* g0);
        [DllImport("direction.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void Counterclockwise_Rotation(int* f0, int w, int h, int* g0);
        [DllImport("Histogram_Equalization.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void Equalization(int* f, int w, int h, int* g);

        Bitmap NpBitmap;
        int[] f;
        int[] g;
        int w, h;
        private void histogramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void DIPSample_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
			this.stStripLabel.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oFileDlg.CheckFileExists = true;
            oFileDlg.CheckPathExists = true;
            oFileDlg.Title = "Open File - DIP Sample";
            oFileDlg.ValidateNames = true;
            oFileDlg.Filter = "bmp files (*.bmp)|*.bmp";
            oFileDlg.FileName = "";

            if (oFileDlg.ShowDialog() == DialogResult.OK)
            {
                MSForm childForm = new MSForm();
                childForm.MdiParent = this;
                childForm.pf1 = stStripLabel;    //把主視窗的狀態列（StatusStrip）物件傳給子視窗，可以讓子視窗顯示一些狀態訊息。
                NpBitmap = bmp_read(oFileDlg);
                childForm.pBitmap = NpBitmap;   //將讀取到的圖檔指定給子視窗顯示使用
                w = NpBitmap.Width;
                h = NpBitmap.Height;
                childForm.Show();
            }
        }

        private Bitmap bmp_read(OpenFileDialog oFileDlg)
        {
            Bitmap pBitmap;
            string fileloc = oFileDlg.FileName;
            pBitmap = new Bitmap(fileloc);
            w = pBitmap.Width;
            h = pBitmap.Height;
            return pBitmap;
        }

        private int[] bmp2array(Bitmap myBitmap)
        {
            int[] ImgData = new int[myBitmap.Width * myBitmap.Height];
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),  //指定要鎖定的範圍
                                          ImageLockMode.ReadWrite,  //鎖定圖片記憶體，如果只讀取可以用 ReadOnly
                                          myBitmap.PixelFormat);    //鎖定圖片記憶體，準備寫入像素資料
            int ByteOfSkip = byteArray.Stride - byteArray.Width * (int)(byteArray.Stride / myBitmap.Width);
            unsafe
            {
                byte* imgPtr = (byte*)(byteArray.Scan0);
                for (int y = 0; y < byteArray.Height; y++)
                {
                    for (int x = 0; x < byteArray.Width; x++)
                    {
                        ImgData[x + byteArray.Width * y] = (int)*(imgPtr);
                        imgPtr += (int)(byteArray.Stride / myBitmap.Width);
                    }
                    imgPtr += ByteOfSkip;
                }
            }
            myBitmap.UnlockBits(byteArray);
            return ImgData;
        }

        private static Bitmap array2bmp(int[] ImgData)
        {
            int Width = (int)Math.Sqrt(ImgData.GetLength(0));
            int Height = (int)Math.Sqrt(ImgData.GetLength(0));
            Bitmap myBitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, Width, Height),
                                           ImageLockMode.WriteOnly,
                                           PixelFormat.Format24bppRgb);
            //Padding bytes的長度
            int ByteOfSkip = byteArray.Stride - myBitmap.Width * 3; //計算每一行尾端需要跳過的 Padding bytes 數量（因為每行長度通常會被補齊到 4 的倍數）
            unsafe
            {                                   // 指標取出影像資料
                byte* imgPtr = (byte*)byteArray.Scan0;
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        *imgPtr = (byte)ImgData[x + Width * y];       //B
                        *(imgPtr + 1) = (byte)ImgData[x + Width * y]; //G 
                        *(imgPtr + 2) = (byte)ImgData[x + Width * y]; //R  
                        imgPtr += 3;
                    }
                    imgPtr += ByteOfSkip; // 跳過Padding bytes
                }
            }
            myBitmap.UnlockBits(byteArray);
            return myBitmap;
        }

        //圖片變灰
        private void rGBtoGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int []f;
            int []g;
            foreach (MSForm cF in MdiChildren)
			   {
					if (cF.Focused)
					{
					    f = bmp2array(cF.pBitmap);
			            g=new int[w*h];
                        unsafe
                        {
                            fixed (int* f0 = f) fixed (int* g0 = g)
                            {
                                toGray(f0, w, h, g0);
                            }
                        } 
                        NpBitmap = array2bmp(g);
				        break;
				    }
			   }
			MSForm childForm = new MSForm();
	        childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
			childForm.pBitmap = NpBitmap; 
			childForm.Show();
        }

        private void iPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //圖片翻轉
        private void verticalFlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    f = bmp2array(cF.pBitmap);
                    g = new int[w * h];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            Vertical_Flip(f0, w, h, g0);
                        }
                    }
                    NpBitmap = array2bmp(g);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }
        private void degreeRotationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    f = bmp2array(cF.pBitmap);
                    g = new int[w * h];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            Counterclockwise_Rotation(f0, w, h, g0);
                        }
                    }
                    NpBitmap = array2bmp(g);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }
        private void degreeRotationToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    f = bmp2array(cF.pBitmap);
                    g = new int[w * h];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            clockwise_Rotation(f0, w, h, g0);
                        }
                    }
                    NpBitmap = array2bmp(g);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }
        private void horizontalFlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    f = bmp2array(cF.pBitmap);
                    g = new int[w * h];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            Horizontal_Flip(f0, w, h, g0);
                        }
                    }
                    NpBitmap = array2bmp(g);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        //直線圖
        private void equalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] f;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    f = bmp2array(cF.pBitmap);
                    unsafe
                    {
                        fixed (int* f0 = f)
                        {
                            Histograms_form form2 = new Histograms_form(f);
                            form2.Show();
                        }
                    }
                    break;
                }
            }
        }
        private void equalizationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] f;
            int[] g;
            foreach (MSForm cF in MdiChildren)
            {
                if (cF.Focused)
                {
                    f = bmp2array(cF.pBitmap);
                    g = new int[w * h];
                    unsafe
                    {
                        fixed (int* f0 = f) fixed (int* g0 = g)
                        {
                            Equalization(f0, w, h, g0);
                        }
                    }
                    NpBitmap = array2bmp(g);
                    break;
                }
            }
            MSForm childForm = new MSForm();
            childForm.MdiParent = this;
            childForm.pf1 = stStripLabel;
            childForm.pBitmap = NpBitmap;
            childForm.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
