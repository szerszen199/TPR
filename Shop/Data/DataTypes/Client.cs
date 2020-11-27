using System;

namespace Shop.Data.DataTypes
{
    internal class Client : IClient
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public Client(string firstName, string surname)
        {
            FirstName = firstName;
            SurName = surname;
        }
    }
}