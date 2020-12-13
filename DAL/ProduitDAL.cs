using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class ProduitDAL
    {
        public ProduitDAL(){}
        
        public static ObservableCollection<ProduitDAO> selectProduits()
        {
            ObservableCollection<ProduitDAO> l = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM Produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.GetByte(6), reader.GetFloat(7), reader.GetString(8), reader.GetString(9));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateProduit(ProduitDAO p)
        {
            string query = "UPDATE Produit set id_lot=\"" + p.id_lot + "\", prix_depart=\"" + p.prix_depart + "\", description=\"" + p.description + "\", date_vente=\"" + p.date_vente + "\", estimation=\"" + p.estimation + "\", is_vendu=\"" + p.is_vendu + "\", prix_reserve=\"" + p.prix_reserve + "\", region=\"" + p.region + "\", attribut=\"" + p.attribut + "\" where id_produit=" + p.id_produit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertProduit(ProduitDAO p)
        {
            int id = getMaxIdProduit() + 1;
            string query = "INSERT INTO Produit VALUES (\"" + id + "\",\"" +  p.id_lot + "\",\"" + p.prix_depart + "\",\"" +  p.description + "\",\"" +  p.date_vente + "\",\"" +  p.estimation + "\",\"" +  p.is_vendu + "\",\"" +  p.prix_reserve + "\",\"" +  p.region + "\",\"" +  p.attribut + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduit(int id)
        {
            string query = "DELETE FROM Produit WHERE id_produit = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdProduit()
        {
            int maxIdProduit = 0;
            string query = "SELECT MAX(id_produit) FROM produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdProduit = reader.GetInt32(0);
                }
                else
                {
                    maxIdProduit = 0;
                }
            }
            reader.Close();
            return maxIdProduit;
        }

        public static ProduitDAO getProduit(int idProduit)
        {
            string query = "SELECT * FROM Produit WHERE id_produit=" + idProduit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ProduitDAO pers = new ProduitDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.GetByte(6), reader.GetFloat(7), reader.GetString(8), reader.GetString(9));
            reader.Close();
            return pers;
        }
    }
}