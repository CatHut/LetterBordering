using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CatHut
{
    public static class CatHutCommon
    {
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(XmlWriter.Create(ms), obj);

                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                return (T)xs.Deserialize(XmlReader.Create(ms));

            }
        }
    }
}
