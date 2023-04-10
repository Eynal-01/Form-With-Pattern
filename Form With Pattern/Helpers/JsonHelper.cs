using Form_With_Pattern.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Form_With_Pattern.Helpers
{
    public class FileHelper
    {
        public static void WriteJsonHuman(Human human)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{human.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, human);
                }
            }
        }
    }
}
