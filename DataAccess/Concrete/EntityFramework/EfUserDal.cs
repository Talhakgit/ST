using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaims> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from OperationClaims in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaims.op_claim_id equals UserOperationClaim.op_claim_ID
                             where UserOperationClaim.user_ID == user.user_id
                             select new OperationClaims { op_claim_id = OperationClaims.op_claim_id, name = OperationClaims.name };
                             return result.ToList();
            }
        }
    }
}
