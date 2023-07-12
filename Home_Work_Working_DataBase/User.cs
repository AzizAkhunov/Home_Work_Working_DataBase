using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net;

namespace Home_Work_Working_DataBase
{
    public static class User
    {
        public static string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=56767655;Database=Users";

        static public void Add()
        {
            try
            {
                // userId,  lastname,  password
                Console.WriteLine("[ID] [First Name] [Password]");
                string[] newClientInfo = Console.ReadLine().Split();
                var newClient = new UserProp(int.Parse(newClientInfo[0]), newClientInfo[1], newClientInfo[2]);
                using (var con = new NpgsqlConnection(connectionString))
                {
                    var sqlQuery = "INSERT INTO public.User VALUES(@userId,@username,@password)";
                    con.Execute(sqlQuery, newClient);
                }
            }
            catch
            {
                Console.WriteLine("Hatolikk!!");
            }
        }

        static public void DeleteAll()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = "delete  from public.User";
                var s = connection.QueryFirstOrDefault(sqlQuery);
                if (s != null)
                {
                    Console.WriteLine("Uchirgani narsa topilmadi");
                }
                else
                {
                    Console.WriteLine("Uchirildi");
                }
            }
        }
        
        static public void DeleteById(int userId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"delete  from public.User where userId = {userId}";
                var s = connection.QueryFirstOrDefault(sqlQuery);
                if (s != null)
                {
                    Console.WriteLine("Bu Id da narsa qushilamagan");
                }
                else
                {
                    Console.WriteLine("Uchirildi");
                }
            }
        }

        static public void GetAll()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"select * from public.User";
                var s = connection.Query(sqlQuery);
                foreach(var item in s)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static public void GetById(int userId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"select * from public.User where userId = {userId}";
                var s = connection.Query(sqlQuery);
                foreach (var item in s)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
