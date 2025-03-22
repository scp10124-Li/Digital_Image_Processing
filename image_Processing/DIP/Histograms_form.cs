using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace DIP
{
    public partial class Histograms_form: Form
    {
        private double[] _data;
        public Histograms_form()
        {
            InitializeComponent();
        }

        public Histograms_form(int[] f)
        {
            _data = Array.ConvertAll(f, x => (double)x);
            InitializeComponent();
        }

        private void Histograms_form_Load(object sender, EventArgs e)
        {
            var hist = ScottPlot.Statistics.Histogram.WithBinSize(1, _data);

            // Display the histogram as a bar plot
            var barPlot = formsPlot1.Plot.Add.Bars(hist.Bins, hist.Counts);

            // Customize the style of each bar
            foreach (var bar in barPlot.Bars)
            {
                bar.Size = hist.FirstBinSize;
                bar.LineWidth = 0;
                bar.FillStyle.AntiAlias = false;
            }

            // Customize plot style
            formsPlot1.Plot.Axes.Margins(bottom: 0);
            formsPlot1.Plot.YLabel("Number of numPixels");
            formsPlot1.Plot.XLabel("numLevels");

            formsPlot1.Refresh();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
    }
}
