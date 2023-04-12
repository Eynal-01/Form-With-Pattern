using Form_With_Pattern.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_With_Pattern.Repositories
{
    public class HumanRepository
    {
        public class UsersRepository
        {
            public List<Human> Users { get; set; }
            public UsersRepository()
            {
                Users = new List<Human>();
            }
        }
    }
}
