using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;


namespace BidCardCoin.DAL
{
    public class EstimationDAL
    {
        public EstimationDAL(){}
        
        public static ObservableCollection<EstimationDAO> selectEstimations()
        {
            ObservableCollection<EstimationDAO> l = new ObservableCollection<EstimationDAO>();
            string query = "SELECT * FROM estimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstimationDAO p = new EstimationDAO(reader.GetInt32(0), reader.GetInt32(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Estimation : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateEstimation(EstimationDAO p)
        {
            string query = "UPDATE estimation set id_comissaire_priseur=" + p.id_comissaire_priseur + ", id_vendeur=" + p.id_vendeur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEstimation(EstimationDAO p)
        {
            string query = "INSERT INTO estimation VALUES (\"" + p.id_comissaire_priseur + "\",\"" +  p.id_vendeur + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEstimation(int id_commissaire_priseur, int id_vendeur)
        {
            string query = "DELETE FROM estimation WHERE id_comissaire_priseur = " + id_commissaire_priseur + " and id_produit=" + id_vendeur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static EstimationDAO getEstimation(int id_commissaire_priseur, int id_vendeur )
        {
            string query = "SELECT * FROM estimation WHERE id_comissaire_priseur = \"" + id_commissaire_priseur + "\" and id_produit=" + id_vendeur + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EstimationDAO pers = new EstimationDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}