using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string e_mail { get; set; }
        public bool status { get; set; }
        public byte[] password_salt { get; set; }
        public byte[] password_hash { get; set; } 
         
    }
}
