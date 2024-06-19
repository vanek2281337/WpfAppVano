using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVano.Entity
{
    class OrderEntity
    {
        public int Id { get; set; }

        public int Table { get; set; }

        public int Clients { get; set; }

        public string Food_Drink { get; set; }

        public string Status { get; set; }
    }

}
