/*
 
 Edrawing IEModelView控件属性和方法的主要实现

 WeiGan 2020 4/30 创建 发布nuget包

 WeiGan 2020 6/6 添加属性 FullUI - ShowShaderEdges

 */

namespace DuEDrawingControl
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public partial class EDrawingComponent : AxHost
    {
        #region Fields

        private bool _isLoaded;
        private ComponentCountCls _componentCount;

        #endregion

        #region Event
        public event Action<dynamic> OnControlLoaded;
        #endregion

        #region ctor

        /// <summary>
        /// ctor
        /// </summary>
        public EDrawingComponent() : base("22945A69-1191-4DCF-9E6F-409BDE94D101")
        {
            _isLoaded = false;
        }

        #endregion

        #region Other method

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

        #endregion

        #region Properties

        /// <summary>
        /// activeX control
        /// </summary>
        public dynamic Ocx { get; private set; }

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
        /// Gets whether ambient occlusion is permitted. 
        /// </summary>
        /// <remake>
        /// https://help.solidworks.com/2019/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~AmbientOcclusionAllowed.html
        ///</remake>>
        public bool AmbientOcclusionAllowed
        {
            get
            {
                VerifyOcx();
                return Ocx.AmbientOcclusionAllowed;
            }
        }

        /// <summary>
        /// Gets or sets whether ambient occlusion is enabled.
        /// </summary>
        /// <remake>
        /// https://help.solidworks.com/2019/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~AmbientOcclusionEnabled.html
        ///</remake>>
        public bool AmbientOcclusionEnabled
        {
            get
            {
                VerifyOcx();
                return Ocx.AmbientOcclusionEnabled;
            }
            set
            {
                VerifyOcx();
                Ocx.AmbientOcclusionEnabled = value;
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
        public string ComponentName(string Config, int index)
        {
            VerifyOcx();
            return Ocx.ComponentName[Config, index];
        }

        /// <summary>
        /// <remake>Gets the state of the specified component
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="State"></param>
        /// <remake>https://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~ComponentState.html</remake>>
        /// <returns></returns>
        public bool ComponentState_Get(string Name, EMVComponentState State)
        {
            VerifyOcx();
            return Ocx.ComponentState(Name, (int)State);
        }

        /// <summary>
        /// sets the state of the specified component. 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="State"></param>
        /// <param name="value"></param>
        /// <remake>https://help.solidworks.com/2018/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~ComponentState.html</remake>>
        public void ComponentState_Set(string Name, EMVComponentState State, bool value)
        {
            VerifyOcx();
            Ocx.ComponentState[Name, (int)State] = value;
        }

        /// <summary>
        /// Gets  the transform for the specified component. 
        /// </summary>
        /// <param name="ComponentName"></param>
        /// <returns></returns>
        /// <remake> https://help.solidworks.com/2019/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~ComponentTransform.html</remake>>
        public double[] ComponentTransform_Get(string ComponentName)
        {
            VerifyOcx();
            return Ocx.ComponentTransform(ComponentName);
        }

        /// <summary>
        ///  sets the transform for the specified component. 
        /// </summary>
        /// <param name="ComponentName"></param>
        /// <param name="value"></param>
        /// <remake>https://help.solidworks.com/2019/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~ComponentTransform.html</remake>>
        public void ComponentTransform_Set(string ComponentName, double[] value)
        {
            VerifyOcx();
            Ocx.ComponentTransform[ComponentName] = value;
        }

        /// <summary>
        /// Gets the total number of configurations. 
        /// </summary>
        public int ConfigurationCount { get { VerifyOcx(); return Ocx.ConfigurationCount; } }

        /// <summary>
        /// Gets the name of the specified configuration. 
        /// </summary>
        /// <param name="ConfigurationIndex"></param>
        /// <returns></returns>
        public string ConfigurationName(int ConfigurationIndex)
        {
            VerifyOcx();
            return Ocx.ConfigurationName(ConfigurationIndex);
        }

        /// <summary>
        /// Gets the index number of this configuration. 
        /// </summary>
        public int CurrentConfigurationIndex { get { VerifyOcx(); return Ocx.CurrentConfigurationIndex; } }

        /// <summary>
        /// Gets the index number of the currently displayed drawing sheet. 
        /// </summary>
        public int CurrentSheetIndex { get { VerifyOcx(); return Ocx.CurrentSheetIndex; } }

        /// <summary>
        /// Gets a property of the IEModelViewControl. 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public bool EnableFeature_Get(EMVEnableFeatures feature)
        {
            VerifyOcx();
            return Ocx.EnableFeature((int)feature);
        }

        /// <summary>
        /// Sets a property of the IEModelViewControl. 
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="value"></param>
        public void EnableFeature_Set(EMVEnableFeatures feature, bool value)
        {
            VerifyOcx();
            Ocx.EnableFeature[(int)feature] = value;
        }

        /// <summary>
        /// Gets or sets properties of the IEModelViewControl. 
        /// </summary>
        public int EnableFeatures
        {
            get { VerifyOcx(); return Ocx.EnableFeatures; }
            set { VerifyOcx(); Ocx.EnableFeatures = value; }
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

        /// <summary>
        /// Gets or sets whether to show complete UI mode or simple UI mode.
        /// -1 to show complete UI mode, 0 to show simple UI mode
        /// </summary>
        public int FullUI
        {
            get
            {
                VerifyOcx();
                return Ocx.FullUI;
            }
            set
            {
                VerifyOcx();
                if (value < -1 || value > 0)
                {
                    throw new InvalidOperationException($"The FullUI Property only can be set to -1 or 0,you canot set it as {value.ToString()}");
                }
                Ocx.FullUI = value;
            }
        }

        /// <summary>
        /// Gets the height of the control.
        /// </summary>
        /// <remarks>Depending on the programming environment, height and width may be displayed in either Twips or Pixels. See MSDN for more information on Twips.</remarks>
        public int EdrawingHeight { get { VerifyOcx(); return Ocx.Height; } }

        ///<summary>Gets or sets the color used when an entity is selected</summary>
        ///<remarks>A COLORREF is a 32-bit integer value that specifies the red, blue, and green components of a 24-bit color.See http://msdn2.microsoft.com/en-us/library/ms532655.aspx for details.</remarks>
        public int HighlightColor
        {
            get
            {
                VerifyOcx();
                return Ocx.HighlightColor;
            }
            set
            {
                VerifyOcx();
                Ocx.HighlightColor = value;
            }
        }

        /// <summary>
        /// Gets the number of SOLIDWORKS ink markups. 
        /// <remake>https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~InkMarkupCount.html</remake>>
        /// <Availability>2020</Availability>
        /// </summary>
        public int InkMarkupCount
        {
            get { VerifyOcx(); return Ocx.InkMarkupCount; }
        }

        /// <summary>
        /// Gets the name of the specified SOLIDWORKS ink markup.
        /// </summary>
        /// <param name="InkMarkupIndex"></param>
        /// <remake>https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelViewControl~eDrawings.Interop.EModelViewControl.IEModelViewControl~InkMarkupName.html</remake>>
        /// <Availability>2020</Availability>
        /// <returns></returns>
        public string InkMarkupName(int InkMarkupIndex)
        {
            VerifyOcx();
            return Ocx.InkMarkupName(InkMarkupIndex);
        }

        ///<summary>Gets whether the markup file was modified.True if markup file was modified, false if not</summary>
        public bool IsMarkupModified { get { VerifyOcx(); return Ocx.IsMarkupModified; } }

        ///<summary>Gets whether the current document is measure-enabled.</summary>
        public bool IsMeasureEnabled { get { VerifyOcx(); return Ocx.IsMeasureEnabled; } }

        ///<summary>Gets the number of layers in this eDrawings document.</summary>
        ///<remarks>Call this property before calling IEModelViewControl::LayerName to get the total number of the layers in this eDrawings document.</remarks>
        public int LayerCount { get { VerifyOcx(); return Ocx.LayerCount; } }

        ///<summary>Gets the name of the specified layer in this eDrawings document.</summary>
        ///<remarks>Before calling this property, call IEModelViewControl::LayerCount to get the total number of layers in this eDrawings document.</remarks>
        public string LayerName { get { VerifyOcx(); return Ocx.LayerName; } }

        /// <summary>
        /// Gets the value of the specified mass property.
        /// </summary>
        public double GetMassProperty(EMVMassProperty massProperty)
        {
            VerifyOcx();
            return Ocx.MassProperty((int)massProperty);
        }

        /// <summary>
        /// Gets the material name.
        /// </summary>
        /// <remarks>If the material name is not available, the string <not specified> is returned.</remarks>
        public string MaterialPropertyName { get { VerifyOcx(); return Ocx.MaterialPropertyName; } }

        ///<summary>Gets or sets the color of the paper (sheet) for an eDrawings document of a drawing only. </summary>
        ///<remarks>IEModelViewControl::PaperColorOverride must be true for this method to have an effect. A COLORREF is a 32-bit integer value that specifies the red, blue, and green components of a 24-bit color.See http://msdn2.microsoft.com/en-us/library/ms532655.aspx for details. </remarks>
        public int PaperColor
        {
            get
            {
                VerifyOcx();
                return PaperColor;
            }
            set
            {
                VerifyOcx();
                Ocx.PaperColor = value;
            }
        }

        ///<summary>Specifies whether to override the color of the paper of an eDrawings document of a drawing and display the color specified by IEModelViewControl::PaperColor. </summary>
        ///<value>True to override the color of the paper, false to not</value>
        public bool PaperColorOverride
        {
            get
            {
                VerifyOcx(); return Ocx.PaperColorOverride;
            }
            set { VerifyOcx(); Ocx.PaperColorOverride = value; }
        }

        /// <summary>
        /// Sets the password needed to open a model downloaded from a server that requires authentication.
        /// </summary>
        /// <value>Password needed to open a model downloaded from a server that requires authentication</value>
        public string Password
        {
            set
            {
                VerifyOcx();
                Ocx.Password = value;
            }
        }

        /// <summary>
        /// Gets or sets whether shadows are enabled in parts and assemblies. 
        /// </summary>
        public bool ShadowEnabled
        {
            get
            {
                VerifyOcx(); return Ocx.ShadowEnabled;
            }
            set
            {
                VerifyOcx();
                Ocx.ShadowEnabled = value;
            }
        }

        /// <summary>
        /// Gets the total number of drawing sheets. 
        /// </summary>
        public int SheetCount { get { VerifyOcx(); return Ocx.SheetCount; } }

        /// <summary>
        /// Gets the height of the drawing sheet.
        /// </summary>
        public double SheetHeight { get { VerifyOcx(); return Ocx.SheetHeight; } }

        /// <summary>
        /// Gets the name of the specified drawing sheet. 
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <returns></returns>
        public string SheetName(int SheetIndex) { VerifyOcx(); return Ocx.SheetName(SheetIndex); }

        /// <summary>
        /// Gets the name of the specified drawing sheet. 
        /// </summary>
        /// <param name="index">Index number of the drawing sheet to get</param>
        /// <returns>Name of the drawing sheet</returns>
        public string GetSheetName(int index)
        {
            VerifyOcx();
            return Ocx.SheetName[index];
        }

        /// <summary>
        /// Gets the width of the drawing sheet.
        /// </summary>
        /// <value>Width of drawing sheet in either inches or millimeters, depending on the regional settings of your computer, not the model units of the drawing</value>
        public double SheetWidth { get { VerifyOcx(); return Ocx.SheetWidth; } }

        /// <summary>
        /// Sets whether to display the specified SOLIDWORKS ink markup. 
        /// </summary>
        /// <param name="InkMarkupIndex"></param>
        /// <Availability>2020</Availability>>
        /// <returns></returns>
        public bool ShowInkMarkup(int InkMarkupIndex)
        {
            VerifyOcx();
            return Ocx.ShowInkMarkup(InkMarkupIndex);
        }

        /// <summary>
        /// Gets the layer to show. 
        /// </summary>
        /// <param name="layerName">Name of layer to show(see Remarks)</param>
        /// <returns></returns>
        /// <remarks>Before calling this method, call IEModelViewControl::LayerName to get the name of the layer to show.</remarks>
        public bool ShowLayer_Get(string layerName)
        {
            VerifyOcx();
            return Ocx.ShowLayer(layerName);
        }

        /// <summary>
        /// Sets the layer to show. 
        /// </summary>
        /// <param name="layerName">Name of layer to show(see Remarks)</param>
        /// <param name="value"></param>
        /// <remarks>
        /// Before calling this method, call IEModelViewControl::LayerName to get the name of the layer to show.</remarks>
        public void ShowLayer_Set(string layerName, bool value)
        {
            VerifyOcx();
            Ocx.ShowLayer[layerName] = value;
        }

        /// <summary>
        /// Gets or sets whether to show edges in shaded mode. 
        /// </summary>
        public bool ShowShadowEdge
        {
            get
            {
                VerifyOcx();
                return Ocx.ShowShadowEdge;
            }
            set
            {
                VerifyOcx();
                Ocx.ShowShadowEdge = value;
            }
        }

        /// <summary>
        /// Displays the specified ToolTip at the cursor's location. 
        /// </summary>
        /// <param name="TooltipID"></param>
        /// <returns></returns>True if the ToolTip is displayed at the cursor's location, false if not
        public bool ShowTipAtMousePosition(int TooltipID)
        {
            VerifyOcx();
            return Ocx.ShowTipAtMousePosition(TooltipID);
        }

        /// <summary>
        /// Gets or sets whether stereographic viewing is enabled
        /// </summary>
        public bool StereoEnabled
        {
            get { VerifyOcx(); return Ocx.StereoEnabled; }
            set { VerifyOcx(); Ocx.StereoEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the distance between camera position and the stereo focal plane in terms of the camera eye distance.
        /// </summary>
        /// <remake>Distance between camera position and the stereo focal plane in terms of the camera eye distance; default stereo distance = 0
        public float StereoFocalLength
        {
            get
            {
                VerifyOcx();
                return Ocx.StereoFocalLength;
            }
            set
            {
                VerifyOcx();
                Ocx.StereoFocalLength = value;
            }
        }

        /// <summary>
        ///  Gets or sets the angle of separation between right and left stereo views.    
        ///  <remake>Angle of separation between right and left stereo views; default angle = 3.0 degrees
        /// </summary>
        public float StereoSeparation
        {
            get { VerifyOcx(); return Ocx.StereoSeparation; }
            set { VerifyOcx(); Ocx.StereoSeparation = value; }
        }

        /// <summary>
        /// Gets  the text for the specified ToolTip. 
        /// <remake>Read Text for ToolTip
        /// </summary>
        public string TipText_Get(int TooltipID)
        {
            VerifyOcx(); return Ocx.TipText(TooltipID);
        }

        /// <summary>
        /// sets the text for the specified ToolTip. 
        /// <remake>Write Text for ToolTip
        /// </summary>
        public void TipText_Set(int TooltipID, string value)
        {
            VerifyOcx();
            Ocx.TipText[TooltipID] = value;
        }

        /// <summary>
        /// Gets the title of the specified ToolTip
        /// <remake>ToolTip
        /// </summary>
        public string TipTitle_Get(int TooltipID)
        {
            VerifyOcx(); return Ocx.TipTitle(TooltipID);
        }

        /// <summary>
        /// Sets the title of the specified ToolTip
        /// <remake>ToolTip
        /// </summary>
        public void TipTitle_Set(int TooltipID, string value)
        {
            VerifyOcx(); Ocx.TipTitle[TooltipID] = value;
        }

        /// <summary>
        /// Gets the x coordinate for the specified ToolTip
        /// </summary>
        /// <param name="TooltipID"></param>
        /// <returns></returns>x coordinate for ToolTip
        public int TipXCoordinate_Get(int TooltipID)
        {
            VerifyOcx();
            return Ocx.TipXCoordinate(TooltipID);
        }

        /// <summary>
        ///  Sets the x coordinate for the specified ToolTip
        /// </summary>
        /// <param name="TooltipID"></param>ID of ToolTip
        /// <param name="value"></param>x coordinate for ToolTip
        public void TipXCoordinate_Set(int TooltipID, int value)
        {
            VerifyOcx();
            Ocx.TipXCoordinate[TooltipID] = value;
        }

        /// <summary>
        /// Gets the Y coordinate for the specified ToolTip
        /// </summary>
        /// <param name="TooltipID"></param>
        /// <returns></returns>Y coordinate for ToolTip
        public int TipYCoordinate_Get(int TooltipID)
        {
            VerifyOcx();
            return Ocx.TipYCoordinate(TooltipID);
        }

        /// <summary>
        ///  Sets the Y coordinate for the specified ToolTip
        /// </summary>
        /// <param name="TooltipID"></param>ID of ToolTip
        /// <param name="value"></param>Y coordinate for ToolTip
        public void TipYCoordinate_Set(int TooltipID, int value)
        {
            VerifyOcx();
            Ocx.TipYCoordinate[TooltipID] = value;
        }

        /// <summary>
        /// Gets the total number of ToolTips. 
        /// <remake>Total number of ToolTips
        /// </summary>
        public int TooltipCount
        {
            get { VerifyOcx(); return Ocx.TooltipCount; }
        }

        /// <summary>
        /// Gets the ID of the ToolTip. 
        /// </summary>
        /// <param name="index"></param>Index number of the ToolTip
        /// <returns></returns>
        public int TooltipID(int index)
        {
            VerifyOcx();
            return Ocx.TooltipID(index);
        }

        /// <summary>
        /// Sets the user name needed to open a model downloaded from a server that requires authentication. 
        /// </summary>
        /// <param name="value"></param>User name
        public void UserName(string value)
        {
            VerifyOcx();
            Ocx.UserName = value;
        }

        /// <summary>
        /// Gets the version number of eDrawings. 
        /// </summary>
        public string Version
        {
            get { VerifyOcx(); return Ocx.Version; }
        }

        /// <summary>
        /// Gets or sets the current camera properties. 
        /// </summary>
        /// <remake>Array of 12 doubles of the camera properties
        public double[] ViewCamera
        {
            get { VerifyOcx(); return Ocx.ViewCamera; }
            set { VerifyOcx(); Ocx.ViewCamera = value; }
        }

        /// <summary>
        /// Sets the select, rotate, zoom, and pan tools. 
        /// </summary>
        /// <param name="value"></param>
        public void ViewOperator(EMVOperators value)
        {
            VerifyOcx();
            Ocx.ViewOperator = (int)value;
        }

        /// <summary>
        /// Sets the view orientation. 
        /// </summary>
        /// <param name="value"></param>
        public void ViewOrientation(EMVViewOrientation value)
        {
            VerifyOcx();
            Ocx.ViewOrientation = (int)value;
        }

        /// <summary>
        /// Gets the view state. 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ViewState_Get(EMVViewState state)
        {
            VerifyOcx(); return Ocx.ViewState((int)state);
        }

        /// <summary>
        ///sets the view state. 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>True if the view state is set, false if not
        public void ViewState_Set(EMVViewState state, bool value)
        {
            VerifyOcx();
            Ocx.ViewState[(int)state] = value;
        }

        /// <summary>
        /// Gets the width of the control. 
        /// </summary>
        public int EdrawingWidth
        {
            get { VerifyOcx(); return Ocx.Width; }
        }

        #endregion

        #region Public Method


        /// <summary>
        /// Activates the specified SOLIDWORKS ink markup. 
        /// </summary>
        /// <param name="InkMarkupIndex"></param>Index of SOLIDWORKS ink markup to activate
        /// <Availability>2020</Availability>
        /// <note>This method is valid only if IEModelViewControl::ShowInkMarkup is set to true</note>
        public void ActivateInkMarkup(int InkMarkupIndex)
        {
            VerifyOcx();
            Ocx.ActivateInkMarkup(InkMarkupIndex);
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

        private void VerifyOcx()
        {
            if (Ocx == null)
            {
                throw new InvalidOperationException($"Can not get edrawing's OCX.Check whether edrawing is installed");
            }
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
        /// Shows all ToolTips. 
        /// </summary>
        public void ShowAllTooltips()
        {
            VerifyOcx();
            Ocx.ShowAllTooltips();
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
        /// Shows the specified ToolTip. 
        /// </summary>
        /// <param name="ToolTipID"></param>
        public void ShowToolTip(int ToolTipID)
        {
            VerifyOcx();
            Ocx.ShowToolTip(ToolTipID);
        }

        /// <summary>
        /// Redraws the scene graph.
        /// </summary>
        public void UpdateScene()
        {
            VerifyOcx();
            Ocx.UpdateScene();
        }

        #endregion

    }
}
