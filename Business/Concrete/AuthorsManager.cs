using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorsManager : IAuthorService
    {
        private IAuthorsDal _authorsDal;

        public AuthorsManager(IAuthorsDal authorsDal)
        {
            
             _authorsDal = authorsDal;
        }
        public IResult Add(Authors authors)
        {
            _authorsDal.Add(authors);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Authors authors)
        {
            _authorsDal.delete(authors);
            return new SuccessResult(Messages.ProductDeleted);  
        }

        public IDataResults<Authors> GetById(string au_id)
        {
            EfAuthorDal p = new EfAuthorDal();
            return new SuccessDataResult<Authors>(_authorsDal.Get(p => p.au_id == au_id));
        }

        public IDataResults<List<Authors>> GetByState(string state)
        {
            return new SuccessDataResult<List<Authors>>(_authorsDal.GetList(p =>p.state == state).ToList());        
        }

        public IDataResults<List<Authors>>GetList()
        {
           

            return new SuccessDataResult<List<Authors>>(_authorsDal.GetList().ToList());
        }

        public IResult Update(Authors authors)
        {
            _authorsDal.update(authors);
            return new SuccessResult(Messages.ProductUpdated);
        }

   
    }
}
