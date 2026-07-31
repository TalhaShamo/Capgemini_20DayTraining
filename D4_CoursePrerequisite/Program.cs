using System;
using System.Collections.Generic;

public class CourseSystem
{
    private int totalCourses;
    private List<int>[] adj;
    private List<int>[] prereqs;

    public CourseSystem(int courses)
    {
        totalCourses = courses;
        adj = new List<int>[courses];
        prereqs = new List<int>[courses];

        for (int i = 0; i < courses; i++)
        {
            adj[i] = new List<int>();
            prereqs[i] = new List<int>();
        }
    }

    public void AddPrerequisite(int prerequisite, int course)
    {
        adj[prerequisite].Add(course);
        prereqs[course].Add(prerequisite);
    }

    public List<int> GetAllPrerequisites(int course)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        foreach (int p in prereqs[course])
        {
            queue.Enqueue(p);
            visited.Add(p);
        }

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            foreach (int p in prereqs[current])
            {
                if (!visited.Contains(p))
                {
                    visited.Add(p);
                    queue.Enqueue(p);
                }
            }
        }

        List<int> result = new List<int>(visited);
        result.Sort();
        return result;
    }

    public List<int> GetDirectPrerequisites(int course)
    {
        return new List<int>(prereqs[course]);
    }

    public bool HasCycle()
    {
        int[] inDegree = new int[totalCourses];
        for (int i = 0; i < totalCourses; i++)
        {
            foreach (int neighbor in adj[i])
            {
                inDegree[neighbor]++;
            }
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < totalCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        int count = 0;
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            count++;

            foreach (int neighbor in adj[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return count != totalCourses;
    }

    public List<int> GetTopologicalOrder()
    {
        int[] inDegree = new int[totalCourses];
        for (int i = 0; i < totalCourses; i++)
        {
            foreach (int neighbor in adj[i])
            {
                inDegree[neighbor]++;
            }
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < totalCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        List<int> order = new List<int>();
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            order.Add(current);

            foreach (int neighbor in adj[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return order;
    }

    public List<int> GetCoursesWithNoPrerequisites()
    {
        List<int> result = new List<int>();
        for (int i = 0; i < totalCourses; i++)
        {
            if (prereqs[i].Count == 0)
            {
                result.Add(i);
            }
        }
        return result;
    }

    public int CountDirectDependents(int course)
    {
        return adj[course].Count;
    }
}

public class Program
{
    public static void Main()
    {
        CourseSystem system = new CourseSystem(6);

        system.AddPrerequisite(0, 1);
        system.AddPrerequisite(0, 2);
        system.AddPrerequisite(1, 3);
        system.AddPrerequisite(2, 3);
        system.AddPrerequisite(2, 4);
        system.AddPrerequisite(3, 5);
        system.AddPrerequisite(4, 5);

        List<int> allPrereqsCourse5 = system.GetAllPrerequisites(5);
        Console.WriteLine("All prerequisites for Course 5: " + string.Join(", ", allPrereqsCourse5));

        List<int> directPrereqsCourse3 = system.GetDirectPrerequisites(3);
        Console.WriteLine("Direct prerequisites for Course 3: " + string.Join(", ", directPrereqsCourse3));

        bool hasCycle = system.HasCycle();
        Console.WriteLine("Graph has cycle: " + hasCycle);

        if (!hasCycle)
        {
            List<int> order = system.GetTopologicalOrder();
            Console.WriteLine("Course order (Topological Sort): " + string.Join(" -> ", order));
        }

        List<int> noPrereqs = system.GetCoursesWithNoPrerequisites();
        Console.WriteLine("Courses with no prerequisites: " + string.Join(", ", noPrereqs));

        int dependentsOfCourse2 = system.CountDirectDependents(2);
        Console.WriteLine("Number of courses directly depending on Course 2: " + dependentsOfCourse2);
    }
}