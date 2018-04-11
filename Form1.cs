using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVBPS_Project
{
    public partial class Form1 : Form
    {
        public string folderPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.folderPath = folderBrowserDialog1.SelectedPath;
                    this.labelPath.Text = "Zvolená cesta: " + this.folderPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.labelStatus.Text = "";
            if (this.folderPath != "")
            {
                this.labelStatus.Text = " In progress...";

                MalwareDetector detector = new MalwareDetector(new Directory(this.folderPath));
                List<ScanItem> threats = detector.Scan();
                this.labelStatus.Text = " Done success";

                this.textBox.Text = "";
                foreach(ScanItem threat in threats)
                {
                    string detectionRate = threat.reportResult != null ? threat.reportResult.DetectionResultToString() : threat.stringResult;
                    string output = threat.GetFilename() + " - " + detectionRate;
                    this.textBox.AppendText(output);
                    this.textBox.AppendText(Environment.NewLine);
                }

            } else
            {
                this.labelStatus.Text = " Choose folder at first...";
            }
        }
        

    }
}
