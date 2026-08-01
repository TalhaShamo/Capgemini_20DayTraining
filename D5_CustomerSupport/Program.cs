using System;
using System.Collections.Generic;
using System.Linq;

public class Ticket
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string IssueType { get; set; }

    public Ticket(int id, string customerName, string issueType)
    {
        Id = id;
        CustomerName = customerName;
        IssueType = issueType;
    }

    public override string ToString()
    {
        return $"[ID: {Id}] {CustomerName} - Issue: {IssueType}";
    }
}

public class SupportTicketSystem
{
    private Queue<Ticket> ticketQueue;
    private List<Ticket> processedTickets;

    public SupportTicketSystem()
    {
        ticketQueue = new Queue<Ticket>();
        processedTickets = new List<Ticket>();
    }

    public void EnqueueTicket(Ticket ticket)
    {
        ticketQueue.Enqueue(ticket);
        Console.WriteLine($"Ticket added: {ticket}");
    }

    public void DisplayAllTickets()
    {
        if (ticketQueue.Count == 0)
        {
            Console.WriteLine("No tickets in the queue.");
            return;
        }

        Console.WriteLine("\n--- Current Ticket Queue ---");
        foreach (var ticket in ticketQueue)
        {
            Console.WriteLine(ticket);
        }
    }

    public Ticket ProcessNextTicket()
    {
        if (ticketQueue.Count == 0)
        {
            Console.WriteLine("No tickets to process.");
            return null;
        }

        Ticket ticket = ticketQueue.Dequeue();
        processedTickets.Add(ticket);
        Console.WriteLine($"Processed: {ticket}");
        return ticket;
    }

    public Ticket PeekNextTicket()
    {
        if (ticketQueue.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return null;
        }

        Ticket ticket = ticketQueue.Peek();
        Console.WriteLine($"Next ticket in line: {ticket}");
        return ticket;
    }

    public int GetQueueCount()
    {
        return ticketQueue.Count;
    }

    public Ticket SearchTicketById(int id)
    {
        foreach (var ticket in ticketQueue)
        {
            if (ticket.Id == id)
            {
                return ticket;
            }
        }
        return null;
    }

    public int CountTicketsByIssueType(string issueType)
    {
        int count = 0;
        foreach (var ticket in ticketQueue)
        {
            if (ticket.IssueType.Equals(issueType, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        return count;
    }

    public void RemoveAllProcessedTickets()
    {
        int count = processedTickets.Count;
        processedTickets.Clear();
        Console.WriteLine($"Removed {count} processed ticket(s) from history.");
    }
}

public class Program
{
    public static void Main()
    {
        SupportTicketSystem supportSystem = new SupportTicketSystem();

        Console.WriteLine("=== TASK 1: Enqueue Tickets ===");
        supportSystem.EnqueueTicket(new Ticket(101, "Alice", "Network"));
        supportSystem.EnqueueTicket(new Ticket(102, "Bob", "Hardware"));
        supportSystem.EnqueueTicket(new Ticket(103, "Charlie", "Network"));
        supportSystem.EnqueueTicket(new Ticket(104, "Diana", "Software"));

        Console.WriteLine("\n=== TASK 2: Display All Tickets ===");
        supportSystem.DisplayAllTickets();

        Console.WriteLine("\n=== TASK 4: View Next Ticket (Peek) ===");
        supportSystem.PeekNextTicket();

        Console.WriteLine("\n=== TASK 3: Process First Ticket (Dequeue) ===");
        supportSystem.ProcessNextTicket();
        supportSystem.ProcessNextTicket();

        Console.WriteLine("\n=== TASK 5: Check Queue Count ===");
        Console.WriteLine($"Remaining tickets in queue: {supportSystem.GetQueueCount()}");

        Console.WriteLine("\n=== TASK 6: Search Ticket by ID ===");
        Ticket foundTicket = supportSystem.SearchTicketById(103);
        Console.WriteLine(foundTicket != null ? $"Found: {foundTicket}" : "Ticket not found.");

        Console.WriteLine("\n=== TASK 7: Count Tickets by Issue Type ===");
        int networkIssueCount = supportSystem.CountTicketsByIssueType("Network");
        Console.WriteLine($"Network tickets remaining: {networkIssueCount}");

        Console.WriteLine("\n=== TASK 8: Remove All Processed Tickets ===");
        supportSystem.RemoveAllProcessedTickets();
    }
}