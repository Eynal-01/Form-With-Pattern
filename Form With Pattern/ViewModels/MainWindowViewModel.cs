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
        interface IAdapter
        {
            void Write(List<Human> users);
            //List<Human> Read();
        }
        class JsonAdapter : IAdapter
        {
            private Json _json;

            public JsonAdapter(Json json)
            {
                _json = json;
            }

            //public List<Human> Read()
            //{
            //    return _json.Read();
            //}

            public void Write(List<Human> users)
            {
                _json.Write(users);
            }
        }
        class XmlAdapter : IAdapter
        {
            private XML _xml { get; set; }
            public XmlAdapter(XML xml)
            {
                _xml = xml;
            }

            //public List<Human> Read()
            //{
            //    return _xml.Read();
            //}

            public void Write(List<Human> users)
            {
                _xml.Write(users);
            }
        }
        class Json
        {
            public List<Human> Read()
            {

                List<Human> users = null;
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader("humans.json"))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        users = serializer.Deserialize<List<Human>>(jr);
                    }
                }
                return users;

            }
            public void Write(List<Human> users)
            {
                FileHelper.WriteHumans(users);
            }
        }
        class XML
        {
            public List<Human> Read()
            {
                List<Human> users = null;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
                using (TextReader reader = new StreamReader("humans.xml"))
                {
                    users = (List<Human>)serializer.Deserialize(reader);
                }
                return users;
            }

            public void Write(List<Human> users)
            {
                FileHelper.WriteHumansXml(users);
            }
        }
        class Converter
        {
            private readonly IAdapter _adapter;
            public Converter(IAdapter adapter)
            {
                _adapter = adapter;
            }
            public void Write(List<Human> users)
            {
                _adapter.Write(users);
            }
            //public List<Human> Read()
            //{
            //    return _adapter.Read();
            //}
        }
        class Application
        {
            private readonly Converter _converter;
            public Application(IAdapter adapter)
            {
                _converter = new Converter(adapter);
            }
            public void Write(List<Human> users)
            {
                _converter.Write(users);

            }
            //public List<Human> Read()
            //{
            //    return _converter.Read();
            //}
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
        //private bool jsonReader;

        //public bool JsonReaderChecked
        //{
        //    get { return jsonReader; }
        //    set { jsonReader = value; OnPropertyChanged(); }
        //}

        private bool xmlWriter;

        public bool XMLWriterChecked
        {
            get { return xmlWriter; }
            set { xmlWriter = value; OnPropertyChanged(); }
        }
        //private bool xmlReader;

        //public bool XMLReaderChecked
        //{
        //    get { return xmlReader; }
        //    set { xmlReader = value; OnPropertyChanged(); }
        //}

        public MainWindowViewModel()
        {
            SaveCommand = new RelayCommand((obj) =>
            {
                Name=String.Empty;  
                Surname=String.Empty;  
                if (JsonWriterChecked ||/* JsonReaderChecked||*/ XMLWriterChecked /*|| XMLReaderChecked*/)
                {

                    var user = new Human { Name = Name, Surname = Surname, Age = Age, Speciality = Speciality };
                    App.UserRepo.Users.Add(user);
                    var allUsers = App.UserRepo.Users;
                    IAdapter adapter;
                    if (JsonWriterChecked)
                    {
                        Json json = new Json();
                        adapter = new JsonAdapter(json);
                        Application app = new Application(adapter);
                        adapter.Write(allUsers);
                    }
                    //else if (JsonReaderChecked)
                    //{
                    //    Json json = new Json();
                    //    adapter = new JsonAdapter(json);
                    //    Application app = new Application(adapter);
                    //    var myuser = adapter.Read();
                    //    Name = myuser[myuser.Count - 1].Name;
                    //    Surname = myuser[myuser.Count - 1].Surname;
                    //    Age = myuser[myuser.Count - 1].Age;
                    //    Speciality = myuser[myuser.Count - 1].Speciality;
                    //}
                    else if (XMLWriterChecked)
                    {
                        XML xml = new XML();
                        adapter = new XmlAdapter(xml);
                        Application app = new Application(adapter);
                        adapter.Write(allUsers);
                    }
                    //else
                    //{
                    //    XML xml = new XML();
                    //    adapter = new XmlAdapter(xml);
                    //    Application app = new Application(adapter);
                    //    var myuser = adapter.Read();
                    //    UserName = myuser[myuser.Count - 1].UserName;
                    //    Surname = myuser[myuser.Count - 1].Surname;
                    //    Email = myuser[myuser.Count - 1].Email;
                    //    Password = myuser[myuser.Count - 1].Password;
                    //}
                }
                else
                {
                    MessageBox.Show("You have to choose operation type");
                }
            });
        }
    }
}
