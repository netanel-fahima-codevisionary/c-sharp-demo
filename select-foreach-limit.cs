using System;
using System.Data;
using System.Data.SqlClient;
using OrderUtils;

class Program
{
    static void Main()
    {
        string connectionString = "Your_Connection_String_Here";
        string query = "SELECT OrderID, CustomerName, OrderDate FROM ORDERS";

        DataTable ordersTable = FetchDataFromDatabase(connectionString, query);

        foreach (DataRow row in ordersTable.Rows)
        {
            OrderUtils.ProcessOrderLimited(row, 0);
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
}
