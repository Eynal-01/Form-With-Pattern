using Form_With_Pattern;
using Newtonsoft.Json;
using System;
using Form_With_Pattern.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Bibliography;
using Formatting = System.Xml.Formatting;

namespace Form_With_Pattern.Helpers
{
    public class Subject
    {
        List<Human> humans = new List<Human>();
        public void WriteXmlfile()
        {

            using (var writer = new XmlTextWriter("human.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Humans");

                foreach (var human in humans)
                {
                    writer.WriteStartElement("Human");
                    writer.WriteElementString(nameof(human.Name), human.Name);
                    writer.WriteElementString(nameof(human.Surname), human.Surname);
                    writer.WriteElementString(nameof(human.Age), human.Age.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
