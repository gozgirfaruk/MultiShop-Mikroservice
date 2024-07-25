using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerMenager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomer;

        public CargoCustomerMenager(ICargoCustomerDal cargoCustomer)
        {
            _cargoCustomer = cargoCustomer;
        }

        public void TDelete(int id)
        {
            _cargoCustomer.Delete(id);
        }

        public List<CargoCustomer> TGetAllList()
        {
            var values =_cargoCustomer.GetAllList();
            return values;
        }

        public CargoCustomer TGetById(int id)
        {
            var values = _cargoCustomer.GetById(id);
            return values;
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomer.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomer.Update(entity);
        }
    }
}
