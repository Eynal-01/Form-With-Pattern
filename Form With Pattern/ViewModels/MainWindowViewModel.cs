using Form_With_Pattern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Form_With_Pattern.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand JsonCommand { get; set; }
        public RelayCommand XmlCommand { get; set; }
        public MainWindowViewModel()
        {
            SaveCommand = new RelayCommand((c) =>
            {
                MessageBox.Show("Human added successfully");
            });

            JsonCommand = new RelayCommand((c) =>
            {
                
            });

            XmlCommand = new RelayCommand((c) =>
            {

            });
        }
    }
}
