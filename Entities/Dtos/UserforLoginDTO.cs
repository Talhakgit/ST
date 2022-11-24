using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserforLoginDTO:IDto
    {
        public string e_mail { get; set; }
        public string  password { get; set; }

    }
}
