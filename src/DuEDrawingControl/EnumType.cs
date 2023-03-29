using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuEDrawingControl
{
    /// <summary>
    /// Print types.
    /// </summary>
    public enum EMVPrintType
    {
        /// <summary>
        /// 2 = Print actual size; for drawings only
        /// </summary>
        eOneToOne = 2,
        /// <summary>
        /// 3 = Not used
        /// </summary>
        ePrintSelection = 3,
        /// <summary>
        /// 4 = Scaled; scaling factor and offsets apply
        /// </summary>
        eScaled = 4,
        /// <summary>
        /// 1 = Scale to fit; for drawings only
        /// </summary>
        eScaleToFit = 1,
        /// <summary>
        /// 0 = What You See Is What You Get; for parts, assemblies, and drawings
        /// </summary>
        eWYSIWYG = 0
    }

    /// <summary>
    /// Animation actions.
    /// </summary>
    public enum EMVAnimateAction
    {
        /// <summary>
        /// 1 = Previous view
        /// </summary>
        eMVBack = 1,
        /// <summary>
        /// 4 = Play continuously
        /// </summary>
        eMVContinuous = 4,
        /// <summary>
        /// 3 = Next view
        /// </summary>
        eMVForward = 3,
        /// <summary>
        /// 0 = Not animating
        /// </summary>
        eMVNotAnimating = 0,
        /// <summary>
        /// 2 = Stop animation
        /// </summary>
        eMVStop = 2
    }

    /// <summary>
    /// Print orientations.
    /// </summary>
    public enum EMVPrintOrientation
    {
        /// <summary>
        /// Landscape
        /// </summary>
        eLandscape = 2,

        /// <summary>
        /// Portrait
        /// </summary>
        ePortrait = 1
    }

    /// <summary>
    /// Mass Properties
    /// </summary>
    public enum EMVMassProperty
    {
        eMVDensity = 3,

        eMVMass = 0,

        eMVSurfaceArea = 1,

        eMVVolume = 2
    }
    /// <summary>
    /// Component states. Bitmask.
    /// </summary>
    public enum EMVComponentState
    {
        /// <summary>
        ///  Hidden mode
        /// </summary>
        eMVHidden = 1,

        /// <summary>
        /// Highlight mode. Setting a component to its highlight state is not the same as selecting it in the user interface even though both actions turn the component green.
        /// </summary>
        eMVHighlight = 2
    }

    /// <summary>
    /// Enable features. Bitmask. 
    /// </summary>
    public enum EMVEnableFeatures
    {
        eMVDisableGradientBackground = 65536,// Changes the eDrawings Viewer background from a gradient to solid color
        eMVDisableMeasure = 32768,// Disables measure
        eMVDisableMenuSave = 8,// Disable the Save selection on the File menu (Complete UI mode) 
        eMVDisableSNLCheckout = 8192,// Disable SNL checkout  NOTE: If you disable SNL checkout, eDrawings Professional features may be disabled even if the document is review-enabled or if the eDrawings Professional license is present.
        eMVEnableSilentMode = 16384,// Disable all dialogs
        eMVEnableUICommands = 4194304,//When eDrawings is run as a COM object, user-interface (UI) commands are enabled
        eMVFullUI = 16,//Display in Complete UI mode(preferred )
        eMVHLR = 256,// Display files saved in HLR(Hidden Lines Removed) display mode in HLR display mode
        eMVReadOnly = 64,// Open the file as read only
        eMVSeparateMarkup = 128,// Open all markup files associated with this file
        eMVSimplifiedUI = 32,// Display in Simple UI mode
        eMVSmallToolbarButtons = 2048,//Display Small toolbar buttons
        eMVSuppressMarkupFileOpen = 4,//Do not display the File, Markup Open dialog
        eMVSuppressMarkupOpenMenu = 512,//Disable the Open Markup selection on the File menu
        eMVSuppressRMBMenu = 1024,// Disable the right-mouse button menu
        eMVSuppressSavePrompt = 2,// Do not display the Save dialog even if the file was modified
        eMVSupressMenuBar = 4096,//Hide the Menu toolbar
        eMVTriad = 1,// Display triad
    }

    public enum EMVOperators
    {
        eMVOperatorPan = 4,// Pan
        eMVOperatorRotate = 1,// Rotate
        eMVOperatorSelect = 0,// Select
        eMVOperatorZoom = 2,// Zoom
        eMVOperatorZoomToArea = 3, // Zoom to Area
    }

    public enum EMVViewOrientation
    {
        eMVOrientationBack = 1,// Back
        eMVOrientationBottom = 3,// Bottom
        eMVOrientationFront = 0, // Front
        eMVOrientationHome = 8,// As model was when opened
        eMVOrientationIsoMetric = 6,// Isometric
        eMVOrientationLeft = 4,// Left
        eMVOrientationRight = 5,// Right
        eMVOrientationTop = 2,//  Top
        eMVOrientationZoomToFit = 7,//Model completely fits in the view area
    }

    public enum EMVViewState
    {
        eMVPerspective = 1,// Perspective view
        eMVShaded = 2,//Shaded view
    }


    #region EModelMarkupControl

    public enum EMVMarkupEnableFeatures
    {
        eMVMarkupDisableMarkupTab = 8, //Markup tab is available
        eMVMarkupLoadMarkupSilent = 4,// No dialogs displayed when Load Markup is silent
        eMVMarkupMenuSaveMarkup = 1, //Save Markup selection is available on the File menu
        eMVMarkupToolBar = 2, //Markup toolbar is displayed (Complete UI Mode; apply before opening file to suppress)
    }

    public enum EMVMarkupOperators
    {
        eMVOperatorMarkupArc = 8, // Arc
        eMVOperatorMarkupCircle = 7,//Circle
        eMVOperatorMarkupCloud = 4, //Cloud
        eMVOperatorMarkupCloudWithLeader = 2,//Cloud with leader
        eMVOperatorMarkupCloudWithText = 3,//Cloud with text
        eMVOperatorMarkupDimension = 10,//Dimension
        eMVOperatorMarkupImage = 13,// Markup image
        eMVOperatorMarkupLine = 5,//Line
        eMVOperatorMarkupRectangle = 6, //Rectangle
        eMVOperatorMarkupSpline = 9,//Spline
        eMVOperatorMarkupText = 1,//Text
        eMVOperatorMarkupTextWithLeader = 0,//Text with leader
        eMVOperatorMeasure = 11,//Measure
        eMVOperatorMoveComponent = 12,//Move component
        eMVOperatorStamp = 14 //Stamp
    }

    public enum EMVMarkupViewState
    {
        eMVMarkupExplode = 1
    }

    public enum EMVDistanceUnit
    {
        eMVCentimeters = 1,
        eMVFeet = 4,
        eMVFeetAndInches = 5,
        eMVInches = 3,
        eMVMeters = 2,
        eMVMillimeters = 0
    }

    public enum EMVAngleUnit
    {
        eMVDegrees = 0,
        eMVRadians = 1
    }
    #endregion

}
