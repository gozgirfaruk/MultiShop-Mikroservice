using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationMenager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperation;

        public CargoOperationMenager(ICargoOperationDal cargoOperation)
        {
            _cargoOperation = cargoOperation;
        }

        public void TDelete(int id)
        {
            _cargoOperation.Delete(id);
        }

        public List<CargoOperations> TGetAllList()
        {
            var values = _cargoOperation.GetAllList();
            return values;
        }

        public CargoOperations TGetById(int id)
        {
            var  values =_cargoOperation.GetById(id);   
            return values;
        }

        public void TInsert(CargoOperations entity)
        {
           _cargoOperation.Insert(entity);
        }

        public void TUpdate(CargoOperations entity)
        {
            _cargoOperation.Update(entity); 
        }
    }
}
