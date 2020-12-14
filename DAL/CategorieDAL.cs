using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class CategorieDAL
    {
        public CategorieDAL(){}
        
        public static ObservableCollection<CategorieDAO> selectCategories()
        {
            ObservableCollection<CategorieDAO> l = new ObservableCollection<CategorieDAO>();
            string query = "SELECT * FROM categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategorieDAO p = new CategorieDAO(reader.GetInt32(0), reader.GetString(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Categorie : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateCategorie(CategorieDAO p)
        {
            string query = "UPDATE categorie set nom=\"" + p.nom + "\" where id_categorie=" + p.id_categorie + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCategorie(CategorieDAO p)
        {
            int id = getMaxIdCategorie() + 1;
            string query = "INSERT INTO Categorie VALUES (\"" + id + "\",\"" +  p.nom + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCategorie(int id)
        {
            string query = "DELETE FROM Categorie WHERE id_Categorie = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCategorie()
        {
            int maxIdCategorie = 0;
            string query = "SELECT MAX(id_categorie) FROM categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdCategorie = reader.GetInt32(0);
                }
                else
                {
                    maxIdCategorie = 0;
                }
            }
            reader.Close();
            return maxIdCategorie;
        }

        public static CategorieDAO getCategorie(int idCategorie)
        {
            string query = "SELECT * FROM categorie WHERE id_categorie=" + idCategorie + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CategorieDAO pers = new CategorieDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }
    }
}