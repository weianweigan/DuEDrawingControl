using DuEDrawingControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormExample
{
    public partial class Form1 : Form
    {
        private EDrawingView eDrawingView;

        public Form1()
        {
            InitializeComponent();
        }

        //OpenDoc
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;

                eDrawingView.EDrawingHost.OpenDoc(file, false, false, false);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add edrawing control when form loaded
            eDrawingView = new EDrawingView()
            {
                Dock = DockStyle.Fill
            };
            paneleDrawing.Controls.Add(eDrawingView);
        }

        //open local test model
        private void button2_Click(object sender, EventArgs e)
        {
            var testModel = Path.Combine(Path.GetDirectoryName(typeof(Form1).Assembly.Location), "test.SLDPRT");
            eDrawingView.EDrawingHost.OpenDoc(testModel, false, false, false);
        }

        //close active doc
        private void button3_Click(object sender, EventArgs e)
        {
            eDrawingView.EDrawingHost.CloseActiveDoc();

        }
    }
}
