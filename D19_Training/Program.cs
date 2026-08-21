// -------- Lab1 ----------

// using System;
// class Program
// {
//     static void Main()
//     {
//         var count = 10;
//         int countExplicit = 10;
//         dynamic countDynamic = 10;

//         Console.WriteLine($"var: {count}, Type: {count.GetType()}");
//         Console.WriteLine($"explicit: {countExplicit}, Type: {countExplicit.GetType()}");
//         Console.WriteLine($"dynamic: {countDynamic}, Type: {countDynamic.GetType()}");

//         countDynamic = "now text";

//         try
//         {
//             Console.WriteLine(countDynamic + 5);
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Runtime error: {ex.GetType().Name} - {ex.Message}");
//         }

//         var point = new { X = 3, Y = 7 };

//         Console.WriteLine($"Point: X={point.X}, Y={point.Y}");
//     }
// }


// ---------- Lab2 -----------


// using System;
// using System.Collections.Generic;

// public delegate double Discount(double price);

// class Program
// {
//     static double NoDiscount(double price)
//     {
//         return price;
//     }

//     static double TenPercentOff(double price)
//     {
//         return price * 0.90;
//     }

//     static double HalfOff(double price)
//     {
//         return price * 0.50;
//     }

//     static double ApplyDiscount(double price, Discount discount)
//     {
//         return discount(price);
//     }

//     static void Main()
//     {
//         double price = 100;

//         Console.WriteLine($"No discount: {ApplyDiscount(price, NoDiscount):F2}");
//         Console.WriteLine($"10% off: {ApplyDiscount(price, TenPercentOff):F2}");
//         Console.WriteLine($"50% off: {ApplyDiscount(price, HalfOff):F2}");

//         List<Discount> discounts = new List<Discount>
//         {
//             NoDiscount,
//             TenPercentOff,
//             HalfOff
//         };

//         Console.WriteLine("\nUsing delegate list:");

//         foreach (Discount discount in discounts)
//         {
//             Console.WriteLine($"{discount(price):F2}");
//         }
//     }
// }



// ---------- Lab3 ---------


// using System;

// public delegate void OrderEvent(string orderId);

// class Program
// {
//     static void LogToConsole(string orderId)
//     {
//         Console.WriteLine($"Console log: Order {orderId}");
//     }

//     static void SendEmailSimulation(string orderId)
//     {
//         Console.WriteLine($"Email sent for order {orderId}");
//     }

//     static void UpdateInventorySimulation(string orderId)
//     {
//         Console.WriteLine($"Inventory updated for order {orderId}");
//     }

//     static void Main()
//     {
//         OrderEvent orderHandler = LogToConsole;
//         orderHandler += SendEmailSimulation;
//         orderHandler += UpdateInventorySimulation;

//         Console.WriteLine("-- All handlers --");
//         orderHandler("ORD-101");

//         orderHandler -= SendEmailSimulation;

//         Console.WriteLine("\n-- After removing email handler --");
//         orderHandler("ORD-102");

//         OrderEvent lambda1 = id => Console.WriteLine($"Lambda handler: {id}");
//         OrderEvent lambda2 = id => Console.WriteLine($"Lambda handler: {id}");

//         OrderEvent lambdaHandlers = lambda1;
//         lambdaHandlers += lambda2;

//         Console.WriteLine("\n-- Two identical-looking lambdas --");
//         lambdaHandlers("ORD-103");

//         lambdaHandlers -= id => Console.WriteLine($"Lambda handler: {id}");

//         Console.WriteLine("\n-- After trying to remove using a new lambda --");
//         lambdaHandlers("ORD-104");

//         lambdaHandlers -= lambda1;

//         Console.WriteLine("\n-- After removing the stored lambda reference --");
//         lambdaHandlers("ORD-105");
//     }
// }


// ------- Lab4 ----------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Repeat(int times, Action action)
//     {
//         for (int i = 0; i < times; i++)
//         {
//             action();
//         }
//     }

//     static bool IsPrime(int number)
//     {
//         if (number < 2)
//             return false;

//         for (int i = 2; i * i <= number; i++)
//         {
//             if (number % i == 0)
//                 return false;
//         }

//         return true;
//     }

//     static void Main()
//     {
//         Func<int, int, int> addition = (a, b) => a + b;
//         Func<int, int, int> multiplication = (a, b) => a * b;

//         Console.WriteLine($"Addition: {addition(5, 3)}");
//         Console.WriteLine($"Multiplication: {multiplication(5, 3)}");

//         Action<string> log = message =>
//         {
//             Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
//         };

//         log("Application started");

//         Predicate<int> primeCheck = IsPrime;

//         List<int> numbers = Enumerable.Range(1, 50).ToList();

//         List<int> primes = numbers.FindAll(primeCheck);

//         Console.WriteLine("\nPrime numbers:");
//         Console.WriteLine(string.Join(", ", primes));

//         Console.WriteLine("\nRepeat:");
//         Repeat(3, () => Console.WriteLine("Tick"));
//     }
// }


// ------- Lab5 ---------


// using System;

// class Program
// {
//     static void Main()
//     {
//         Action<int> square = delegate(int number)
//         {
//             Console.WriteLine($"Square: {number * number}");
//         };

//         square(5);

//         int total = 0;

//         Action<int> addToTotal = delegate(int number)
//         {
//             total += number;
//         };

//         for (int i = 1; i <= 5; i++)
//         {
//             addToTotal(i);
//         }

//         Console.WriteLine($"Total after anonymous method: {total}");

//         Action<int> squareLambda = number =>
//         {
//             Console.WriteLine($"Lambda square: {number * number}");
//         };

//         squareLambda(5);

//         int lambdaTotal = 0;

//         Action<int> addToLambdaTotal = number =>
//         {
//             lambdaTotal += number;
//         };

//         for (int i = 1; i <= 5; i++)
//         {
//             addToLambdaTotal(i);
//         }

//         Console.WriteLine($"Total after lambda: {lambdaTotal}");
//     }
// }


// --------- Lab6 ---------



// using System;
// using System.Collections.Generic;

// public class Product
// {
//     public string Name { get; set; }
//     public double Price { get; set; }
//     public bool InStock { get; set; }
//     public double DiscountPercent { get; set; }

//     public Product(string name, double price, bool inStock, double discountPercent)
//     {
//         Name = name;
//         Price = price;
//         InStock = inStock;
//         DiscountPercent = discountPercent;
//     }

//     public double DiscountedPrice =>
//         Price * (1 - DiscountPercent / 100);
// }

// public class Order
// {
//     public int Id { get; set; }
//     public string Customer { get; set; }
//     public double Amount { get; set; }

//     public Order(int id, string customer, double amount)
//     {
//         Id = id;
//         Customer = customer;
//         Amount = amount;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Func<double, double, double> rectangleArea =
//             (w, h) => w * h;

//         Console.WriteLine($"Rectangle area: {rectangleArea(5, 4)}");

//         Action<Order> printReceipt = order =>
//         {
//             Console.WriteLine("\n--- Receipt ---");
//             Console.WriteLine($"Order ID: {order.Id}");
//             Console.WriteLine($"Customer: {order.Customer}");
//             Console.WriteLine($"Amount: ${order.Amount:F2}");
//             Console.WriteLine("---------------");
//         };

//         printReceipt(new Order(101, "Alice", 249.99));

//         List<Product> products = new List<Product>
//         {
//             new Product("Laptop", 1000, true, 10),
//             new Product("Mouse", 50, true, 5),
//             new Product("Keyboard", 100, false, 20),
//             new Product("Monitor", 300, true, 15)
//         };

//         Console.WriteLine("\nOriginal:");
//         PrintProducts(products);

//         products.Sort((a, b) => a.Price.CompareTo(b.Price));

//         Console.WriteLine("\nPrice ascending:");
//         PrintProducts(products);

//         products.Sort((a, b) => string.Compare(b.Name, a.Name));

//         Console.WriteLine("\nName descending:");
//         PrintProducts(products);

//         products.Sort((a, b) =>
//             a.DiscountedPrice.CompareTo(b.DiscountedPrice));

//         Console.WriteLine("\nDiscounted price ascending:");
//         PrintProducts(products);

//         products.RemoveAll(product => !product.InStock);

//         Console.WriteLine("\nAfter removing out-of-stock products:");
//         PrintProducts(products);
//     }

//     static void PrintProducts(List<Product> products)
//     {
//         foreach (Product product in products)
//         {
//             Console.WriteLine(
//                 $"{product.Name}: ${product.Price:F2}, " +
//                 $"Discounted: ${product.DiscountedPrice:F2}, " +
//                 $"In Stock: {product.InStock}");
//         }
//     }
// }




// --------- Lab7 ----------


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("-- Incorrect for loop --");

//         List<Action> actions = new List<Action>();

//         for (int i = 0; i < 3; i++)
//         {
//             actions.Add(() => Console.WriteLine(i));
//         }

//         foreach (Action action in actions)
//         {
//             action();
//         }

//         Console.WriteLine("\n-- Fixed for loop --");

//         List<Action> fixedActions = new List<Action>();

//         for (int i = 0; i < 3; i++)
//         {
//             int copy = i;
//             fixedActions.Add(() => Console.WriteLine(copy));
//         }

//         foreach (Action action in fixedActions)
//         {
//             action();
//         }

//         Console.WriteLine("\n-- Foreach loop --");

//         List<Action> foreachActions = new List<Action>();

//         foreach (int number in new[] { 0, 1, 2 })
//         {
//             foreachActions.Add(() => Console.WriteLine(number));
//         }

//         foreach (Action action in foreachActions)
//         {
//             action();
//         }
//     }
// }


// -------- Lab8 ----------


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void ProcessBatch<T>(
//         List<T> items,
//         Action<T> onSuccess,
//         Action<T, string> onFailure,
//         Func<T, bool> validator)
//     {
//         foreach (T item in items)
//         {
//             if (validator(item))
//             {
//                 onSuccess(item);
//             }
//             else
//             {
//                 onFailure(item, "Validation failed");
//             }
//         }
//     }

//     static void Main()
//     {
//         List<int> numbers = new List<int>
//         {
//             10, -5, 20, -1, 30
//         };

//         Console.WriteLine("-- Integer batch --");

//         ProcessBatch(
//             numbers,
//             number => Console.WriteLine($"Success: {number}"),
//             (number, reason) =>
//                 Console.WriteLine($"Failure: {number} - {reason}"),
//             number => number >= 0
//         );

//         List<string> names = new List<string>
//         {
//             "Alice",
//             "",
//             "Bob",
//             "   ",
//             "Charlie"
//         };

//         Console.WriteLine("\n-- String batch --");

//         ProcessBatch(
//             names,
//             name => Console.WriteLine($"Success: {name}"),
//             (name, reason) =>
//                 Console.WriteLine($"Failure: '{name}' - {reason}"),
//             name => !string.IsNullOrWhiteSpace(name)
//         );
//     }
// }
