using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Your_Connection_String_Here";
        string query = "SELECT OrderID, CustomerName, OrderDate FROM ORDERS";

        DataTable ordersTable = FetchDataFromDatabase(connectionString, query);

        if (ordersTable.Rows.Count > 0)
        {
            ProcessOrder(ordersTable.Rows[0]);
        }
    }

    static DataTable FetchDataFromDatabase(string connectionString, string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                DataTable dataTable = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                return dataTable;
            }
        }
    }

    static void ProcessOrder(DataRow orderRow)
    {
        // This function processes each order
        int orderId = Convert.ToInt32(orderRow["OrderID"]);
        string customerName = orderRow["CustomerName"].ToString();
        DateTime orderDate = Convert.ToDateTime(orderRow["OrderDate"]);

        Console.WriteLine($"Processing Order: ID={orderId}, Customer={customerName}, Date={orderDate}");

        // Add your specific order processing logic here
    }
}
