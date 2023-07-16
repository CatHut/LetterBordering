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

        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    reader.ReadStartElement();
        //    A = byte.Parse(reader.ReadElementString("A"));
        //    R = byte.Parse(reader.ReadElementString("R"));
        //    G = byte.Parse(reader.ReadElementString("G"));
        //    B = byte.Parse(reader.ReadElementString("B"));
        //    reader.ReadEndElement();
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    writer.WriteElementString("A", A.ToString());
        //    writer.WriteElementString("R", R.ToString());
        //    writer.WriteElementString("G", G.ToString());
        //    writer.WriteElementString("B", B.ToString());
        //}
    }
}
