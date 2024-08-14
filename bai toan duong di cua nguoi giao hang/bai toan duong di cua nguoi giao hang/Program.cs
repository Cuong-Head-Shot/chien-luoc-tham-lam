using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    // Lớp đại diện cho một điểm trong không gian 2D
    class Point
    {
       
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Tính khoảng cách Euclidean giữa hai điểm
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Danh sách các điểm (tọa độ)
        List<Point> points = new List<Point>
        {
            new Point(2, 3),   // A
            new Point(5, 4),   // B
            new Point(8, 1),   // C
            new Point(6, 7),   // D
            new Point(3, 8),   // E
            new Point(7, 5)    // F
        };

        int n = points.Count;
        if (n == 0)
        {
            Console.WriteLine("Không có điểm nào để tính toán.");
            return;
        }

        // Bắt đầu từ điểm đầu tiên
        var start = 0;
        var visited = new bool[n];
        var tour = new List<int>();
        var totalDistance = 0.0;

        tour.Add(start);
        visited[start] = true;

        for (int i = 1; i < n; i++)
        {
            var last = tour.Last();
            var nearest = -1;
            var minDistance = double.MaxValue;

            // Tìm điểm gần nhất chưa được thăm
            for (int j = 0; j < n; j++)
            {
                if (!visited[j])
                {
                    var distance = Point.Distance(points[last], points[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearest = j;
                    }
                }
            }

            // Thêm điểm gần nhất vào tour
            tour.Add(nearest);
            visited[nearest] = true;
            totalDistance += minDistance;
        }

        // Quay lại điểm bắt đầu
        totalDistance += Point.Distance(points[tour.Last()], points[start]);
        tour.Add(start);

        // Xuất kết quả
        Console.WriteLine("Chu trình TSP tối ưu gần nhất:");
        foreach (var city in tour)
        {
            Console.Write($"{city + 1} -> ");
        }
        Console.WriteLine($"{start + 1}");
        Console.WriteLine($"Tổng độ dài của chu trình: {totalDistance:F2}");
        Console.ReadLine();
    }
}
