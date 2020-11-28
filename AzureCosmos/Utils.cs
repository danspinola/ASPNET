using ASPNET.BLL.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Threading.Tasks;

namespace AzureCosmos
{
    public class Utils
    {
        public static async Task<User> CreateOrMerge(CloudTable table, User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entidade null.");
            }

            try
            {
                TableOperation tableOperation = TableOperation.InsertOrMerge(entity);
                TableResult result = await table.ExecuteAsync(tableOperation);
                User user = result.Result as User;

                //if (result.RequestCharge.HasValue)
                //{
                //    Console.WriteLine($"Carga de requisição: {result.RequestCharge}");
                //}

                return user;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                throw e;
            }
        }

        public static async Task<User> Details(CloudTable table, User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entidade null.");
            }

            string partitionKey = entity.PartitionKey;
            string rowKey = entity.RowKey;

            try
            {
                TableOperation tableOperation = TableOperation.Retrieve<User>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(tableOperation);
                User user = result.Result as User;

                //if (user != null)
                //{
                //    Console.WriteLine($"\t\t{user.PartitionKey}\t{user.RowKey}");
                //}

                //if (result.RequestCharge.HasValue)
                //{
                //    Console.WriteLine($"Custo de requisição da operação de leitura: {result.RequestCharge}.");
                //}

                return user;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                throw e;
            }

        }

        public static async Task Delete(CloudTable table, User entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entitdade nula.");
                }

                TableOperation tableOperation = TableOperation.Delete(entity);
                TableResult result = await table.ExecuteAsync(tableOperation);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
