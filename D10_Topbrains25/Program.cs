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
     * Complete the 'aVeryBigSum' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER_ARRAY ar as parameter.
     */

    public long aVeryBigSum(List<long> ar)
    {
        long finalSum = 0;
        foreach(var v in ar){
            finalSum += v;
        }
        return finalSum;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        List<long> listArr = new List<long>{30000000001, 40000000003, 800000009};
        Result obj = new Result();
        long sum = obj.aVeryBigSum(listArr); 
        Console.WriteLine(sum);
    }
}
