using PropertyTools.DataAnnotations;
using comp = System.ComponentModel;

namespace WPFExample;

internal class ToolTipData : comp.INotifyPropertyChanged
{
    private int tipID;
    private bool showAtMousePosition = true;

    public ToolTipData() { }

    [Category("Data")]
    public string TipTitle { get; set; } = "title";

    [Category("Data")]
    public string TipText { get; set; } = "text";

    [Category("Options")]
    public bool ShowAtMousePosition
    {
        get => showAtMousePosition;
        set
        {
            showAtMousePosition = value;
            PropertyChanged?.Invoke(
                this,
                new comp.PropertyChangedEventArgs(nameof(ShowAtMousePosition))
            );
        }
    }

    [Category("Position")]
    [VisibleBy(nameof(ShowAtMousePosition), false)]
    public int X { get; set; } = 10;

    [Category("Position")]
    [VisibleBy(nameof(ShowAtMousePosition), false)]
    public int Y { get; set; } = 10;

    [Category("Current tipID")]
    public int TipID
    {
        get => tipID;
        set
        {
            tipID = value;
            PropertyChanged?.Invoke(this, new comp.PropertyChangedEventArgs(nameof(tipID)));
        }
    }

    public event comp.PropertyChangedEventHandler PropertyChanged;
}
