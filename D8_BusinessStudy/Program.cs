using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationHierarchySystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int ManagerId { get; set; }

        public Employee(int id, string name, string designation, string department, int managerId)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Department = department;
            ManagerId = managerId;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id,-5} | Name: {Name,-18} | Role: {Designation,-18} | Dept: {Department,-12} | MgrID: {ManagerId}");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee(1001, "John Smith", "CEO", "Management", 0),
            new Employee(1002, "Michael Johnson", "IT Manager", "IT", 1001),
            new Employee(1003, "Sarah Williams", "HR Manager", "HR", 1001),
            new Employee(1004, "David Brown", "Finance Manager", "Finance", 1001),
            new Employee(1005, "Robert Davis", "Team Lead", "IT", 1002),
            new Employee(1006, "Jennifer Miller", "QA Lead", "IT", 1002),
            new Employee(1007, "William Wilson", "Senior Developer", "IT", 1005),
            new Employee(1008, "Emma Moore", "Senior Developer", "IT", 1005),
            new Employee(1009, "Daniel Taylor", "QA Engineer", "IT", 1006),
            new Employee(1010, "Sophia Anderson", "QA Engineer", "IT", 1006),
            new Employee(1011, "James Thomas", "Recruiter", "HR", 1003),
            new Employee(1012, "Olivia Jackson", "Recruiter", "HR", 1003),
            new Employee(1013, "Benjamin White", "Accountant", "Finance", 1004),
            new Employee(1014, "Charlotte Harris", "Accountant", "Finance", 1004),
            new Employee(1015, "Lucas Martin", "Developer", "IT", 1007),
            new Employee(1016, "Ethan Walker", "Developer", "IT", 1007),
            new Employee(1017, "Mia Hall", "UI Developer", "IT", 1008),
            new Employee(1018, "Alexander Young", "Business Analyst", "IT", 1005),
            new Employee(1019, "Harper King", "HR Executive", "HR", 1011),
            new Employee(1020, "Jack Scott", "Finance Executive", "Finance", 1013)
        };

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("             ABC TECHNOLOGIES             ");
                Console.WriteLine(" Organization Hierarchy Management System ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Display Complete Organization Chart");
                Console.WriteLine("2. Find Employee by ID");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Display Employees under a Manager");
                Console.WriteLine("5. Count Total Employees under a Manager");
                Console.WriteLine("6. Display Hierarchy Level");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter your Choice : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
                    continue;
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        DisplayCompleteChart();
                        break;
                    case 2:
                        FindEmployeeById();
                        break;
                    case 3:
                        FindEmployeeByName();
                        break;
                    case 4:
                        DisplayEmployeesUnderManager();
                        break;
                    case 5:
                        CountEmployeesUnderManager();
                        break;
                    case 6:
                        DisplayHierarchyLevel();
                        break;
                    case 7:
                        Console.WriteLine("Exiting Organization Hierarchy System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice! Please enter an option between 1 and 7.");
                        break;
                }
            }
        }

        // 1. Display Complete Organization Chart
        static void DisplayCompleteChart()
        {
            Employee ceo = employees.FirstOrDefault(e => e.ManagerId == 0);
            if (ceo == null)
            {
                Console.WriteLine("CEO not found in the organization!");
                return;
            }

            Console.WriteLine("Organization Hierarchy");
            Console.WriteLine($"{ceo.Name} ({ceo.Designation})");
            Console.WriteLine("│");
            PrintHierarchyRecursive(ceo.Id, "");
        }

        // Recursive helper to build tree with ASCII lines
        static void PrintHierarchyRecursive(int managerId, string indent)
        {
            var subordinates = employees.Where(e => e.ManagerId == managerId).ToList();
            for (int i = 0; i < subordinates.Count; i++)
            {
                bool isLast = (i == subordinates.Count - 1);
                string branch = isLast ? "└── " : "├── ";
                string childIndent = indent + (isLast ? "    " : "│   ");

                Console.WriteLine($"{indent}{branch}{subordinates[i].Name} ({subordinates[i].Designation})");
                PrintHierarchyRecursive(subordinates[i].Id, childIndent);

                if (!isLast && subordinates[i].Id == subordinates.Last().Id)
                {
                    Console.WriteLine($"{indent}│");
                }
            }
        }

        // 2. Find Employee by ID
        static void FindEmployeeById()
        {
            Console.Write("Enter Employee ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int empId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Employee emp = employees.FirstOrDefault(e => e.Id == empId);
            if (emp != null)
            {
                Console.WriteLine("\nEmployee Found:");
                emp.Display();
            }
            else
            {
                Console.WriteLine($"Employee with ID {empId} not found.");
            }
        }

        // 3. Find Employee by Name
        static void FindEmployeeByName()
        {
            Console.Write("Enter Employee Name (or partial name): ");
            string query = Console.ReadLine()?.Trim().ToLower();

            var matchingEmployees = employees.Where(e => e.Name.ToLower().Contains(query)).ToList();
            if (matchingEmployees.Count > 0)
            {
                Console.WriteLine($"\nFound {matchingEmployees.Count} Employee(s):");
                foreach (var emp in matchingEmployees)
                {
                    emp.Display();
                }
            }
            else
            {
                Console.WriteLine("No employee found matching that name.");
            }
        }

        // 4. Display Employees under a Manager (Complete Subtree)
        static void DisplayEmployeesUnderManager()
        {
            Console.Write("Enter Manager ID: ");
            if (!int.TryParse(Console.ReadLine(), out int managerId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Employee mgr = employees.FirstOrDefault(e => e.Id == managerId);
            if (mgr == null)
            {
                Console.WriteLine($"Manager with ID {managerId} not found.");
                return;
            }

            Console.WriteLine($"\nEmployees reporting under {mgr.Name} ({mgr.Designation}):");
            PrintHierarchyRecursive(mgr.Id, "");
        }

        // 5. Count Total Employees under a Manager (Recursively counts direct & indirect)
        static void CountEmployeesUnderManager()
        {
            Console.Write("Enter Manager ID to count subordinates: ");
            if (!int.TryParse(Console.ReadLine(), out int managerId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Employee mgr = employees.FirstOrDefault(e => e.Id == managerId);
            if (mgr == null)
            {
                Console.WriteLine($"Manager with ID {managerId} not found.");
                return;
            }

            int totalCount = CountSubordinatesRecursive(mgr.Id);
            Console.WriteLine($"\nTotal employees reporting directly or indirectly to {mgr.Name}: {totalCount}");
        }

        static int CountSubordinatesRecursive(int managerId)
        {
            int count = 0;
            var subordinates = employees.Where(e => e.ManagerId == managerId).ToList();

            foreach (var sub in subordinates)
            {
                count += 1; // Count the employee themselves
                count += CountSubordinatesRecursive(sub.Id); // Direct recursion for subordinates
            }

            return count;
        }

        // 6. Display Hierarchy Level (Level 0 = CEO, Level 1 = Manager, etc.)
        static void DisplayHierarchyLevel()
        {
            Console.Write("Enter Employee ID to check level: ");
            if (!int.TryParse(Console.ReadLine(), out int empId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Employee emp = employees.FirstOrDefault(e => e.Id == empId);
            if (emp == null)
            {
                Console.WriteLine($"Employee with ID {empId} not found.");
                return;
            }

            int level = GetHierarchyLevelRecursive(emp.Id, 0);
            Console.WriteLine($"\n{emp.Name} ({emp.Designation}) is at Hierarchy Level: {level}");
        }

        static int GetHierarchyLevelRecursive(int currentId, int level)
        {
            Employee emp = employees.FirstOrDefault(e => e.Id == currentId);
            if (emp == null || emp.ManagerId == 0) // Base case: Reached CEO (or root)
            {
                return level;
            }

            // Move up one level to the manager
            return GetHierarchyLevelRecursive(emp.ManagerId, level + 1);
        }
    }
}