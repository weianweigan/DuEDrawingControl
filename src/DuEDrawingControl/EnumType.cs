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
}
