/* 
 Edrawing IEModelMarkupControl控件属性和方法的主要实现
 Hongfeng 2023 3/29 创建

 */

namespace DuEDrawingControl
{
    /// <summary>
    /// IEModelMarkupControl属性和方法的转发类
    /// </summary>
    public class MarkupComponent
    {
        #region ctor
        /// <summary>
        /// IEModelMarkupControl
        /// </summary>
        public dynamic MarkupCtrl { get;private set; }
        public MarkupComponent(dynamic markupCtrl)
        {
            MarkupCtrl = markupCtrl;
        } 
        #endregion

        #region Properties
        public bool CanExplode => MarkupCtrl.CanExplode;
        public int CommentCount => MarkupCtrl.CommentCount;
        public long CommentCountx64 => MarkupCtrl.CommentCountx64;
        //使用索引器转发属性
        public int CommentID(int CommentIndex) => MarkupCtrl.CommentID[CommentIndex];
        public long CommentIDx64(int CommentIndex) => MarkupCtrl.CommentIDx64[CommentIndex];
        public string CommentName(int CommentIndex) => MarkupCtrl.CommentName[CommentIndex];

        public bool EnableFeature_Get(EMVMarkupEnableFeatures feature)
        {
            return MarkupCtrl.EnableFeature[feature];
        }

        public void EnableFeature_Set(EMVMarkupEnableFeatures feature, bool value)
        {
            MarkupCtrl.EnableFeature[feature] = value;
        }

        public int EnableFeatures_Get()
        {
            return MarkupCtrl.EnableFeatures;
        }

        public void EnableFeatures_Set(int value)
        {
            MarkupCtrl.EnableFeature = value;
        }

        public bool IsMeasureEnabled => MarkupCtrl.IsMeasureEnabled;
        public string MeasureResultString => MarkupCtrl.MeasureResultString;

        /// <summary>
        /// 开启测量赋值EMVMarkupOperators.eMVOperatorMeasure
        /// </summary>
        public void ViewOperator_Set(EMVMarkupOperators value)
        {
            MarkupCtrl.ViewOperator = value;
        }

        public bool ViewState_Get(EMVMarkupViewState state)
        {
            return MarkupCtrl.EMVMarkupOperators[state];
        }

        public void ViewState_Set(EMVMarkupViewState state, bool value)
        {
            MarkupCtrl.EMVMarkupOperators[state] = value;
        }

        #endregion

        #region Event
        //Todo：如何转发事件？
        //public event Action OnMeasureResultsChanged;
        #endregion

        #region Public Method
        /// <summary>
        /// 添加图章，图片文件，位置，大小
        /// https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelMarkupControl~eDrawings.Interop.EModelMarkupControl.IEModelMarkupControl~AddStamp.html
        /// </summary>
        public void AddStamp(string filename, float x, float y, float width, float height)
        {
            MarkupCtrl.AddStamp(filename,x,y,width,height);
        }

        /// <summary>
        /// https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelMarkupControl~eDrawings.Interop.EModelMarkupControl.IEModelMarkupControl~SetMeasureUnits.html
        /// </summary>
        public void SetMeasureUnits(EMVDistanceUnit distanceUnit, EMVAngleUnit angleUnit)
        {
            MarkupCtrl.SetMeasureUnits(distanceUnit, angleUnit);
        }

        /// <summary>
        /// https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelMarkupControl~eDrawings.Interop.EModelMarkupControl.IEModelMarkupControl~ShowComment.html
        /// </summary>
        void ShowComment(int commentId)
        {
            MarkupCtrl.ShowComment(commentId);
        }

        /// <summary>
        /// https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelMarkupControl~eDrawings.Interop.EModelMarkupControl.IEModelMarkupControl~ShowCommentx64.html
        /// </summary>
        void ShowCommentx64(long commentIDx64)
        {
            MarkupCtrl.ShowCommentx64(commentIDx64);
        }

        /// <summary>
        /// https://help.solidworks.com/2020/english/api/emodelapi/eDrawings.Interop.EModelMarkupControl~eDrawings.Interop.EModelMarkupControl.IEModelMarkupControl~ShowSaveMarkup.html
        /// </summary>
        void ShowSaveMarkup(string saveName, bool saveAs)
        {
            MarkupCtrl.ShowSaveMarkup(saveName, saveAs);
        }

        #endregion
    }
}
