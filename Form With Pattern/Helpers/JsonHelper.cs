using Form_With_Pattern.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace Form_With_Pattern.Helpers
{
    public class FileHelper
    {
        public static void WriteHumans(List<Human> users)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("humans.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, users);
                }
            }
        }
        //public static List<Human> ReadHumans()
        //{
        //    List<Human> users = null;
        //    var serializer = new JsonSerializer();
        //    using (var sr = new StreamReader("humans.json"))
        //    {
        //        using (var jr = new JsonTextReader(sr))
        //        {
        //            users = serializer.Deserialize<List<Human>>(jr);
        //        }
        //    }
        //    return users;
        //}
        public static void WriteHumansXml(List<Human> Users)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
            using (TextWriter writer = new StreamWriter("humans.xml"))
            {
                serializer.Serialize(writer, Users);
            }
        }
        //public static List<Human> ReadHumanXml()
        //{
        //    List<Human> users = null;
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
        //    using (TextReader reader = new StreamReader("humans.xml"))
        //    {
        //        users = (List<Human>)serializer.Deserialize(reader);
        //    }
        //    return users;
        //}
    }
}
