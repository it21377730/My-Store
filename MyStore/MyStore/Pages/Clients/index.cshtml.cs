

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyStore.Pages.NewFolder
{
    public class InModel : PageModel
    {
        public List<ClientInfo> listsclients;

        public InModel()
        {
            listsclients = new List<ClientInfo>();
        }

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress; Initial Catalog=MYSTORE; Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo
                                {
                                    id = reader.GetInt32(0).ToString(),
                                    name = reader.GetString(1),
                                    email = reader.GetString(2),
                                    phone_number = reader.GetString(3),
                                    address = reader.GetString(4),
                                    created_at = reader.GetDateTime(5).ToString()
                                };

                                listsclients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone_number;
        public String address;
        public String created_at;
    }
}
