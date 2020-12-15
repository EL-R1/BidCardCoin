using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class VendeurDAL
    {
        public VendeurDAL(){}
        
        public static ObservableCollection<VendeurDAO> selectVendeurs()
        {
            ObservableCollection<VendeurDAO> l = new ObservableCollection<VendeurDAO>();
            string query = "SELECT * FROM vendeur ORDER BY id_vendeur ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VendeurDAO p = new VendeurDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table vendeur : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateVendeur(VendeurDAO p)
        {
            string query = "UPDATE vendeur set id_personne=\"" + p.id_personne + "\", id_produit=\"" + p.id_produit + "\" where id_vendeur=" + p.id_vendeur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertVendeur(VendeurDAO p)
        {
            int id = getMaxIdVendeur() + 1;
            string query = "INSERT INTO vendeur VALUES (\"" + id + "\",\"" +  p.id_personne + "\",\"" + p.id_produit + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerVendeur(int id)
        {
            string query = "DELETE FROM vendeur WHERE id_vendeur = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdVendeur()
        {
            int maxIdvendeur = 0;
            string query = "SELECT MAX(id_vendeur) FROM vendeur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdvendeur = reader.GetInt32(0);
                }
                else
                {
                    maxIdvendeur = 0;
                }
            }
            reader.Close();
            return maxIdvendeur;
        }

        public static VendeurDAO getVendeur(int idvendeur)
        {
            string query = "SELECT * FROM vendeur WHERE id_vendeur=" + idvendeur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            VendeurDAO pers = new VendeurDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
            reader.Close();
            return pers;
        }
    }
}