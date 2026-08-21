using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IEntity
{
    int Id { get; }
}

public enum OrderStatus
{
    Placed,
    Queued,
    Dispatched,
    Delivered,
    Cancelled
}

public class MenuItem : IEntity
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    public MenuItem(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - ${Price:F2}";
    }
}

public class Restaurant : IEntity
{
    public int Id { get; }
    public string Name { get; }
    public bool IsOpen { get; set; }
    public List<MenuItem> Menu { get; }

    public Restaurant(int id, string name, bool isOpen)
    {
        Id = id;
        Name = name;
        IsOpen = isOpen;
        Menu = new List<MenuItem>();
    }

    public void AddMenuItem(MenuItem item)
    {
        Menu.Add(item);
    }

    public override string ToString()
    {
        return $"{Name} - {(IsOpen ? "Open" : "Closed")} - {Menu.Count} menu items";
    }
}

public class Customer : IEntity
{
    public int Id { get; }
    public string Name { get; }
    public bool IsVip { get; }

    public Customer(int id, string name, bool isVip)
    {
        Id = id;
        Name = name;
        IsVip = isVip;
    }

    public override string ToString()
    {
        return $"{Name} {(IsVip ? "(VIP)" : "")}";
    }
}

public class OrderItem
{
    public MenuItem MenuItem { get; }
    public int Quantity { get; }

    public OrderItem(MenuItem menuItem, int quantity)
    {
        MenuItem = menuItem;
        Quantity = quantity;
    }

    public decimal Total
    {
        get { return MenuItem.Price * Quantity; }
    }
}

public class Order : IEntity
{
    public int Id { get; }
    public Customer Customer { get; }
    public Restaurant Restaurant { get; }
    public List<OrderItem> Items { get; }
    public DateTime PlacedAt { get; }
    public bool IsExpress { get; }
    public OrderStatus Status { get; set; }

    public Order(
        int id,
        Customer customer,
        Restaurant restaurant,
        DateTime placedAt,
        bool isExpress)
    {
        Id = id;
        Customer = customer;
        Restaurant = restaurant;
        PlacedAt = placedAt;
        IsExpress = isExpress;
        Status = OrderStatus.Placed;
        Items = new List<OrderItem>();
    }

    public decimal Total
    {
        get { return Items.Sum(item => item.Total); }
    }

    public void AddItem(MenuItem item, int quantity)
    {
        Items.Add(new OrderItem(item, quantity));
    }

    public override string ToString()
    {
        return $"Order #{Id} - {Customer.Name} - {Restaurant.Name} - ${Total:F2} - {Status}";
    }
}

public class DeliveryAgent
{
    public int Id { get; }
    public string Name { get; }

    public DeliveryAgent(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name} (Agent {Id})";
    }
}

public class DispatchRecord
{
    public Order Order { get; }
    public DeliveryAgent Agent { get; }
    public DateTime DispatchedAt { get; }

    public DispatchRecord(Order order, DeliveryAgent agent, DateTime dispatchedAt)
    {
        Order = order;
        Agent = agent;
        DispatchedAt = dispatchedAt;
    }
}

public class Repository<T> : IEnumerable<T>
    where T : class, IEntity
{
    private readonly Dictionary<int, T> items = new Dictionary<int, T>();

    public void Add(T item)
    {
        items.Add(item.Id, item);
    }

    public void Update(T item)
    {
        if (!items.ContainsKey(item.Id))
            throw new KeyNotFoundException($"Entity with ID {item.Id} was not found.");

        items[item.Id] = item;
    }

    public bool Remove(int id)
    {
        return items.Remove(id);
    }

    public T? GetById(int id)
    {
        items.TryGetValue(id, out T? item);
        return item;
    }

    public IEnumerable<T> GetAll()
    {
        return items.Values;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class OrderPriorityComparer : IComparer<Order>
{
    public int Compare(Order? x, Order? y)
    {
        if (ReferenceEquals(x, y))
            return 0;

        if (x is null)
            return -1;

        if (y is null)
            return 1;

        int xPriority = x.IsExpress ? 0 : x.Customer.IsVip ? 1 : 2;
        int yPriority = y.IsExpress ? 0 : y.Customer.IsVip ? 1 : 2;

        int priorityResult = xPriority.CompareTo(yPriority);

        if (priorityResult != 0)
            return priorityResult;

        int timeResult = x.PlacedAt.CompareTo(y.PlacedAt);

        if (timeResult != 0)
            return timeResult;

        return x.Id.CompareTo(y.Id);
    }
}

public class DispatchQueue
{
    private readonly Queue<Order> priorityOrders = new Queue<Order>();
    private readonly Queue<Order> normalOrders = new Queue<Order>();

    public void Enqueue(Order order)
    {
        order.Status = OrderStatus.Queued;

        if (order.IsExpress || order.Customer.IsVip)
            priorityOrders.Enqueue(order);
        else
            normalOrders.Enqueue(order);
    }

    public Order DispatchNext()
    {
        if (priorityOrders.Count > 0)
        {
            Order order = priorityOrders.Dequeue();
            order.Status = OrderStatus.Dispatched;
            return order;
        }

        if (normalOrders.Count > 0)
        {
            Order order = normalOrders.Dequeue();
            order.Status = OrderStatus.Dispatched;
            return order;
        }

        throw new InvalidOperationException("No orders waiting for dispatch.");
    }

    public List<Order> GetPriorityView()
    {
        List<Order> allOrders = priorityOrders
            .Concat(normalOrders)
            .ToList();

        allOrders.Sort(new OrderPriorityComparer());

        return allOrders;
    }

    public int Count
    {
        get { return priorityOrders.Count + normalOrders.Count; }
    }
}

public class DeliveryRoster
{
    private readonly LinkedList<DeliveryAgent> agents =
        new LinkedList<DeliveryAgent>();

    public void AddAgent(DeliveryAgent agent)
    {
        agents.AddLast(agent);
    }

    public DeliveryAgent GetNextAvailableAgent()
    {
        if (agents.Count == 0)
            throw new InvalidOperationException("No delivery agents available.");

        LinkedListNode<DeliveryAgent> first = agents.First!;

        DeliveryAgent agent = first.Value;

        agents.RemoveFirst();
        agents.AddLast(agent);

        return agent;
    }

    public void ReturnToFront(DeliveryAgent agent)
    {
        agents.AddFirst(agent);
    }

    public IEnumerable<DeliveryAgent> GetAll()
    {
        return agents;
    }
}

public class QuickBiteEngine
{
    public Repository<Restaurant> Restaurants { get; } =
        new Repository<Restaurant>();

    public Repository<Customer> Customers { get; } =
        new Repository<Customer>();

    public Repository<Order> Orders { get; } =
        new Repository<Order>();

    public DispatchQueue DispatchQueue { get; } =
        new DispatchQueue();

    public DeliveryRoster DeliveryRoster { get; } =
        new DeliveryRoster();

    private readonly Stack<DispatchRecord> dispatchHistory =
        new Stack<DispatchRecord>();

    private readonly int maxHistory;

    public QuickBiteEngine(int maxHistory)
    {
        this.maxHistory = maxHistory;
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
        DispatchQueue.Enqueue(order);
    }

    public void DispatchOrder()
    {
        Order order = DispatchQueue.DispatchNext();
        DeliveryAgent agent = DeliveryRoster.GetNextAvailableAgent();

        DispatchRecord record =
            new DispatchRecord(order, agent, DateTime.Now);

        dispatchHistory.Push(record);

        if (dispatchHistory.Count > maxHistory)
        {
            DispatchRecord[] records = dispatchHistory.ToArray();

            dispatchHistory.Clear();

            for (int i = maxHistory - 1; i >= 0; i--)
                dispatchHistory.Push(records[i]);
        }

        Console.WriteLine(
            $"Dispatched Order #{order.Id} to {agent.Name}");
    }

    public void UndoLastDispatch()
    {
        if (dispatchHistory.Count == 0)
            throw new InvalidOperationException("There is no dispatch to undo.");

        DispatchRecord record = dispatchHistory.Pop();

        record.Order.Status = OrderStatus.Queued;

        DeliveryRoster.ReturnToFront(record.Agent);

        Console.WriteLine(
            $"Undid dispatch of Order #{record.Order.Id}. " +
            $"{record.Agent.Name} returned to front of roster.");
    }

    public HashSet<int> TodaysUniqueCustomerIds()
    {
        DateTime today = DateTime.Today;

        return Orders
            .Where(o =>
                o.PlacedAt.Date == today &&
                o.Status != OrderStatus.Cancelled)
            .Select(o => o.Customer.Id)
            .ToHashSet();
    }

    public Dictionary<int, int> LowAvailabilityRestaurants(int minMenuItems)
    {
        return Restaurants
            .Where(r => r.Menu.Count < minMenuItems)
            .ToDictionary(
                r => r.Id,
                r => r.Menu.Count);
    }

    public List<(string ItemName, int TotalOrdered)> TopOrderedItems(int topN)
    {
        Dictionary<string, int> totals =
            new Dictionary<string, int>();

        foreach (Order order in Orders)
        {
            if (order.Status == OrderStatus.Cancelled)
                continue;

            foreach (OrderItem item in order.Items)
            {
                if (totals.TryGetValue(item.MenuItem.Name, out int current))
                    totals[item.MenuItem.Name] = current + item.Quantity;
                else
                    totals[item.MenuItem.Name] = item.Quantity;
            }
        }

        return totals
            .OrderByDescending(x => x.Value)
            .Take(topN)
            .Select(x => (x.Key, x.Value))
            .ToList();
    }

    public bool CustomerOrderedFromBothRestaurants(
        int customerId,
        int restaurantIdA,
        int restaurantIdB)
    {
        HashSet<int> restaurantHistory = Orders
            .Where(o =>
                o.Customer.Id == customerId &&
                o.Status != OrderStatus.Cancelled)
            .Select(o => o.Restaurant.Id)
            .ToHashSet();

        HashSet<int> requiredRestaurants =
            new HashSet<int>
            {
                restaurantIdA,
                restaurantIdB
            };

        return requiredRestaurants.IsSubsetOf(restaurantHistory);
    }
}

public class Program
{
    public static void Main()
    {
        QuickBiteEngine engine = new QuickBiteEngine(5);

        MenuItem pizza = new MenuItem(1, "Pizza", 12.99m);
        MenuItem burger = new MenuItem(2, "Burger", 9.99m);
        MenuItem fries = new MenuItem(3, "Fries", 4.99m);
        MenuItem pasta = new MenuItem(4, "Pasta", 11.99m);

        Restaurant r1 = new Restaurant(1, "Pizza Palace", true);
        r1.AddMenuItem(pizza);
        r1.AddMenuItem(pasta);
        r1.AddMenuItem(fries);

        Restaurant r2 = new Restaurant(2, "Burger House", true);
        r2.AddMenuItem(burger);
        r2.AddMenuItem(fries);

        Restaurant r3 = new Restaurant(3, "Tiny Cafe", true);
        r3.AddMenuItem(pasta);

        engine.Restaurants.Add(r1);
        engine.Restaurants.Add(r2);
        engine.Restaurants.Add(r3);

        Customer c1 = new Customer(1, "Alice", false);
        Customer c2 = new Customer(2, "Bob", true);
        Customer c3 = new Customer(3, "Charlie", false);

        engine.Customers.Add(c1);
        engine.Customers.Add(c2);
        engine.Customers.Add(c3);

        engine.DeliveryRoster.AddAgent(
            new DeliveryAgent(1, "Agent Mike"));

        engine.DeliveryRoster.AddAgent(
            new DeliveryAgent(2, "Agent Sarah"));

        engine.DeliveryRoster.AddAgent(
            new DeliveryAgent(3, "Agent John"));

        DateTime today = DateTime.Now;

        Order order1 = new Order(
            101,
            c1,
            r1,
            today.AddMinutes(-20),
            false);

        order1.AddItem(pizza, 2);
        order1.AddItem(fries, 1);

        Order order2 = new Order(
            102,
            c2,
            r2,
            today.AddMinutes(-15),
            false);

        order2.AddItem(burger, 2);

        Order order3 = new Order(
            103,
            c3,
            r1,
            today.AddMinutes(-10),
            true);

        order3.AddItem(pizza, 1);

        Order order4 = new Order(
            104,
            c1,
            r2,
            today.AddMinutes(-5),
            false);

        order4.AddItem(burger, 1);
        order4.AddItem(fries, 2);

        engine.AddOrder(order1);
        engine.AddOrder(order2);
        engine.AddOrder(order3);
        engine.AddOrder(order4);

        Console.WriteLine("=== DISPATCH QUEUE ===");

        foreach (Order order in engine.DispatchQueue.GetPriorityView())
            Console.WriteLine(
                $"Order #{order.Id} | Express: {order.IsExpress} | " +
                $"VIP: {order.Customer.IsVip}");

        Console.WriteLine();

        Console.WriteLine("=== DISPATCHING ===");

        engine.DispatchOrder();
        engine.DispatchOrder();

        Console.WriteLine();

        Console.WriteLine("=== UNDO LAST DISPATCH ===");

        engine.UndoLastDispatch();

        Console.WriteLine();

        Console.WriteLine("=== DISPATCH AGAIN ===");

        engine.DispatchOrder();

        Console.WriteLine();

        Console.WriteLine("=== UNIQUE CUSTOMERS TODAY ===");

        HashSet<int> uniqueCustomers =
            engine.TodaysUniqueCustomerIds();

        foreach (int id in uniqueCustomers)
            Console.WriteLine($"Customer ID: {id}");

        Console.WriteLine();

        Console.WriteLine("=== LOW AVAILABILITY RESTAURANTS ===");

        Dictionary<int, int> lowAvailability =
            engine.LowAvailabilityRestaurants(3);

        foreach (var entry in lowAvailability)
            Console.WriteLine(
                $"Restaurant ID: {entry.Key}, Menu Items: {entry.Value}");

        Console.WriteLine();

        Console.WriteLine("=== TOP ORDERED ITEMS ===");

        List<(string ItemName, int TotalOrdered)> topItems =
            engine.TopOrderedItems(3);

        foreach (var item in topItems)
            Console.WriteLine(
                $"{item.ItemName}: {item.TotalOrdered} ordered");

        Console.WriteLine();

        Console.WriteLine("=== CUSTOMER RESTAURANT HISTORY ===");

        bool orderedFromBoth =
            engine.CustomerOrderedFromBothRestaurants(
                1,
                1,
                2);

        Console.WriteLine(
            $"Customer 1 ordered from Restaurant 1 and 2: {orderedFromBoth}");

        Console.WriteLine();

        Console.WriteLine("=== REPOSITORY ENUMERATION ===");

        foreach (Order order in engine.Orders)
            Console.WriteLine(order);
    }
}