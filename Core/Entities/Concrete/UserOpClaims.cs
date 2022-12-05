
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserOpClaims:IEntity
    {
        [Key]
        public int us_op_claim_id { get; set; }
        public int user_ID { get; set; }
        public int op_claim_ID { get; set; }
    }
}
