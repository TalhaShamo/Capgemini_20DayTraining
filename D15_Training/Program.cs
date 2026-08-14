// // using System;
// // using System.Collections.Generic;

// // public class Box<T>
// // {
// //     private T _value;

// //     public Box(T value)
// //     {
// //         _value = value;
// //     }

// //     public T GetValue()
// //     {
// //         return _value;
// //     }

// //     public void Replace(T newValue)
// //     {
// //         _value = newValue;
// //     }

// //     public static Box<T2> CreateEmpty<T2>() where T2 : new()
// //     {
// //         return new Box<T2>(new T2());
// //     }
// // }

// // public class Pair<TFirst, TSecond>
// // {
// //     public TFirst First { get; }
// //     public TSecond Second { get; }

// //     public Pair(TFirst first, TSecond second)
// //     {
// //         First = first;
// //         Second = second;
// //     }

// //     public override string ToString()
// //     {
// //         return $"({First}, {Second})";
// //     }
// // }

// // public class SortedBox<T> where T : IComparable<T>
// // {
// //     private List<T> items = new List<T>();

// //     public void Add(T item)
// //     {
// //         items.Add(item);
// //         items.Sort();
// //     }

// //     public List<T> GetItems()
// //     {
// //         return items;
// //     }
// // }

// // class Program
// // {
// //     static void Main()
// //     {
// //         Box<int> intBox = new Box<int>(42);
// //         Box<string> stringBox = new Box<string>("Hello");
// //         Box<DateTime> dateBox = new Box<DateTime>(
// //             new DateTime(2026, 8, 12)
// //         );

// //         Console.WriteLine($"Box<int>: {intBox.GetValue()}");
// //         Console.WriteLine($"Box<string>: {stringBox.GetValue()}");
// //         Console.WriteLine(
// //             $"Box<DateTime>: {dateBox.GetValue():yyyy-MM-dd}"
// //         );

// //         Pair<string, int> pair =
// //             new Pair<string, int>("Age", 30);

// //         Console.WriteLine($"Pair: {pair}");

// //         SortedBox<int> sortedBox = new SortedBox<int>();

// //         sortedBox.Add(5);
// //         sortedBox.Add(1);
// //         sortedBox.Add(3);

// //         Console.WriteLine(
// //             $"SortedBox after adding 5, 1, 3: " +
// //             $"{string.Join(", ", sortedBox.GetItems())}"
// //         );
// //     }
// // }

// using System;
// using System.Collections.Generic;

// public class Playlist
// {
//     private readonly List<string> _songs = new();

//     public void Add(string title) => _songs.Add(title);

//     public int Count => _songs.Count;

//     public string this[int index]
//     {
//         get => _songs[index];
//         set => _songs[index] = value;
//     }
// }

// public class TeamRoster
// {
//     private readonly Dictionary<string, int> _numbers = new();

//     public int this[string playerName]
//     {
//         get
//         {
//             if (_numbers.ContainsKey(playerName))
//                 return _numbers[playerName];

//             return -1;
//         }

//         set => _numbers[playerName] = value;
//     }
// }

// public class Matrix
// {
//     private readonly int[,] _cells;

//     public Matrix(int rows, int cols)
//     {
//         _cells = new int[rows, cols];
//     }

//     public int this[int row, int col]
//     {
//         get => _cells[row, col];
//         set => _cells[row, col] = value;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Playlist playlist = new Playlist();

//         playlist.Add("Song A");
//         playlist.Add("Song B");
//         playlist.Add("Song C");

//         playlist[1] = "Song B (Replaced)";

//         Console.Write("Playlist: ");

//         for (int i = 0; i < playlist.Count; i++)
//         {
//             if (i > 0)
//                 Console.Write(", ");

//             Console.Write(playlist[i]);
//         }

//         Console.WriteLine();

//         TeamRoster roster = new TeamRoster();

//         roster["Alice"] = 7;
//         roster["Bob"] = 10;

//         Console.WriteLine(
//             $"TeamRoster - Alice: {roster["Alice"]}"
//         );

//         Console.WriteLine(
//             $"TeamRoster - Zoe (not on roster): {roster["Zoe"]}"
//         );

//         Matrix matrix = new Matrix(3, 3);

//         matrix[0, 0] = 1;
//         matrix[0, 2] = 2;
//         matrix[1, 1] = 5;
//         matrix[2, 0] = 3;

//         Console.WriteLine("Matrix:");

//         for (int row = 0; row < 3; row++)
//         {
//             for (int col = 0; col < 3; col++)
//             {
//                 Console.Write(matrix[row, col]);

//                 if (col < 2)
//                     Console.Write(" ");
//             }

//             Console.WriteLine();
//         }
//     }
// }

// using System;

// public class Subscription
// {
//     public string Id { get; }

//     public string PlanName { get; set; } = string.Empty;

//     public DateTime StartedAt { get; init; }

//     public bool IsActive { get; private set; } = true;

//     public int MonthsActive =>
//         (DateTime.Now.Year - StartedAt.Year) * 12 +
//         DateTime.Now.Month - StartedAt.Month;

//     public Subscription(string id)
//     {
//         Id = id;
//     }

//     public void Cancel()
//     {
//         IsActive = false;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Subscription subscription = new Subscription("SUB-1")
//         {
//             PlanName = "Pro",
//             StartedAt = new DateTime(2026, 1, 1)
//         };

//         Console.WriteLine(
//             $"Id={subscription.Id}, " +
//             $"Plan={subscription.PlanName}, " +
//             $"Started={subscription.StartedAt:yyyy-MM-dd}, " +
//             $"Active={subscription.IsActive}, " +
//             $"MonthsActive={subscription.MonthsActive}"
//         );

//         subscription.Cancel();

//         Console.WriteLine(
//             $"After Cancel(): Active={subscription.IsActive}"
//         );
//     }
// }


// using System;

// public static class StringUtils
// {
//     public static bool IsPalindrome(string s)
//     {
//         string reversed = Reverse(s);

//         return s == reversed;
//     }

//     public static string Reverse(string s)
//     {
//         char[] chars = s.ToCharArray();

//         Array.Reverse(chars);

//         return new string(chars);
//     }

//     public static int WordCount(string s)
//     {
//         if (string.IsNullOrWhiteSpace(s))
//             return 0;

//         return s.Split(
//             ' ',
//             StringSplitOptions.RemoveEmptyEntries
//         ).Length;
//     }
// }

// public class TrackedWidget
// {
//     public Guid InstanceId { get; }

//     public static int LiveCount { get; private set; }

//     public TrackedWidget()
//     {
//         InstanceId = Guid.NewGuid();
//         LiveCount++;
//     }

//     public void Dispose()
//     {
//         LiveCount--;
//     }

//     public void PrintInfo()
//     {
//         Console.WriteLine(
//             $"Widget {InstanceId}: LiveCount={LiveCount}"
//         );
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine(
//             $"IsPalindrome(\"racecar\") -> " +
//             $"{StringUtils.IsPalindrome("racecar")}"
//         );

//         Console.WriteLine(
//             $"Reverse(\"Hello\") -> " +
//             $"{StringUtils.Reverse("Hello")}"
//         );

//         Console.WriteLine(
//             $"WordCount(\"the quick brown fox\") -> " +
//             $"{StringUtils.WordCount("the quick brown fox")}"
//         );

//         TrackedWidget widget1 = new TrackedWidget();
//         TrackedWidget widget2 = new TrackedWidget();
//         TrackedWidget widget3 = new TrackedWidget();

//         Console.WriteLine(
//             $"LiveCount after creating 3 widgets: " +
//             $"{TrackedWidget.LiveCount}"
//         );

//         widget1.PrintInfo();
//         widget2.PrintInfo();
//         widget3.PrintInfo();

//         widget1.Dispose();
//         widget2.Dispose();

//         Console.WriteLine(
//             $"LiveCount after disposing 2: " +
//             $"{TrackedWidget.LiveCount}"
//         );
//     }
// }


// using System;
// using System.Collections.Generic;

// public class Address
// {
//     public string Street { get; set; } = string.Empty;
//     public string City { get; set; } = string.Empty;
//     public string ZipCode { get; set; } = string.Empty;
// }

// public class Order
// {
//     public string OrderId { get; }

//     public Address? ShipTo { get; set; }

//     public List<string> Items { get; set; } = new();

//     public decimal Total { get; set; }

//     public Order(string orderId)
//     {
//         OrderId = orderId;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Order order1 = new Order("ORD-1")
//         {
//             ShipTo = new Address
//             {
//                 Street = "123 Main Street",
//                 City = "Springfield",
//                 ZipCode = "12345"
//             },

//             Items =
//             {
//                 "Keyboard",
//                 "Mouse"
//             },

//             Total = 59.98m
//         };

//         Console.WriteLine(
//             $"Order {order1.OrderId} ships to " +
//             $"{order1.ShipTo?.City} with " +
//             $"{order1.Items.Count} items, " +
//             $"Total=${order1.Total:F2}"
//         );

//         Order order2 = new Order("ORD-2");

//         if (order2.ShipTo == null)
//         {
//             Console.WriteLine(
//                 $"Order {order2.OrderId} has no shipping address " +
//                 $"set (ShipTo is null)"
//             );
//         }
//     }
// }