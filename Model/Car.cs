namespace CLASSEM19.Model
{
    public class Car
    {
        public string RefNumber{get;set;}
        public string CarName{get;set;}
        public string CarColor{get;set;}
        public decimal CarPrice{get;set;}
        public string CarEngineType{get;set;}
        public Car(string refNumber, string carName, string carColor, decimal carPrice, string carEngineType)
        {
            RefNumber = refNumber;
            CarName = carName;
            CarColor = carColor;
            CarPrice = carPrice;
            CarEngineType = carEngineType;
        }
    }
}