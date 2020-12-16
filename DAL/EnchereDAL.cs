using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class EnchereDAL
    {
        public EnchereDAL(){}
        
        public static ObservableCollection<EnchereDAO> selectEncheres()
        {
            ObservableCollection<EnchereDAO> l = new ObservableCollection<EnchereDAO>();
            string query = "SELECT * FROM vente_enchere ORDER BY id_vente_enchere ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EnchereDAO p = new EnchereDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Enchere : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateEnchere(EnchereDAO p)
        {
            string query = "UPDATE vente_enchere set date_vente_enchere=\"" + p.date_vente_enchere + "\", id_lieu=\"" + p.id_lieu + "\" where id_vente_enchere=" + p.id_vente_enchere + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEnchere(EnchereDAO p)
        {
            int id = getMaxIdEnchere() + 1;
            string query = "INSERT INTO vente_enchere VALUES ('" + id + "','" + p.date_vente_enchere + "','" + p.id_lieu + "');";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEnchere(int id)
        {
            string query = "DELETE FROM vente_enchere WHERE id_vente_enchere = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEnchere()
        {
            int maxIdEnchere = 0;
            string query = "SELECT MAX(id_vente_enchere) FROM vente_enchere;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdEnchere = reader.GetInt32(0);
                }
                else
                {
                    maxIdEnchere = 0;
                }
            }
            reader.Close();
            return maxIdEnchere;
        }

        public static EnchereDAO getEnchere(int idEnchere)
        {
            string query = "SELECT * FROM vente_enchere WHERE id_vente_enchere=" + idEnchere + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EnchereDAO pers = new EnchereDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            reader.Close();
            return pers;
        }
    }
}