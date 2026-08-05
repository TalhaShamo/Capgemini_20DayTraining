using System;
using System.Collections.Generic;

namespace EmployeeSearchSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public int Experience { get; set; }
        public double Salary { get; set; }
        public string City { get; set; }

        public Employee(int id, string name, string department, string designation, int experience, double salary, string city)
        {
            Id = id;
            Name = name;
            Department = department;
            Designation = designation;
            Experience = experience;
            Salary = salary;
            City = city;
        }

        public void Display()
        {
            Console.WriteLine($"{Id,-6} | {Name,-15} | {Department,-10} | {Designation,-20} | {Experience,-4} | {Salary,-8} | {City,-12}");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee(1001, "Rahul Sharma", "IT", "Software Engineer", 2, 45000, "Chennai"),
            new Employee(1002, "Priya Singh", "HR", "HR Executive", 3, 40000, "Bangalore"),
            new Employee(1003, "Amit Kumar", "Finance", "Accountant", 5, 55000, "Hyderabad"),
            new Employee(1004, "Neha Patel", "IT", "Senior Developer", 6, 85000, "Pune"),
            new Employee(1005, "Arjun Reddy", "Sales", "Sales Executive", 2, 38000, "Chennai"),
            new Employee(1006, "Sneha Iyer", "Marketing", "Marketing Executive", 4, 52000, "Coimbatore"),
            new Employee(1007, "Karan Mehta", "IT", "Team Lead", 8, 95000, "Mumbai"),
            new Employee(1008, "Divya Nair", "Support", "Support Engineer", 1, 32000, "Kochi"),
            new Employee(1009, "Rohit Verma", "IT", "Software Engineer", 3, 50000, "Delhi"),
            new Employee(1010, "Anjali Gupta", "Finance", "Financial Analyst", 4, 65000, "Noida"),
            new Employee(1011, "Suresh Kumar", "Admin", "Administrator", 7, 58000, "Madurai"),
            new Employee(1012, "Pooja Sharma", "HR", "Recruiter", 2, 42000, "Bangalore"),
            new Employee(1013, "Vikram Das", "IT", "System Engineer", 5, 62000, "Chennai"),
            new Employee(1014, "Meena Joshi", "Support", "Technical Support", 3, 41000, "Trichy"),
            new Employee(1015, "Naveen Raj", "Sales", "Sales Manager", 9, 98000, "Salem"),
            new Employee(1016, "Kavya R", "Marketing", "SEO Analyst", 2, 45000, "Chennai"),
            new Employee(1017, "Ajay Kumar", "IT", "DevOps Engineer", 4, 72000, "Hyderabad"),
            new Employee(1018, "Lakshmi Devi", "Finance", "Senior Accountant", 6, 76000, "Coimbatore"),
            new Employee(1019, "Manoj Singh", "IT", "QA Engineer", 3, 53000, "Pune"),
            new Employee(1020, "Deepika Rao", "HR", "HR Manager", 8, 90000, "Bangalore")
        };

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n====================================");
                Console.WriteLine("          ABC Technologies          ");
                Console.WriteLine(" Employee Search Management System  ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Display All Employees");
                Console.WriteLine("2. Search by Employee ID (Linear Search)");
                Console.WriteLine("3. Search by Employee ID (Binary Search)");
                Console.WriteLine("4. Search by Employee Name");
                Console.WriteLine("5. Search by Department");
                Console.WriteLine("6. Search by City");
                Console.WriteLine("7. Search by Experience");
                Console.WriteLine("8. Search by Salary Range");
                Console.WriteLine("9. Exit");
                Console.Write("\nEnter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 9.");
                    continue;
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        DisplayEmployees(employees);
                        break;
                    case 2:
                        SearchByIdLinear();
                        break;
                    case 3:
                        SearchByIdBinary();
                        break;
                    case 4:
                        SearchByName();
                        break;
                    case 5:
                        SearchByDepartment();
                        break;
                    case 6:
                        SearchByCity();
                        break;
                    case 7:
                        SearchByExperience();
                        break;
                    case 8:
                        SearchBySalaryRange();
                        break;
                    case 9:
                        Console.WriteLine("Exiting system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please select an option from 1 to 9.");
                        break;
                }
            }
        }

        static void DisplayEmployees(List<Employee> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No employees found matching the criteria.");
                return;
            }
            foreach (var emp in list)
            {
                emp.Display();
            }
        }

        // 2. Linear Search by Employee ID
        static void SearchByIdLinear()
        {
            Console.Write("Enter Employee ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int targetId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            bool found = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == targetId)
                {
                    Console.WriteLine("\nEmployee Found (Linear Search):");
                    DisplayEmployees(new List<Employee> { employees[i] });
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Employee with ID {targetId} not found.");
            }
        }

        // 3. Binary Search by Employee ID (Requires sorted list by ID)
        static void SearchByIdBinary()
        {
            Console.Write("Enter Employee ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int targetId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            // Ensure list is sorted by ID before binary search
            employees.Sort((a, b) => a.Id.CompareTo(b.Id));

            int left = 0;
            int right = employees.Count - 1;
            bool found = false;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (employees[mid].Id == targetId)
                {
                    Console.WriteLine("\nEmployee Found (Binary Search):");
                    DisplayEmployees(new List<Employee> { employees[mid] });
                    found = true;
                    break;
                }
                else if (employees[mid].Id < targetId)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Employee with ID {targetId} not found.");
            }
        }

        // 4. Search by Name (Case-insensitive partial match)
        static void SearchByName()
        {
            Console.Write("Enter Name (or part of Name): ");
            string nameQuery = Console.ReadLine()?.Trim().ToLower();

            List<Employee> results = new List<Employee>();
            foreach (var emp in employees)
            {
                if (emp.Name.ToLower().Contains(nameQuery))
                {
                    results.Add(emp);
                }
            }

            DisplayEmployees(results);
        }

        // 5. Search by Department
        static void SearchByDepartment()
        {
            Console.Write("Enter Department (e.g., IT, HR, Finance): ");
            string deptQuery = Console.ReadLine()?.Trim();

            List<Employee> results = new List<Employee>();
            foreach (var emp in employees)
            {
                if (string.Equals(emp.Department, deptQuery, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(emp);
                }
            }

            DisplayEmployees(results);
        }

        // 6. Search by City
        static void SearchByCity()
        {
            Console.Write("Enter City: ");
            string cityQuery = Console.ReadLine()?.Trim();

            List<Employee> results = new List<Employee>();
            foreach (var emp in employees)
            {
                if (string.Equals(emp.City, cityQuery, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(emp);
                }
            }

            DisplayEmployees(results);
        }

        // 7. Search by Experience
        static void SearchByExperience()
        {
            Console.Write("Enter Years of Experience: ");
            if (!int.TryParse(Console.ReadLine(), out int expQuery))
            {
                Console.WriteLine("Invalid experience input.");
                return;
            }

            List<Employee> results = new List<Employee>();
            foreach (var emp in employees)
            {
                if (emp.Experience == expQuery)
                {
                    results.Add(emp);
                }
            }

            DisplayEmployees(results);
        }

        // 8. Search by Salary Range
        static void SearchBySalaryRange()
        {
            Console.Write("Enter Minimum Salary: ");
            if (!double.TryParse(Console.ReadLine(), out double minSalary))
            {
                Console.WriteLine("Invalid salary input.");
                return;
            }

            Console.Write("Enter Maximum Salary: ");
            if (!double.TryParse(Console.ReadLine(), out double maxSalary))
            {
                Console.WriteLine("Invalid salary input.");
                return;
            }

            List<Employee> results = new List<Employee>();
            foreach (var emp in employees)
            {
                if (emp.Salary >= minSalary && emp.Salary <= maxSalary)
                {
                    results.Add(emp);
                }
            }

            DisplayEmployees(results);
        }
    }
}