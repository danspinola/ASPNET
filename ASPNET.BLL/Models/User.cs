using Microsoft.Azure.Cosmos.Table;
using System;

namespace ASPNET.BLL.Models
{
    public class User : TableEntity
    {
        public User(string lastName, string firstName)
        {
            PartitionKey = lastName;
            RowKey = firstName;
        }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
