﻿using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
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
        public IResult Add(Stor stor)
        {
           ValidationTool.Validate(new StorValidator(),stor);

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

        public IDataResults<List<Stor>> GetList()
        {
            return new SuccessDataResult<List<Stor>>(_storDal.GetList().ToList()); 
        }

        public IDataResults<List<Stor>> GetListByAdress(string stor_address)
        {
            return new SuccessDataResult<List<Stor>>(_storDal.GetList(p => p.stor_address == stor_address).ToList());
        }

        public IResult Update(Stor stor)
        {
           _storDal.update(stor);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
