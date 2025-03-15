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
        public Histograms_form()
        {
            InitializeComponent();
        }

        private void Histograms_form_Load(object sender, EventArgs e)
        {
            // Create a histogram from a collection of values
            double[] heights = SampleData.MaleHeights();
            var hist = ScottPlot.Statistics.Histogram.WithBinCount(10, heights);

            // Display the histogram as a bar plot
            var barPlot = formsPlot1.Plot.Add.Bars(hist.Bins, hist.Counts);

            // Size each bar slightly less than the width of a bin
            foreach (var bar in barPlot.Bars)
            {
                bar.Size = hist.FirstBinSize * .8;
            }

            // Customize plot style
            formsPlot1.Plot.Axes.Margins(bottom: 0);
            formsPlot1.Plot.YLabel("Number of People");
            formsPlot1.Plot.XLabel("Height (cm)");


            formsPlot1.Refresh();
        }
    }
}
