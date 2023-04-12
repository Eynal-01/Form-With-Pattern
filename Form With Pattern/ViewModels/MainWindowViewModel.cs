using Form_With_Pattern.Commands;
using Form_With_Pattern.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Form_With_Pattern.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ReadCommand { get; set; }
        interface IAdapter
        {
            void Write(Human user);
            void Read(string filename);
        }
        class JsonAdapter : IAdapter
        {
            private Json _json;

            public JsonAdapter(Json json)
            {
                _json = json;
            }

            public void Read(string filename)
            {
                _json.Read(filename);
            }

            public void Write(Human user)
            {
                _json.Write(user);
            }
        }
        class XmlAdapter : IAdapter
        {
            private XML _xml { get; set; }
            public XmlAdapter(XML xml)
            {
                _xml = xml;
            }

            public void Write(Human user)
            {
                _xml.Write(user);
            }

            public void Read(string filename)
            {
                _xml.Read();
            }
        }
        class Json
        {
            public Human Read(string filename)
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
            public void Write(Human user)
            {
                FileHelper.WriteHumans(user);
            }
        }
        class XML
        {
            public Human Read()
            {
                Human users = null;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
                using (TextReader reader = new StreamReader("humans.xml"))
                {
                    users = (Human)serializer.Deserialize(reader);
                }
                return users;
            }

            public void Write(Human user)
            {
                FileHelper.WriteHumansXml(user);
            }
        }
        class Converter
        {
            private readonly IAdapter _adapter;
            public Converter(IAdapter adapter)
            {
                _adapter = adapter;
            }
            public void Write(Human user)
            {
                _adapter.Write(user);
            }
            public void Read(string filename)
            {
                _adapter.Read(filename);
            }
        }
        class Application
        {
            private readonly Converter _converter;
            public Application(IAdapter adapter)
            {
                _converter = new Converter(adapter);
            }
            public void Write(Human user)
            {
                _converter.Write(user);

            }
            public void Read(string filename)
            {
                _converter.Read(filename);
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }
        private string speciality;

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; OnPropertyChanged(); }
        }
        private bool jsonWriter;

        public bool JsonWriterChecked
        {
            get { return jsonWriter; }
            set { jsonWriter = value; OnPropertyChanged(); }
        }
        private bool jsonReader;

        public bool JsonReaderChecked
        {
            get { return jsonReader; }
            set { jsonReader = value; OnPropertyChanged(); }
        }

        private bool xmlWriter;

        public bool XMLWriterChecked
        {
            get { return xmlWriter; }
            set { xmlWriter = value; OnPropertyChanged(); }
        }
        private bool xmlReader;

        public bool XMLReaderChecked
        {
            get { return xmlReader; }
            set { xmlReader = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            SaveCommand = new RelayCommand((obj) =>
            {
                if (JsonWriterChecked || XMLWriterChecked)
                {
                    IAdapter adapter;
                    Human users = new Human();
                    users.Name = Name;
                    users.Surname = Surname;
                    users.Age = Age;
                    users.Speciality = Speciality;
                    if (JsonWriterChecked)
                    {
                        Json json = new Json();
                        adapter = new JsonAdapter(json);
                        Application app = new Application(adapter);
                        adapter.Write(users);
                        MessageBox.Show("Succesfully");
                    }
                    else if (XMLWriterChecked)
                    {
                        XML xml = new XML();
                        adapter = new XmlAdapter(xml);
                        Application app = new Application(adapter);
                        adapter.Write(users);
                        MessageBox.Show("Succesfully");
                    }
                    else
                    {
                        MessageBox.Show("You have to choose operation type");
                    }

                    Name = String.Empty;
                    Surname = String.Empty;
                    Age = 0;
                    Speciality = String.Empty;
                }
            });

            ReadCommand = new RelayCommand((obj) =>
            {

            });
        }
    }
}