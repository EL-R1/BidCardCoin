using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;


namespace BidCardCoin.DAL
{
    public class CategorieProduitDAL
    {
        public CategorieProduitDAL(){}
        
        public static ObservableCollection<CategorieProduitDAO> selectCategorieProduits()
        {
            ObservableCollection<CategorieProduitDAO> l = new ObservableCollection<CategorieProduitDAO>();
            string query = "SELECT * FROM categorie_produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategorieProduitDAO p = new CategorieProduitDAO(reader.GetInt32(0), reader.GetInt32(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table CategorieProduit : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateCategorieProduit(CategorieProduitDAO p)
        {
            string query = "UPDATE categorie_produit set id_produit=\"" + p.id_produit + "\", id_categorie=\"" + p.id_categorie + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCategorieProduit(CategorieProduitDAO p)
        {
            string query = "INSERT INTO categorie_produit VALUES (\"" + p.id_produit + "\",\"" +  p.id_categorie + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCategorieProduit(int id_categorie, int id_produit)
        {
            string query = "DELETE FROM categorie_produit WHERE id_categorie = \"" + id_categorie + "\" and id_produit=" + id_produit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static CategorieProduitDAO getCategorieProduit(int id_categorie, int id_produit)
        {
            string query = "SELECT * FROM categorie_produit WHERE id_categorie = \"" + id_categorie + "\" and id_produit=" + id_produit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CategorieProduitDAO pers = new CategorieProduitDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}