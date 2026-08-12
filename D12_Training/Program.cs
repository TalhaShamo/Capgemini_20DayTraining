using System;

public struct RgbColor
{
    public byte R, G, B;

    public RgbColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public override string ToString()
    {
        return $"#{R:X2}{G:X2}{B:X2}";
    }
}

public enum NamedColor
{
    Red,
    Green,
    Blue,
    White,
    Black
}

public class Pixel
{
    public RgbColor Color;
}

class Program
{
    public static RgbColor FromNamed(NamedColor name)
    {
        switch (name)
        {
            case NamedColor.Red:
                return new RgbColor(255, 0, 0);

            case NamedColor.Green:
                return new RgbColor(0, 255, 0);

            case NamedColor.Blue:
                return new RgbColor(0, 0, 255);

            case NamedColor.White:
                return new RgbColor(255, 255, 255);

            case NamedColor.Black:
                return new RgbColor(0, 0, 0);

            default:
                throw new ArgumentException("Invalid color");
        }
    }

    static void Main()
    {
        Console.WriteLine("-- struct copy --");

        RgbColor a = FromNamed(NamedColor.Red);

        RgbColor b = a;

        b.R = 1;

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");

        Console.WriteLine();
        Console.WriteLine("-- class/reference copy --");

        Pixel p1 = new Pixel();
        p1.Color = FromNamed(NamedColor.Green);

        Pixel p2 = p1;

        p2.Color = new RgbColor(0, 255, 0);

        Console.WriteLine($"p1.Color = {p1.Color}");
        Console.WriteLine($"p2.Color = {p2.Color}");
    }
}

// // // // // using System;

// // // // // public class LibraryBook
// // // // // {
// // // // //     private string _isbn;
// // // // //     public string Title;
// // // // //     protected string ShelfLocation = "Unassigned";
// // // // //     internal int CopiesAvailable;
// // // // //     public static int TotalBooksCreated;

// // // // //     public LibraryBook(string title, string isbn)
// // // // //     {
// // // // //         Title = title;
// // // // //         _isbn = isbn;

// // // // //         CopiesAvailable = 1;

// // // // //         TotalBooksCreated++;
// // // // //     }


// // // // //     protected internal void Relocate(string newLocation)
// // // // //     {
// // // // //         ShelfLocation = newLocation;
// // // // //     }


// // // // //     private protected void AdjustCopies(int delta)
// // // // //     {
// // // // //         CopiesAvailable += delta;
// // // // //     }
// // // // // }


// // // // // public class ReferenceBook : LibraryBook
// // // // // {
// // // // //     public ReferenceBook(string title, string isbn)
// // // // //         : base(title, isbn)
// // // // //     {
// // // // //     }


// // // // //     public void PrintLocation()
// // // // //     {
// // // // //         // Access protected field
// // // // //         Console.WriteLine(
// // // // //             $"ReferenceBook shelf location before Relocate: \"{ShelfLocation}\""
// // // // //         );

// // // // //         // Access protected internal method
// // // // //         Relocate("Reference Section");

// // // // //         Console.WriteLine(
// // // // //             $"ReferenceBook shelf location after Relocate: \"{ShelfLocation}\""
// // // // //         );

// // // // //         // Access private protected method
// // // // //         AdjustCopies(2);

// // // // //         Console.WriteLine(
// // // // //             $"Copies available after AdjustCopies(+2): {CopiesAvailable}"
// // // // //         );
// // // // //     }
// // // // // }


// // // // // class Program
// // // // // {
// // // // //     static void Main()
// // // // //     {
// // // // //         LibraryBook book1 = new LibraryBook("C# Basics", "ISBN001");

// // // // //         Console.WriteLine(
// // // // //             $"Book 1 created. Total books so far: {LibraryBook.TotalBooksCreated}"
// // // // //         );

// // // // //         LibraryBook book2 = new LibraryBook("Java Basics", "ISBN002");

// // // // //         Console.WriteLine(
// // // // //             $"Book 2 created. Total books so far: {LibraryBook.TotalBooksCreated}"
// // // // //         );

// // // // //         LibraryBook book3 = new LibraryBook("Data Structures", "ISBN003");

// // // // //         Console.WriteLine(
// // // // //             $"Book 3 created. Total books so far: {LibraryBook.TotalBooksCreated}"
// // // // //         );

// // // // //         ReferenceBook referenceBook =
// // // // //             new ReferenceBook("C# Reference", "ISBN004");

// // // // //         referenceBook.PrintLocation();
// // // // //     }
// // // // // }


// // // // using System;

// // // // public class Appointment
// // // // {
// // // //     public string Title { get; }
// // // //     public DateTime Start { get; }
// // // //     public TimeSpan Duration { get; }
// // // //     public string Location { get; }

// // // //     public static int DefaultDurationMinutes;


// // // //     // Static constructor
// // // //     static Appointment()
// // // //     {
// // // //         Console.WriteLine(
// // // //             "Appointment type initialized. Default duration set to 30 minutes."
// // // //         );

// // // //         DefaultDurationMinutes = 30;
// // // //     }


// // // //     // Full constructor
// // // //     public Appointment(
// // // //         string title,
// // // //         DateTime start,
// // // //         TimeSpan duration,
// // // //         string location)
// // // //     {
// // // //         Title = title;
// // // //         Start = start;
// // // //         Duration = duration;
// // // //         Location = location;
// // // //     }


// // // //     // Two-argument constructor
// // // //     public Appointment(string title, DateTime start)
// // // //         : this(
// // // //             title,
// // // //             start,
// // // //             TimeSpan.FromMinutes(DefaultDurationMinutes),
// // // //             "TBD")
// // // //     {
// // // //     }


// // // //     // One-argument constructor
// // // //     public Appointment(string title)
// // // //         : this(title, DateTime.Now.AddDays(1))
// // // //     {
// // // //     }
// // // // }


// // // // class Program
// // // // {
// // // //     static void Main()
// // // //     {
// // // //         // Full constructor
// // // //         Appointment full = new Appointment(
// // // //             "Standup",
// // // //             new DateTime(2026, 8, 12, 9, 0, 0),
// // // //             TimeSpan.FromMinutes(30),
// // // //             "Room 4"
// // // //         );


// // // //         // Two-argument constructor
// // // //         Appointment twoArg = new Appointment(
// // // //             "Client Call",
// // // //             new DateTime(2026, 8, 12, 14, 0, 0)
// // // //         );


// // // //         // One-argument constructor
// // // //         Appointment oneArg = new Appointment("Follow Up");


// // // //         // Print details
// // // //         Console.WriteLine(
// // // //             $"Full: {full.Title} @ {full.Start:yyyy-MM-dd HH:mm}, " +
// // // //             $"{full.Duration.TotalMinutes:0} min, {full.Location}"
// // // //         );

// // // //         Console.WriteLine(
// // // //             $"Two-arg: {twoArg.Title} @ {twoArg.Start:yyyy-MM-dd HH:mm}, " +
// // // //             $"{twoArg.Duration.TotalMinutes:0} min, {twoArg.Location}"
// // // //         );

// // // //         Console.WriteLine(
// // // //             $"One-arg: {oneArg.Title} @ {oneArg.Start:yyyy-MM-dd}, " +
// // // //             $"(tomorrow, ~now), {oneArg.Duration.TotalMinutes:0} min, " +
// // // //             $"{oneArg.Location}"
// // // //         );

// // // //         Console.WriteLine(
// // // //             $"DefaultDurationMinutes: {Appointment.DefaultDurationMinutes}"
// // // //         );
// // // //     }
// // // // }

// // // using System;
// // // using System.Collections.Generic;

// // // public abstract class Employee
// // // {
// // //     public string Name { get; }
// // //     public decimal BaseSalary { get; }

// // //     protected Employee(string name, decimal baseSalary)
// // //     {
// // //         Name = name;
// // //         BaseSalary = baseSalary;
// // //     }

// // //     public abstract decimal CalculatePay();

// // //     public void PrintPaySlip()
// // //     {
// // //         Console.WriteLine($"{Name}: {CalculatePay():C}");
// // //     }
// // // }


// // // public class SalariedEmployee : Employee
// // // {
// // //     public SalariedEmployee(string name, decimal baseSalary) : base(name, baseSalary)
// // //     {
// // //     }

// // //     public override decimal CalculatePay()
// // //     {
// // //         return BaseSalary;
// // //     }
// // // }


// // // public class CommissionEmployee : Employee
// // // {
// // //     public decimal CommissionEarned;

// // //     public CommissionEmployee(string name, decimal baseSalary, decimal commission) : base(name, baseSalary)
// // //     {
// // //         CommissionEarned = commission;
// // //     }

// // //     public override decimal CalculatePay()
// // //     {
// // //         return BaseSalary + CommissionEarned;
// // //     }
// // // }


// // // class Program
// // // {
// // //     static void Main()
// // //     {
// // //         List<Employee> employees = new List<Employee>();

// // //         employees.Add(
// // //             new SalariedEmployee("Alice", 4500m)
// // //         );

// // //         employees.Add(
// // //             new SalariedEmployee("Bob", 3200m)
// // //         );

// // //         employees.Add(
// // //             new CommissionEmployee("Carla", 3500m, 650m)
// // //         );


// // //         foreach (Employee employee in employees)
// // //         {
// // //             employee.PrintPaySlip();
// // //         }

// // //     }
// // // }

// // using System;
// // public class Formatter
// // {
// //     public string Format(int value)
// //     {
// //         return value.ToString();
// //     }

// //     public string Format(double value)
// //     {
// //         return value.ToString("F2");
// //     }

// //     public string Format(int numerator, int denominator)
// //     {
// //         return $"{numerator}/{denominator}";
// //     }
// // }


// // public class Notifier
// // {
// //     public virtual void Send()
// //     {
// //         Console.WriteLine("Notifier: generic send");
// //     }

// //     public void Log()
// //     {
// //         Console.WriteLine("Notifier: generic log");
// //     }
// // }


// // public class EmailNotifier : Notifier
// // {
// //     public override void Send()
// //     {
// //         Console.WriteLine("EmailNotifier: sending email");
// //     }

// //     public new void Log()
// //     {
// //         Console.WriteLine("EmailNotifier: logging to email log");
// //     }
// // }


// // public struct Vector2
// // {
// //     public double X, Y;

// //     public Vector2(double x, double y)
// //     {
// //         X = x;
// //         Y = y;
// //     }

// //     // Operator +
// //     public static Vector2 operator +(Vector2 a, Vector2 b)
// //     {
// //         return new Vector2(
// //             a.X + b.X,
// //             a.Y + b.Y
// //         );
// //     }

// //     // Operator * for scalar multiplication
// //     public static Vector2 operator *(Vector2 vector, double scalar)
// //     {
// //         return new Vector2(
// //             vector.X * scalar,
// //             vector.Y * scalar
// //         );
// //     }

// //     public override string ToString()
// //     {
// //         return $"({X}, {Y})";
// //     }
// // }


// // class Program
// // {
// //     static void Main()
// //     {
// //         // Method overloading
// //         Formatter formatter = new Formatter();

// //         Console.WriteLine(
// //             $"Format(7) -> \"{formatter.Format(7)}\""
// //         );

// //         Console.WriteLine(
// //             $"Format(3.5) -> \"{formatter.Format(3.5)}\""
// //         );

// //         Console.WriteLine(
// //             $"Format(3, 4) -> \"{formatter.Format(3, 4)}\""
// //         );

// //         // Override vs method hiding

// //         EmailNotifier email = new EmailNotifier();

// //         Notifier notifier = email;


// //         Console.WriteLine();
// //         Console.WriteLine("-- through EmailNotifier variable --");

// //         email.Send();
// //         email.Log();

// //         Console.WriteLine();
// //         Console.WriteLine("-- through Notifier variable, same object --");

// //         notifier.Send();
// //         notifier.Log();

// //         // Operator overloading

// //         Console.WriteLine();

// //         Vector2 v1 = new Vector2(1, 2);
// //         Vector2 v2 = new Vector2(3, 4);

// //         Vector2 sum = v1 + v2;

// //         Console.WriteLine(
// //             $"{v1} + {v2} = {sum}"
// //         );


// //         Vector2 v3 = new Vector2(2, 2);

// //         Vector2 scaled = v3 * 3;

// //         Console.WriteLine(
// //             $"{v3} * 3 = {scaled}"
// //         );
// //     }
// // }

// using System;
// using System.Collections.Generic;
// public enum ShapeKind
// {
//     Circle,
//     Rectangle,
//     Triangle
// }

// public abstract class Shape
// {
//     public ShapeKind Kind { get; protected set; }

//     public abstract double Area();

//     public abstract double Perimeter();

//     public override string ToString()
//     {
//         return $"{Kind}: Area={Area():F2}, Perimeter={Perimeter():F2}";
//     }
// }

// public class Circle : Shape
// {
//     public double Radius { get; }

//     public Circle(double radius)
//     {
//         Radius = radius;
//         Kind = ShapeKind.Circle;
//     }

//     public override double Area()
//     {
//         return Math.PI * Radius * Radius;
//     }

//     public override double Perimeter()
//     {
//         return 2 * Math.PI * Radius;
//     }
// }

// public class Rectangle : Shape
// {
//     public double Width { get; }
//     public double Height { get; }

//     public Rectangle(double width, double height)
//     {
//         Width = width;
//         Height = height;
//         Kind = ShapeKind.Rectangle;
//     }

//     public override double Area()
//     {
//         return Width * Height;
//     }

//     public override double Perimeter()
//     {
//         return 2 * (Width + Height);
//     }
// }

// public class Triangle : Shape
// {
//     public double A { get; }
//     public double B { get; }
//     public double C { get; }

//     public Triangle(double a, double b, double c)
//     {
//         A = a;
//         B = b;
//         C = c;
//         Kind = ShapeKind.Triangle;
//     }

//     public override double Area()
//     {
//         double s = (A + B + C) / 2;

//         return Math.Sqrt(
//             s * (s - A) * (s - B) * (s - C)
//         );
//     }

//     public override double Perimeter()
//     {
//         return A + B + C;
//     }
// }

// public struct BoundingBox
// {
//     public double Width;
//     public double Height;

//     public BoundingBox(double w, double h)
//     {
//         Width = w;
//         Height = h;
//     }

//     public static BoundingBox operator *(
//         BoundingBox box,
//         double factor)
//     {
//         return new BoundingBox(
//             box.Width * factor,
//             box.Height * factor
//         );
//     }

//     public override string ToString()
//     {
//         return $"({Width:0}, {Height:0})";
//     }
// }

// public static class ShapeMath
// {
//     public static double TotalArea(IEnumerable<Shape> shapes)
//     {
//         double total = 0;

//         foreach (Shape shape in shapes)
//         {
//             total += shape.Area();
//         }

//         return total;
//     }

//     public static double TotalArea(
//         IEnumerable<Shape> shapes,
//         ShapeKind onlyKind)
//     {
//         double total = 0;

//         foreach (Shape shape in shapes)
//         {
//             if (shape.Kind == onlyKind)
//             {
//                 total += shape.Area();
//             }
//         }

//         return total;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Shape> shapes = new List<Shape>
//         {
//             new Circle(3),
//             new Rectangle(4, 6),
//             new Triangle(3, 4, 5)
//         };

//         foreach (Shape shape in shapes)
//         {
//             Console.WriteLine(shape);
//         }

//         double totalArea = ShapeMath.TotalArea(shapes);

//         Console.WriteLine();
//         Console.WriteLine(
//             $"Total area (all shapes): {totalArea:F2}"
//         );

//         double circleArea =
//             ShapeMath.TotalArea(shapes, ShapeKind.Circle);

//         Console.WriteLine(
//             $"Total area (circles only): {circleArea:F2}"
//         );

//         BoundingBox box = new BoundingBox(4, 3);

//         BoundingBox scaledBox = box * 2;

//         Console.WriteLine();
//         Console.WriteLine(
//             $"Scaled bounding box (4 x 3) * 2 -> {scaledBox}"
//         );
//     }
// }