using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OperationClaims:IEntity
    {
        public int op_claim_id { get; set; }
        public string name { get; set; }
    }
}
