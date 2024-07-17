using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DuEDrawingControl;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(Panel))]
[Category("Du")]
[DisplayName("eDrawing View Control")]
[Description("eDrawing Control for PreView")]
public class EDrawingView : UserControl
{
    public event Action<dynamic> OnControlLoaded;

    /// <summary>
    /// 通过此属性调用eDrawing api
    /// </summary>
    [Browsable(false)]
    public EDrawingComponent EDrawingHost { get; private set; }

    /// <summary>
    /// 通过此属性调用EModelMarkupControl
    /// </summary>
    [Browsable(false)]
    public MarkupComponent Markup { get; private set; }

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

        //2023.03.29 Honfeng添加IEModelMarkupControl，用于开启测量
        Markup = new MarkupComponent(
            EDrawingHost.CoCreateInstance("EModelViewMarkup.EModelMarkupControl")
        );
    }
}
