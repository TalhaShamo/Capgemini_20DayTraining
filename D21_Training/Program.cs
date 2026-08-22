using System;
using System.Collections.Generic;
using System.Linq;

public class SaleLineItem
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string StaffName { get; set; } = "";
    public string StoreLocation { get; set; } = "";
    public DateTime SoldAt { get; set; }

    public decimal LineTotal => UnitPrice * Quantity;
}

public abstract class Promotion
{
    public string Code { get; set; } = "";
}

public class PercentOffPromotion : Promotion
{
    public double PercentOff { get; set; }
}

public class FlatAmountPromotion : Promotion
{
    public decimal AmountOff { get; set; }
}

public class BuyOneGetOnePromotion : Promotion
{
}

public class ProductSales
{
    public string ProductName { get; set; } = "";
    public int TotalQuantity { get; set; }
}

public class CategoryRevenue
{
    public string Category { get; set; } = "";
    public decimal Revenue { get; set; }
}

public class StaffPerformance
{
    public string StaffName { get; set; } = "";
    public int SalesCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal AverageSaleValue { get; set; }
}

public class HourlySales
{
    public int Hour { get; set; }
    public int SaleCount { get; set; }
    public decimal Revenue { get; set; }
}

public class StorePerformance
{
    public string StoreLocation { get; set; } = "";
    public decimal Revenue { get; set; }
    public int ItemCount { get; set; }
    public string TopCategory { get; set; } = "";
}

public class InsightDesk
{
    private readonly List<SaleLineItem> sales;
    private readonly List<Promotion> promotions;

    public InsightDesk(
        List<SaleLineItem> sales,
        List<Promotion> promotions)
    {
        this.sales = sales;
        this.promotions = promotions;
    }

    /// <summary>
    /// Returns the top products ranked by total quantity sold.
    /// </summary>
    public IEnumerable<ProductSales> TopSellingProducts(int topN)
    {
        if (topN <= 0)
            return Enumerable.Empty<ProductSales>();

        return sales
            .GroupBy(s => s.ProductName)
            .Select(g => new ProductSales
            {
                ProductName = g.Key,
                TotalQuantity = g.Sum(s => s.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(topN);
    }

    /// <summary>
    /// Returns total revenue for each product category, ordered from highest to lowest revenue.
    /// </summary>
    public IEnumerable<CategoryRevenue> RevenueByCategory()
    {
        var query =
            from sale in sales
            group sale by sale.Category into categoryGroup
            let revenue = categoryGroup.Sum(s => s.LineTotal)
            orderby revenue descending
            select new CategoryRevenue
            {
                Category = categoryGroup.Key,
                Revenue = revenue
            };

        return query;
    }

    /// <summary>
    /// Returns sales count, total revenue, and average sale value for every staff member.
    /// </summary>
    public IEnumerable<StaffPerformance> StaffPerformanceReport()
    {
        return sales
            .GroupBy(s => s.StaffName)
            .Select(g => new StaffPerformance
            {
                StaffName = g.Key,
                SalesCount = g.Count(),
                TotalRevenue = g.Sum(s => s.LineTotal),
                AverageSaleValue = g.Average(s => s.LineTotal)
            })
            .OrderByDescending(x => x.TotalRevenue)
            .ThenBy(x => x.StaffName);
    }

    /// <summary>
    /// Returns sales count and revenue grouped by the hour of the sale.
    /// </summary>
    public IEnumerable<HourlySales> HourlySalesTrend()
    {
        var query =
            from sale in sales
            group sale by sale.SoldAt.Hour into hourGroup
            orderby hourGroup.Key
            select new HourlySales
            {
                Hour = hourGroup.Key,
                SaleCount = hourGroup.Count(),
                Revenue = hourGroup.Sum(s => s.LineTotal)
            };

        return query;
    }

    /// <summary>
    /// Returns percent-off promotions whose discount exceeds the supplied threshold.
    /// </summary>
    public IEnumerable<PercentOffPromotion> PercentOffPromotionsOver(double minPercent)
    {
        return promotions
            .OfType<PercentOffPromotion>()
            .Where(p => p.PercentOff > minPercent);
    }

    /// <summary>
    /// Returns categories whose total revenue is below the supplied threshold.
    /// </summary>
    public IEnumerable<CategoryRevenue> LowPerformingCategories(decimal revenueThreshold)
    {
        var query =
            from sale in sales
            group sale by sale.Category into categoryGroup
            let revenue = categoryGroup.Sum(s => s.LineTotal)
            where revenue < revenueThreshold
            orderby revenue ascending
            select new CategoryRevenue
            {
                Category = categoryGroup.Key,
                Revenue = revenue
            };

        return query;
    }

    /// <summary>
    /// Returns revenue, item count, and highest-revenue category for every store.
    /// </summary>
    public IEnumerable<StorePerformance> StoreComparisonReport()
    {
        return sales
            .GroupBy(s => s.StoreLocation)
            .Select(storeGroup =>
            {
                var topCategory = storeGroup
                    .GroupBy(s => s.Category)
                    .Select(categoryGroup => new
                    {
                        Category = categoryGroup.Key,
                        Revenue = categoryGroup.Sum(s => s.LineTotal)
                    })
                    .OrderByDescending(x => x.Revenue)
                    .FirstOrDefault();

                return new StorePerformance
                {
                    StoreLocation = storeGroup.Key,
                    Revenue = storeGroup.Sum(s => s.LineTotal),
                    ItemCount = storeGroup.Sum(s => s.Quantity),
                    TopCategory = topCategory?.Category ?? "None"
                };
            })
            .OrderByDescending(x => x.Revenue);
    }

    /// <summary>
    /// Demonstrates the difference between deferred execution and an immediately materialized snapshot.
    /// </summary>
    public IEnumerable<string> DeferredVsSnapshotDemo()
    {
        var output = new List<string>();

        var deferredQuery = sales.Where(s => s.Category == "Electronics");

        output.Add(
            $"Original sales count: {sales.Count}");

        var snapshot = sales
            .Where(s => s.Category == "Electronics")
            .ToList();

        sales.Add(new SaleLineItem
        {
            Id = 999,
            ProductName = "Late Added Laptop",
            Category = "Electronics",
            UnitPrice = 1200m,
            Quantity = 1,
            StaffName = "Alice",
            StoreLocation = "Delhi",
            SoldAt = new DateTime(2026, 8, 22, 18, 0, 0)
        });

        output.Add(
            $"Deferred query count after adding item: {deferredQuery.Count()}");

        output.Add(
            $"Snapshot count after adding item: {snapshot.Count}");

        output.Add(
            "The deferred query sees the newly added item, while the snapshot does not.");

        return output;
    }

    /// <summary>
    /// Implements the top-selling-products query using query syntax.
    /// </summary>
    public IEnumerable<ProductSales> TopSellingProductsQuerySyntax(int topN)
    {
        var query =
            from sale in sales
            group sale by sale.ProductName into productGroup
            let quantity = productGroup.Sum(s => s.Quantity)
            orderby quantity descending
            select new ProductSales
            {
                ProductName = productGroup.Key,
                TotalQuantity = quantity
            };

        return query.Take(topN);
    }

    /// <summary>
    /// Demonstrates the incorrect use of multiple OrderBy calls.
    /// </summary>
    public IEnumerable<StaffPerformance> BrokenStaffSort()
    {
        return sales
            .GroupBy(s => s.StaffName)
            .Select(g => new StaffPerformance
            {
                StaffName = g.Key,
                SalesCount = g.Count(),
                TotalRevenue = g.Sum(s => s.LineTotal),
                AverageSaleValue = g.Average(s => s.LineTotal)
            })
            .OrderByDescending(x => x.TotalRevenue)
            .OrderBy(x => x.StaffName);
    }
}

public class Program
{
    static List<SaleLineItem> SeedSales()
    {
        var sales = new List<SaleLineItem>();

        string[] products =
        {
            "Laptop",
            "Keyboard",
            "Mouse",
            "Monitor",
            "Phone",
            "Headphones",
            "Desk",
            "Chair"
        };

        string[] categories =
        {
            "Electronics",
            "Accessories",
            "Furniture",
            "Mobile"
        };

        string[] staff =
        {
            "Alice",
            "Bob",
            "Charlie"
        };

        string[] stores =
        {
            "Delhi",
            "Mumbai"
        };

        decimal[] prices =
        {
            70000m,
            2500m,
            1200m,
            18000m,
            45000m,
            5000m,
            9000m,
            12000m
        };

        int id = 1;

        for (int i = 0; i < 40; i++)
        {
            int productIndex = i % products.Length;

            sales.Add(new SaleLineItem
            {
                Id = id++,
                ProductName = products[productIndex],
                Category = categories[productIndex % categories.Length],
                UnitPrice = prices[productIndex],
                Quantity = (i % 5) + 1,
                StaffName = staff[i % staff.Length],
                StoreLocation = stores[i % stores.Length],
                SoldAt = new DateTime(
                    2026,
                    8,
                    22,
                    9 + (i % 10),
                    (i * 7) % 60,
                    0)
            });
        }

        return sales;
    }

    static List<Promotion> SeedPromotions()
    {
        return new List<Promotion>
        {
            new PercentOffPromotion
            {
                Code = "SAVE10",
                PercentOff = 10
            },
            new PercentOffPromotion
            {
                Code = "SAVE20",
                PercentOff = 20
            },
            new PercentOffPromotion
            {
                Code = "SAVE35",
                PercentOff = 35
            },
            new FlatAmountPromotion
            {
                Code = "FLAT500",
                AmountOff = 500
            },
            new FlatAmountPromotion
            {
                Code = "FLAT1000",
                AmountOff = 1000
            },
            new BuyOneGetOnePromotion
            {
                Code = "BOGO"
            }
        };
    }

    static void PrintHeader(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 60));
    }

    static void PrintTopProducts(IEnumerable<ProductSales> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine(
                $"{product.ProductName,-15} {product.TotalQuantity} units");
        }
    }

    static void PrintCategoryRevenue(IEnumerable<CategoryRevenue> categories)
    {
        foreach (var category in categories)
        {
            Console.WriteLine(
                $"{category.Category,-15} Rs.{category.Revenue:N2}");
        }
    }

    static void PrintStaffPerformance(IEnumerable<StaffPerformance> staff)
    {
        foreach (var employee in staff)
        {
            Console.WriteLine(
                $"{employee.StaffName,-10} " +
                $"Sales: {employee.SalesCount,-3} " +
                $"Revenue: Rs.{employee.TotalRevenue:N2} " +
                $"Average: Rs.{employee.AverageSaleValue:N2}");
        }
    }

    static void PrintHourlySales(IEnumerable<HourlySales> hours)
    {
        foreach (var hour in hours)
        {
            Console.WriteLine(
                $"{hour.Hour:00}:00 - " +
                $"Sales: {hour.SaleCount,-3} " +
                $"Revenue: Rs.{hour.Revenue:N2}");
        }
    }

    static void PrintStores(IEnumerable<StorePerformance> stores)
    {
        foreach (var store in stores)
        {
            Console.WriteLine(
                $"{store.StoreLocation,-10} " +
                $"Revenue: Rs.{store.Revenue:N2} | " +
                $"Items: {store.ItemCount,-3} | " +
                $"Top Category: {store.TopCategory}");
        }
    }

    static bool StaffReportsMatch(
        IEnumerable<StaffPerformance> first,
        IEnumerable<StaffPerformance> second)
    {
        return first
            .Zip(second, (a, b) =>
                a.StaffName == b.StaffName &&
                a.SalesCount == b.SalesCount &&
                a.TotalRevenue == b.TotalRevenue &&
                a.AverageSaleValue == b.AverageSaleValue)
            .All(x => x);
    }

    public static void Main()
    {
        List<SaleLineItem> sales = SeedSales();
        List<Promotion> promotions = SeedPromotions();

        InsightDesk engine = new InsightDesk(sales, promotions);

        PrintHeader("1. TOP SELLING PRODUCTS");

        var topProducts = engine.TopSellingProducts(5);

        PrintTopProducts(topProducts);


        PrintHeader("2. REVENUE BY CATEGORY");

        var categoryRevenue = engine.RevenueByCategory();

        PrintHeader("3. STAFF PERFORMANCE");

        var staffPerformance = engine.StaffPerformanceReport();

        PrintStaffPerformance(staffPerformance);


        PrintHeader("4. HOURLY SALES TREND");

        var hourlySales = engine.HourlySalesTrend();

        PrintHourlySales(hourlySales);


        PrintHeader("5. PERCENT-OFF PROMOTIONS ABOVE 15%");

        var promotionsOver15 =
            engine.PercentOffPromotionsOver(15);

        foreach (var promotion in promotionsOver15)
        {
            Console.WriteLine(
                $"{promotion.Code}: {promotion.PercentOff}% off");
        }


        PrintHeader("6. LOW-PERFORMING CATEGORIES");

        var lowCategories =
            engine.LowPerformingCategories(200000m);

        PrintCategoryRevenue(lowCategories);


        PrintHeader("7. STORE COMPARISON");

        var storeReport = engine.StoreComparisonReport();

        PrintStores(storeReport);


        PrintHeader("8. DEFERRED EXECUTION DEMO");

        var deferredDemo = engine.DeferredVsSnapshotDemo();

        foreach (var line in deferredDemo)
        {
            Console.WriteLine(line);
        }


        PrintHeader("QUERY SYNTAX vs METHOD SYNTAX");

        var methodVersion =
            engine.TopSellingProducts(10).ToList();

        var queryVersion =
            engine.TopSellingProductsQuerySyntax(10).ToList();

        bool equivalent =
            methodVersion.Count == queryVersion.Count &&
            methodVersion
                .Zip(queryVersion, (a, b) =>
                    a.ProductName == b.ProductName &&
                    a.TotalQuantity == b.TotalQuantity)
                .All(x => x);

        Console.WriteLine(
            $"Both implementations produce identical results: {equivalent}");


        PrintHeader("BROKEN STAFF SORT");

        Console.WriteLine(
            "Broken: .OrderByDescending(revenue).OrderBy(name)");
        Console.WriteLine(
            "The second OrderBy replaces the first ordering.");

        PrintStaffPerformance(engine.BrokenStaffSort());

        Console.WriteLine();
        Console.WriteLine("Correct: .OrderByDescending(revenue).ThenBy(name)");

        PrintStaffPerformance(
            engine.StaffPerformanceReport());


        PrintHeader("EDGE CASE: TOP 100 PRODUCTS");

        var manyProducts =
            engine.TopSellingProducts(100);

        PrintTopProducts(manyProducts);

        Console.WriteLine(
            "No exception occurs even when topN exceeds available products.");


        PrintHeader("EDGE CASE: PROMOTIONS ABOVE 999%");

        var impossiblePromotions =
            engine.PercentOffPromotionsOver(999);

        Console.WriteLine(
            $"Matching promotions: {impossiblePromotions.Count()}");


        PrintHeader("DEFERRED QUERY ENUMERATION");

        var storedHourlyQuery =
            engine.HourlySalesTrend();

        var storedCategoryQuery =
            engine.RevenueByCategory();

        Console.WriteLine(
            "Queries have been created but not enumerated.");

        Console.WriteLine(
            "Running another report before enumeration...");

        var staffReportAgain =
            engine.StaffPerformanceReport().ToList();

        Console.WriteLine(
            $"Staff report contains {staffReportAgain.Count} staff members.");

        Console.WriteLine();
        Console.WriteLine("Hourly query:");

        PrintHourlySales(storedHourlyQuery);

        Console.WriteLine();
        Console.WriteLine("Category query:");

        PrintCategoryRevenue(storedCategoryQuery);
    }
}