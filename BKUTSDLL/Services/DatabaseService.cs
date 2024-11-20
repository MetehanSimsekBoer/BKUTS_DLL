using BKUTSDLL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKUTSDLL.Service
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<CommandInfo> GetCommandsForBrand(PLCBrand brand)
        {
            var commands = new List<CommandInfo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Id, CommandName, PlcBrand, CommandText, Address, DataType FROM Commands WHERE PlcBrand = @PlcBrand";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlcBrand", brand.ToString());

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            commands.Add(new CommandInfo
                            {
                                Id = reader.GetInt32(0),
                                CommandName = reader.GetString(1),
                                PlcBrand = Enum.Parse<PLCBrand>(reader.GetString(2)),
                                CommandText = reader.GetString(3),
                                Address = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DataType = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return commands;
        }
    }
}
