using DuEDrawingControl;
using Microsoft.Win32;
using PropertyTools.DataAnnotations;

namespace WPFExample
{
    public class PrintData : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private EMVPrintType printType;
        private bool printAll = true;

        [Category("Print Dialog")]
        [Description("True to show the Print dialog, false to not")]
        public bool ShowDialog { get; set; } = true;

        [Category("Name")]
        public string FileNameInPrintQueue { get; set; } = "打印任务1";

        [Category("Options")]
        [Description("True to print shaded, false to not print shaded")]
        public bool Shaded { get; set; } = true;

        [Category("Options")]
        [Description("True to print draft quality, false to print regular quality")]
        public bool DraftQuality { get; set; } = false;

        [Category("Options")]
        [Description("黑白或者彩色")]
        public bool Color { get; set; } = true;

        [Category("Options")]
        public EMVPrintType PrintType
        {
            get => printType; set
            {
                printType = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(PrintType)));
            }
        }

        [Category("Scale")]
        [VisibleBy(nameof(PrintType), EMVPrintType.eScaled)]
        public double Scale { get; set; } = 1;

        [Category("Scale")]
        [Description("Offset in thousands of an inch; this argument is valid only when printType is set to eScaled")]
        public int CenterOffsetX { get; set; }

        [Category("Scale")]
        [Description("Offset in thousands of an inch; this argument is valid only when printType is set to eScaled")]
        public int CenterOffsetY { get; set; }

        [Category("Options")]
        public bool PrintAll
        {
            get => printAll; set
            {
                printAll = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(PrintAll)));
            }
        }

        [Category("PageNum")]
        [VisibleBy(nameof(PrintAll), false)]
        [Description("Page number of first page to print; this argument is valid only when printAll is set to false")]
        public int PageFirst { get; set; }

        [Category("PageNum")]
        [VisibleBy(nameof(PrintAll), false)]
        [Description("Page number of first page to print; this argument is valid only when printAll is set to false")]
        public int PageLast { get; set; }

        [Category("Name")]
        [Description("File name to which to print the eDrawings file ")]
        public string PrintToFileName { get; set; }
    }

}
