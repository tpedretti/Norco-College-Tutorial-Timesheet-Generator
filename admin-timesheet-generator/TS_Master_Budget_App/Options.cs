using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TS_Master_Budget_App.Services;

namespace TS_Master_Budget_App
{
    public partial class Options : Form
    {
        ProgramSettings settings = new ProgramSettings();

        public Options()
        {
            InitializeComponent();
            loadOptions();
            ShowDialog();
        }

        private void saveOptions_Click(object sender, EventArgs e)
        {
            settings.warningThresholds = warningThresText.Text;
            settings.stopThreshold = stopThresText.Text;
            settings.FWSWT5 = FWSPaidTitleV.Checked;
            settings.overwrite = overwriteFunds.Checked;
            settings.Save(settings);
            this.Close();
        }

        private void loadOptions()
        {
            settings.Load(ref settings);
            warningThresText.Text = settings.warningThresholds;
            stopThresText.Text = settings.stopThreshold;
            FWSPaidTitleV.Checked = settings.FWSWT5;
            overwriteFunds.Checked = settings.overwrite;
        }
    }
}
