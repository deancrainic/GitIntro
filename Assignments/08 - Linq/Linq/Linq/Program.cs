using System;
using System.Collections;
using Linq;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carList = PopulateCarList();

            //Where
            var filteredCarList = carList.Where(x => x.HorsePower > 200)
                                         .Where(x => x.HorsePower < 1000);

            Console.WriteLine("Where------");
            PrintCarList(filteredCarList);
            Console.WriteLine();

            //Take
            var firstThreeCars = carList.Take(3);

            Console.WriteLine("Take-------");
            PrintCarList(firstThreeCars);
            Console.WriteLine();

            //Skip
            var allButFirstThreeCars = carList.Skip(3);

            Console.WriteLine("Skip-------");
            PrintCarList(allButFirstThreeCars);
            Console.WriteLine();

            //TakeWhile
            var HpSmallerThanFiveHundred = carList.TakeWhile(x => x.HorsePower < 500);

            Console.WriteLine("TakeWhile--");
            PrintCarList(HpSmallerThanFiveHundred);
            Console.WriteLine();

            //Distinct
            var distincCarList = carList.Distinct(new CarEqualityComparer());

            Console.WriteLine("Distinct--");
            PrintCarList(distincCarList);
            Console.WriteLine();

            //Select
            var biggerHP = carList.Select(x => x.HorsePower * 2);

            Console.WriteLine("Select----");
            foreach (var item in biggerHP)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //OrderBy, ThenBy
            var orderedCarList = carList.OrderBy(x => x.Brand).ThenBy(x => x.Model);

            Console.WriteLine("OrderBy---");
            PrintCarList(orderedCarList);
            Console.WriteLine();

            //Reverse
            var reversedCarList = carList.Reverse();

            Console.WriteLine("Reverse---");
            PrintCarList(reversedCarList);
            Console.WriteLine();

            //Group
            var groupedCarList = carList.GroupBy(x => x.Brand);

            Console.WriteLine("Group-----");
            foreach (var brand in groupedCarList)
            {
                Console.WriteLine(brand.Key);
                PrintCarList(brand);
            }
            Console.WriteLine();

            //Concat
            var concatCarList = HpSmallerThanFiveHundred.Concat(allButFirstThreeCars);

            Console.WriteLine("Concat----");
            PrintCarList(concatCarList);
            Console.WriteLine();

            //Union
            var unionCarList = HpSmallerThanFiveHundred.Union(allButFirstThreeCars);

            Console.WriteLine("Union-----");
            PrintCarList(unionCarList);
            Console.WriteLine();

            //Intersect
            var intersectCarList = HpSmallerThanFiveHundred.Intersect(allButFirstThreeCars);

            Console.WriteLine("Intersect-");
            PrintCarList(intersectCarList);
            Console.WriteLine();

            //Except
            var exceptCarList = HpSmallerThanFiveHundred.Except(allButFirstThreeCars);

            Console.WriteLine("Except----");
            PrintCarList(exceptCarList);
            Console.WriteLine();

            //OfType

            var electricCarList = carList.OfType<ElectricCar>();

            Console.WriteLine("OfType----");
            PrintCarList(electricCarList);
            Console.WriteLine();

            //ToArray
            Car[] carArray = carList.ToArray();

            Console.WriteLine("ToArray---");
            Console.WriteLine($"carArray length: {carArray.Length}");
            Console.WriteLine();

            //ToDictionary
            Dictionary<int, Car> carDictionary = carList.ToDictionary(car => car.HorsePower, car => car);

            Console.WriteLine("ToDictionary");
            foreach (var car in carDictionary)
            {
                Console.WriteLine(car.Key);
                Console.WriteLine(car.Value);
            }
            Console.WriteLine();

            //First
            var firstCarBMW = carList.First(x => x.Brand.Equals("BMW"));

            Console.WriteLine("First-------");
            Console.WriteLine($"first bmw: {firstCarBMW}");
            Console.WriteLine();

            //Count
            var numberOfAudiCars = carList.Count(x => x.Brand.Equals("Audi"));

            Console.WriteLine("Count-------");
            Console.WriteLine($"audi cars: {numberOfAudiCars}");
            Console.WriteLine();

            //Any
            var containsDacia = carList.Any(x => x.Brand.Equals("Dacia"));

            Console.WriteLine("Contains----");
            Console.WriteLine("contains Dacia: {0}", containsDacia);
            Console.WriteLine();

            //Join
            var brandList = PopulateBrandList();

            var joinedCarBrands = from car in carList
                                  join brand in brandList
                                  on car.Brand equals brand.Name
                                  select new { BrandName = car.Brand, ModelName = car.Model, BrandCountry = brand.Country };

            Console.WriteLine("Join--------");
            foreach (var car in joinedCarBrands)
            {
                Console.WriteLine($"{car.BrandName}, {car.ModelName}, {car.BrandCountry}");
            }
            Console.WriteLine();

            //GroupJoin
            var groupJoined = from brand in brandList
                              join car in carList on brand.Name equals car.Brand
                              into carGroups
                              select new
                              {
                                  BrandName = brand.Name,
                                  Models = carGroups
                              };

            Console.WriteLine("GroupJoin--");
            foreach (var brand in groupJoined)
            {
                Console.WriteLine($"Brand: {brand.BrandName}");

                foreach (var car in brand.Models)
                {
                    Console.WriteLine($"Model: {car.Model}");
                }
            }
            Console.WriteLine();

            //OuterJoin
            var outerJoinedCarsBrands = from car in carList
                                        join brand in brandList on car.Brand equals brand.Name into brandGroups
                                        from brandName in brandGroups.DefaultIfEmpty()
                                        select new
                                        {
                                            BrandName = car.Brand,
                                            ModelName = car.Model,
                                            BrandCountry = brandName?.Country
                                        };

            Console.WriteLine("OuterJoin---");
            foreach (var car in outerJoinedCarsBrands)
            {
                Console.WriteLine($"{car.BrandName}, {car.ModelName}, {car.BrandCountry}");
            }
            Console.WriteLine();

            //MyExtensionMethods
            var myFilteredCarList = carList.Filter(x => x.Model.StartsWith('e') || x.Model.StartsWith('E'));

            Console.WriteLine("MyFilter----");
            PrintCarList(myFilteredCarList);
            Console.WriteLine();


            var hasBlueCar = carList.HasColor("blue");

            Console.WriteLine("HasColor----");
            Console.WriteLine($"Has blue car: {hasBlueCar}");
            Console.WriteLine();


            var carsWithLessHP = carList.CountCarsWhere(x => x.HorsePower < 200);

            Console.WriteLine("CountCarsWhere");
            Console.WriteLine($"{carsWithLessHP} car(s) with less then 200 HP exist in the list");
            Console.WriteLine();

            //Cast
            List<Int32> int32List = new List<Int32> { 1, 5, 2, 8, 9 };

            var castedInt32List = int32List.Cast<int>();

            Console.WriteLine("Cast--------");
            foreach (var item in castedInt32List)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //ToLookup
            var carsLookup = carList.ToLookup(x => x.HorsePower, x => x);

            Console.WriteLine("ToLookup----");
            foreach (var car in carsLookup)
            {
                Console.WriteLine(car.Key);
                foreach (var attribute in car)
                {
                    Console.WriteLine(attribute);
                }
            }
            Console.WriteLine();

            //SelectMany
            var selectManyCars = brandList.SelectMany(x => x.CarModels);

            Console.WriteLine("SelectMany-");
            foreach (var model in selectManyCars)
            {
                Console.WriteLine(model);
            }
            Console.WriteLine();

            //Zip
            var zipCarBrandList = carList.Zip(brandList);

            Console.WriteLine("Zip--------");
            foreach (var item in zipCarBrandList)
            {
                Console.WriteLine(item.First);
                Console.WriteLine("-");
                Console.WriteLine(item.Second);
                Console.WriteLine();
            }
            Console.WriteLine();

            //Aggregate
            var aggregateCarList = carList.Aggregate(false, (value, car) => value || (car.HorsePower > 500));

            Console.WriteLine("Aggregate--");
            Console.WriteLine("Is there a car with more than 500 HP: " + aggregateCarList);
            Console.WriteLine();

            int[] myArr = new List<int> { 4, 3 ,2 ,7 }.ToArray();



            var colors = from brand in brandList
                         join car in carList on brand.Name equals car.Brand
                         where brand.Country.Equals("Germany") && (car.HorsePower > 500)
                         select car.Color;

            var colors2 = brandList.Join(carList,
                            x => x.Name,
                            x => x.Brand,
                            (x, y) => new { x.Country, y.HorsePower, y.Color })
                            .Where(x => x.Country.Equals("Germany") && x.HorsePower > 100)
                            .Select(x => x.Color);


            foreach(var color2 in colors)
                Console.WriteLine(color2);

        }

        public static IEnumerable<Car> PopulateCarList()
        {
            List<Car> cars = new List<Car> 
            {
                new Car { Brand = "Audi", Model = "A5", HorsePower = 190, Color = "gray" },
                new Car { Brand = "Audi", Model = "RS4", HorsePower = 320, Color = "red" },
                new Car { Brand = "Volkswagen", Model = "Golf 7", HorsePower = 90, Color = "blue" },
                new Car { Brand = "Dacia", Model = "Duster", HorsePower = 75, Color = "orange" },
                new ElectricCar { Brand = "Tesla", Model = "S", HorsePower = 1060, Color = "white", BatteryAutonomy = 600 },
                new ElectricCar { Brand = "Volkswagen", Model = "e-Up!", HorsePower = 46, Color = "white", BatteryAutonomy = 350 },
                new Car { Brand = "BMW", Model = "525e", HorsePower = 600, Color = "dark gray" },
                new Car { Brand = "Hyundai", Model = "Elantra", HorsePower = 120, Color = "blue" },
                new Car { Brand = "BMW", Model = "525e", HorsePower = 602, Color = "dark gray" }
            };

            return cars;
        }

        public static IEnumerable<CarBrand> PopulateBrandList()
        {
            List<CarBrand> brands = new List<CarBrand>
            {
                new CarBrand { Name = "BMW", Year = 1900, Country = "Germany", CarModels = new List<string> { "320i", "x6", "z4" } },
                new CarBrand { Name = "Audi", Year = 1920, Country = "Germany", CarModels = new List<string> { "S3" } },
                new CarBrand { Name = "Volkswagen", Year = 1890, Country = "Germany", CarModels = new List<string> { "Polo" } },
                new CarBrand { Name = "Dacia", Year = 1945, Country = "Romania", CarModels = new List<string> { "Logan", "Stepway", "Duster" } },
                new CarBrand { Name = "Hyundai", Year = 1930, Country = "South Korea", CarModels = new List<string> { "i30" } }
            };

            return brands;
        }

        public static void PrintCarList(IEnumerable<Car> carList)
        {
            foreach (Car car in carList)
                Console.WriteLine(car);
        }
    }
}