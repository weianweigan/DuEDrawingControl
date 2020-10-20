using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DuEDrawingControl
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
    [Category("Du")]
    [DisplayName("eDrawing View Control")]
    [Description("eDrawing Control for PreView")]
    public class EDrawingView:UserControl
    {
        public event Action<dynamic> OnControlLoaded;

        /// <summary>
        /// 通过此属性调用eDrawing api
        /// </summary>
        [Browsable(false)]
        public EDrawingComponent EDrawingHost { get; private set; }

        [Browsable(false)]
        public dynamic Ctrl { get; private set; }

        public EDrawingView()
        {
            this.Load += EDrawingControl_Load;
        }

        private void Host_OnControlLoaded(dynamic obj)
        {
            Ctrl = obj;
            OnControlLoaded?.Invoke(obj);
        }

        private void EDrawingControl_Load(object sender, EventArgs e)
        {
            EDrawingHost = new EDrawingComponent();
            EDrawingHost.OnControlLoaded += Host_OnControlLoaded;

            this.Controls.Add(EDrawingHost);
            EDrawingHost.Dock = DockStyle.Fill;
        }
    }
}
