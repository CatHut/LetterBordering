using CatHut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterBordering
{
    public class DecorationInfo
    {
        public int Thick;
        public SerializableColor Color;

        public DecorationInfo()
        {
            Thick = 10;
            Color = new SerializableColor(System.Drawing.Color.Black);
        }
    }
}
