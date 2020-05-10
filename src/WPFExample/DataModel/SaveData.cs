using PropertyTools.DataAnnotations;

namespace WPFExample
{
    internal class SaveData
    {
        public SaveData()
        {
        }

        [OutputFilePath()]
        [FilterProperty("Filter")]
        [Category("SaveOptions")]
        [VisibleBy(nameof(SaveAs),false)]
        [Description("Fully qualified path and file name to which to save the data(see Remarks)")]
        public string SaveName { get; set; }

        [Category("SaveOptions")]
        public bool SaveAs { get; set; } = true;

        [Category("SaveOptions")]
        public string CommandString { get; set; } = "";

        [Browsable(false)]
        public string Filter { get; private set; } = "edrw files (*.edrw)|*.edrw|eprt files (*.eprt)|*.eprt|easm files (*.easm)|*.easm|jpg files (*.jpg)|*.jpg |tif files (*.tif)|*.tif| bmp files (*.bmp)|*.bmp| stl files (*.stl)|*.stl|htm files (*.htm)|*.htm|zip files (*.zip)|*.zip|All files (*.*)|*.*";

    }
}
