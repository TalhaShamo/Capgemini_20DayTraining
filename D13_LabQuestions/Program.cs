// using System;

// public class InventoryItem
// {
//     private int _quantity;
//     private decimal _unitPrice;

//     public string Name { get; init; }

//     public int Quantity
//     {
//         get
//         {
//             return _quantity;
//         }
//         set
//         {
//             if (value < 0)
//             {
//                 throw new ArgumentException(
//                     "Quantity cannot be negative"
//                 );
//             }

//             _quantity = value;
//         }
//     }

//     public decimal UnitPrice
//     {
//         get
//         {
//             return _unitPrice;
//         }
//         set
//         {
//             if (value <= 0)
//             {
//                 throw new ArgumentException(
//                     "UnitPrice must be greater than zero"
//                 );
//             }

//             _unitPrice = value;
//         }
//     }

//     public decimal TotalValue
//     {
//         get
//         {
//             return Quantity * UnitPrice;
//         }
//     }

//     public InventoryItem(
//         string name,
//         int quantity,
//         decimal unitPrice)
//     {
//         if (string.IsNullOrWhiteSpace(name))
//         {
//             throw new ArgumentException(
//                 "Name cannot be null or whitespace"
//             );
//         }

//         Name = name;
//         Quantity = quantity;
//         UnitPrice = unitPrice;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         InventoryItem item = new InventoryItem(
//             "Keyboard",
//             3,
//             45.00m
//         );

//         Console.WriteLine(
//             $"Created: {item.Name}, Qty={item.Quantity}, " +
//             $"Price=${item.UnitPrice:F2}, Total=${item.TotalValue:F2}"
//         );

//         try
//         {
//             item.Quantity = -5;
//         }
//         catch (ArgumentException ex)
//         {
//             Console.WriteLine(
//                 $"Caught expected error setting Quantity=-5: {ex.Message}"
//             );
//         }

//         try
//         {
//             item.UnitPrice = 0;
//         }
//         catch (ArgumentException ex)
//         {
//             Console.WriteLine(
//                 $"Caught expected error setting UnitPrice=0: {ex.Message}"
//             );
//         }
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public abstract class NotificationChannel
// {
//     public bool TrySend(string message)
//     {
//         try
//         {
//             return Send(message);
//         }
//         catch
//         {
//             return false;
//         }
//     }

//     protected abstract bool Send(string message);
// }

// public class EmailChannel : NotificationChannel
// {
//     protected override bool Send(string message)
//     {
//         return true;
//     }
// }

// public class SmsChannel : NotificationChannel
// {
//     protected override bool Send(string message)
//     {
//         if (message.Length > 160)
//         {
//             throw new Exception("SMS message is too long");
//         }

//         return true;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<NotificationChannel> channels =
//             new List<NotificationChannel>
//             {
//                 new EmailChannel(),
//                 new SmsChannel(),
//                 new EmailChannel(),
//                 new SmsChannel()
//             };

//         string shortMessage = "Hello, this is a short message.";

//         string longMessage = new string('A', 161);

//         var results = new[]
//         {
//             new
//             {
//                 Channel = channels[0],
//                 Success = channels[0].TrySend(shortMessage)
//             },

//             new
//             {
//                 Channel = channels[1],
//                 Success = channels[1].TrySend(shortMessage)
//             },

//             new
//             {
//                 Channel = channels[2],
//                 Success = channels[2].TrySend(shortMessage)
//             },

//             new
//             {
//                 Channel = channels[3],
//                 Success = channels[3].TrySend(longMessage)
//             }
//         };

//         var report = results.Select(x => new
//         {
//             ChannelType = x.Channel.GetType().Name,
//             Success = x.Success
//         });

//         foreach (var entry in report)
//         {
//             Console.WriteLine(
//                 $"{entry.ChannelType}: " +
//                 $"{(entry.Success ? "Success" : "Failed")}"
//             );
//         }

//         int succeeded = report.Count(x => x.Success);
//         int failed = report.Count(x => !x.Success);

//         Console.WriteLine();
//         Console.WriteLine($"Succeeded: {succeeded}, Failed: {failed}");
//     }
// }


// using System;

// public class TaxCalculator
// {
//     public virtual decimal CalculateTax(decimal amount)
//     {
//         return amount * 0.10m;
//     }
// }

// public class RegionalTaxCalculator : TaxCalculator
// {
//     public sealed override decimal CalculateTax(decimal amount)
//     {
//         return amount * 0.12m;
//     }
// }
// public sealed class FixedDiscountCalculator
// {
//     public decimal ApplyDiscount(decimal price)
//     {
//         return price * 0.9m;
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         RegionalTaxCalculator regional =
//             new RegionalTaxCalculator();

//         decimal tax = regional.CalculateTax(200);

//         Console.WriteLine(
//             $"RegionalTaxCalculator.CalculateTax(200) -> {tax:F2}"
//         );

//         FixedDiscountCalculator discount =
//             new FixedDiscountCalculator();

//         decimal discountedPrice =
//             discount.ApplyDiscount(50);

//         Console.WriteLine(
//             $"FixedDiscountCalculator.ApplyDiscount(50) -> {discountedPrice:F2}"
//         );
//     }
// }


// using System;

// public interface IVehicle
// {
//     string Model { get; }

//     void Drive();
// }

// public interface IElectric
// {
//     int BatteryPercent { get; set; }

//     void Charge();
// }

// public interface IElectricVehicle : IVehicle, IElectric
// {
// }

// public class ElectricCar : IElectricVehicle
// {
//     public string Model { get; init; }

//     private int _batteryPercent;

//     public int BatteryPercent
//     {
//         get
//         {
//             return _batteryPercent;
//         }
//         set
//         {
//             if (value < 0)
//             {
//                 _batteryPercent = 0;
//             }
//             else if (value > 100)
//             {
//                 _batteryPercent = 100;
//             }
//             else
//             {
//                 _batteryPercent = value;
//             }
//         }
//     }

//     public void Drive()
//     {
//         BatteryPercent -= 10;
//     }

//     public void Charge()
//     {
//         BatteryPercent = 100;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         ElectricCar car = new ElectricCar
//         {
//             Model = "Tesla Model 3",
//             BatteryPercent = 100
//         };

//         car.Drive();
//         Console.WriteLine(
//             $"Battery after drive 1: {car.BatteryPercent}%"
//         );

//         car.Drive();
//         Console.WriteLine(
//             $"Battery after drive 2: {car.BatteryPercent}%"
//         );

//         car.Drive();
//         Console.WriteLine(
//             $"Battery after drive 3: {car.BatteryPercent}%"
//         );

//         car.Charge();
//         Console.WriteLine(
//             $"Battery after charge: {car.BatteryPercent}%"
//         );

//         IVehicle vehicle = car;

//         Console.WriteLine(
//             $"As IVehicle - Model: {vehicle.Model}"
//         );

//         IElectric electric = car;

//         Console.WriteLine(
//             $"As IElectric - BatteryPercent: {electric.BatteryPercent}%"
//         );
//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;

public interface IIdentifiable
{
    string Id { get; }
}

public interface IPaymentMethod : IIdentifiable
{
    string DisplayName { get; }

    PaymentResult Charge(decimal amount);
}

public class PaymentResult
{
    public bool Success { get; }
    public string Message { get; }

    public PaymentResult(bool success, string message)
    {
        if (message == null)
        {
            throw new ArgumentException(
                "Message cannot be null"
            );
        }

        Success = success;
        Message = message;
    }
}

public abstract class PaymentMethodBase : IPaymentMethod
{
    public string Id { get; }
    public string DisplayName { get; }

    protected PaymentMethodBase(
        string id,
        string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    public abstract PaymentResult Charge(decimal amount);
}

public class CreditCardPayment : PaymentMethodBase
{
    public CreditCardPayment(
        string id,
        string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(decimal amount)
    {
        if (amount > 5000)
        {
            return new PaymentResult(
                false,
                "Credit card limit exceeded"
            );
        }

        return new PaymentResult(
            true,
            "Credit card payment successful"
        );
    }
}

public sealed class CashPayment : PaymentMethodBase
{
    public CashPayment(
        string id,
        string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(decimal amount)
    {
        return new PaymentResult(
            true,
            "Cash payment successful"
        );
    }
}

class Program
{
    static void Main()
    {
        List<IPaymentMethod> paymentMethods =
            new List<IPaymentMethod>
            {
                new CreditCardPayment(
                    "CC001",
                    "Visa Credit Card"
                ),

                new CashPayment(
                    "CASH001",
                    "Cash"
                ),

                new CreditCardPayment(
                    "CC002",
                    "Mastercard"
                )
            };

        var report = new List<object>();

        decimal[] amounts =
        {
            2500m,
            6000m
        };

        foreach (IPaymentMethod paymentMethod in paymentMethods)
        {
            foreach (decimal amount in amounts)
            {
                PaymentResult result =
                    paymentMethod.Charge(amount);

                report.Add(new
                {
                    Id = paymentMethod.Id,
                    DisplayName = paymentMethod.DisplayName,
                    AmountAttempted = amount,
                    Success = result.Success
                });
            }
        }

        foreach (dynamic entry in report)
        {
            Console.WriteLine(
                $"{entry.Id} | " +
                $"{entry.DisplayName} | " +
                $"Amount: ${entry.AmountAttempted:F2} | " +
                $"{(entry.Success ? "Success" : "Failed")}"
            );
        }

        decimal totalSettled =
            report
                .Cast<dynamic>()
                .Where(x => x.Success)
                .Sum(x => x.AmountAttempted);

        Console.WriteLine();
        Console.WriteLine(
            $"Total successfully settled: ${totalSettled:F2}"
        );
    }
}