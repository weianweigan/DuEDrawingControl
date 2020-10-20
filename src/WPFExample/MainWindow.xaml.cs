using DuEDrawingControl;
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
            //edrawing = new EDrawingWPFControl() { 
            //    Margin = new Thickness(5)
            //};
            //edrawingPanel.Children.Add(edrawing);
            edrawing = edrawingControl;
            //edrawing.EDrawingHost.OnControlLoaded += EDrawingHost_OnControlLoaded;
            edrawing.OnControlLoaded += EDrawingHost_OnControlLoaded;

            toolTipProGrid.SelectedObject = new ToolTipData();

            printProGrid.SelectedObject = new PrintData();

            saveProGrid.SelectedObject = new SaveData();

            selectedRayProGrid.SelectedObject = new SelectedByRayData();
        }

        private void EDrawingHost_OnControlLoaded(dynamic obj)
        {
            //启动时加载
            var testModel = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "test.SLDPRT");
            edrawing.EDrawingHost.OpenDoc(testModel, false, false, false);

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
            var testModel = "";
            if (part.IsChecked == true)
            {
                testModel = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "test.SLDPRT");
            }
            if (assembly.IsChecked == true)
            {
                testModel = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "test.SLDASM");
            }
            if (drawing.IsChecked == true)
            {
                testModel = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "test.SLDDRW");
            }

            edrawing.EDrawingHost.OpenDoc(testModel,false,false,false);
        }

        //opoen markup file
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;

                edrawing.EDrawingHost.OpenMarkupFile(file);

            }
        }

        //close active doc
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            edrawing.EDrawingHost.CloseActiveDoc();
        }

        //clear selection,shoulde enable the selection mode
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            edrawing.EDrawingHost.ClearSelections();
        }

        //动画
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (back.IsChecked == true )
            {
                edrawing.EDrawingHost.Animate(EMVAnimateAction.eMVBack);
                return;
            }
            if (continuous.IsChecked == true)
            {
                edrawing.EDrawingHost.Animate(EMVAnimateAction.eMVContinuous);
                return;
            }
            if (forward.IsChecked == true)
            {
                edrawing.EDrawingHost.Animate(EMVAnimateAction.eMVForward);
                return;
            }
            if (notanimating.IsChecked == true)
            {
                edrawing.EDrawingHost.Animate(EMVAnimateAction.eMVNotAnimating);
                return;
            }
            if (stopanimation.IsChecked == true)
            {
                edrawing.EDrawingHost.Animate(EMVAnimateAction.eMVStop);
                return;
            }
        }

        //CreateToolTip
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var tootipData = toolTipProGrid.SelectedObject as ToolTipData;

            tootipData.TipID = edrawing.EDrawingHost.CreateToolTip(tootipData.TipTitle, tootipData.TipText, tootipData.ShowAtMousePosition, tootipData.X, tootipData.Y);
            edrawing.EDrawingHost.ShowToolTip(tootipData.TipID);
        }

        //Hide all tooltip
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            edrawing.EDrawingHost.HideAllTooltips();
        }

        //hide tooltip with tipid
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var tootipData = toolTipProGrid.SelectedObject as ToolTipData;

            edrawing.EDrawingHost.HideToolTip(tootipData.TipID);
        }

        //Refresh
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            edrawing.EDrawingHost.OcxRefresh();
        }

        //Print
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var printData = printProGrid.SelectedObject as PrintData;

            edrawing.EDrawingHost.Print5(printData.ShowDialog, printData.FileNameInPrintQueue, printData.Shaded, printData.DraftQuality, printData.Color, printData.PrintType, printData.Scale, printData.CenterOffsetX, printData.CenterOffsetY, printData.PrintAll, printData.PageFirst, printData.PageLast, printData.PrintToFileName);
        }

        //Save
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var saveData = saveProGrid.SelectedObject as SaveData;

            edrawing.EDrawingHost.Save(saveData.SaveName, saveData.SaveAs, saveData.CommandString);
        }

        //selectedbyray
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (!Path.GetExtension(path: edrawing.EDrawingHost.FileName).ToLower().Contains("asm"))
            {
                System.Windows.MessageBox.Show($"You can only use {nameof(edrawing.EDrawingHost.SelectByRay)} in asm file,Current file:{edrawing.EDrawingHost.FileName}");
                return;
            }

            var data = selectedRayProGrid.SelectedObject as SelectedByRayData;

            edrawing.EDrawingHost.SelectByRay(data.PointX, data.PointY, data.PointZ, data.DirectionX, data.DirectionY, data.DirectionZ);
        }


    }
}
