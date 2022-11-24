using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResults<Authors> GetById(string au_id);
        IDataResults<List<Authors>> GetList();
        IDataResults<List<Authors>> GetByState(string state);
        IResult Add(Authors authors);
        IResult Update(Authors authors);
        IResult Delete(Authors authors);

    }
}
