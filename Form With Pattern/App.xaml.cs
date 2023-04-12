using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static Form_With_Pattern.Repositories.HumanRepository;
using System.Windows.Controls;

namespace Form_With_Pattern
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid MyGrid { get; set; }
        public static UsersRepository UserRepo { get; set; }
        public static UIElement BackPage { get; set; }
        public App()
        {
            UserRepo = new UsersRepository();
        }
    }
}
