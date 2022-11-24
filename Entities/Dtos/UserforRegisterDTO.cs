using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserforRegisterDTO:IDto
    {
        public string e_mail { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
