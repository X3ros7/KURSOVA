using Npgsql;
using System.Threading.Tasks;

namespace Kursova.utils
{
    public static class DatabaseConnector
    {
        public static async Task<NpgsqlConnection> OpenConnectionAsync(string connectionString)
        {
            var conn = new NpgsqlConnection(connectionString);
            try
            {
                await conn.OpenAsync();
                return conn;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }
    }
}
