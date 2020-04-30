using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace WPFExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DuEDrawingControl.EDrawingWPFControl edrawing;

        public MainWindow()
        {
            InitializeComponent();

            //Add edrawing control
            edrawing = new DuEDrawingControl.EDrawingWPFControl() { 
                Margin = new Thickness(5)
            };
            edrawingPanel.Children.Add(edrawing);
        }

        //openDoc
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;

                edrawing.EDrawingHost.OpenDoc(file, false, false, false);

            }
        }

        //open local test model
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var testModel = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "test.SLDPRT");
            edrawing.EDrawingHost.OpenDoc(testModel,false,false,false);
        }

        //close active doc
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            edrawing.EDrawingHost.CloseActiveDoc();
        }
    }
}
