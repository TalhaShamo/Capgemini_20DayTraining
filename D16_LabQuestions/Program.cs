using System;

class Program
{
    static int ParseAge(string input)
    {
        Console.WriteLine("Step 1");

        int age = int.Parse(input);

        if (age < 0 || age > 150)
        {
            throw new ArgumentOutOfRangeException(
                nameof(input),
                "Age must be between 0 and 150"
            );
        }

        Console.WriteLine("Step 2 (only if valid)");

        return age;
    }

    static void Main()
    {
        Console.WriteLine("-- ParseAge(\"abc\") --");

        try
        {
            ParseAge("abc");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                $"Caught FormatException: {ex.Message}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Caught general Exception: {ex.Message}"
            );
        }

        Console.WriteLine();


        Console.WriteLine("-- ParseAge(\"200\") --");

        try
        {
            ParseAge("200");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(
                $"Caught ArgumentOutOfRangeException " +
                $"(most specific, ran first): {ex.Message}"
            );
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                $"Caught ArgumentException: {ex.Message}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Caught general Exception: {ex.Message}"
            );
        }

        Console.WriteLine();


        Console.WriteLine("-- ParseAge(\"30\") --");

        try
        {
            int result = ParseAge("30");
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }
    }
}


// using System;

// class Program
// {
//     static void Process(int mode)
//     {
//         Console.WriteLine("Opening");

//         try
//         {
//             if (mode == 1)
//             {
//                 throw new InvalidOperationException(
//                     "Simulated failure"
//                 );
//             }

//             Console.WriteLine("Working");

//             if (mode == 2)
//             {
//                 return;
//             }

//             Console.WriteLine("Finishing normally");
//         }
//         finally
//         {
//             Console.WriteLine("Closing");
//         }
//     }

//     class FakeFileHandle : IDisposable
//     {
//         public FakeFileHandle()
//         {
//             Console.WriteLine("Handle opened");
//         }

//         public void Dispose()
//         {
//             Console.WriteLine("Handle closed");
//         }
//     }

//     static void UseFakeFile()
//     {
//         using (FakeFileHandle handle = new FakeFileHandle())
//         {
//             Console.WriteLine("Working with handle");

//             throw new Exception(
//                 "Simulated resource failure"
//             );
//         }
//     }

//     static void Main()
//     {
//         Console.WriteLine("-- Process(0) --");

//         Process(0);

//         Console.WriteLine();


//         Console.WriteLine("-- Process(1) --");

//         try
//         {
//             Process(1);
//         }
//         catch (InvalidOperationException ex)
//         {
//             Console.WriteLine($"Caught: {ex.Message}");
//         }

//         Console.WriteLine();


//         Console.WriteLine("-- Process(2) --");

//         Process(2);

//         Console.WriteLine();


//         Console.WriteLine("-- using / IDisposable --");

//         try
//         {
//             UseFakeFile();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Caught: {ex.Message}");
//         }
//     }
// }


// using System;

// class Program
// {
//     static int DivideInternal(int a, int b)
//     {
//         if (b == 0)
//         {
//             throw new DivideByZeroException(
//                 "Cannot divide by zero in DivideInternal"
//             );
//         }

//         return a / b;
//     }

//     static int CallSiteGood(int a, int b)
//     {
//         try
//         {
//             return DivideInternal(a, b);
//         }
//         catch (DivideByZeroException)
//         {
//             Console.WriteLine(
//                 "[Good] Logging before rethrow..."
//             );

//             throw;
//         }
//     }

//     static int CallSiteBad(int a, int b)
//     {
//         try
//         {
//             return DivideInternal(a, b);
//         }
//         catch (DivideByZeroException ex)
//         {
//             Console.WriteLine(
//                 "[Bad] Logging before rethrow..."
//             );

//             throw ex;
//         }
//     }

//     static void Validate(int value)
//     {
//         if (value < 0)
//         {
//             throw new ArgumentOutOfRangeException(
//                 nameof(value),
//                 "Value cannot be negative."
//             );
//         }
//     }

//     static void Main()
//     {
//         try
//         {
//             CallSiteGood(10, 0);
//         }
//         catch (DivideByZeroException ex)
//         {
//             Console.WriteLine(
//                 "Good stack trace:"
//             );

//             Console.WriteLine(ex.StackTrace);
//             Console.WriteLine();
//         }


//         try
//         {
//             CallSiteBad(10, 0);
//         }
//         catch (DivideByZeroException ex)
//         {
//             Console.WriteLine(
//                 "Bad stack trace:"
//             );

//             Console.WriteLine(ex.StackTrace);
//             Console.WriteLine();
//         }


//         try
//         {
//             Validate(-5);
//         }
//         catch (ArgumentOutOfRangeException ex)
//         {
//             Console.WriteLine(
//                 $"Validate(-5) threw: {ex.Message}"
//             );
//         }
//     }
// }


// using System;

// class Program
// {
//     static string ReadRawConfigValue(string key)
//     {
//         if (key == "timeout")
//         {
//             throw new FormatException(
//                 "Value 'abc' is not a valid integer"
//             );
//         }

//         return "dummy-value";
//     }

//     static int GetTimeoutSetting()
//     {
//         try
//         {
//             string raw = ReadRawConfigValue("timeout");
//             return int.Parse(raw);
//         }
//         catch (FormatException ex)
//         {
//             throw new InvalidOperationException(
//                 "Application configuration is invalid",
//                 ex
//             );
//         }
//     }

//     static void PrintExceptionChain(Exception ex)
//     {
//         int depth = 0;

//         while (ex != null)
//         {
//             Console.WriteLine(
//                 $"{new string(' ', depth * 2)}" +
//                 $"{ex.GetType().Name}: {ex.Message}"
//             );

//             ex = ex.InnerException;
//             depth++;
//         }
//     }

//     static void Main()
//     {
//         try
//         {
//             GetTimeoutSetting();
//         }
//         catch (InvalidOperationException ex)
//         {
//             Console.WriteLine(
//                 $"Top-level: {ex.Message}"
//             );

//             if (ex.InnerException != null)
//             {
//                 Console.WriteLine(
//                     $"Caused by: {ex.InnerException.Message}"
//                 );

//                 Console.WriteLine(
//                     $"Inner exception type: " +
//                     $"{ex.InnerException.GetType().Name}"
//                 );
//             }

//             Console.WriteLine();

//             Console.WriteLine("-- PrintExceptionChain --");

//             PrintExceptionChain(ex);
//         }
//     }
// }


// using System;

// public class OrderValidationException : Exception
// {
//     public string FieldName { get; }

//     public OrderValidationException() : base() { }

//     public OrderValidationException(string message)
//         : base(message) { }

//     public OrderValidationException(string message, Exception inner)
//         : base(message, inner) { }

//     public OrderValidationException(string message, string fieldName)
//         : base(message)
//     {
//         FieldName = fieldName;
//     }
// }

// public class MissingFieldException : OrderValidationException
// {
//     public MissingFieldException(string fieldName)
//         : base($"Required field is missing: {fieldName}", fieldName)
//     {
//     }
// }

// public class InvalidQuantityException : OrderValidationException
// {
//     public InvalidQuantityException()
//         : base("Quantity must be greater than zero", "quantity")
//     {
//     }
// }

// public class Program
// {
//     static decimal ValidateOrder(
//         string customerName,
//         int quantity,
//         decimal unitPrice)
//     {
//         if (string.IsNullOrWhiteSpace(customerName))
//             throw new MissingFieldException("customerName");

//         if (quantity <= 0)
//             throw new InvalidQuantityException();

//         if (unitPrice < 0)
//             throw new OrderValidationException(
//                 "Unit price cannot be negative",
//                 "unitPrice"
//             );

//         return quantity * unitPrice;
//     }

//     static void SaveOrder(
//         string customerName,
//         int quantity,
//         decimal unitPrice)
//     {
//         throw new InvalidOperationException("Database unavailable");
//     }

//     static void ProcessOrder(
//         string customerName,
//         int quantity,
//         decimal unitPrice)
//     {
//         try
//         {
//             decimal total = ValidateOrder(
//                 customerName,
//                 quantity,
//                 unitPrice
//             );

//             try
//             {
//                 SaveOrder(customerName, quantity, unitPrice);
//                 Console.WriteLine($"Order total: {total:C}");
//             }
//             catch (InvalidOperationException ex)
//             {
//                 // We are creating a NEW exception, so throw; does not apply.
//                 // The original exception is preserved as InnerException.
//                 throw new OrderValidationException(
//                     "Could not save order",
//                     ex
//                 );
//             }
//         }
//         catch (MissingFieldException ex)
//         {
//             Console.WriteLine($"Missing field: {ex.FieldName}");
//         }
//         catch (InvalidQuantityException ex)
//         {
//             Console.WriteLine($"Invalid quantity for field: {ex.FieldName}");
//         }
//         catch (OrderValidationException ex)
//         {
//             string message = ex.Message;

//             if (ex.InnerException != null)
//                 message += $" (caused by: {ex.InnerException.Message})";

//             Console.WriteLine($"Order validation failed: {message}");
//         }
//         finally
//         {
//             Console.WriteLine("Order attempt complete.");
//         }
//     }

//     public static void Main()
//     {
//         Console.WriteLine("-- Missing customer name --");
//         ProcessOrder("", 2, 50m);

//         Console.WriteLine();

//         Console.WriteLine("-- Zero quantity --");
//         ProcessOrder("Alice", 0, 50m);

//         Console.WriteLine();

//         Console.WriteLine("-- Negative price --");
//         ProcessOrder("Alice", 2, -50m);

//         Console.WriteLine();

//         Console.WriteLine("-- Valid order, SaveOrder fails --");
//         ProcessOrder("Alice", 4, 49.99m);

//         Console.WriteLine();

//         Console.WriteLine("-- Fully valid order --");

//         try
//         {
//             decimal total = ValidateOrder("Alice", 4, 49.99m);
//             Console.WriteLine($"Order total: {total:C}");
//         }
//         finally
//         {
//             Console.WriteLine("Order attempt complete.");
//         }
//     }
// }