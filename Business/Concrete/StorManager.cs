using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StorManager : IStorService
    {
        StorValidator storValidator= new StorValidator();
        private IStorDal _storDal;
        
        public StorManager (IStorDal storDal)
        {
            _storDal = storDal;
        }
        [ValidationAspect(typeof(StorValidator),Priority = 1)]
        public IResult Add(Stor stor)
        {
            _storDal.Add(stor);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Stor stor)
        {
            _storDal.delete(stor);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResults<Stor> GetById(int stor_id)
        {
            EfStorDal p = new EfStorDal();

            return new SuccessDataResult<Stor>(_storDal.Get(p => p.stor_id == stor_id));
        }
        [CacheAspect(duration: 1)]
        public IDataResults<List<Stor>> GetList()
        {
            return new SuccessDataResult<List<Stor>>(_storDal.GetList().ToList()); 
        }
        [CacheAspect(duration :1)]
        public IDataResults<List<Stor>> GetListByAdress(string stor_address)
        {
            return new SuccessDataResult<List<Stor>>(_storDal.GetList(p => p.stor_address == stor_address).ToList());
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Stor stor)
        {
            _storDal.update(stor);
            //_storDal.Add(stor);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Stor stor)
        {
           _storDal.update(stor);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
