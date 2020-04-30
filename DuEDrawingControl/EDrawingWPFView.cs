using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms.Integration;

namespace DuEDrawingControl
{
    public class EDrawingWPFView : WindowsFormsHost
    {
        public EDrawingView EDrawingView { get; private set; }

        public EDrawingComponent EDrawingHost { get { return EDrawingView.EDrawingHost; } }

        public EDrawingWPFView()
        {
            this.Loaded += EDrawingWPFView_Loaded;
        }

        private void EDrawingWPFView_Loaded(object sender, RoutedEventArgs e)
        {
            EDrawingView = new EDrawingView();
            Child = EDrawingView;
        }

    }
}
