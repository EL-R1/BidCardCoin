using MySql.Data.MySqlClient;
using System;

namespace BidCardCoin.DAL
{
    public class DALConnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static MySqlConnection OpenConnection()
        {
            if (connection == null) //  si la connexion est déjà ouverte, il ne la refera pas 
            {
                server = "localhost";
                database = "bcc";
                uid = "bcc";
                password = "bcc";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                                   database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }       
    }
}