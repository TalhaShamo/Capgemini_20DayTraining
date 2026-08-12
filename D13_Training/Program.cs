using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class LogEntry
{
    public string Timestamp { get; set; }
    public string Level { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }

    public LogEntry(
        string timestamp,
        string level,
        string message,
        string exception = null)
    {
        Timestamp = timestamp;
        Level = level;
        Message = message;
        Exception = exception;
    }
}

public class LogProcessor
{
    private List<string> buffer = new List<string>();
    private List<LogEntry> errors = new List<LogEntry>();

    private int bufferCapacity;
    private string filePath;

    public LogProcessor(int bufferCapacity, string filePath)
    {
        this.bufferCapacity = bufferCapacity;
        this.filePath = filePath;

        File.WriteAllText(filePath, "");
    }

    public void Process(LogEntry entry)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("[")
               .Append(entry.Timestamp)
               .Append("] ")
               .Append(entry.Level)
               .Append(": ")
               .Append(entry.Message);

        if (!string.IsNullOrEmpty(entry.Exception))
        {
            builder.Append(" | ")
                   .Append(entry.Exception);
        }

        string log = builder.ToString();

        buffer.Add(log);

        if (entry.Level == "Error")
        {
            errors.Add(entry);
        }

        if (buffer.Count >= bufferCapacity)
        {
            Flush();
        }
    }

    public void Flush()
    {
        if (buffer.Count == 0)
            return;

        File.AppendAllLines(filePath, buffer);

        Console.WriteLine(
            $"Flushed {buffer.Count} log entries."
        );

        buffer.Clear();
    }

    public void PrintErrorSummary()
    {
        Console.WriteLine();
        Console.WriteLine("Error Summary");
        Console.WriteLine($"Total errors: {errors.Count}");

        foreach (LogEntry error in errors)
        {
            Console.WriteLine(
                $"[{error.Timestamp}] {error.Level}: {error.Message}"
            );
        }
    }
}

class Program
{
    static void Main()
    {
        LogProcessor processor =
            new LogProcessor(3, "application.log");

        processor.Process(
            new LogEntry(
                "2026-08-12 10:00:01",
                "Info",
                "Application started"
            )
        );

        processor.Process(
            new LogEntry(
                "2026-08-12 10:00:02",
                "Info",
                "User logged in"
            )
        );

        processor.Process(
            new LogEntry(
                "2026-08-12 10:00:03",
                "Warning",
                "Memory usage is high"
            )
        );

        processor.Process(
            new LogEntry(
                "2026-08-12 10:00:04",
                "Error",
                "Database connection failed",
                "TimeoutException"
            )
        );

        processor.Process(
            new LogEntry(
                "2026-08-12 10:00:05",
                "Info",
                "Request completed"
            )
        );

        processor.Flush();

        processor.PrintErrorSummary();
    }
}