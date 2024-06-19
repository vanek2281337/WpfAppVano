using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVano.Entity
{
    class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Status { get; set; }

        public string Role { get; set; }

       public string Smena { get; set; }
    }
}
