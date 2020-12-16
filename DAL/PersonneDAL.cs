using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class PersonneDAL
    {
        public PersonneDAL(){}
        
        public static ObservableCollection<PersonneDAO> selectPersonnes()
        {
            ObservableCollection<PersonneDAO> l = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM personne ORDER BY id_personne ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneDAO p = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Personne : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }


        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne set username=\"" + p.username + "\", password=\"" + p.password +"\", nom=\"" + p.nom + "\", email=\"" + p.email + "\", age=\"" + p.age + "\" where id_personne=" + p.id_personne + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonne(PersonneDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.username + "\",\"" + p.password + "\",\"" + p.nom + "\",\"" +  p.email + "\",\"" + p.age + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE id_personne = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPersonne()
        {
            int maxIdPersonne = 0;
            string query = "SELECT MAX(id_personne) FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdPersonne = reader.GetInt32(0);
                }
                else
                {
                    maxIdPersonne = 0;
                }
            }
            reader.Close();
            return maxIdPersonne;
        }
        public static int getLoginCount(string username, string password)
        {
            int countLogin = 0;
            string query = "SELECT * FROM Personne WHERE username='" + username + "' AND password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetInt32(0) == 0)
                {
                    countLogin = 0;
                }
                else
                {
                    countLogin = 1;
                }
            }
            reader.Close();

            return countLogin;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE id_personne=" + idPersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
            reader.Close();
            return pers;
        }


    }
}