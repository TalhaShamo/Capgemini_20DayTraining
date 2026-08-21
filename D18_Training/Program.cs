// --------- Lab 1 ------------


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static (double Average, double Min, double Max) GetStats(IEnumerable<double> values)
//     {
//         double sum = 0;
//         double min = double.MaxValue;
//         double max = double.MinValue;
//         int count = 0;

//         foreach (double value in values)
//         {
//             sum += value;
//             count++;

//             if (value < min)
//                 min = value;

//             if (value > max)
//                 max = value;
//         }

//         return (sum / count, min, max);
//     }

//     static (bool Success, string? ErrorMessage) TryParseAge(string input)
//     {
//         if (!int.TryParse(input, out int age))
//             return (false, "Input is not a valid number");

//         if (age < 0 || age > 150)
//             return (false, "Age must be between 0 and 150");

//         return (true, null);
//     }

//     static void Main()
//     {
//         double[] numbers = { 10, 20, 30, 40, 50 };

//         var stats = GetStats(numbers);

//         Console.WriteLine("Statistics:");
//         Console.WriteLine($"Average: {stats.Average}");
//         Console.WriteLine($"Minimum: {stats.Min}");
//         Console.WriteLine($"Maximum: {stats.Max}");

//         var (avg, min, max) = GetStats(numbers);

//         Console.WriteLine("\nUsing deconstruction:");
//         Console.WriteLine($"Average = {avg}");
//         Console.WriteLine($"Min = {min}");
//         Console.WriteLine($"Max = {max}");

//         var validAge = TryParseAge("25");
//         var invalidAge = TryParseAge("abc");

//         Console.WriteLine("\nTryParseAge:");
//         Console.WriteLine($"25 -> Success={validAge.Success}, Error={validAge.ErrorMessage}");
//         Console.WriteLine($"abc -> Success={invalidAge.Success}, Error={invalidAge.ErrorMessage}");

//         Dictionary<(int Row, int Col), string> board =
//             new Dictionary<(int Row, int Col), string>();

//         board[(0, 0)] = "X";
//         board[(1, 1)] = "O";
//         board[(2, 2)] = "X";

//         Console.WriteLine("\nTic-Tac-Toe Board:");

//         for (int row = 0; row < 3; row++)
//         {
//             for (int col = 0; col < 3; col++)
//             {
//                 if (board.TryGetValue((row, col), out string? value))
//                     Console.Write(value + " ");
//                 else
//                     Console.Write("- ");
//             }

//             Console.WriteLine();
//         }
//     }
// }


// ------- Lab 2 ---------

// using System;
// using System.Collections.Generic;

// public class UndoManager
// {
//     private Stack<string> actions = new Stack<string>();

//     public void RecordAction(string action)
//     {
//         actions.Push(action);
//     }

//     public string? Undo()
//     {
//         if (actions.Count == 0)
//             return null;

//         return actions.Pop();
//     }
// }

// public class TicketQueue
// {
//     private Queue<string> tickets = new Queue<string>();

//     public void SubmitTicket(string ticketId)
//     {
//         tickets.Enqueue(ticketId);
//     }

//     public string? ProcessNext()
//     {
//         if (tickets.Count == 0)
//             return null;

//         return tickets.Dequeue();
//     }
// }

// public class DailyVisitorTracker
// {
//     private HashSet<int> visitors = new HashSet<int>();

//     public void RecordVisit(int userId)
//     {
//         visitors.Add(userId);
//     }

//     public int UniqueVisitorCount()
//     {
//         return visitors.Count;
//     }
// }

// public class Playlist
// {
//     private LinkedList<string> songs = new LinkedList<string>();

//     public void Add(string song)
//     {
//         songs.AddLast(song);
//     }

//     public void InsertAfter(string afterSong, string newSong)
//     {
//         LinkedListNode<string>? node = songs.Find(afterSong);

//         if (node == null)
//             return;

//         songs.AddAfter(node, newSong);
//     }

//     public void Remove(string song)
//     {
//         songs.Remove(song);
//     }

//     public void Print()
//     {
//         foreach (string song in songs)
//             Console.WriteLine(song);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("UNDO STACK");

//         UndoManager undo = new UndoManager();

//         undo.RecordAction("Typed Hello");
//         undo.RecordAction("Typed World");
//         undo.RecordAction("Deleted World");

//         Console.WriteLine("Undo: " + undo.Undo());
//         Console.WriteLine("Undo: " + undo.Undo());

//         Console.WriteLine("\nCUSTOMER SUPPORT QUEUE");

//         TicketQueue tickets = new TicketQueue();

//         tickets.SubmitTicket("T001");
//         tickets.SubmitTicket("T002");
//         tickets.SubmitTicket("T003");

//         Console.WriteLine("Processing: " + tickets.ProcessNext());
//         Console.WriteLine("Processing: " + tickets.ProcessNext());

//         Console.WriteLine("\nUNIQUE VISITORS");

//         DailyVisitorTracker visitors = new DailyVisitorTracker();

//         visitors.RecordVisit(101);
//         visitors.RecordVisit(102);
//         visitors.RecordVisit(101);
//         visitors.RecordVisit(103);

//         Console.WriteLine("Unique visitors: " + visitors.UniqueVisitorCount());

//         Console.WriteLine("\nPLAYLIST");

//         Playlist playlist = new Playlist();

//         playlist.Add("Song A");
//         playlist.Add("Song B");
//         playlist.Add("Song D");

//         playlist.InsertAfter("Song B", "Song C");
//         playlist.Remove("Song A");

//         playlist.Print();
//     }
// }


// ------ Lab3 ---------


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static List<string> BreadthFirstSearch(
//         Dictionary<string, List<string>> graph,
//         string start)
//     {
//         Queue<string> queue = new Queue<string>();
//         HashSet<string> visited = new HashSet<string>();
//         List<string> result = new List<string>();

//         queue.Enqueue(start);
//         visited.Add(start);

//         while (queue.Count > 0)
//         {
//             string current = queue.Dequeue();
//             result.Add(current);

//             foreach (string neighbour in graph[current])
//             {
//                 if (!visited.Contains(neighbour))
//                 {
//                     visited.Add(neighbour);
//                     queue.Enqueue(neighbour);
//                 }
//             }
//         }

//         return result;
//     }

//     static List<string> DepthFirstSearch(
//         Dictionary<string, List<string>> graph,
//         string start)
//     {
//         Stack<string> stack = new Stack<string>();
//         HashSet<string> visited = new HashSet<string>();
//         List<string> result = new List<string>();

//         stack.Push(start);

//         while (stack.Count > 0)
//         {
//             string current = stack.Pop();

//             if (visited.Contains(current))
//                 continue;

//             visited.Add(current);
//             result.Add(current);

//             List<string> neighbours = graph[current];

//             for (int i = neighbours.Count - 1; i >= 0; i--)
//             {
//                 if (!visited.Contains(neighbours[i]))
//                     stack.Push(neighbours[i]);
//             }
//         }

//         return result;
//     }

//     static void Main()
//     {
//         Dictionary<string, List<string>> graph =
//             new Dictionary<string, List<string>>
//             {
//                 { "A", new List<string> { "B", "C" } },
//                 { "B", new List<string> { "D" } },
//                 { "C", new List<string> { "D" } },
//                 { "D", new List<string> { "E" } },
//                 { "E", new List<string>() }
//             };

//         List<string> bfs = BreadthFirstSearch(graph, "A");
//         List<string> dfs = DepthFirstSearch(graph, "A");

//         Console.WriteLine("BFS:");
//         Console.WriteLine(string.Join(" -> ", bfs));

//         Console.WriteLine("\nDFS:");
//         Console.WriteLine(string.Join(" -> ", dfs));
//     }
// }


// --------- Lab4 -----------

using System;
using System.Collections.Generic;

class Program
{
    static T[] Snapshot<T>(ICollection<T> source)
    {
        T[] result = new T[source.Count];
        source.CopyTo(result, 0);
        return result;
    }

    static bool TryAddAll<T>(
        ICollection<T> target,
        IEnumerable<T> items)
    {
        if (target.IsReadOnly)
            return false;

        foreach (T item in items)
            target.Add(item);

        return true;
    }

    static void PrintCollection<T>(ICollection<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
    }

    static void Main()
    {
        List<int> list = new List<int> { 1, 2, 3 };

        HashSet<int> set = new HashSet<int> { 1, 2, 3 };

        LinkedList<int> linkedList =
            new LinkedList<int>(new[] { 1, 2, 3 });

        int[] extra = { 4, 5 };

        Console.WriteLine("LIST");

        Console.WriteLine(
            "TryAddAll: " + TryAddAll(list, extra));

        PrintCollection(list);

        Console.WriteLine(
            "Snapshot: " + string.Join(", ", Snapshot(list)));

        Console.WriteLine("\nHASHSET");

        Console.WriteLine(
            "TryAddAll: " + TryAddAll(set, extra));

        PrintCollection(set);

        Console.WriteLine(
            "Snapshot: " + string.Join(", ", Snapshot(set)));

        Console.WriteLine("\nLINKEDLIST");

        Console.WriteLine(
            "TryAddAll: " + TryAddAll(linkedList, extra));

        PrintCollection(linkedList);

        Console.WriteLine(
            "Snapshot: " + string.Join(", ", Snapshot(linkedList)));

        Console.WriteLine("\nREAD-ONLY COLLECTION");

        List<int> original = new List<int> { 1, 2, 3 };

        ICollection<int> readOnly =
            Array.AsReadOnly(original.ToArray());

        bool result = TryAddAll(readOnly, new[] { 4, 5 });

        Console.WriteLine("TryAddAll result: " + result);
        Console.WriteLine("Count: " + readOnly.Count);
    }
}


// -------- Lab 5 ------------

// using System;
// using System.Collections;
// using System.Collections.Generic;

// public class MyList<T> : IEnumerable<T>
// {
//     private T[] items;
//     private int count;

//     public int Count => count;

//     public MyList(int capacity = 4)
//     {
//         if (capacity < 1)
//             capacity = 1;

//         items = new T[capacity];
//     }

//     public void Add(T item)
//     {
//         if (count == items.Length)
//         {
//             T[] newItems = new T[items.Length * 2];

//             Array.Copy(items, newItems, count);

//             items = newItems;
//         }

//         items[count] = item;
//         count++;
//     }

//     public void RemoveAt(int index)
//     {
//         if (index < 0 || index >= count)
//             throw new ArgumentOutOfRangeException(nameof(index));

//         for (int i = index; i < count - 1; i++)
//             items[i] = items[i + 1];

//         items[count - 1] = default!;
//         count--;
//     }

//     public T this[int index]
//     {
//         get
//         {
//             if (index < 0 || index >= count)
//                 throw new ArgumentOutOfRangeException(nameof(index));

//             return items[index];
//         }

//         set
//         {
//             if (index < 0 || index >= count)
//                 throw new ArgumentOutOfRangeException(nameof(index));

//             items[index] = value;
//         }
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         for (int i = 0; i < count; i++)
//             yield return items[i];
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// public class Product
// {
//     public string Name { get; set; }

//     public Product(string name)
//     {
//         Name = name;
//     }

//     public override string ToString()
//     {
//         return Name;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         MyList<int> numbers = new MyList<int>();

//         numbers.Add(10);
//         numbers.Add(20);
//         numbers.Add(30);

//         Console.WriteLine("Integers:");

//         foreach (int number in numbers)
//             Console.WriteLine(number);

//         numbers[1] = 25;

//         Console.WriteLine("\nAfter changing index 1:");
//         Console.WriteLine(numbers[1]);

//         numbers.RemoveAt(0);

//         Console.WriteLine("\nAfter RemoveAt(0):");

//         foreach (int number in numbers)
//             Console.WriteLine(number);

//         MyList<int> initialized = new MyList<int>
//         {
//             1,
//             2,
//             3
//         };

//         Console.WriteLine("\nCollection initializer:");

//         foreach (int number in initialized)
//             Console.WriteLine(number);

//         MyList<Product> products = new MyList<Product>();

//         products.Add(new Product("Keyboard"));
//         products.Add(new Product("Mouse"));
//         products.Add(new Product("Monitor"));

//         Console.WriteLine("\nProducts:");

//         foreach (Product product in products)
//             Console.WriteLine(product);

//         try
//         {
//             Console.WriteLine("\nAccessing invalid index:");
//             Console.WriteLine(numbers[100]);
//         }
//         catch (ArgumentOutOfRangeException ex)
//         {
//             Console.WriteLine("Caught: " + ex.GetType().Name);
//         }
//     }
// }


// -------- Lab 6 ---------------


// using System;
// using System.Collections;
// using System.Collections.Generic;

// public class MyDictionary<TKey, TValue> :
//     IEnumerable<KeyValuePair<TKey, TValue>>
//     where TKey : notnull
// {
//     private class Entry
//     {
//         public TKey Key;
//         public TValue Value;
//         public Entry? Next;

//         public Entry(TKey key, TValue value)
//         {
//             Key = key;
//             Value = value;
//         }
//     }

//     private readonly Entry?[] buckets;

//     public MyDictionary(int bucketCount = 5)
//     {
//         buckets = new Entry[bucketCount];
//     }

//     private int GetBucketIndex(TKey key)
//     {
//         return (key.GetHashCode() & 0x7FFFFFFF) % buckets.Length;
//     }

//     public void Add(TKey key, TValue value)
//     {
//         int index = GetBucketIndex(key);

//         Entry? current = buckets[index];

//         while (current != null)
//         {
//             if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
//                 throw new ArgumentException("An item with the same key already exists.");

//             current = current.Next;
//         }

//         Entry entry = new Entry(key, value);

//         entry.Next = buckets[index];
//         buckets[index] = entry;
//     }

//     public TValue this[TKey key]
//     {
//         get
//         {
//             if (TryGetValue(key, out TValue? value))
//                 return value;

//             throw new KeyNotFoundException(
//                 $"Key '{key}' was not found.");
//         }

//         set
//         {
//             int index = GetBucketIndex(key);

//             Entry? current = buckets[index];

//             while (current != null)
//             {
//                 if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
//                 {
//                     current.Value = value;
//                     return;
//                 }

//                 current = current.Next;
//             }

//             Entry entry = new Entry(key, value);

//             entry.Next = buckets[index];
//             buckets[index] = entry;
//         }
//     }

//     public bool TryGetValue(TKey key, out TValue value)
//     {
//         int index = GetBucketIndex(key);

//         Entry? current = buckets[index];

//         while (current != null)
//         {
//             if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
//             {
//                 value = current.Value;
//                 return true;
//             }

//             current = current.Next;
//         }

//         value = default!;
//         return false;
//     }

//     public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
//     {
//         foreach (Entry? bucket in buckets)
//         {
//             Entry? current = bucket;

//             while (current != null)
//             {
//                 yield return new KeyValuePair<TKey, TValue>(
//                     current.Key,
//                     current.Value);

//                 current = current.Next;
//             }
//         }
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         MyDictionary<int, string> mine =
//             new MyDictionary<int, string>(5);

//         Dictionary<int, string> builtIn =
//             new Dictionary<int, string>();

//         for (int i = 1; i <= 20; i++)
//         {
//             mine.Add(i, "Value " + i);
//             builtIn.Add(i, "Value " + i);
//         }

//         Console.WriteLine("MyDictionary:");

//         foreach (KeyValuePair<int, string> pair in mine)
//             Console.WriteLine($"{pair.Key} = {pair.Value}");

//         bool correct = true;

//         foreach (KeyValuePair<int, string> pair in builtIn)
//         {
//             if (!mine.TryGetValue(pair.Key, out string? value) ||
//                 value != pair.Value)
//             {
//                 correct = false;
//                 break;
//             }
//         }

//         Console.WriteLine("\nCorrectness check: " + correct);

//         Console.WriteLine("\nIndexer:");

//         Console.WriteLine(mine[10]);

//         mine[10] = "Updated";

//         Console.WriteLine(mine[10]);

//         MyDictionary<int, string> initialized =
//             new MyDictionary<int, string>(5)
//             {
//                 [1] = "One",
//                 [2] = "Two",
//                 [3] = "Three"
//             };

//         Console.WriteLine("\nIndex initializer:");

//         foreach (KeyValuePair<int, string> pair in initialized)
//             Console.WriteLine($"{pair.Key} = {pair.Value}");

//         try
//         {
//             Console.WriteLine(mine[999]);
//         }
//         catch (KeyNotFoundException ex)
//         {
//             Console.WriteLine("\nCaught: " + ex.Message);
//         }
//     }
// }


// --------- lab7 ----------


// using System;
// using System.Collections.Generic;

// public interface IEntity
// {
//     int Id { get; }
// }

// public interface IRepository<T>
//     where T : class
// {
//     void Add(T item);
//     T? GetById(int id);
//     IEnumerable<T> GetAll();
// }

// public class MyEntity : IEntity
// {
//     public int Id { get; }
//     public string Name { get; }

//     public MyEntity(int id, string name)
//     {
//         Id = id;
//         Name = name;
//     }

//     public override string ToString()
//     {
//         return $"{Id}: {Name}";
//     }
// }

// public class InMemoryRepository<T> : IRepository<T>
//     where T : class, IEntity
// {
//     private Dictionary<int, T> items =
//         new Dictionary<int, T>();

//     public void Add(T item)
//     {
//         items[item.Id] = item;
//     }

//     public T? GetById(int id)
//     {
//         if (items.TryGetValue(id, out T? item))
//             return item;

//         return null;
//     }

//     public IEnumerable<T> GetAll()
//     {
//         return items.Values;
//     }
// }

// public class TagList : IEnumerable<string>
// {
//     private List<string> tags = new List<string>();

//     public void Add(string tag)
//     {
//         tags.Add(tag);
//     }

//     public void Add(string tag, bool highlighted)
//     {
//         if (highlighted)
//             tags.Add("[" + tag + "]");
//         else
//             tags.Add(tag);
//     }

//     public IEnumerator<string> GetEnumerator()
//     {
//         return tags.GetEnumerator();
//     }

//     System.Collections.IEnumerator
//         System.Collections.IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         InMemoryRepository<MyEntity> repository =
//             new InMemoryRepository<MyEntity>();

//         repository.Add(new MyEntity(1, "Keyboard"));
//         repository.Add(new MyEntity(2, "Mouse"));
//         repository.Add(new MyEntity(3, "Monitor"));

//         Console.WriteLine("Repository:");

//         foreach (MyEntity entity in repository.GetAll())
//             Console.WriteLine(entity);

//         Console.WriteLine("\nGetById(2):");

//         MyEntity? found = repository.GetById(2);

//         if (found != null)
//             Console.WriteLine(found);

//         TagList tags = new TagList
//         {
//             "electronics",
//             { "important", true },
//             { "sale", false },
//             { "featured", true }
//         };

//         Console.WriteLine("\nTags:");

//         foreach (string tag in tags)
//             Console.WriteLine(tag);
//     }
// }


// ----------- Lab8 ------------


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class TreeNode<T> : IEnumerable<T>
// {
//     public T Value { get; set; }

//     private List<TreeNode<T>> children =
//         new List<TreeNode<T>>();

//     public TreeNode(T value)
//     {
//         Value = value;
//     }

//     public void AddChild(TreeNode<T> child)
//     {
//         children.Add(child);
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         yield return Value;

//         foreach (TreeNode<T> child in children)
//         {
//             foreach (T value in child)
//                 yield return value;
//         }
//     }

//     System.Collections.IEnumerator
//         System.Collections.IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// public class IteratorDemo
// {
//     public static IEnumerable<int> Fibonacci()
//     {
//         int first = 0;
//         int second = 1;

//         while (true)
//         {
//             yield return first;

//             int next = first + second;
//             first = second;
//             second = next;
//         }
//     }

//     public static IEnumerable<int> TakeWhilePositive(
//         IEnumerable<int> source)
//     {
//         foreach (int value in source)
//         {
//             if (value <= 0)
//                 yield break;

//             yield return value;
//         }
//     }

//     public static IEnumerable<int> LazyNumbers()
//     {
//         Console.WriteLine("Iterator started");

//         yield return 1;

//         Console.WriteLine("Producing 2");

//         yield return 2;

//         Console.WriteLine("Producing 3");

//         yield return 3;
//     }
// }

// public class MyList<T> : IEnumerable<T>
// {
//     private List<T> items = new List<T>();

//     public void Add(T item)
//     {
//         items.Add(item);
//     }

//     public IEnumerable<T> InReverse()
//     {
//         for (int i = items.Count - 1; i >= 0; i--)
//             yield return items[i];
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         return items.GetEnumerator();
//     }

//     System.Collections.IEnumerator
//         System.Collections.IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("FIBONACCI:");

//         foreach (int number in IteratorDemo.Fibonacci().Take(10))
//             Console.Write(number + " ");

//         Console.WriteLine();

//         Console.WriteLine("\n\nTAKE WHILE POSITIVE:");

//         int[] numbers = { 5, 4, 3, 2, 1, 0, 10, 20 };

//         foreach (int number in IteratorDemo.TakeWhilePositive(numbers))
//             Console.Write(number + " ");

//         Console.WriteLine();

//         Console.WriteLine("\n\nLAZY EVALUATION:");

//         IEnumerable<int> lazy = IteratorDemo.LazyNumbers();

//         Console.WriteLine("Iterator created");

//         Console.WriteLine("Starting foreach:");

//         foreach (int number in lazy)
//         {
//             Console.WriteLine("Received: " + number);
//         }

//         Console.WriteLine("\nTREE DFS:");

//         TreeNode<string> root =
//             new TreeNode<string>("Root");

//         TreeNode<string> left =
//             new TreeNode<string>("Left");

//         TreeNode<string> right =
//             new TreeNode<string>("Right");

//         TreeNode<string> leftChild =
//             new TreeNode<string>("Left Child");

//         TreeNode<string> rightChild =
//             new TreeNode<string>("Right Child");

//         root.AddChild(left);
//         root.AddChild(right);

//         left.AddChild(leftChild);
//         right.AddChild(rightChild);

//         foreach (string value in root)
//             Console.WriteLine(value);

//         Console.WriteLine("\nREVERSE ITERATOR:");

//         MyList<int> list = new MyList<int>();

//         list.Add(10);
//         list.Add(20);
//         list.Add(30);
//         list.Add(40);

//         foreach (int value in list.InReverse())
//             Console.Write(value + " ");

//         Console.WriteLine();
//     }
// }