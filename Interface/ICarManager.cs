using CLASSEM19.Model;
namespace CLASSEM19.Interface
{
    public interface ICarManager
    {
        public void CreateCar(string carName, string carColor, decimal carPrice, string carEngineType);
        public void UpdateCar();
        public void DeleteCar();
        public Car GetCar(string refNumber);
        public void GetAllCars();
    }
}