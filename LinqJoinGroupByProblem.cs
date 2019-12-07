using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>()
            {
                new Car(21, "TestA", "2010"),
                new Car(22, "TestB", "2011"),
                new Car(23, "TestC", "2010")
            };
            List<Sales> Sales = new List<Sales>()
            {
                new Sales(101,21,"2011-10-21"),
                new Sales(102,21,"2012-10-21"),
                new Sales(103,22,"2011-10-21"),
            };

            var HighestSales = Sales.GroupBy(x => x.CarId).ToDictionary(x => x.Key, y => y.ToList<Sales>()).OrderBy(x => x.Value.Count).Select(x => x.Value).Last().Join(Cars, s => s.CarId, c => c.ID, (s, c) => new { CarId = s.CarId, brand = c.Brand, TradeYear = s.TradeYear }).Select((x)=> new { x.CarId, x.brand, x.TradeYear }) ;

            foreach (var item in HighestSales)
            {
                Console.WriteLine(item.CarId + " " + item.brand + " " +item.TradeYear);
            }
            
            Console.Read();
        }
    }
    public class Car 
    {
        public Car(int ID, string Brand, string YEAR)
        {
            this.ID = ID;
            this.Brand = Brand;
            this.YEAR = YEAR;
        }
        public int ID { get; set; }
        public string Brand { get; set; }
        public string YEAR { get; set; }
        
    }

    public class Sales
    {
        public Sales(int SaleId, int CarId, string TradeYear)
        {
            this.SaleId = SaleId;
            this.CarId = CarId;
            this.TradeYear = TradeYear;
        }
        public int SaleId { get; set; }
        public int CarId { get; set; }
        public string TradeYear { get; set; }
    }

}
