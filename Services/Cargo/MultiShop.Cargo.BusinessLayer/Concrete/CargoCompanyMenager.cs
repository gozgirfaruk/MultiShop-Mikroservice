using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyMenager : ICargoCompanyService<CargoCompany>
    {
        private readonly ICargoCompanyDal _cargoCompany;

        public CargoCompanyMenager(ICargoCompanyDal cargoCompany)
        {
            _cargoCompany = cargoCompany;
        }

        public void TDelete(int id)
        {
            _cargoCompany.Delete(id);
        }

        public List<CargoCompany> TGetAllList()
        {
            var values = _cargoCompany.GetAllList();
            return values;
        }

        public CargoCompany TGetById(int id)
        {
            var value = _cargoCompany.GetById(id);
            return value;
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompany.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompany.Update(entity);
        }
    }
}
