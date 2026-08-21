// // ------------- Lab 1 -------------
using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;

// class Program
// {
//     static void Main()
//     {
//         ArrayList arrayList = new ArrayList
//         {
//             10,
//             "twenty",
//             30.5,
//             true
//         };

//         double sum = 0;

//         foreach (object item in arrayList)
//         {
//             if (item is int intValue)
//                 sum += intValue;
//             else if (item is double doubleValue)
//                 sum += doubleValue;
//             else if (item is float floatValue)
//                 sum += floatValue;
//             else if (item is decimal decimalValue)
//                 sum += (double)decimalValue;
//         }

//         Console.WriteLine($"ArrayList numeric sum: {sum}");

//         List<int> numbers = new List<int>
//         {
//             10,
//             20,
//             30
//         };

//         int genericSum = 0;

//         foreach (int number in numbers)
//             genericSum += number;

//         Console.WriteLine($"List<int> sum: {genericSum}");

//         const int count = 2_000_000;

//         Stopwatch stopwatch = Stopwatch.StartNew();

//         ArrayList arrayListBenchmark = new ArrayList();

//         for (int i = 0; i < count; i++)
//             arrayListBenchmark.Add(i);

//         stopwatch.Stop();

//         Console.WriteLine($"ArrayList insertion time: {stopwatch.ElapsedMilliseconds} ms");

//         stopwatch.Restart();

//         List<int> listBenchmark = new List<int>();

//         for (int i = 0; i < count; i++)
//             listBenchmark.Add(i);

//         stopwatch.Stop();

//         Console.WriteLine($"List<int> insertion time: {stopwatch.ElapsedMilliseconds} ms");
//     }
// }

// //---- Lab 2 ------

// using System;
// using System.Collections.Generic;

// public class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public double Marks { get; set; }

//     public Student(int id, string name, double marks)
//     {
//         Id = id;
//         Name = name;
//         Marks = marks;
//     }

//     public override string ToString()
//     {
//         return $"ID: {Id}, Name: {Name}, Marks: {Marks:F2}";
//     }
// }

// public class ByNameComparer : IComparer<Student>
// {
//     public int Compare(Student x, Student y)
//     {
//         return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
//     }
// }

// public class StudentRoster
// {
//     private readonly List<Student> students = new List<Student>();

//     public void AddStudent(Student student)
//     {
//         students.Add(student);
//     }

//     public bool RemoveStudent(int id)
//     {
//         Student student = students.Find(s => s.Id == id);

//         if (student == null)
//             return false;

//         students.Remove(student);
//         return true;
//     }

//     public bool UpdateMarks(int id, double newMarks)
//     {
//         Student student = students.Find(s => s.Id == id);

//         if (student == null)
//             return false;

//         student.Marks = newMarks;
//         return true;
//     }

//     public Student GetTopStudent()
//     {
//         if (students.Count == 0)
//             return null;

//         Student top = students[0];

//         foreach (Student student in students)
//         {
//             if (student.Marks > top.Marks)
//                 top = student;
//         }

//         return top;
//     }

//     public void PrintRoster()
//     {
//         foreach (Student student in students)
//             Console.WriteLine(student);
//     }

//     public void SortByMarks()
//     {
//         students.Sort((a, b) => b.Marks.CompareTo(a.Marks));
//     }

//     public void SortByName()
//     {
//         students.Sort(new ByNameComparer());
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         StudentRoster roster = new StudentRoster();

//         roster.AddStudent(new Student(1, "Alice", 88.5));
//         roster.AddStudent(new Student(2, "Bob", 92.0));
//         roster.AddStudent(new Student(3, "Charlie", 76.5));
//         roster.AddStudent(new Student(4, "David", 92.0));

//         Console.WriteLine("Initial roster:");
//         roster.PrintRoster();

//         Console.WriteLine("\nAfter updating Charlie:");
//         roster.UpdateMarks(3, 95.0);
//         roster.PrintRoster();

//         Console.WriteLine("\nAfter removing Alice:");
//         roster.RemoveStudent(1);
//         roster.PrintRoster();

//         Student top = roster.GetTopStudent();

//         Console.WriteLine($"\nTop student: {top}");

//         Console.WriteLine("\nSorted by marks descending:");
//         roster.SortByMarks();
//         roster.PrintRoster();

//         Console.WriteLine("\nSorted by name ascending:");
//         roster.SortByName();
//         roster.PrintRoster();
//     }
// }


// ------- Lab 3 -------

// using System;
// using System.Collections.Generic;

// public class InsufficientStockException : Exception
// {
//     public InsufficientStockException(string message) : base(message)
//     {
//     }
// }

// public class Inventory
// {
//     private readonly Dictionary<string, int> stock = new Dictionary<string, int>();

//     public void RestockItem(string sku, int quantity)
//     {
//         if (quantity <= 0)
//             throw new ArgumentException("Restock quantity must be greater than zero.");

//         if (stock.TryGetValue(sku, out int currentQuantity))
//             stock[sku] = currentQuantity + quantity;
//         else
//             stock[sku] = quantity;
//     }

//     public void SellItem(string sku, int quantity)
//     {
//         if (!stock.TryGetValue(sku, out int currentQuantity))
//             throw new KeyNotFoundException($"SKU '{sku}' was not found.");

//         if (quantity <= 0)
//             throw new ArgumentException("Sale quantity must be greater than zero.");

//         if (quantity > currentQuantity)
//             throw new InsufficientStockException(
//                 $"Not enough stock for {sku}. Available: {currentQuantity}, Requested: {quantity}");

//         stock[sku] = currentQuantity - quantity;
//     }

//     public List<string> LowStockReport(int threshold)
//     {
//         List<string> result = new List<string>();

//         foreach (KeyValuePair<string, int> item in stock)
//         {
//             if (item.Value < threshold)
//                 result.Add($"{item.Key}: {item.Value}");
//         }

//         return result;
//     }

//     public void PrintInventory()
//     {
//         foreach (KeyValuePair<string, int> item in stock)
//             Console.WriteLine($"{item.Key}: {item.Value}");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Inventory inventory = new Inventory();

//         inventory.RestockItem("SKU001", 20);
//         inventory.RestockItem("SKU002", 5);
//         inventory.RestockItem("SKU003", 15);
//         inventory.RestockItem("SKU004", 3);
//         inventory.RestockItem("SKU005", 30);
//         inventory.RestockItem("SKU006", 8);
//         inventory.RestockItem("SKU007", 2);
//         inventory.RestockItem("SKU008", 12);

//         Console.WriteLine("Initial inventory:");
//         inventory.PrintInventory();

//         Console.WriteLine("\nRestocking SKU002 by 10:");
//         inventory.RestockItem("SKU002", 10);
//         inventory.PrintInventory();

//         Console.WriteLine("\nSelling 5 units of SKU001:");
//         inventory.SellItem("SKU001", 5);
//         inventory.PrintInventory();

//         Console.WriteLine("\nAttempting to oversell SKU004:");

//         try
//         {
//             inventory.SellItem("SKU004", 10);
//         }
//         catch (InsufficientStockException ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }

//         Console.WriteLine("\nLow-stock items:");

//         List<string> lowStock = inventory.LowStockReport(6);

//         foreach (string item in lowStock)
//             Console.WriteLine(item);

//         Console.WriteLine("\nAttempting to sell unknown SKU:");

//         try
//         {
//             inventory.SellItem("UNKNOWN", 1);
//         }
//         catch (KeyNotFoundException ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//     }
// }


// // ------- Lab 4 --------



// using System;
// using System.Collections.Generic;

// public class PrintJob
// {
//     public string DocumentName { get; set; }
//     public int Pages { get; set; }

//     public PrintJob(string documentName, int pages)
//     {
//         DocumentName = documentName;
//         Pages = pages;
//     }
// }

// class Program
// {
//     static bool IsBalanced(string expression)
//     {
//         Stack<char> stack = new Stack<char>();

//         foreach (char character in expression)
//         {
//             if (character == '(' || character == '{' || character == '[')
//             {
//                 stack.Push(character);
//             }
//             else if (character == ')' || character == '}' || character == ']')
//             {
//                 if (stack.Count == 0)
//                     return false;

//                 char opening = stack.Pop();

//                 if (character == ')' && opening != '(')
//                     return false;

//                 if (character == '}' && opening != '{')
//                     return false;

//                 if (character == ']' && opening != '[')
//                     return false;
//             }
//         }

//         return stack.Count == 0;
//     }

//     static void ProcessPrintQueue(
//         Queue<PrintJob> normalQueue,
//         Queue<PrintJob> priorityQueue)
//     {
//         while (priorityQueue.Count > 0 || normalQueue.Count > 0)
//         {
//             Queue<PrintJob> currentQueue =
//                 priorityQueue.Count > 0 ? priorityQueue : normalQueue;

//             PrintJob next = currentQueue.Peek();

//             Console.WriteLine(
//                 $"Now printing next: {next.DocumentName} ({next.Pages} pages)");

//             PrintJob job = currentQueue.Dequeue();

//             Console.WriteLine(
//                 $"Printing {job.DocumentName} ({job.Pages} pages)...");
//         }
//     }

//     static void Main()
//     {
//         Console.WriteLine("Balanced Parentheses:");

//         string expression1 = "{[a+(b*c)]-d}";
//         string expression2 = "{[(a+b]}";

//         Console.WriteLine($"{expression1}: {IsBalanced(expression1)}");
//         Console.WriteLine($"{expression2}: {IsBalanced(expression2)}");

//         Console.WriteLine("\nPrint Queue:");

//         Queue<PrintJob> normalQueue = new Queue<PrintJob>();
//         Queue<PrintJob> priorityQueue = new Queue<PrintJob>();

//         normalQueue.Enqueue(new PrintJob("Document1.pdf", 5));
//         normalQueue.Enqueue(new PrintJob("Document2.pdf", 10));
//         normalQueue.Enqueue(new PrintJob("Document3.pdf", 3));
//         normalQueue.Enqueue(new PrintJob("Document4.pdf", 8));
//         normalQueue.Enqueue(new PrintJob("Document5.pdf", 2));

//         priorityQueue.Enqueue(new PrintJob("Urgent.pdf", 1));

//         ProcessPrintQueue(normalQueue, priorityQueue);
//     }
// }


// // ------ Lab 5 ------

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         HashSet<string> newsletterSubscribers = new HashSet<string>
//         {
//             "alice@example.com",
//             "bob@example.com",
//             "charlie@example.com",
//             "david@example.com",
//             "eve@example.com"
//         };

//         HashSet<string> appUsers = new HashSet<string>
//         {
//             "bob@example.com",
//             "charlie@example.com",
//             "eve@example.com",
//             "frank@example.com",
//             "grace@example.com"
//         };

//         HashSet<string> both = new HashSet<string>(newsletterSubscribers);
//         both.IntersectWith(appUsers);

//         HashSet<string> subscribersOnly = new HashSet<string>(newsletterSubscribers);
//         subscribersOnly.ExceptWith(appUsers);

//         HashSet<string> allCustomers = new HashSet<string>(newsletterSubscribers);
//         allCustomers.UnionWith(appUsers);

//         bool isSubset = newsletterSubscribers.IsSubsetOf(appUsers);

//         Console.WriteLine("Both subscribers and app users:");

//         foreach (string email in both)
//             Console.WriteLine(email);

//         Console.WriteLine("\nSubscribers but not app users:");

//         foreach (string email in subscribersOnly)
//             Console.WriteLine(email);

//         Console.WriteLine("\nAll unique customers:");

//         foreach (string email in allCustomers)
//             Console.WriteLine(email);

//         Console.WriteLine(
//             $"\nNewsletter subscribers are subset of app users: {isSubset}");

//         List<string> emails = new List<string>();

//         for (int i = 0; i < 100; i++)
//         {
//             emails.Add($"customer{i % 70}@example.com");
//         }

//         HashSet<string> uniqueEmails = new HashSet<string>(emails);

//         int duplicatesRemoved = emails.Count - uniqueEmails.Count;

//         Console.WriteLine($"\nOriginal email count: {emails.Count}");
//         Console.WriteLine($"Unique email count: {uniqueEmails.Count}");
//         Console.WriteLine($"Duplicates removed: {duplicatesRemoved}");
//     }
// }


// // ------- Lab 6 ---------



using System;
using System.Collections.Generic;

public static class GenericMethods
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public static bool AllMatch<T>(
        IEnumerable<T> items,
        Func<T, bool> predicate)
    {
        foreach (T item in items)
        {
            if (!predicate(item))
                return false;
        }

        return true;
    }
}

public class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return $"({First}, {Second})";
    }
}

public class MinMaxTracker<T> where T : IComparable<T>
{
    public T Min { get; private set; }
    public T Max { get; private set; }

    private bool hasValue;

    public void Add(T value)
    {
        if (!hasValue)
        {
            Min = value;
            Max = value;
            hasValue = true;
            return;
        }

        if (value.CompareTo(Min) < 0)
            Min = value;

        if (value.CompareTo(Max) > 0)
            Max = value;
    }
}

public class Product : IComparable<Product>
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public int CompareTo(Product other)
    {
        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"{Name}: ${Price:F2}";
    }
}

class Program
{
    static void Main()
    {
        int a = 10;
        int b = 20;

        GenericMethods.Swap(ref a, ref b);

        Console.WriteLine($"Swapped integers: {a}, {b}");

        string first = "Hello";
        string second = "World";

        GenericMethods.Swap(ref first, ref second);

        Console.WriteLine($"Swapped strings: {first}, {second}");

        Pair<int, string> pair1 = new Pair<int, string>(1, "One");
        Pair<string, double> pair2 = new Pair<string, double>("Price", 99.99);

        Console.WriteLine($"Pair 1: {pair1}");
        Console.WriteLine($"Pair 2: {pair2}");

        MinMaxTracker<int> intTracker = new MinMaxTracker<int>();

        intTracker.Add(10);
        intTracker.Add(3);
        intTracker.Add(25);
        intTracker.Add(7);

        Console.WriteLine(
            $"Integer Min: {intTracker.Min}, Max: {intTracker.Max}");

        MinMaxTracker<Product> productTracker =
            new MinMaxTracker<Product>();

        productTracker.Add(new Product("Keyboard", 45));
        productTracker.Add(new Product("Mouse", 25));
        productTracker.Add(new Product("Monitor", 200));

        Console.WriteLine($"Product Min: {productTracker.Min}");
        Console.WriteLine($"Product Max: {productTracker.Max}");

        List<int> numbers = new List<int> { 2, 4, 6, 8 };

        bool allEven = GenericMethods.AllMatch(
            numbers,
            number => number % 2 == 0);

        Console.WriteLine($"All numbers even: {allEven}");

        List<Product> products = new List<Product>
        {
            new Product("Keyboard", 45),
            new Product("Mouse", 25)
        };

        bool allAffordable = GenericMethods.AllMatch(
            products,
            product => product.Price < 100);

        Console.WriteLine($"All products under $100: {allAffordable}");
    }
}


// //-------- Lab 7 ----------


// using System;
// using System.Collections;
// using System.Collections.Generic;

// public class FixedSizeStack<T> : IReadOnlyCollection<T>
// {
//     private readonly T[] items;
//     private int count;

//     public int Count => count;

//     public FixedSizeStack(int capacity)
//     {
//         if (capacity <= 0)
//             throw new ArgumentException("Capacity must be greater than zero.");

//         items = new T[capacity];
//     }

//     public void Push(T item)
//     {
//         if (count == items.Length)
//             throw new InvalidOperationException("Stack is full.");

//         items[count] = item;
//         count++;
//     }

//     public T Pop()
//     {
//         if (count == 0)
//             throw new InvalidOperationException("Stack is empty.");

//         count--;

//         T item = items[count];
//         items[count] = default;

//         return item;
//     }

//     public T Peek()
//     {
//         if (count == 0)
//             throw new InvalidOperationException("Stack is empty.");

//         return items[count - 1];
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         for (int i = count - 1; i >= 0; i--)
//             yield return items[i];
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// public static class StackExtensions
// {
//     public static FixedSizeStack<T> ToFixedSizeStack<T>(
//         this IEnumerable<T> source,
//         int capacity)
//     {
//         FixedSizeStack<T> stack = new FixedSizeStack<T>(capacity);

//         foreach (T item in source)
//             stack.Push(item);

//         return stack;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         FixedSizeStack<int> stack = new FixedSizeStack<int>(3);

//         stack.Push(10);
//         stack.Push(20);
//         stack.Push(30);

//         Console.WriteLine("Stack contents:");

//         foreach (int item in stack)
//             Console.WriteLine(item);

//         Console.WriteLine($"\nPeek: {stack.Peek()}");
//         Console.WriteLine($"Pop: {stack.Pop()}");
//         Console.WriteLine($"Count after pop: {stack.Count}");

//         try
//         {
//             stack.Push(40);
//             stack.Push(50);
//             stack.Push(60);
//             stack.Push(70);
//         }
//         catch (InvalidOperationException ex)
//         {
//             Console.WriteLine($"Push error: {ex.Message}");
//         }

//         while (stack.Count > 0)
//             stack.Pop();

//         try
//         {
//             stack.Pop();
//         }
//         catch (InvalidOperationException ex)
//         {
//             Console.WriteLine($"Pop error: {ex.Message}");
//         }

//         try
//         {
//             stack.Peek();
//         }
//         catch (InvalidOperationException ex)
//         {
//             Console.WriteLine($"Peek error: {ex.Message}");
//         }

//         List<string> words = new List<string>
//         {
//             "Apple",
//             "Banana",
//             "Cherry"
//         };

//         FixedSizeStack<string> stringStack =
//             words.ToFixedSizeStack(3);

//         Console.WriteLine("\nString stack:");

//         foreach (string word in stringStack)
//             Console.WriteLine(word);
//     }
// }

