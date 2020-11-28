using Microsoft.Azure.Cosmos.Table;
using System;
using System.Threading.Tasks;

namespace AzureCosmos
{
    public class Common
    {
        public static CloudStorageAccount CreateStorageAccount(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (Exception e)
            {
                throw e;
                throw;
            }
            return storageAccount;
        }

        public static async Task<CloudTable> CreateTableAsync(string tableName)
        {
            string storageConnection = AppSettings.LoadAppSettings().StorageConnectionString;

            // Recuperar dados
            CloudStorageAccount storageAccount = CreateStorageAccount(storageConnection);
            // Criar um cliente para as tabelas
            CloudTableClient tableClient = storageAccount
                .CreateCloudTableClient(new TableClientConfiguration());
            // Criar uma tabela 
            CloudTable table = tableClient.GetTableReference(tableName);

            bool created = await table.CreateIfNotExistsAsync();
            return table;
        }
    }
}
