using Serilog;
using System;
using System.Threading.Tasks;
using Npgsql;

namespace HotelApplication.Logging
{
    public class CheckDbConnection
    {
        private readonly string _connectionString;

        public CheckDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CheckConnectionAsync()
        {
            try
            {
                await using var connection = new NpgsqlConnection(_connectionString);
                await connection.OpenAsync();
                Log.Information("PostgreSQL bağlantısı başarılı.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "PostgreSQL bağlantısı kurulamadı.");
            }
        }
    }
}
