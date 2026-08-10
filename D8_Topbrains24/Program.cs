using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    /*
     * Complete the 'gridlandMetro' function below.
     *
     * The function is expected to return a LONG INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     *  3. INTEGER k
     *  4. 2D_INTEGER_ARRAY track
     */

    public static long gridlandMetro(int n, int m, int k, List<List<int>> track)
    {
        // Total cells must be stored as a long to prevent integer overflow
        long totalCells = (long)n * m;
        
        // Dictionary to hold list of track intervals for each row
        Dictionary<int, List<long[]>> rowTracks = new Dictionary<int, List<long[]>>();
        
        foreach (var t in track)
        {
            int row = t[0];
            long c1 = t[1];
            long c2 = t[2];
            
            // Ensure c1 is the start and c2 is the end
            if (c1 > c2) 
            { 
                long temp = c1; c1 = c2; c2 = temp; 
            }
            
            if (!rowTracks.ContainsKey(row))
            {
                rowTracks[row] = new List<long[]>();
            }
                
            rowTracks[row].Add(new long[] { c1, c2 });
        }
        
        long occupiedCells = 0;
        
        foreach (var kvp in rowTracks)
        {
            // Sort intervals for the current row by their starting column
            var intervals = kvp.Value.OrderBy(x => x[0]).ToList();
            
            long currentStart = intervals[0][0];
            long currentEnd = intervals[0][1];
            
            for (int i = 1; i < intervals.Count; i++)
            {
                // If the next track overlaps with the current merged track
                if (intervals[i][0] <= currentEnd)
                {
                    // Extend the end if the overlapping track goes further
                    currentEnd = Math.Max(currentEnd, intervals[i][1]);
                }
                else
                {
                    // No overlap; add the finalized track length to our occupied count
                    occupiedCells += (currentEnd - currentStart + 1);
                    
                    // Reset current track to the new, separate track
                    currentStart = intervals[i][0];
                    currentEnd = intervals[i][1];
                }
            }
            
            // Add the final merged track for this row
            occupiedCells += (currentEnd - currentStart + 1);
        }
        
        return totalCells - occupiedCells;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int k = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> track = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            track.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(trackTemp => Convert.ToInt32(trackTemp)).ToList());
        }

        // Updated result to 'long'
        long result = Result.gridlandMetro(n, m, k, track);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}