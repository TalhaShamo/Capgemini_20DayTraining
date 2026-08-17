// // using System;
// // using System.Text.RegularExpressions;

// // class Program
// // {
// //     static void Main()
// //     {
// //         string zipPattern = @"^\d{5}(-\d{4})?$";

// //         Console.WriteLine(
// //             $"ZIP \"12345\": {Regex.IsMatch("12345", zipPattern)} | " +
// //             $"\"12345-6789\": {Regex.IsMatch("12345-6789", zipPattern)} | " +
// //             $"\"1234\": {Regex.IsMatch("1234", zipPattern)}"
// //         );


// //         string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";

// //         Console.WriteLine(
// //             $"Username \"user_1\": {Regex.IsMatch("user_1", usernamePattern)} | " +
// //             $"\"1user\": {Regex.IsMatch("1user", usernamePattern)} | " +
// //             $"\"ab\": {Regex.IsMatch("ab", usernamePattern)}"
// //         );


// //         string hexPattern = @"^#[0-9A-Fa-f]{6}$";

// //         Console.WriteLine(
// //             $"Hex \"#1A2B3C\": {Regex.IsMatch("#1A2B3C", hexPattern)} | " +
// //             $"\"#GGGGGG\": {Regex.IsMatch("#GGGGGG", hexPattern)} | " +
// //             $"\"1A2B3C\": {Regex.IsMatch("1A2B3C", hexPattern)}"
// //         );


// //         string passwordPattern =
// //             @"^(?=.*[A-Z])(?=.*\d).{8,}$";

// //         Console.WriteLine(
// //             $"Password \"password\": {Regex.IsMatch("password", passwordPattern)} | " +
// //             $"\"Password1\": {Regex.IsMatch("Password1", passwordPattern)} | " +
// //             $"\"pass1\": {Regex.IsMatch("pass1", passwordPattern)}"
// //         );


// //         string sentencePattern =
// //             @"^[^.!?]*[.!?]$";

// //         Console.WriteLine(
// //             $"Sentence \"Hello there.\": {Regex.IsMatch("Hello there.", sentencePattern)} | " +
// //             $"\"Wait...\": {Regex.IsMatch("Wait...", sentencePattern)} | " +
// //             $"\"Really?\": {Regex.IsMatch("Really?", sentencePattern)}"
// //         );
// //     }
// // }


// using System;
// using System.Text.RegularExpressions;

// class Program
// {
//     static void Main()
//     {
//         string text =
//             "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";

//         MatchCollection orders =
//             Regex.Matches(
//                 text,
//                 @"Order #(\d+)",
//                 RegexOptions.IgnoreCase
//             );

//         Console.Write("Order numbers found: ");

//         for (int i = 0; i < orders.Count; i++)
//         {
//             Console.Write(orders[i].Groups[1].Value);

//             if (i < orders.Count - 1)
//             {
//                 Console.Write(", ");
//             }
//         }

//         Console.WriteLine();


//         string cardText =
//             "Card on file: 4111-1111-1111-1234";

//         string maskedCard =
//             Regex.Replace(
//                 cardText,
//                 @"\d{4}[- ]\d{4}[- ]\d{4}[- ](\d{4})",
//                 "XXXX-XXXX-XXXX-$1"
//             );

//         Console.WriteLine($"Masked card: {maskedCard}");


//         string names = "Smith, John";

//         string reformattedName =
//             Regex.Replace(
//                 names,
//                 @"(\w+),\s*(\w+)",
//                 "$2 $1"
//             );

//         Console.WriteLine(
//             $"Reformatted name: {reformattedName}"
//         );


//         string tags =
//             "red, blue;green , yellow";

//         string[] tagsArray =
//             Regex.Split(tags, @"[,;]")
//                   .Select(tag => tag.Trim())
//                   .ToArray();

//         Console.WriteLine(
//             $"Tags: [{string.Join(", ", tagsArray)}]"
//         );
//     }
// }


// using System;
// using System.Text.RegularExpressions;
// using System.Globalization;

// class Program
// {
//     static void Main()
//     {
//         string logLine =
//             "2026-08-14 09:15:32 ERROR Connection timed out";

//         string logPattern =
//             @"^(?<date>\d{4}-\d{2}-\d{2}) " +
//             @"(?<time>\d{2}:\d{2}:\d{2}) " +
//             @"(?<level>\w+) " +
//             @"(?<message>.+)$";

//         Match logMatch = Regex.Match(logLine, logPattern);

//         Console.WriteLine(
//             $"date={logMatch.Groups["date"].Value}, " +
//             $"time={logMatch.Groups["time"].Value}, " +
//             $"level={logMatch.Groups["level"].Value}, " +
//             $"message={logMatch.Groups["message"].Value}"
//         );


//         string kvText =
//             "name=Alice;age=30;city=NYC";

//         string kvPattern =
//             @"(?<key>[^=;]+)=(?<value>[^;]+)";

//         MatchCollection pairs =
//             Regex.Matches(kvText, kvPattern);

//         foreach (Match pair in pairs)
//         {
//             Console.WriteLine(
//                 $"{pair.Groups["key"].Value}=" +
//                 $"{pair.Groups["value"].Value}"
//             );
//         }


//         string numbers =
//             "Revenue: 1234567, Costs: 89000";

//         string formattedNumbers =
//             Regex.Replace(
//                 numbers,
//                 @"\d+",
//                 match =>
//                 {
//                     long number =
//                         long.Parse(match.Value);

//                     return number.ToString(
//                         "N0",
//                         CultureInfo.InvariantCulture
//                     );
//                 }
//             );

//         Console.WriteLine(formattedNumbers);


//         string shouting =
//             "THIS IS URGENT please respond";

//         string convertedShouting =
//             Regex.Replace(
//                 shouting,
//                 @"\b[A-Z]{2,}\b",
//                 match =>
//                 {
//                     string word =
//                         match.Value.ToLower();

//                     return char.ToUpper(word[0]) +
//                            word.Substring(1);
//                 }
//             );

//         Console.WriteLine(convertedShouting);
//     }
// }


// using System;
// using System.Text.RegularExpressions;

// public static class PatternLibrary
// {
//     public static readonly Regex Email =
//         new Regex(
//             @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
//             RegexOptions.Compiled
//         );

//     public static readonly Regex UsPhone =
//         new Regex(
//             @"^\d{3}-\d{3}-\d{4}$",
//             RegexOptions.Compiled
//         );

//     public static readonly Regex HexColor =
//         new Regex(
//             @"^#[0-9A-Fa-f]{6}$",
//             RegexOptions.Compiled
//         );

//     public static bool IsValidEmail(string value)
//     {
//         return Email.IsMatch(value);
//     }

//     public static bool IsValidPhone(string value)
//     {
//         return UsPhone.IsMatch(value);
//     }

//     public static bool IsValidHexColor(string value)
//     {
//         return HexColor.IsMatch(value);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         string pattern = "hello";

//         bool ignoreCaseOff =
//             Regex.IsMatch("HELLO", pattern);

//         bool ignoreCaseOn =
//             Regex.IsMatch(
//                 "HELLO",
//                 pattern,
//                 RegexOptions.IgnoreCase
//             );

//         Console.WriteLine(
//             $"IgnoreCase off: {ignoreCaseOff}, " +
//             $"IgnoreCase on: {ignoreCaseOn}"
//         );


//         string lines =
//             "first line\nsecond line\nthird line";

//         int withoutMultiline =
//             Regex.Matches(lines, "^").Count;

//         int withMultiline =
//             Regex.Matches(
//                 lines,
//                 "^",
//                 RegexOptions.Multiline
//             ).Count;

//         Console.WriteLine(
//             $"Line-start matches WITHOUT Multiline: " +
//             $"{withoutMultiline}"
//         );

//         Console.WriteLine(
//             $"Line-start matches WITH Multiline: " +
//             $"{withMultiline}"
//         );


//         Console.WriteLine(
//             $"IsValidEmail(\"a@b.com\"): " +
//             $"{PatternLibrary.IsValidEmail("a@b.com")}, " +
//             $"IsValidEmail(\"not-an-email\"): " +
//             $"{PatternLibrary.IsValidEmail("not-an-email")}"
//         );

//         Console.WriteLine(
//             $"IsValidPhone(\"555-123-4567\"): " +
//             $"{PatternLibrary.IsValidPhone("555-123-4567")}, " +
//             $"IsValidPhone(\"5551234567\"): " +
//             $"{PatternLibrary.IsValidPhone("5551234567")}"
//         );

//         Console.WriteLine(
//             $"IsValidHexColor(\"#1A2B3C\"): " +
//             $"{PatternLibrary.IsValidHexColor("#1A2B3C")}, " +
//             $"IsValidHexColor(\"1A2B3C\"): " +
//             $"{PatternLibrary.IsValidHexColor("1A2B3C")}"
//         );
//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LogEntry
{
    public string Date { get; init; } = string.Empty;
    public string Time { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}

class Program
{
    public static List<LogEntry> ParseLog(string rawLog)
    {
        string pattern =
            @"^(?<date>\d{4}-\d{2}-\d{2}) " +
            @"(?<time>\d{2}:\d{2}:\d{2}) " +
            @"(?<level>INFO|WARN|ERROR) " +
            @"(?<message>.+)$";

        MatchCollection matches =
            Regex.Matches(
                rawLog,
                pattern,
                RegexOptions.Multiline
            );

        List<LogEntry> entries = new List<LogEntry>();

        foreach (Match match in matches)
        {
            LogEntry entry = new LogEntry
            {
                Date = match.Groups["date"].Value,
                Time = match.Groups["time"].Value,
                Level = match.Groups["level"].Value,
                Message = match.Groups["message"].Value
            };

            entries.Add(entry);
        }

        return entries;
    }

    public static string RedactErrorCodes(string rawLog)
    {
        string pattern =
            @"^.*\bERROR\b.*\bcode=(\d{3})\b.*$";

        return Regex.Replace(
            rawLog,
            pattern,
            match =>
            {
                return Regex.Replace(
                    match.Value,
                    @"code=\d{3}",
                    "code=###"
                );
            },
            RegexOptions.Multiline
        );
    }

    static void Main()
    {
        string rawLog =
            "2026-08-17 09:15:32 INFO Application started\n" +
            "2026-08-17 09:16:10 INFO User logged in\n" +
            "2026-08-17 09:17:45 WARN Memory usage is high\n" +
            "2026-08-17 09:18:20 ERROR Database connection failed code=500\n" +
            "2026-08-17 09:19:05 INFO Request processed successfully\n" +
            "2026-08-17 09:20:30 ERROR Page not found code=404";

        List<LogEntry> entries = ParseLog(rawLog);

        Console.WriteLine("Parsed log entries:");

        foreach (LogEntry entry in entries)
        {
            Console.WriteLine(
                $"{entry.Date} {entry.Time} " +
                $"{entry.Level} {entry.Message}"
            );
        }

        Console.WriteLine();

        var summary =
            entries
                .GroupBy(entry => entry.Level)
                .Select(group => new
                {
                    Level = group.Key,
                    Count = group.Count()
                });

        Console.WriteLine("Log summary:");

        foreach (var item in summary)
        {
            Console.WriteLine(
                $"{item.Level}: {item.Count}"
            );
        }

        Console.WriteLine();

        Console.WriteLine("Redacted log:");

        string redactedLog =
            RedactErrorCodes(rawLog);

        Console.WriteLine(redactedLog);
    }
}