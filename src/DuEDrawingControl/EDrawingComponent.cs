using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DuEDrawingControl
{
    public partial class EDrawingComponent : AxHost
    {
        public event Action<dynamic> OnControlLoaded;

        private bool _isLoaded;
        private ComponentCountCls _componentCount;

        /// <summary>
        /// activeX control
        /// </summary>
        public dynamic Ocx { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        public EDrawingComponent() : base("22945A69-1191-4DCF-9E6F-409BDE94D101")
        {
            _isLoaded = false;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!_isLoaded)
            {
                _isLoaded = true;
                Ocx = this.GetOcx() as dynamic;
                OnControlLoaded?.Invoke(Ocx);
            }
        }

        #region Properties

        /// <summary>
        /// Gets the screen coordinates of the upper-left and lower-right corners of the window.
        /// </summary>
        /// <remarks>
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~ActiveViewRectangle.html"/>
        /// </remarks>
        public int[] ActiveViewRectangle
        {
            get
            {
                VerifyOcx();
                return Ocx.ActiveViewRectangle;
            }
        }

        /// <summary>
        /// Gets or sets whether to show a warning watermark when an existing file is opened.
        /// -1 to show a warning watermark, 0 to not show a warning watermark
        /// </summary>
        /// <remarks>
        /// http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~AlwaysShowWarningWatermark.html
        /// </remarks>
        public int AlwaysShowWarningWatermark
        {
            get
            {
                VerifyOcx();
                return Ocx.AlwaysShowWarningWatermark;
            }
            set
            {
                VerifyOcx();
                Ocx.AlwaysShowWarningWatermark = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color for all eDrawings files.
        /// </summary>
        /// <remarks>
        /// http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~BackgroundColor.html
        /// </remarks>
        public int BackgroundColor
        {
            get
            {
                VerifyOcx();
                return Ocx.BackgroundColor;
            }
            set
            {
                VerifyOcx();
                Ocx.BackgroundColor = value;
            }
        }

        /// <summary>
        /// Specifies whether to apply a gradient background using the document's background color.
        /// </summary>
        public bool BackgroundColorGradient
        {
            get
            {

                VerifyOcx();
                return Ocx.BackgroundColorGradient;
            }
            set
            {
                VerifyOcx();
                Ocx.BackgroundColorGradient = value;
            }
        }

        /// <summary>
        /// Specifies whether to override the document's background color and display the color specified by IEModelViewControl::BackgroundColor. 
        /// </summary>
        public bool BackgroundColorOverride
        {
            get
            {

                VerifyOcx();
                return Ocx.BackgroundColorOverride;
            }
            set
            {
                VerifyOcx();
                Ocx.BackgroundColorOverride = value;
            }
        }

        /// <summary>
        /// Gets the fully qualified path and file name of the background image. 
        /// </summary>
        public string BackgroundImagePath
        {
            get
            {
                VerifyOcx();
                return Ocx.BackgroundImagePath;
            }
            set
            {
                VerifyOcx();
                Ocx.BackgroundImagePath = value;
            }
        }

        /// <summary>
        /// Gets the build number of eDrawings.
        /// </summary>
        public string BuildNumber
        {
            get
            {
                VerifyOcx();
                return Ocx.BuildNumber;
            }
            set
            {
                VerifyOcx();
                Ocx.BuildNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance of the camera near clip plane.
        /// </summary>
        public Single CameraNearClip
        {
            get
            {
                VerifyOcx();
                return Ocx.CameraNearClip;
            }
            set
            {
                VerifyOcx();
                Ocx.CameraNearClip = value;
            }
        }

        /// <summary>
        /// Gets or sets the camera projection type.
        /// </summary>
        public string CameraProjection
        {
            get
            {
                VerifyOcx();
                return Ocx.CameraProjection;
            }
            set
            {
                VerifyOcx();
                Ocx.CameraProjection = value;
            }
        }

        /// <summary>
        /// Gets the name of the configuration for the specified component. 
        /// </summary>
        /// <param name="Config">Name of a component configuration in the top-level assembly or an asterisk ("*") for all component configurations in the top-level assembly (see Remarks)</param>
        /// <param name="index">Index number of the component whose configuration name to get</param>
        /// <returns></returns>
        public string ComponentConfigurationName(string Config, int index)
        {
            VerifyOcx();
            return Ocx.ComponentConfigurationName[Config, index];
        }

        /// <summary>
        /// Gets the number of components in the specified configuration
        /// </summary>
        public ComponentCountCls ComponentCount
        {
            get
            {
                if (_componentCount == null)
                {
                    _componentCount = new ComponentCountCls(this);
                }
                return _componentCount;
            }
        }

        /// <summary>
        /// Gets the number of components in the specified configuration
        /// </summary>
        public class ComponentCountCls
        {
            private EDrawingComponent eDrawingComponent;

            internal ComponentCountCls(EDrawingComponent eDrawingComponent)
            {
                this.eDrawingComponent = eDrawingComponent;
            }

            public int this[int Config]
            {
                get
                {
                    eDrawingComponent.VerifyOcx();
                    return eDrawingComponent.Ocx.ComponentName[Config];
                }
            }
        }

        /// <summary>
        /// Gets the name of the component in the specified configuration.
        /// </summary>
        /// <param name="Config"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string ComponentName(string Config,int index)
        {
            VerifyOcx();
            return Ocx[Config, index];
        }


        /// <summary>
        /// Gets the path and name of the file to open or the file name of the currently displayed file.
        /// </summary>
        public string FileName
        {
            get
            {
                VerifyOcx();
                return Ocx.FileName;
            }
            set
            {
                VerifyOcx();
                Ocx.FileName = value;
            }
        }



        //TODO More Properties



        #endregion

        #region Public Method

        /// <summary>
        /// Open the specified eDrawing file 
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~OpenDoc.html"/>
        /// </summary>
        /// <param name="FileName">Fully qualified path and file name (see Remarks)</param>
        /// <param name="IsTemp">True to delete the local copy of a remote non-eDrawings file when that file is closed, false to keep the local copy</param>
        /// <param name="PromptToSave">True to show a dialog if the user exits without saving the file, false to not show a dialog</param>
        /// <param name="ReadOnly">True if the file is read-only, false if not</param>
        /// <param name="CommandString">Specify an empty string (""); do not specify Nothing, Empty, or vbNullString</param>
        public void OpenDoc(string FileName, bool IsTemp, bool PromptToSave, bool ReadOnly, string CommandString = "")
        {
            VerifyOcx();
            Ocx.OpenDoc(FileName, IsTemp, PromptToSave, ReadOnly, CommandString);
        }

        private void VerifyOcx()
        {
            if (Ocx == null)
            {
                throw new InvalidOperationException($"Can not get edrawing's OCX.Check whether edrawing is installed");
            }
        }

        /// <summary>
        /// Opens the specified markup (*.markup) eDrawings file.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~OpenMarkupFile.html"/>
        /// </summary>
        /// <param name="inFileName">Fully qualified path and file name</param>
        public void OpenMarkupFile(string inFileName)
        {
            VerifyOcx();
            Ocx.OpenMarkupFile(inFileName);
        }

        /// <summary>
        /// Sets the state of animation.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~Animate.html"/>
        /// </summary>
        /// <param name="Animating">Animate option as defined in EMVAnimateAction 
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.EMVAnimateAction.html"/>
        /// </param>
        public void Animate(EMVAnimateAction Animating)
        {
            VerifyOcx();
            Ocx.Animate((int)Animating);
        }

        /// <summary>
        /// Prints the eDrawings file.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~Print5.html"/>
        /// </summary>
        /// <param name="ShowDialog">True to show the Print dialog, false to not</param>
        /// <param name="FileNameInPrintQueue">Document name to show in the printer queue for this eDrawings file (see Remarks)</param>
        /// <param name="Shaded">True to print shaded, false to not print shaded</param>
        /// <param name="DraftQuality">True to print draft quality, false to print regular quality</param>
        /// <param name="Color">True to print in grayscale on black-and-white printers, false to print black and white (lines, edges, and text are black, and shaded data is grayscale)</param>
        /// <param name="printType">Scale the eDrawings file as defined in <see cref="EMVPrintType"/> (see Remarks)</param>
        /// <param name="scale">Scaling factor; this argument is valid only when printType is set to eScaled</param>
        /// <param name="centerOffsetX">Offset in thousands of an inch; this argument is valid only when printType is set to eScaled</param>
        /// <param name="centerOffsetY">Offset in thousands of an inch; this argument is valid only when printType is set to eScaled</param>
        /// <param name="printAll">True to print all pages, false to not</param>
        /// <param name="pageFirst">Page number of first page to print; this argument is valid only when printAll is set to false</param>
        /// <param name="pageLast">Page number of last page to print; this argument is valid only when printAll is set to false</param>
        /// <param name="PrintToFileName">Page number of last page to print; this argument is valid only when printAll is set to false</param>
        public void Print5(bool ShowDialog, string FileNameInPrintQueue, bool Shaded, bool DraftQuality, bool Color, EMVPrintType printType, double scale, int centerOffsetX, int centerOffsetY, bool printAll, int pageFirst, int pageLast, string PrintToFileName)
        {
            VerifyOcx();
            Ocx.Print5(ShowDialog, FileNameInPrintQueue, Shaded, DraftQuality, Color, (int)printType, scale, centerOffsetX, centerOffsetY, printAll, pageFirst, pageLast, PrintToFileName);
        }

        /// <summary>
        /// Clear all selections.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~ClearSelections.html"/>
        /// </summary>
        public void ClearSelections()
        {
            VerifyOcx();
            Ocx.ClearSelections();
        }

        /// <summary>
        /// Closes the active eDrawings document.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~CloseActiveDoc.html"/>
        /// </summary>
        /// <param name="commandString">Specify an empty string (""); do not specify Nothing, Empty, or vbNullString</param>
        public void CloseActiveDoc(string commandString = "")
        {
            VerifyOcx();
            Ocx.CloseActiveDoc(commandString);
        }

        /// <summary>
        /// Creates an instance of an eDrawings add-in object, such as IEModelViewMarkupControl.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~CoCreateInstance.html"/>
        /// </summary>
        /// <param name="CLSIDString">Class ID for an eDrawings add-in</param>
        /// <returns>Pointer to the add-in object</returns>
        /// <example>
        /// <code>
        /// Dim m_Markup as EModelViewMarkup.EModelMarkupControl
        /// Set m_Markup = EModelViewControl1.CoCreateInstance("EModelViewMarkup.EmodelMarkupControl")
        /// </code>
        /// </example>
        public object CoCreateInstance(string CLSIDString)
        {
            VerifyOcx();

            return Ocx.CoCreateInstance(CLSIDString);
        }

        /// <summary>
        /// Creates a ToolTip at the specified location.
        /// <see cref="help.solidworkls.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~CreateTooltip.html"/>
        /// </summary>
        /// <param name="TipTitle">Title for ToolTip; only the ToolTip text is displayed if you set TipTitle to an empty string ("")</param>
        /// <param name="TipText">Text for ToolTip; only the ToolTip title is displayed if you set TipText to an empty string ("")</param>
        /// <param name="ShowAtMousePostion">True to show the ToolTip at the cursor's location, false to show the ToolTip at the specified location</param>
        /// <param name="XCoordinate">x coordinate for the ToolTip location</param>
        /// <param name="YCoordinate">y coordinate for the ToolTip location</param>
        /// <returns>ID of ToolTip</returns>
        public int CreateToolTip(string TipTitle, string TipText, bool ShowAtMousePostion, int XCoordinate, int YCoordinate)
        {
            VerifyOcx();

            return Ocx.CreateTooltip(TipTitle, TipText, ShowAtMousePostion, XCoordinate, YCoordinate);
        }

        /// <summary>
        /// Gets the name of the selected component.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~GetSelectedComponentName.html"/>
        /// </summary>
        /// <returns>Name of the selected component or an empty string if a component is not selected</returns>
        /// <remarks>
        /// To select a component, call IEModelViewControl::SelectByRay before calling this method.
        /// </remarks>
        public string GetSelectedComponentName()
        {
            VerifyOcx();

            return Ocx.GetSelectedComponentName();
        }

        /// <summary>
        /// Hides all ToolTips.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~HideAllTooltips.html"/>
        /// </summary>
        public void HideAllTooltips()
        {
            VerifyOcx();

            Ocx.HideAllTooltips();
        }

        /// <summary>
        /// Hides the specified ToolTip.
        /// </summary>
        /// <param name="ToolTipID">ID of the ToolTip</param>
        public void HideToolTip(int ToolTipID)
        {
            VerifyOcx();

            Ocx.HideToolTip(ToolTipID);
        }

        /// <summary>
        /// Loads the model from data from an XML source.
        /// </summary>
        /// <param name="XMLDoc">Pointer to the an MSXML DOMDocument object (MSXML2.DOMDocument40)</param>
        public void LoadXMLBuffer(object XMLDoc)
        {
            VerifyOcx();

            Ocx.LoadXMLBuffer(XMLDoc);
        }

        /// <summary>
        /// Refreshes the eDrawings window.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~Refresh.html"/>
        /// </summary>
        public void OcxRefresh()
        {
            VerifyOcx();

            Ocx.Refresh();
        }

        /// <summary>
        /// Saves the eDrawings file.
        /// <see cref="http://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~Save.html"/>
        /// </summary>
        /// <param name="SaveName">Fully qualified path and file name to which to save the data (see Remarks)</param>
        /// <param name="SaveAs">
        /// <list type="table">
        /// <item>True => A dialog is displayed prompting the user to specify where to save the file. SaveName is ignored.
        /// </item>
        /// <item>False => If SaveName is specified, then the active document is saved to that location and file.
        /// If SaveName is empty, then the active document is saved to the location and file from which it was opened.</item>
        /// </list>
        /// </param>
        /// <param name="CommandString">Specify an empty string (""); do not specify Nothing, Empty, or vbNullString</param>
        public void Save(string SaveName, bool SaveAs, string CommandString = "")
        {
            VerifyOcx();
            Ocx.Save(SaveName, SaveAs, CommandString);
        }

        /// <summary>
        /// Shows the specified ToolTip. 
        /// </summary>
        /// <param name="ToolTipID"></param>
        public void ShowToolTip(int ToolTipID)
        {
            VerifyOcx();
            Ocx.ShowToolTip(ToolTipID);
        }

        /// <summary>
        /// Selects the first component intersected by a ray that starts at the specified point in the specified direction vector. 
        /// </summary>
        /// <param name="StartX">x coordinate of start point</param>
        /// <param name="StartY">y coordinate of start point</param>
        /// <param name="StartZ">z coordinate of start point</param>
        /// <param name="DirectionX">x coordinate of direction vector</param>
        /// <param name="DirectionY">y coordinate of direction vector</param>
        /// <param name="DirectionZ">z coordinate of direction vector</param>
        public void SelectByRay(float StartX, float StartY, float StartZ, float DirectionX, float DirectionY, float DirectionZ)
        {
            VerifyOcx();
            Ocx.SelectByRay(StartX, StartY, StartZ, DirectionX, DirectionY, DirectionZ);
        }

        /// <summary>
        /// Shows or hides a 3D pointer in the active view in the graphics area.
        /// </summary>
        /// <param name="show">True to show the 3D Pointer, false to hide it</param>
        /// <param name="StartX">x coordinate of the position of the sphere and the start point of the line</param>
        /// <param name="StartY">y coordinate of the position of the sphere and the start point of the line</param>
        /// <param name="StartZ">z coordinate of the position of the sphere and the start point of the line</param>
        /// <param name="EndX">x coordinate of the end point of the line</param>
        /// <param name="EndY">y coordinate of the end point of the line</param>
        /// <param name="EndZ">z coordinate of the end point of the line</param>
        public void Show3DPointer(bool show, float StartX, float StartY, float StartZ, float EndX, float EndY, float EndZ)
        {
            VerifyOcx();
            Ocx.Show3DPointer(show, StartX, StartY, StartZ, EndX, EndY, EndZ);
        }

        /// <summary>
        /// Index number of the configuration to display
        /// </summary>
        /// <param name="ConfigurationIndex"></param>
        public void ShowConfiguration(int ConfigurationIndex)
        {
            VerifyOcx();
            Ocx.ShowConfiguration(ConfigurationIndex);
        }

        /// <summary>
        /// Maximizes the drawing to fill the screen.
        /// </summary>
        /// <param name="fullscreen"></param>
        public void ShowFullScreen(bool fullscreen)
        {
            VerifyOcx();
            Ocx.ShowFullScreen(fullscreen);
        }

        /// <summary>
        /// Displays eDrawings Help.
        /// </summary>
        public void ShowHelp()
        {
            VerifyOcx();
            Ocx.ShowHelp();
        }

        /// <summary>
        /// Displays the Send As dialog.
        /// </summary>
        public void ShowSend()
        {
            VerifyOcx();
            Ocx.ShowSend();
        }

        /// <summary>
        /// Displays the specified drawing sheet
        /// </summary>
        /// <param name="SheetIndex">Index number of the drawing sheet to display</param>
        public void ShowSheet(int SheetIndex)
        {
            VerifyOcx();
            Ocx.ShowSheet(SheetIndex);
        }

        /// <summary>
        /// Redraws the scene graph.
        /// </summary>
        public void UpdateScene()
        {
            VerifyOcx();
            Ocx.UpdateScene();
        }

        /// <summary>
        /// Sets the Page Setup parameters for printing. 
        /// </summary>
        /// <param name="Orientation">Page orientation as defined in <see cref="EMVPrintOrientation"/></param>
        /// <param name="PaperSize">Use Windows printer constants (see Remarks)</param>
        /// <param name="PaperLength">Custom size in thousandths of an inch, if you are not using a standard paper size</param>
        /// <param name="PaperWidth">Custom size in thousandths of an inch</param>
        /// <param name="Copies">Number of copies</param>
        /// <param name="Source">Paper tray source; use Windows printer constants</param>
        /// <param name="Printer">Printer name </param>
        /// <param name="TopMargin">Top margin in thousandths of an inch or 0 to use printer's margin</param>
        /// <param name="BottomMargin">Bottom margin in thousandths of an inch or 0 to use printer's margin</param>
        /// <param name="LeftMargin">Left margin in thousandths of an inch or 0 to use printer's margin</param>
        /// <param name="RightMargin">Right margin in thousandths of an inch or 0 to use printer's margin</param>
        public void SetPageSetupOptions(EMVPrintOrientation Orientation, int PaperSize, int PaperLength, int PaperWidth, int Copies, int Source, string Printer, int TopMargin, int BottomMargin, int LeftMargin, int RightMargin)
        {
            VerifyOcx();
            Ocx.SetPageSetupOptions(Orientation, PaperSize, PaperLength, PaperWidth, Copies, Source, Printer, TopMargin, BottomMargin, LeftMargin, RightMargin);
        }

        //TODO More Methods

        #endregion
    }
}
