using System;
using System.Windows;
using System.Windows.Forms.Integration;

namespace DuEDrawingControl;

public class EDrawingWPFView : WindowsFormsHost
{
    public EDrawingView EDrawingView { get; private set; }

    public event Action<dynamic> OnControlLoaded;

    public EDrawingComponent EDrawingHost
    {
        get { return EDrawingView.EDrawingHost; }
    }

    public EDrawingWPFView()
    {
        this.Loaded += EDrawingWPFView_Loaded;
    }

    private void EDrawingWPFView_Loaded(object sender, RoutedEventArgs e)
    {
        EDrawingView = new EDrawingView();
        EDrawingView.OnControlLoaded += EDrawingView_OnControlLoaded;
        Child = EDrawingView;
    }

    private void EDrawingView_OnControlLoaded(dynamic obj)
    {
        OnControlLoaded?.Invoke(obj);
    }
}
