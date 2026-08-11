// // // using System;
// // // namespace D11_Training
// // // {
// // //     class Program
// // //     {
// // //         static void Main()
// // //         {
// // //             string original = "  Hello, Training Team!  ";

// // //             // TODO 1: Trim the string into a new variable `trimmed`
// // //             string trimmed = original.Trim();

// // //             // TODO 2: Compare original vs trimmed with object.ReferenceEquals and print the result
// // //             bool isSameObject = object.ReferenceEquals(original, trimmed);
// // //             Console.WriteLine($"ReferenceEquals(original, trimmed): {isSameObject}");

// // //             // TODO 3: Contains / StartsWith / IndexOf / Replace checks
// // //             bool containsTraining = trimmed.Contains("Training");
// // //             bool startsWithHello = trimmed.StartsWith("Hello");
// // //             int firstCommaIndex = trimmed.IndexOf(',');
// // //             string replacedString = trimmed.Replace("Training Team", "Engineering Team");

// // //             Console.WriteLine($"Contains \"Training\": {containsTraining}");
// // //             Console.WriteLine($"StartsWith trimmed \"Hello\": {startsWithHello}");
// // //             Console.WriteLine($"Index of first comma: {firstCommaIndex}");
// // //             Console.WriteLine($"\"Training Team\" replaced -> {replacedString}");

// // //             // TODO 4: Split into words and print each on its own line
// // //             char[] separators = { ' ', ',' };
// // //             string[] words = trimmed.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
// // //             foreach (string word in words)
// // //             {
// // //                 Console.WriteLine(word);
// // //             }

// // //             // TODO 5: IsNullOrWhiteSpace checks for null, "", "   ", "ok"
// // //             Console.WriteLine($"IsNullOrWhiteSpace(null): {string.IsNullOrWhiteSpace(null)}");
// // //             Console.WriteLine($"IsNullOrWhiteSpace(\"\"): {string.IsNullOrWhiteSpace("")}");
// // //             // Note: I matched the three spaces you provided in your expected output "   "
// // //             Console.WriteLine($"IsNullOrWhiteSpace(\"   \"): {string.IsNullOrWhiteSpace("   ")}");
// // //             Console.WriteLine($"IsNullOrWhiteSpace(\"ok\"): {string.IsNullOrWhiteSpace("ok")}");
// // //         }
// // //     }
// // // }

// // using System;
// // using System.Diagnostics;
// // using System.Text;

// // namespace LabExercises
// // {
// //     class Lab2
// //     {
// //         static string BuildWithString(int count)
// //         {
// //             string result = "";
// //             for (int i = 0; i < count; i++)
// //             {
// //                 result += i.ToString();
// //             }
// //             return result;
// //         }

// //         static string BuildWithStringBuilder(int count)
// //         {
// //             // Pre-size capacity to avoid resizing overhead. 
// //             // Assuming an average of ~6 characters per number.
// //             StringBuilder sb = new StringBuilder(count * 6);
// //             for (int i = 0; i < count; i++)
// //             {
// //                 sb.Append(i.ToString());
// //             }
// //             return sb.ToString();
// //         }

// //         static void RunBenchmark(int count)
// //         {
// //             // 1. Time standard string concatenation
// //             Stopwatch sw = Stopwatch.StartNew();
// //             BuildWithString(count);
// //             sw.Stop();
// //             long stringTime = sw.ElapsedMilliseconds;

// //             // 2. Time StringBuilder
// //             sw.Restart();
// //             BuildWithStringBuilder(count);
// //             sw.Stop();
// //             long sbTime = sw.ElapsedMilliseconds;

// //             // Prevent divide-by-zero if StringBuilder executes in < 1 ms
// //             long safeSbTime = Math.Max(sbTime, 1);
// //             long ratio = stringTime / safeSbTime;

// //             // 3. Print Results formatted to match expected output
// //             Console.WriteLine($"String concatenation ({count:N0} items): {stringTime} ms");
// //             Console.WriteLine($"StringBuilder ({count:N0} items):        {sbTime} ms");
// //             Console.WriteLine($"StringBuilder is roughly {ratio}x faster on this run\n");
// //         }

// //         static void Main(string[] args)
// //         {
// //             // Step 4 & 5: Time both methods for count = 50,000
// //             RunBenchmark(50_000);
// //         }
// //     }
// // }

// using System;
// using System.Text;
// namespace D11_Training
// {
//     static class StringToolkit
//     {
//         public static string ReverseString(string input)
//         {
//             char[] charArr = input.ToCharArray();
//             charArr.Reverse();
//             string reversedString = new string(charArr);

//             return reversedString;
//         }
//         public static int CountChar(string text, char searchChar)
//         {
//             int count = 0;
//             for(int i=0; i<text.Length; i++)
//             {
//                 if(text[i] == searchChar)
//                 {
//                     count++;
//                 }
//             }
//             return count;
//         }
//         public static string RemoveDuplicates(string input)
//         {
//             HashSet<char> seenChar = new HashSet<char>();
//             StringBuilder sb = new StringBuilder();
//             foreach(var v in input)
//             {
//                 if (seenChar.Add(v))
//                 {
//                     sb.Append(v);
//                 }
//             }
//             string newString = sb.ToString();
//             return sb.ToString();
//         }
//         public static bool IsPalindrome(string input)
//         {
//             string cleaned = input.Replace(" ", "").ToLower();
            
//             string reversed = ReverseString(cleaned);
            
//             return cleaned == reversed;
//         }
//         public static string ToTitleCase(string input)
//         {
//             string[] words =  input.Split(' ');
//             for(int i=0; i<words.Length; i++)
//             {
//                 string word = words[i];
//                 words[i] = char.ToUpper(word[0]) + word.Substring(1).ToLower();
//             }
//             return string.Join(" ", words);
//         }
//         public static string ExtractNumbers(string input)
//         {
//             StringBuilder sb = new StringBuilder();
            
//             foreach (char c in input)
//             {
//                 if (char.IsDigit(c))
//                 {
//                     sb.Append(c);
//                 }
//             }
            
//             return sb.ToString();
//         }
//     }
//     class Program
//     {
//         static void Main()
//         {
//             string greetings = "Hello";
//             Console.WriteLine($"Reverse(\"{greetings}\") -> \"{StringToolkit.ReverseString(greetings)}\"");

//             string fruit = "banana";
//             Console.WriteLine($"CountChar(\"{fruit}\", 'a') -> {StringToolkit.CountChar(fruit, 'a')}");

//             string duplicates = "mississippi";
//             Console.WriteLine($"RemoveDuplicates(\"{duplicates}\") -> \"{StringToolkit.RemoveDuplicates(duplicates)}\"");

//             string palindrome = "race car";
//             Console.WriteLine($"IsPalindrome(\"{palindrome}\") -> {StringToolkit.IsPalindrome(palindrome)}");

//             string titleTarget = "hello training team";
//             Console.WriteLine($"ToTitleCase(\"{titleTarget}\") -> \"{StringToolkit.ToTitleCase(titleTarget)}\"");

//             string textWithNumbers = "Order #4521, qty 3";
//             Console.WriteLine($"ExtractNumbers(\"{textWithNumbers}\") -> \"{StringToolkit.ExtractNumbers(textWithNumbers)}\"");
//         }
//     }
// }

using System;
using System.Text;

namespace LabExercises
{
    static class StringToolkit
    {
        public static string ToTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                words[i] = char.ToUpper(word[0]) + word.Substring(1).ToLower();
            }
            return string.Join(" ", words);
        }
    }

    class Lab4
    {
        static void Main()
        {
            const string rawData = @"
            john smith|engineering|72000
            MARY jones|sales|65000
            ravi KUMAR|engineering|81000";

            // TODO 1: split into rows, skip blanks
            string[] rows = rawData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // TODO 3: build report with StringBuilder + PadRight/PadLeft + AppendLine
            StringBuilder sb = new StringBuilder();

            // Building the Header
            sb.AppendLine(new string('=', 50));
            sb.AppendLine("            EMPLOYEE COMPENSATION REPORT");
            sb.AppendLine(new string('=', 50));
            
            sb.Append("Name".PadRight(21));
            sb.Append("Department".PadRight(18));
            sb.AppendLine("Salary");
            
            sb.AppendLine(new string('-', 50));

            int employeeCount = 0;
            long totalSalary = 0;

            foreach (string row in rows)
            {
                // Defensive check to skip blank rows
                if (string.IsNullOrWhiteSpace(row)) continue;

                // TODO 2: split each row on '|' into name/department/salary
                string[] fields = row.Split('|');

                if (fields.Length == 3) // Ensure we have valid data
                {
                    // TODO 4: normalize names with StringToolkit.ToTitleCase
                    string name = StringToolkit.ToTitleCase(fields[0]);
                    string department = StringToolkit.ToTitleCase(fields[1]); // Normalizing department too!
                    int salary = int.Parse(fields[2]);

                    sb.Append(name.PadRight(21));
                    sb.Append(department.PadRight(18));
                    sb.AppendLine(salary.ToString("N0"));

                    employeeCount++;
                    totalSalary += salary;
                }
            }

            // TODO 5: append footer with total salary and employee count
            sb.AppendLine(new string('-', 50));
            sb.Append($"Employees: {employeeCount}".PadRight(18));
            sb.AppendLine($"Total Salary: {totalSalary:N0}");
            sb.AppendLine(new string('=', 50));

            // Print the final report
            Console.WriteLine(sb.ToString());

            // Print the performance confirmation
            Console.WriteLine("\n--- Performance Check ---");
            Console.WriteLine("StringBuilder Append/AppendLine calls in loop: 3 per employee");
            Console.WriteLine("String '+=' concatenations in loop: 0");
        }
    }
}