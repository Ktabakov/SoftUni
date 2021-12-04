using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper { get; set; }
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersString = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(context, suppliersString));
            string partsString = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, partsString));
            string carsString = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(context, carsString));
            string customersString = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(context, customersString));
            string salesString = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(context, salesString));
            Console.WriteLine(GetOrderedCustomers(context));
        }

        //Problem 08
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SuplierInputDto> suppliers = JsonConvert.DeserializeObject<IEnumerable<SuplierInputDto>>(inputJson);
            InitializeMapper();
            var mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";

        }

        //Problem 09
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<int> validSuppliers = context.Suppliers.Select(s => s.Id).ToList();
            InitializeMapper();
            IEnumerable<PartsInputDto> parts = JsonConvert.DeserializeObject<IEnumerable<PartsInputDto>>(inputJson)
                .Where(c => validSuppliers.Contains(c.SupplierId));

            var mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";

        }

        //Problem 10
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            IEnumerable<CarsInputDto> cars = JsonConvert.DeserializeObject<IEnumerable<CarsInputDto>>(inputJson);


            var mappedCars = mapper.Map<IEnumerable<Car>>(cars);

            context.Cars.AddRange(mappedCars);
            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count()}.";
        }

        //Problem 11
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            IEnumerable<CustomerInputDto> customers = JsonConvert.DeserializeObject<IEnumerable<CustomerInputDto>>(inputJson);

            var mappedCustomers = mapper.Map<IEnumerable<Customer>>(customers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        //Problem 12
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            IEnumerable<SalesInputDto> sales = JsonConvert.DeserializeObject<IEnumerable<SalesInputDto>>(inputJson);

            var mappedSales = mapper.Map<IEnumerable<Sale>>(sales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        //Problem 13
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            InitializeMapper();

            var customers = context
               .Customers
               .OrderBy(c => c.BirthDate)
               .ThenBy(c => c.IsYoungDriver ? 1 : 0)
               .ProjectTo<CustomerInputDto>(mapper.ConfigurationProvider)
               .ToList();

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                //ContractResolver = resolver,
                DateFormatString = "dd/MM/yyyy"
            };

            string json = JsonConvert.SerializeObject(customers, jsonSerializerSettings);
            return json;

        }
        private static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfig);
        }
    }
}