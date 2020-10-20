using System;
using System.Windows.Controls;

namespace DuEDrawingControl
{
    /// <summary>
    /// EDrawingWPFControl.xaml 的交互逻辑
    /// </summary>
    public partial class EDrawingWPFControl : UserControl
    {
        public event Action<dynamic> OnControlLoaded;

        public EDrawingWPFControl()
        {
            InitializeComponent();
            edrawingView.OnControlLoaded += EdrawingView_OnControlLoaded;  
        }

        private void EdrawingView_OnControlLoaded(dynamic obj)
        {
            OnControlLoaded?.Invoke(obj);
        }

        /// <summary>
        /// eDrawing host
        /// </summary>
        public EDrawingComponent EDrawingHost { get { return edrawingView.EDrawingHost; } }
    }
}
