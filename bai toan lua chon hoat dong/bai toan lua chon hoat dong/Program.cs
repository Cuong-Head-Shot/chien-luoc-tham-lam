using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
   
    class Activity
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Activity(int start, int end)
        {
            Start = start;
            End = end;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<Activity> activities = new List<Activity>
        {
            new Activity(1, 4),
            new Activity(3, 5),
            new Activity(0, 6),
            new Activity(5, 7),
            new Activity(8, 9),
            new Activity(5, 9)
        };

        var sortedActivities = activities.OrderBy(a => a.End).ToList();

        List<Activity> selectedActivities = new List<Activity>();

        Activity lastSelected = sortedActivities[0];
        selectedActivities.Add(lastSelected);

        for (int i = 1; i < sortedActivities.Count; i++)
        {
            if (sortedActivities[i].Start >= lastSelected.End)
            {
                selectedActivities.Add(sortedActivities[i]);
                lastSelected = sortedActivities[i];
            }
        }


        Console.WriteLine("Danh sách các hoạt động được chọn:");
        foreach (var activity in selectedActivities)
        {
            Console.WriteLine($"Bắt đầu: {activity.Start}, Kết thúc: {activity.End}");
            Console.ReadLine();

        }
    }
}
