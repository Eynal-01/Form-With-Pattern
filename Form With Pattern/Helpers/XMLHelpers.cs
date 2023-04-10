using ConsoleApp5;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace Form_With_Pattern.Helpers
{
    [Serializable]
    public class Subject
    {
        using (var writer = new XmlTextWriter("human.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();

                writer.WriteStartElement("Humans");

                foreach (var human in humans)
                {
                    writer.WriteStartElement("Human");

                    writer.WriteAttributeString(nameof(human.Name), human.Name);
                    writer.WriteAttributeString(nameof(human.Surname), human.Surname);
                    writer.WriteAttributeString(nameof(human.Age), human.Age.ToString());

                    writer.WriteEndElement();
                }

writer.WriteEndElement();

writer.WriteEndDocument();
            }
    }
}
