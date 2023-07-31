using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

namespace CatHut
{
    public struct SerializableColor
    {
        public SerializableColor() 
        {
            A = 255;
            R = 0;
            G = 0;
            B = 0;
        }

        public SerializableColor(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color ToColor()
        {
            return Color.FromArgb(A, R, G, B);
        }

    }
}
