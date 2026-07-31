using System;
using System.Collections.Generic;

public class SocialNetwork
{
    private int totalUsers;
    private List<int>[] adj;

    public SocialNetwork(int users)
    {
        totalUsers = users;
        adj = new List<int>[users];
        for (int i = 0; i < users; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddFriendship(int user1, int user2)
    {
        adj[user1].Add(user2);
        adj[user2].Add(user1);
    }

    public List<int> GetFriends(int user)
    {
        return new List<int>(adj[user]);
    }

    public bool AreConnected(int start, int end)
    {
        bool[] visited = new bool[totalUsers];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current == end) return true;

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    public List<int> GetShortestPath(int start, int end)
    {
        bool[] visited = new bool[totalUsers];
        int[] parent = new int[totalUsers];
        for (int i = 0; i < totalUsers; i++) parent[i] = -1;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current == end) break;

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        List<int> path = new List<int>();
        if (!visited[end]) return path;

        for (int at = end; at != -1; at = parent[at])
        {
            path.Add(at);
        }
        path.Reverse();

        return path;
    }

    public List<int> GetUsersAtDistance(int start, int targetDistance)
    {
        int[] distance = new int[totalUsers];
        for (int i = 0; i < totalUsers; i++) distance[i] = -1;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        distance[start] = 0;

        List<int> result = new List<int>();

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (distance[current] == targetDistance)
            {
                result.Add(current);
                continue;
            }

            foreach (int neighbor in adj[current])
            {
                if (distance[neighbor] == -1)
                {
                    distance[neighbor] = distance[current] + 1;
                    queue.Enqueue(neighbor);
                }
            }
        }

        result.Sort();
        return result;
    }

    public bool HasCycle()
    {
        bool[] visited = new bool[totalUsers];

        for (int i = 0; i < totalUsers; i++)
        {
            if (!visited[i])
            {
                if (HasCycleDFS(i, -1, visited))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool HasCycleDFS(int current, int parent, bool[] visited)
    {
        visited[current] = true;

        foreach (int neighbor in adj[current])
        {
            if (!visited[neighbor])
            {
                if (HasCycleDFS(neighbor, current, visited))
                {
                    return true;
                }
            }
            else if (neighbor != parent)
            {
                return true;
            }
        }

        return false;
    }

    public List<List<int>> GetConnectedComponents()
    {
        bool[] visited = new bool[totalUsers];
        List<List<int>> components = new List<List<int>>();

        for (int i = 0; i < totalUsers; i++)
        {
            if (!visited[i])
            {
                List<int> component = new List<int>();
                Queue<int> queue = new Queue<int>();

                queue.Enqueue(i);
                visited[i] = true;

                while (queue.Count > 0)
                {
                    int current = queue.Dequeue();
                    component.Add(current);

                    foreach (int neighbor in adj[current])
                    {
                        if (!visited[neighbor])
                        {
                            visited[neighbor] = true;
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                component.Sort();
                components.Add(component);
            }
        }

        return components;
    }
}

public class Program
{
    public static void Main()
    {
        SocialNetwork network = new SocialNetwork(6);

        network.AddFriendship(0, 1);
        network.AddFriendship(0, 2);
        network.AddFriendship(1, 3);
        network.AddFriendship(2, 3);
        network.AddFriendship(2, 4);
        network.AddFriendship(3, 5);
        network.AddFriendship(4, 5);

        List<int> friendsOf2 = network.GetFriends(2);
        Console.WriteLine("Friends of User 2: " + string.Join(", ", friendsOf2));

        bool connected0and5 = network.AreConnected(0, 5);
        Console.WriteLine("User 0 and User 5 are connected: " + connected0and5);

        List<int> shortestPath = network.GetShortestPath(0, 5);
        Console.WriteLine("Shortest path (0 to 5): " + string.Join(" -> ", shortestPath) + 
                          " (Distance: " + (shortestPath.Count - 1) + ")");

        List<int> distance2From1 = network.GetUsersAtDistance(1, 2);
        Console.WriteLine("Users at distance 2 from User 1: " + string.Join(", ", distance2From1));

        bool hasCycle = network.HasCycle();
        Console.WriteLine("Network has a cycle: " + hasCycle);

        List<List<int>> components = network.GetConnectedComponents();
        Console.WriteLine("Connected components (Friend groups):");
        for (int i = 0; i < components.Count; i++)
        {
            Console.WriteLine("  Group " + (i + 1) + ": " + string.Join(", ", components[i]));
        }
    }
}