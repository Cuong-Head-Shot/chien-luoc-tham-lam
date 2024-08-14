using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    
    class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }
        public double ValuePerWeight { get; set; }

        public Item(int weight, int value)
        {
            Weight = weight;
            Value = value;
            ValuePerWeight = (double)value / weight;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int W = 50; 

       
        List<Item> items = new List<Item>
        {
            new Item(10, 60),
            new Item(20, 100),
            new Item(30, 120)
        };

        items = items.OrderByDescending(item => item.ValuePerWeight).ToList();

        
        double totalValue = 0;
        int remainingWeight = W;

     
        Dictionary<Item, int> selectedItems = new Dictionary<Item, int>();

        foreach (var item in items)
        {
            if (remainingWeight <= 0)
                break;

           
            int maxQuantity = remainingWeight / item.Weight;

            if (maxQuantity > 0)
            {
               
                totalValue += maxQuantity * item.Value;

                // Cập nhật trọng lượng còn lại
                remainingWeight -= maxQuantity * item.Weight;

                
                selectedItems[item] = maxQuantity;
            }
        }

     
        Console.WriteLine($"Giá trị tối đa có thể đạt được: {totalValue}");
        Console.WriteLine("Danh sách đồ vật được chọn:");
        foreach (var kvp in selectedItems)
        {
            Item item = kvp.Key;
            int quantity = kvp.Value;
            Console.WriteLine($"Đồ vật: Trọng lượng = {item.Weight}, Giá trị = {item.Value}, Số lượng = {quantity}");
            Console.ReadLine();
        }
    }
}
