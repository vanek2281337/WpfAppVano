using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfAppVano.Entity;

namespace WpfAppVano.Services
{
    class UserServices
    {
        public async static Task<string> Auth(string UserName, string Password)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

            await using var dataSource = dataSourceBuilder.Build();

            var command = dataSource.CreateCommand($"SELECT password FROM users WHERE username='{UserName}'");
            var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {


                if ((string)reader["password"] == Password)
                {
                    command = dataSource.CreateCommand($"SELECT role FROM users WHERE username='{UserName}'");
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        return (string)reader["role"];
                    }
                }


            }
            return null;
        }

        public async static Task<List<UserEntity>> ShowAll()
        {
            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"SELECT * FROM users");

                var reader = await command.ExecuteReaderAsync();
                List<UserEntity> listToReturn = new();
                while (reader.Read())
                {
                    UserEntity entity = new();
                    entity.Id = (int)reader["Id"];
                    entity.UserName = (string)reader["username"];
                    entity.Status = (string)reader["status"];
                    entity.Role = (string)reader["role"];
                    entity.Password = (string)reader["password"];
                    entity.Smena = (string)reader["smena"];
                    listToReturn.Add(entity);
                }
                return listToReturn;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async static Task<bool> Reg(string UserName, string Password, string Role)
        {
            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"INSERT INTO users (username, password, role, status, smena) VALUES ('{UserName}', '{Password}', '{Role}', 'Работает', 'не назначено');");

                var reader = await command.ExecuteReaderAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async static Task<bool> UpdateUserStatus(string id)
        {
            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"UPDATE users SET status = 'уволен' WHERE id = '{id}'");

                var reader = await command.ExecuteReaderAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async static Task<bool> UpdateUserSmena(string smena, string id)
        {
            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"UPDATE users SET smena = '{smena}' WHERE id = '{id}'");

                var reader = await command.ExecuteReaderAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async static Task<List<OrderEntity>> ShowOrder()
        {
            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"SELECT * FROM orders");

                var reader = await command.ExecuteReaderAsync();
                List<OrderEntity> listToReturn = new();
                while (reader.Read())
                {
                    OrderEntity entity = new();
                    entity.Id = (int)reader["Id"];
                    entity.Table = (int)reader["clienttable"];
                    entity.Clients = (int)reader["clients"];
                    entity.Food_Drink = (string)reader["food_drink"];
                    entity.Status = (string)reader["status"];
                    listToReturn.Add(entity);
                }
                return listToReturn;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async static Task<bool> Orders(int Clients, int ClientTable, string Food_Drink)
        {

            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"INSERT INTO orders (clients, clienttable, food_drink, status) VALUES ('{Clients}', '{ClientTable}', '{Food_Drink}', 'Ожидает');");

                var reader = await command.ExecuteReaderAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async static Task<bool> UpdateOrderStatus(int Id, string Role)
        {
            try
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnection.Connection);

                await using var dataSource = dataSourceBuilder.Build();

                var command = dataSource.CreateCommand($"UPDATE orders SET status = '{Role}' WHERE id = '{Id}'");

                var reader = await command.ExecuteReaderAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}

