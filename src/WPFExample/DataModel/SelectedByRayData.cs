using PropertyTools.DataAnnotations;
using System.Windows.Media.Media3D;

namespace WPFExample
{
    internal class SelectedByRayData
    {
        public SelectedByRayData()
        {
            
        }

        [Category("Point")]
        public float PointX { get; set; }

        [Category("Point")]
        public float PointY { get; set; }

        [Category("Point")]
        public float PointZ { get; set; }

        [Category("Direction")]
        public float DirectionX { get; set; }

        [Category("Direction")]
        public float DirectionY { get; set; }

        [Category("Direction")]
        public float DirectionZ { get; set; }


    }
}