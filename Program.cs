using Dapper;
using Npgsql;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Host=127.0.0.1;Port=5432;Username=postgres;Password=login123;Database=postgres";//連線字串
            using (var cn = new NpgsqlConnection(connStr))
            {
                string sql = @"WITH cte AS (
                    SELECT *
                    FROM A
                    WHERE myid = ANY(@list)
                )
				Update secuuser SET mkck_seq = null FROM cte WHERE secuuser.kbsid = cte.myid";
                List<int> k = new List<int>();
                k.Add(1);
                k.Add(2);
                var param = new { list= k };
                dynamic a = cn.Query<dynamic>(sql, param);
            }

        }
    }
}