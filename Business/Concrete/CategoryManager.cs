using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
            }
            catch
            {
                return new ErrorDataResult<List<Category>>(_categoryDal.GetList().ToList());
            }
        }
    }
}
