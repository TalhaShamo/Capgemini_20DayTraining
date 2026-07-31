using System;
using System.Collections.Generic;

public class Transaction
{
    public string AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string MerchantName { get; set; }

    public Transaction(string id, decimal amount, DateTime time, string merchant)
    {
        AccountId = id;
        Amount = amount;
        Timestamp = time;
        MerchantName = merchant;
    }

    public override string ToString()
    {
        return $"[{Timestamp:yyyy-MM-dd HH:mm}] {AccountId} | ${Amount} | {MerchantName}";
    }
}

public class BankManager
{
    public List<Transaction> TransactionList = new List<Transaction>();
    public void AddTransaction(Transaction t)
    {
        TransactionList.Add(t);
    }

    public void DetectLarge(decimal threshold)
    {
        foreach (var t in TransactionList)
        {
            if (t.Amount > threshold)
            {
                Console.WriteLine($"[ALERT] Large Transfer: {t}");
            }
        }
    }

    public void DetectSuspicious(List<string> watchlist)
    {
        foreach (var t in TransactionList)
        {
            foreach (var badMerchant in watchlist)
            {
                if (t.MerchantName.Contains(badMerchant, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"[ALERT] Watchlist Merchant: {t}");
                    break; 
                }
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BankManager bankObj = new BankManager();
        
        // Read how many commands the user will input
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine()!;
            string[] parts = input.Split(' ');

            if (parts[0] == "ADD")
            {
                string id = parts[1];
                decimal amount = decimal.Parse(parts[2]);
                DateTime time = DateTime.Parse(parts[3]); 
                string merchant = parts[4];

                Transaction newTrans = new Transaction(id, amount, time, merchant);
                bankObj.AddTransaction(newTrans);
            }
            else if (parts[0] == "CHECK_LARGE")
            {
                decimal threshold = decimal.Parse(parts[1]);
                bankObj.DetectLarge(threshold);
            }
            else if (parts[0] == "CHECK_WATCHLIST")
            {
                List<string> watchlist = new List<string>();
                
                // Loop starts at 1 to skip the command word itself
                for (int j = 1; j < parts.Length; j++) 
                {
                    watchlist.Add(parts[j]);
                }
                
                bankObj.DetectSuspicious(watchlist);
            }
        }
    }
}