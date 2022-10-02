using System.Xml.Serialization;

namespace Ofx
{
    public static class OfxSerializer
    {
        public static OFX Deserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(OFX));
            using (var reader = new StreamReader(path))
            {
                return (OFX)serializer.Deserialize(reader);
            }
        }

        public static bool Serialize(this OFX obj, string path)
        {
            throw new NotImplementedException();
        }
    }
}
