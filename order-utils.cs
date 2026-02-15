using System;
using System.Data;
using System.Data.SqlClient;

public class OrderUtils
{

    static void ProcessOrderLimited(DataRow orderRow, int index)
    {
         // processes only the first row.
        if (index > 0)
        {
            return;
        }
            
        int orderId = Convert.ToInt32(orderRow["OrderID"]);
        string customerName = orderRow["CustomerName"].ToString();
        DateTime orderDate = Convert.ToDateTime(orderRow["OrderDate"]);

        Console.WriteLine($"Processing Order: ID={orderId}, Customer={customerName}, Date={orderDate}");

        // Add your specific order processing logic here
    }
}
