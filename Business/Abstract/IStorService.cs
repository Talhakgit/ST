using Business.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStorService
    {
        IDataResults<Stor> GetById(int storid);
        IDataResults<List<Stor>> GetList();
        IDataResults<List<Stor>> GetListByAdress(string stor_adress);
        IResult Add(Stor stor);
        IResult Update(Stor stor);
        IResult Delete(Stor stor);

        IResult TransactionalOperation(Stor stor);


    }
}
