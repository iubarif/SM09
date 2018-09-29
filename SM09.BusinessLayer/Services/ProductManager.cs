//using SM09.Common.Core;
//using SM09.Common.Entities;
//using SM09.Common.Interface;
//using SM09.DataAccess.Core;
//using System;
//using System.Collections.Generic;

//namespace SM09.BusinessLayer.Services
//{
//    public class ProductManager : ICategoryManager
//    {
//        IRepository _repository;        
//        IUnitOfWork _unitOfWork;

//        public ProductManager(IRepository repository, IUnitOfWork unitOfWork)
//        {
//            _repository = repository;
//            _unitOfWork = unitOfWork;
//        }

//        public void Create(BaseEntity entity)
//        {
//            Product product = ConvertBaseEntity(entity);
//            _repository.Create<Product>(product);            
//        }

//        public void Delete(BaseEntity entity)
//        {
//            Product product = ConvertBaseEntity(entity);
//            product.Active = false;
//            _repository.Update<Product>(product);
//        }

//        public IEnumerable<BaseEntity> GetAll()
//        {
//            return _repository.All<Product>();
//        }

//        public void SaveChanges()
//        {
//            _unitOfWork.SaveChanges();
//        }

//        public void Update(BaseEntity entity)
//        {
//            throw new NotImplementedException();
//        }

//        private Product ConvertBaseEntity(BaseEntity entity) {
//            return (Product)entity;
//        }
//    }
//}
