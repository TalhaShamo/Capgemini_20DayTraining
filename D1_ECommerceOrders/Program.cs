using System;

namespace ECommerceStringHandling
{
    class Program
    {
        static string[] orders =
        {
            "ORD1001|John Smith|Laptop|2|$1200|Delivered",
            "ORD1002|Alice Brown|Mobile|1|$800|Pending",
            "ORD1003|David Wilson|Keyboard|3|$150|Shipped",
            "ORD1004|Emma Davis|Monitor|2|$350|Delivered",
            "ORD1005|James Miller|Mouse|5|$50|Pending"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("E-COMMERCE ORDER DETAILS\n");

            DisplayOrders();

            DisplayUpperCaseNames();

            DisplayPending();

            DisplayDelivered();
        }

        static void DisplayOrders()
        {
            Console.WriteLine("Order Details\n");

            foreach (string order in orders)
            {
                string[] data = order.Split('|');

                Console.WriteLine("Order ID : " + data[0]);
                Console.WriteLine("Customer : " + data[1]);
                Console.WriteLine("Product  : " + data[2]);
                Console.WriteLine("Quantity : " + data[3]);
                Console.WriteLine("Total    : " + data[4]);
                Console.WriteLine("Status   : " + data[5]);
                Console.WriteLine();
            }
        }

        static void DisplayUpperCaseNames()
        {
            Console.WriteLine("Uppercase Customer Names\n");

            foreach (string order in orders)
            {
                string[] data = order.Split('|');
        
                Console.WriteLine(data[1].ToUpper());
            }
        }

        static void DisplayPending()
        {
            Console.WriteLine("Customer Pending Deliveries\n");

            foreach(var v in orders)
            {
                if (v.Contains("Pending"))
                {
                    string[] data = v.Split('|');
                    Console.WriteLine(data[1]);
                }
            }
        }

        static void DisplayDelivered()
        {
            Console.WriteLine("Delivered Orders\n");
            foreach(var v in orders)
            {
                if (v.Contains("Delivered"))
                {
                    string[] parts = v.Split('|');
                    Console.WriteLine(parts[1]);
                }
            }
        }
    }
}