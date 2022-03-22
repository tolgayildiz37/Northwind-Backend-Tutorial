using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }



        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
            }
            catch
            {
                return new ErrorDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
            }
        }

        public IDataResult<List<Product>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
            }
            catch
            {
                return new ErrorDataResult<List<Product>>(_productDal.GetList().ToList());
            }
        }

        public IDataResult<List<Product>> GetListByCategoryId(int categoryId)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
            }
            catch
            {
                return new ErrorDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
            }
        }

        public IResult Add(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(CRUDMessages.ADDED_SUCCESSFUL);
            }
            catch
            {
                return new SuccessResult(CRUDMessages.ADDED_ERROR);
            }
        }

        public IResult Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
                return new SuccessResult(CRUDMessages.DELETED_SUCCESSFUL);
            }
            catch
            {
                return new SuccessResult(CRUDMessages.DELETED_ERROR);
            }
        }

        public IResult Update(Product product)
        {
            try
            {
                _productDal.Update(product);
                return new SuccessResult(CRUDMessages.UPDATED_SUCCESSFUL);
            }
            catch
            {
                return new SuccessResult(CRUDMessages.UPDATED_ERROR);
            }
        }
    }
}
