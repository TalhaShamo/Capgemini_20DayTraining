// ------- Lab1 ---------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }

//     public override string ToString()
//     {
//         return $"{Name} - Rs.{Price}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = GetProducts();

//         var methodSyntax = products
//             .Where(p => p.Price < 1000)
//             .OrderBy(p => p.Name);

//         var querySyntax =
//             from p in products
//             where p.Price < 1000
//             orderby p.Name
//             select p;

//         var queryThenMethod =
//             (from p in products
//              where p.Price < 1000
//              select p)
//             .OrderBy(p => p.Name);

//         var methodThenQuery =
//             from p in products.Where(p => p.Price < 1000)
//             orderby p.Name
//             select p;

//         Print("A - Method Syntax", methodSyntax);
//         Print("B - Query Syntax", querySyntax);
//         Print("C - Query + Method Syntax", queryThenMethod);
//         Print("D - Method + Query Syntax", methodThenQuery);

//         Console.WriteLine(
//             "\nAll match: " +
//             methodSyntax.SequenceEqual(querySyntax) +
//             " / " +
//             methodSyntax.SequenceEqual(queryThenMethod) +
//             " / " +
//             methodSyntax.SequenceEqual(methodThenQuery));
//     }

//     static void Print(string title, IEnumerable<Product> products)
//     {
//         Console.WriteLine($"\n{title}:");

//         foreach (var p in products)
//             Console.WriteLine(p);
//     }

//     static List<Product> GetProducts()
//     {
//         return new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899, InStock = true },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
//             new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7999, InStock = true },
//             new Product { Id = 4, Name = "Notebook", Category = "Stationery", Price = 150, InStock = true },
//             new Product { Id = 5, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
//             new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 1200, InStock = true },
//             new Product { Id = 7, Name = "Bottle", Category = "Accessories", Price = 700, InStock = false },
//             new Product { Id = 8, Name = "Headphones", Category = "Electronics", Price = 999, InStock = true },
//             new Product { Id = 9, Name = "Chair", Category = "Furniture", Price = 4500, InStock = true },
//             new Product { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 850, InStock = false },
//             new Product { Id = 11, Name = "Eraser", Category = "Stationery", Price = 30, InStock = true },
//             new Product { Id = 12, Name = "USB Cable", Category = "Electronics", Price = 299, InStock = true }
//         };
//     }
// }




// ------ Lab2 --------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }
// }

// public class ProductSummaryDto
// {
//     public string Name { get; set; } = "";
//     public string PriceLabel { get; set; } = "";
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = GetProducts();

//         var names = products.Select(p => p.Name);

//         var anonymousProjection = products.Select(p => new
//         {
//             p.Name,
//             PriceWithTax = p.Price * 1.18m
//         });

//         var dtoProjection = products.Select(p => new ProductSummaryDto
//         {
//             Name = p.Name,
//             PriceLabel = $"Rs.{p.Price:F2}"
//         });

//         var indexedProjection = products.Select(
//             (p, index) => $"#{index + 1}: {p.Name}");

//         Console.WriteLine("Names:");
//         foreach (var name in names)
//             Console.WriteLine(name);

//         Console.WriteLine("\nAnonymous Projection:");
//         foreach (var p in anonymousProjection)
//             Console.WriteLine($"{p.Name}: Rs.{p.PriceWithTax:F2}");

//         Console.WriteLine("\nDTO Projection:");
//         foreach (var p in dtoProjection)
//             Console.WriteLine($"{p.Name}: {p.PriceLabel}");

//         Console.WriteLine("\nIndex Projection:");
//         foreach (var item in indexedProjection)
//             Console.WriteLine(item);
//     }

//     static List<Product> GetProducts()
//     {
//         return new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899 },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499 },
//             new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7999 },
//             new Product { Id = 4, Name = "Notebook", Category = "Stationery", Price = 150 },
//             new Product { Id = 5, Name = "Pen", Category = "Stationery", Price = 50 },
//             new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 1200 },
//             new Product { Id = 7, Name = "Bottle", Category = "Accessories", Price = 700 },
//             new Product { Id = 8, Name = "Headphones", Category = "Electronics", Price = 999 },
//             new Product { Id = 9, Name = "Chair", Category = "Furniture", Price = 4500 },
//             new Product { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 850 },
//             new Product { Id = 11, Name = "Eraser", Category = "Stationery", Price = 30 },
//             new Product { Id = 12, Name = "USB Cable", Category = "Electronics", Price = 299 }
//         };
//     }
// }


// ------- Lab3 ---------

// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }

//     public override string ToString()
//     {
//         return $"{Name} - Rs.{Price} - {Category}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = GetProducts();

//         var under500 = products.Where(p => p.Price < 500);

//         var electronicsInStock = products.Where(
//             p => p.Category == "Electronics" && p.InStock);

//         var evenPositions = products.Where(
//             (p, index) => index % 2 == 0);

//         var twoWhere = products
//             .Where(p => p.Price < 1000)
//             .Where(p => p.InStock);

//         var oneWhere = products.Where(
//             p => p.Price < 1000 && p.InStock);

//         Print("Under Rs.500", under500);
//         Print("Electronics and In Stock", electronicsInStock);
//         Print("Even Positions", evenPositions);

//         Console.WriteLine("\nTwo Where calls:");
//         PrintProducts(twoWhere);

//         Console.WriteLine("\nOne Where with &&:");
//         PrintProducts(oneWhere);

//         Console.WriteLine(
//             $"\nResults identical: {twoWhere.SequenceEqual(oneWhere)}");
//     }

//     static void Print(string title, IEnumerable<Product> products)
//     {
//         Console.WriteLine($"\n{title} ({products.Count()}):");
//         PrintProducts(products);
//     }

//     static void PrintProducts(IEnumerable<Product> products)
//     {
//         foreach (var p in products)
//             Console.WriteLine(p);
//     }

//     static List<Product> GetProducts()
//     {
//         return new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899, InStock = true },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
//             new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7999, InStock = true },
//             new Product { Id = 4, Name = "Notebook", Category = "Stationery", Price = 150, InStock = true },
//             new Product { Id = 5, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
//             new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 1200, InStock = true },
//             new Product { Id = 7, Name = "Bottle", Category = "Accessories", Price = 700, InStock = false },
//             new Product { Id = 8, Name = "Headphones", Category = "Electronics", Price = 999, InStock = true },
//             new Product { Id = 9, Name = "Chair", Category = "Furniture", Price = 4500, InStock = true },
//             new Product { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 850, InStock = false },
//             new Product { Id = 11, Name = "Eraser", Category = "Stationery", Price = 30, InStock = true },
//             new Product { Id = 12, Name = "USB Cable", Category = "Electronics", Price = 299, InStock = true }
//         };
//     }
// }



// -------- Lab4 --------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public decimal Price { get; set; }
// }

// public class Shape
// {
// }

// public class Circle : Shape
// {
//     public double Radius { get; set; }
// }

// public class Rectangle : Shape
// {
//     public double Width { get; set; }
//     public double Height { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         List<object> objects = new List<object>
//         {
//             10,
//             "Hello",
//             20,
//             5.5,
//             new Product { Id = 1, Name = "Keyboard", Price = 899 },
//             new Product { Id = 2, Name = "Mouse", Price = 499 },
//             "World"
//         };

//         Console.WriteLine("Integers:");
//         foreach (var x in objects.OfType<int>())
//             Console.WriteLine(x);

//         Console.WriteLine("\nStrings:");
//         foreach (var x in objects.OfType<string>())
//             Console.WriteLine(x);

//         Console.WriteLine("\nProducts:");
//         foreach (var x in objects.OfType<Product>())
//             Console.WriteLine($"{x.Name}: Rs.{x.Price}");

//         List<Shape> shapes = new List<Shape>
//         {
//             new Circle { Radius = 5 },
//             new Rectangle { Width = 4, Height = 6 },
//             new Circle { Radius = 3 },
//             new Rectangle { Width = 2, Height = 8 }
//         };

//         double circleArea = shapes
//             .OfType<Circle>()
//             .Sum(c => Math.PI * c.Radius * c.Radius);

//         double rectangleArea = shapes
//             .OfType<Rectangle>()
//             .Sum(r => r.Width * r.Height);

//         Console.WriteLine($"\nTotal circle area: {circleArea:F2}");
//         Console.WriteLine($"Total rectangle area: {rectangleArea:F2}");

//         Console.WriteLine("\nOfType<Rectangle>:");
//         foreach (var r in shapes.OfType<Rectangle>())
//             Console.WriteLine($"{r.Width} x {r.Height}");

//         Console.WriteLine("\nCast<Rectangle>:");
//         try
//         {
//             foreach (var r in shapes.Cast<Rectangle>())
//                 Console.WriteLine($"{r.Width} x {r.Height}");
//         }
//         catch (InvalidCastException ex)
//         {
//             Console.WriteLine($"Caught: {ex.GetType().Name}");
//         }
//     }
// }



// ------ Lab5 --------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }

//     public override string ToString()
//     {
//         return $"{Category} | {Name} | Rs.{Price} | Stock: {InStock}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = GetProducts();

//         var bugVersion = products
//             .OrderBy(p => p.Category)
//             .OrderBy(p => p.Price);

//         var fixedVersion = products
//             .OrderBy(p => p.Category)
//             .ThenByDescending(p => p.Price);

//         var threeKeys = products
//             .OrderByDescending(p => p.InStock)
//             .ThenBy(p => p.Category)
//             .ThenBy(p => p.Name);

//         Console.WriteLine("BUG VERSION:");
//         Print(bugVersion);

//         Console.WriteLine("\nFIXED VERSION:");
//         Print(fixedVersion);

//         Console.WriteLine("\nTHREE-KEY SORT:");
//         Print(threeKeys);
//     }

//     static void Print(IEnumerable<Product> products)
//     {
//         foreach (var p in products)
//             Console.WriteLine(p);
//     }

//     static List<Product> GetProducts()
//     {
//         return new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899, InStock = true },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
//             new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7999, InStock = true },
//             new Product { Id = 4, Name = "Notebook", Category = "Stationery", Price = 150, InStock = true },
//             new Product { Id = 5, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
//             new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 1200, InStock = true },
//             new Product { Id = 7, Name = "Bottle", Category = "Accessories", Price = 700, InStock = false },
//             new Product { Id = 8, Name = "Headphones", Category = "Electronics", Price = 999, InStock = true },
//             new Product { Id = 9, Name = "Chair", Category = "Furniture", Price = 4500, InStock = true },
//             new Product { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 850, InStock = false },
//             new Product { Id = 11, Name = "Eraser", Category = "Stationery", Price = 30, InStock = true },
//             new Product { Id = 12, Name = "USB Cable", Category = "Electronics", Price = 299, InStock = true }
//         };
//     }
// }



// --------- Lab6 ----------

// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = GetProducts();

//         var groups = products.GroupBy(p => p.Category);

//         Console.WriteLine("Products per category:");

//         foreach (var group in groups)
//             Console.WriteLine($"{group.Key}: {group.Count()}");

//         var largeGroups =
//             from group in products.GroupBy(p => p.Category)
//             let total = group.Sum(p => p.Price)
//             where group.Count() >= 3
//             orderby total descending
//             select new
//             {
//                 Category = group.Key,
//                 Count = group.Count(),
//                 Total = total
//             };

//         Console.WriteLine("\nCategories with 3+ products:");

//         foreach (var group in largeGroups)
//             Console.WriteLine(
//                 $"{group.Category}: Count={group.Count}, Total=Rs.{group.Total:F2}");

//         Console.WriteLine("\nDetailed category report:");

//         foreach (var group in groups)
//         {
//             var expensive = group.OrderByDescending(p => p.Price).First();

//             Console.WriteLine(
//                 $"{group.Key}: " +
//                 $"Count={group.Count()}, " +
//                 $"Total=Rs.{group.Sum(p => p.Price):F2}, " +
//                 $"Average=Rs.{group.Average(p => p.Price):F2}, " +
//                 $"Most Expensive={expensive.Name}");
//         }

//         var compositeGroups = products.GroupBy(
//             p => new { p.Category, p.InStock });

//         Console.WriteLine("\nCategory + Stock groups:");

//         foreach (var group in compositeGroups)
//         {
//             Console.WriteLine(
//                 $"{group.Key.Category} | InStock={group.Key.InStock}: {group.Count()}");
//         }
//     }

//     static List<Product> GetProducts()
//     {
//         return new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899, InStock = true },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
//             new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7999, InStock = true },
//             new Product { Id = 4, Name = "Notebook", Category = "Stationery", Price = 150, InStock = true },
//             new Product { Id = 5, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
//             new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 1200, InStock = true },
//             new Product { Id = 7, Name = "Bottle", Category = "Accessories", Price = 700, InStock = false },
//             new Product { Id = 8, Name = "Headphones", Category = "Electronics", Price = 999, InStock = true },
//             new Product { Id = 9, Name = "Chair", Category = "Furniture", Price = 4500, InStock = true },
//             new Product { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 850, InStock = false },
//             new Product { Id = 11, Name = "Eraser", Category = "Stationery", Price = 30, InStock = true },
//             new Product { Id = 12, Name = "USB Cable", Category = "Electronics", Price = 299, InStock = true }
//         };
//     }
// }




// ------- Lab7 ---------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }

//     public override string ToString()
//     {
//         return $"{Name} - Rs.{Price}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899 },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499 }
//         };

//         Console.WriteLine("DEFERRED EXECUTION:");

//         var query = products.Where(p => p.Price < 1000);

//         Console.WriteLine("Query built.");

//         products.Add(new Product
//         {
//             Id = 3,
//             Name = "USB Cable",
//             Category = "Electronics",
//             Price = 299
//         });

//         Console.WriteLine("After adding new product:");

//         foreach (var p in query)
//             Console.WriteLine(p);

//         Console.WriteLine("\nIMMEDIATE EXECUTION WITH ToList():");

//         var snapshot = products
//             .Where(p => p.Price < 1000)
//             .ToList();

//         products.Add(new Product
//         {
//             Id = 4,
//             Name = "Headphones",
//             Category = "Electronics",
//             Price = 799
//         });

//         Console.WriteLine("Snapshot:");

//         foreach (var p in snapshot)
//             Console.WriteLine(p);

//         Console.WriteLine("\nDEFERRED QUERY ENUMERATED TWICE:");

//         var expensiveQuery = products.Where(p =>
//         {
//             Console.WriteLine($"Checking {p.Name}");
//             return p.Price > 500;
//         });

//         Console.WriteLine("\nFirst enumeration:");

//         foreach (var p in expensiveQuery)
//             Console.WriteLine($"Result: {p.Name}");

//         Console.WriteLine("\nSecond enumeration:");

//         foreach (var p in expensiveQuery)
//             Console.WriteLine($"Result: {p.Name}");

//         Console.WriteLine("\nMATERIALIZED QUERY:");

//         var materialized = products.Where(p =>
//         {
//             Console.WriteLine($"Checking {p.Name}");
//             return p.Price > 500;
//         }).ToList();

//         Console.WriteLine("\nFirst enumeration:");

//         foreach (var p in materialized)
//             Console.WriteLine($"Result: {p.Name}");

//         Console.WriteLine("\nSecond enumeration:");

//         foreach (var p in materialized)
//             Console.WriteLine($"Result: {p.Name}");
//     }
// }


// --------- Lab8 ---------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public string Category { get; set; } = "";
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }
// }

// public class CategorySummary
// {
//     public string Category { get; set; } = "";
//     public int ItemCount { get; set; }
//     public decimal TotalValue { get; set; }
//     public string TopProduct { get; set; } = "";
// }

// class Program
// {
//     static void Main()
//     {
//         List<Product> products = GetProducts();

//         var queryReport =
//             from categoryGroup in products
//                 .Where(p => p.InStock)
//                 .GroupBy(p => p.Category)
//             let ordered = categoryGroup
//                 .OrderByDescending(p => p.Price)
//                 .ToList()
//             let totalValue = categoryGroup.Sum(p => p.Price)
//             orderby totalValue descending
//             select new CategorySummary
//             {
//                 Category = categoryGroup.Key,
//                 ItemCount = categoryGroup.Count(),
//                 TotalValue = totalValue,
//                 TopProduct = ordered.First().Name
//             };

//         var methodReport = products
//             .Where(p => p.InStock)
//             .GroupBy(p => p.Category)
//             .Select(group =>
//             {
//                 var ordered = group
//                     .OrderByDescending(p => p.Price)
//                     .ToList();

//                 return new CategorySummary
//                 {
//                     Category = group.Key,
//                     ItemCount = group.Count(),
//                     TotalValue = group.Sum(p => p.Price),
//                     TopProduct = ordered.First().Name
//                 };
//             })
//             .OrderByDescending(x => x.TotalValue);

//         Console.WriteLine("QUERY SYNTAX REPORT");
//         PrintReport(queryReport);

//         Console.WriteLine("\nMETHOD SYNTAX REPORT");
//         PrintReport(methodReport);

//         bool matches = queryReport.Zip(
//             methodReport,
//             (a, b) =>
//                 a.Category == b.Category &&
//                 a.ItemCount == b.ItemCount &&
//                 a.TotalValue == b.TotalValue &&
//                 a.TopProduct == b.TopProduct
//         ).All(x => x);

//         Console.WriteLine($"\nReports match: {matches}");
//     }

//     static void PrintReport(IEnumerable<CategorySummary> report)
//     {
//         foreach (var category in report)
//         {
//             Console.WriteLine($"\nCategory: {category.Category}");
//             Console.WriteLine($"Items: {category.ItemCount}");
//             Console.WriteLine($"Total Value: Rs.{category.TotalValue:F2}");
//             Console.WriteLine($"Top Product: {category.TopProduct}");
//         }
//     }

//     static List<Product> GetProducts()
//     {
//         return new List<Product>
//         {
//             new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 899, InStock = true },
//             new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
//             new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 7999, InStock = true },
//             new Product { Id = 4, Name = "Notebook", Category = "Stationery", Price = 150, InStock = true },
//             new Product { Id = 5, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
//             new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 1200, InStock = true },
//             new Product { Id = 7, Name = "Bottle", Category = "Accessories", Price = 700, InStock = false },
//             new Product { Id = 8, Name = "Headphones", Category = "Electronics", Price = 999, InStock = true },
//             new Product { Id = 9, Name = "Chair", Category = "Furniture", Price = 4500, InStock = true },
//             new Product { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 850, InStock = false },
//             new Product { Id = 11, Name = "Eraser", Category = "Stationery", Price = 30, InStock = true },
//             new Product { Id = 12, Name = "USB Cable", Category = "Electronics", Price = 299, InStock = true }
//         };
//     }
// }