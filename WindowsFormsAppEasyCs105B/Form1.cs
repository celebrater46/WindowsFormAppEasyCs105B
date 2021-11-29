using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs105B
{
    public partial class Form1 : Form
    {
        private ChildForm[] cf;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Test that opens Xml on a child form";
            this.Width = 400;
            this.Height = 400;
            this.IsMdiContainer = true;

            string dir = "C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs105B\\WindowsFormsAppEasyCs105B\\";
            string[] fls = Directory.GetFiles(dir, "*.xml");
            cf = new ChildForm[fls.Length];

            for (int i = 0; i < fls.Length; i++)
            {
                cf[i] = new ChildForm(fls[i]);
                cf[i].MdiParent = this;
                cf[i].Show();
            }
        }
    }

    class ChildForm : Form
    {
        private TextBox tb;

        public ChildForm(string name)
        {
            this.Text = name;
            tb = new TextBox();
            tb.Multiline = true;
            tb.Width = this.Width;
            tb.Height = this.Height;

            StreamReader sr = new StreamReader(name, System.Text.Encoding.Default);
            tb.Text = sr.ReadToEnd();
            sr.Close();

            tb.Parent = this;
        }
    }
}