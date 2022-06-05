using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederationModel
{
	class Program
	{
		static void Main(string[] args)
		{
			string connStr = "Data Source=localhost;Initial Catalog=SQLTarget;Integrated Security=True;Connect Timeout=30";
			var cmd = new SqlCommand("SELECT * FROM[SQLTarget].[dbo].[Person]");
			using (var conn = new SqlConnection(connStr))
			{
				conn.Open();
				cmd.Connection = conn;

				var reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					while (true)
					{
						var value = reader["Id"];

						if (reader.Read())
						{
							//invoke(value, false);
						}
						else
						{
							//invoke(value, true);
							break;
						}
					}
				}
			}

		}
	}
}
