using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string users = File.ReadAllText("../../../Datasets/users.json");
            string products = File.ReadAllText("../../../Datasets/products.json");
            string categories = File.ReadAllText("../../../Datasets/categories.json");
            string categoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportUsers(context, users));
            Console.WriteLine(ImportProducts(context, products));
            Console.WriteLine(ImportCategories(context, categories));
            Console.WriteLine(ImportCategoryProducts(context, categoryProducts));
            Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Problem 02
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);
            InitializeMapper();
            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        //Problem 03
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductsInputDto> products = JsonConvert.DeserializeObject<IEnumerable<ProductsInputDto>>(inputJson);
            InitializeMapper();
            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);
            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        //Problem 04
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategotiesInputDto> categories = JsonConvert.DeserializeObject<IEnumerable<CategotiesInputDto>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));
            InitializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        //Problem 05
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesProductsInputDto> categoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoriesProductsInputDto>>(inputJson);
            InitializeMapper();
            var mappedCategorieProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProducts);

            context.CategoryProducts.AddRange(mappedCategorieProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategorieProducts.Count()}";
        }

        //Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(p => new ProductOutputDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string json = JsonConvert.SerializeObject(products, jsonSettings);
            return json;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(i => i.ProductsSold.Any(x => x.Buyer != null))
                .OrderBy(f => f.LastName)
                .ThenBy(l => l.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string json = JsonConvert.SerializeObject(users, jsonSettings);
            return json;

        }

        //Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = (x.CategoryProducts.Average(p => p.Product.Price).ToString("F2")),
                    TotalRevenue = (x.CategoryProducts.Sum(p => p.Product.Price)).ToString("F2")
                })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string json = JsonConvert.SerializeObject(categories, jsonSettings);
            return json;
        }

        //Problem 07
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(x => x.Buyer != null))
                .OrderByDescending(p => p.ProductsSold.Count)
                .Select(c => new
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Age = c.Age,

                    SoldProducts = c.ProductsSold
                    .Select(r => new
                    {
                        Count = c.ProductsSold.Count(),
                        Products = c.ProductsSold
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    })

                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var resultWithCount = new
            {
                usersCount = users.Count,
                users
            };

            string result = JsonConvert.SerializeObject(resultWithCount, jsonSettings);
            return result;

        }
        private static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfig);
        }
    }
}