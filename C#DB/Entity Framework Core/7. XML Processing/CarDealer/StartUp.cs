using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Export;
using CarDealer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            /*
              context.Database.EnsureDeleted();
              context.Database.EnsureCreated();*/

            string result = GetLocalSuppliers(context);
            Console.WriteLine(result);

        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportSupplierDto[] dtos = (ImportSupplierDto[])serializer.Deserialize(reader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var d in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = d.Name,
                    IsImporter = bool.Parse(d.IsImporter)
                };

                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Parts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartsDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportPartsDto[] dtoParts = (ImportPartsDto[])serializer.Deserialize(reader);

            var supplierIds = context.Suppliers.Select(s => s.Id).ToArray();

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var part in dtoParts)
            {
                if (supplierIds.Contains(part.SupplierId))
                {
                    Part p = new Part()
                    {
                        Name = part.Name,
                        Price = decimal.Parse(part.Price),
                        Quantity = part.Quantity,
                        SupplierId = part.SupplierId
                    };
                    parts.Add(p);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";

        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute carRoot = new XmlRootAttribute("Cars");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarsDto[]), carRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportCarsDto[] carsDto = (ImportCarsDto[])serializer.Deserialize(reader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var carDto in carsDto)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                };

                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();
                foreach (var partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context
                        .Parts
                        .Find(partId);

                    if (part == null)
                    {
                        continue;
                    }
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        Part = part
                    };

                    currentCarParts.Add(partCar);
                }

                car.PartCars = currentCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Customers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportCustomerDto[] customersDtos = (ImportCustomerDto[])serializer.Deserialize(reader);
            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var customerDto in customersDtos)
            {
                Customer c = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = bool.Parse(customerDto.IsYoungDriver)
                };
                customers.Add(c);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 13 
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Sales");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportSaleDto[] saleDtos = (ImportSaleDto[])serializer.Deserialize(reader);

            var cars = context
                .Cars
                .Select(i => i.Id)
                .ToArray();
            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var saleDto in saleDtos)
            {
                if (cars.Contains(saleDto.CarId))
                {
                    Sale s = new Sale()
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };

                    sales.Add(s);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), root);

            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportBMWCars[] bmwCars = context
                                 .Cars
                                 .Where(c => c.Make == "BMW")
                                 .OrderBy(c => c.Model)
                                 .ThenByDescending(t => t.TravelledDistance)
                                 .Select(c => new ExportBMWCars()
                                 {
                                     Model = c.Model,
                                     Id = c.Id,
                                     TravelledDistance = c.TravelledDistance.ToString()
                                 })
                                 .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBMWCars[]), root);
            using StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, bmwCars, nameSpaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSuppliers[] suppliers = context
                                                    .Suppliers
                                                    .Where(s => s.IsImporter == false)
                                                    .Select(p => new ExportLocalSuppliers()
                                                    {
                                                        Id = p.Id,
                                                        Name = p.Name,
                                                        PartsCount = p.Parts.Count
                                                    })
                                                    .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSuppliers[]), root);
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}