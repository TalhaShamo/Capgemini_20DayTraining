// using System;
// namespace D2_Training
// {
//     class BrowserHistory
//     {
//         Stack<string> history = new Stack<string>();
//         public void VisitPage(string url)
//         {
//             history.Push(url);
//             Console.WriteLine($"Successfully visited: {url}");
//         }

//         public void Back()
//         {
//             if(history.Count != 0)
//             {
//                 history.Pop();
//                 Console.WriteLine("Going back...");
//             }
//             else
//             {
//                 Console.WriteLine("Stack is empty!");
//             }
//         }

//         public void CurrentPage()
//         {
//             if(history.Count != 0)
//             {
//                 Console.WriteLine($"Current Page: {history.Peek()}");
//             }
//             else
//             {
//                 Console.WriteLine("Stack is empty!");
//             }
//         }

//         public void DisplayHistory()
//         {
//             if(history.Count == 0)
//             {
//                 Console.WriteLine("Nothing to Display");
//                 return;
//             }
//             Console.WriteLine("Browser History: ");
//             foreach(var v in history)
//             {
//                 Console.WriteLine(v);
//             }
//             Console.WriteLine("---------------------");
//         }

//         public void ClearHistory()
//         {
//             history.Clear();
//             Console.WriteLine("Successfully cleared history!");
//         }

//         public void TotalPages()
//         {
//             Console.WriteLine($"Total Pages: {history.Count}");
//         }
//     }
//     class Program
//     {
//         static void Main()
//         {
//             BrowserHistory newObj = new BrowserHistory();
//             bool running = true;

//             while (running)
//             {
//                 Console.WriteLine("Browser History System \n");
//                 Console.WriteLine("1. Visit Page");
//                 Console.WriteLine("2. Back");
//                 Console.WriteLine("3. Current Page");
//                 Console.WriteLine("4. Display History");
//                 Console.WriteLine("5. Clear History");
//                 Console.WriteLine("6. Total Pages");
//                 Console.WriteLine("7. Exit");
//                 Console.Write("Enter your choice: ");

//                 string choice = Console.ReadLine();

//                 if(choice == "1")
//                 {
//                     Console.WriteLine("Enter Website URL: ");
//                     string url = Console.ReadLine();
//                     newObj.VisitPage(url);
//                 }
//                 else if(choice == "2")
//                 {
//                     newObj.Back();
//                 }
//                 else if (choice == "3")
//                 {
//                     newObj.CurrentPage();
//                 }
//                 else if (choice == "4")
//                 {
//                     newObj.DisplayHistory();
//                 }
//                 else if (choice == "5")
//                 {
//                     newObj.ClearHistory();
//                 }
//                 else if (choice == "6")
//                 {
//                     newObj.TotalPages();
//                 }
//                 else if (choice == "7")
//                 {
//                     running = false;
//                     Console.WriteLine("Exiting Browser...");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
//                 }
//             }
//         }
//     }
// }


// // using System;
// // using System.Collections.Generic;

// // namespace HospitalQueueManagement
// // {
// //     class HospitalQueue
// //     {
// //         Queue<string> patients = new Queue<string>();

// //         public void RegisterPatient(string name)
// //         {
// //             patients.Enqueue(name);
// //             Console.WriteLine($"Success: '{name}' has been added to the waiting list.");
// //         }
// //         public void CallNextPatient()
// //         {
// //             if (patients.Count != 0)
// //             {
// //                 string nextPatient = patients.Dequeue();
// //                 Console.WriteLine($"Calling patient: {nextPatient}. Please proceed to the doctor's room.");
// //             }
// //             else
// //             {
// //                 Console.WriteLine("The waiting room is empty. No patients to call.");
// //             }
// //         }

// //         public void ViewNextPatient()
// //         {
// //             if (patients.Count != 0)
// //             {
// //                 Console.WriteLine($"Next patient in line is: {patients.Peek()}");
// //             }
// //             else
// //             {
// //                 Console.WriteLine("The waiting room is empty.");
// //             }
// //         }

// //         public void DisplayWaitingPatients()
// //         {
// //             if (patients.Count == 0)
// //             {
// //                 Console.WriteLine("No patients currently waiting.");
// //                 return;
// //             }

// //             Console.WriteLine("\n--- Current Waiting List ---");
// //             foreach (var patient in patients)
// //             {
// //                 Console.WriteLine(patient);
// //             }
// //             Console.WriteLine("----------------------------");
// //         }

// //         public void SearchPatient(string name)
// //         {

// //             if (patients.Contains(name))
// //             {
// //                 Console.WriteLine($"Yes, '{name}' is currently in the waiting queue.");
// //             }
// //             else
// //             {
// //                 Console.WriteLine($"No, '{name}' was not found in the waiting queue.");
// //             }
// //         }

// //         public void CountWaitingPatients()
// //         {
// //             Console.WriteLine($"Total patients currently waiting: {patients.Count}");
// //         }
// //     }

// //     class Program
// //     {
// //         static void Main()
// //         {
// //             HospitalQueue hospital = new HospitalQueue();
// //             bool run = true;

// //             while (run)
// //             {
// //                 Console.WriteLine("Hospital Queue Management System");
// //                 Console.WriteLine("====================================");
// //                 Console.WriteLine("1. Register Patient");
// //                 Console.WriteLine("2. Call Next Patient");
// //                 Console.WriteLine("3. View Next Patient");
// //                 Console.WriteLine("4. Display Waiting Patients");
// //                 Console.WriteLine("5. Search Patient");
// //                 Console.WriteLine("6. Count Waiting Patients");
// //                 Console.WriteLine("7. Exit");
// //                 Console.Write("Enter Choice : ");

// //                 string choice = Console.ReadLine();
// //                 Console.WriteLine();

// //                 if (choice == "1")
// //                 {
// //                     Console.Write("Enter Patient Name: ");
// //                     string name = Console.ReadLine();
// //                     hospital.RegisterPatient(name);
// //                 }
// //                 else if (choice == "2")
// //                 {
// //                     hospital.CallNextPatient();
// //                 }
// //                 else if (choice == "3")
// //                 {
// //                     hospital.ViewNextPatient();
// //                 }
// //                 else if (choice == "4")
// //                 {
// //                     hospital.DisplayWaitingPatients();
// //                 }
// //                 else if (choice == "5")
// //                 {
// //                     Console.Write("Enter Patient Name to search: ");
// //                     string name = Console.ReadLine();
// //                     hospital.SearchPatient(name);
// //                 }
// //                 else if (choice == "6")
// //                 {
// //                     hospital.CountWaitingPatients();
// //                 }
// //                 else if (choice == "7")
// //                 {
// //                     run = false;
// //                     Console.WriteLine("Closing the hospital system...");
// //                 }
// //                 else
// //                 {
// //                     Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
// //                 }
// //             }
// //         }
// //     }
// // }

using System;
using System.Collections.Generic;

namespace D2_Training
{
    class Program
    {
        static string[] tickets =
        {
            "T001|John|Login Issue",
            "T002|Alice|Payment Failed",
            "T003|David|Account Locked",
            "T004|Emma|Refund Request",
            "T005|James|Password Reset"
        };
        static Queue<string> ticketQueue = new Queue<string>();

        static void CountTicketsByIssueType()
        {
            Dictionary<string, int> issueCounts = new Dictionary<string, int>();

            foreach (string t in ticketQueue)
            {
                string[] data = t.Split('|');
                string issue = data[2];

                if (issueCounts.ContainsKey(issue))
                {
                    issueCounts[issue]++;
                }
                else
                {
                    issueCounts[issue] = 1;
                }
            }

            foreach (var entry in issueCounts)
            {
                Console.WriteLine($"{entry.Key} = {entry.Value}");
            }
        }
        static void Main(string[] args)
        {
            foreach(string t in tickets)
            {
                ticketQueue.Enqueue(t);
            }
            Console.WriteLine("Task 8: Count tickets by issue type");
            CountTicketsByIssueType();
        }
    }
}