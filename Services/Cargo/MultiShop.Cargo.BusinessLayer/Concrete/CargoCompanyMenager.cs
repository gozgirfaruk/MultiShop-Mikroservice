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
    public class CargoCompanyMenager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _companyDal;

        public CargoCompanyMenager(ICargoCompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public void TDelete(int id)
        {
            _companyDal.Delete(id);
        }

        public List<CargoCompany> TGetAllList()
        {
            var values = _companyDal.GetAllList();
            return values;
        }

        public CargoCompany TGetById(int id)
        {
            var value = _companyDal.GetById(id);
            return value;
        }

        public void TInsert(CargoCompany entity)
        {
            _companyDal.Insert(entity); 
        }

        public void TUpdate(CargoCompany entity)
        {
            _companyDal.Update(entity);
        }
    }
}
