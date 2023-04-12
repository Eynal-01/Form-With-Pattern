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
        public static void WriteHumans(Human user)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{user.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, user);
                }
            }
        }
        public static Human ReadHumans(string filename)
        {
            Human users = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{filename}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    users = serializer.Deserialize<Human>(jr);
                }
            }
            return users;
        }
        public static void WriteHumansXml(Human user)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Human));
            using (TextWriter writer = new StreamWriter($"{user.Name}.xml"))
            {
                serializer.Serialize(writer, user);
            }
        }
        public static Human ReadHumanXml(string filename)
        {
            Human users = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Human));
            using (TextReader reader = new StreamReader($"{filename}.xml"))
            {
                users = (Human)serializer.Deserialize(reader);
            }
            return users;
        }
    }
}