using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class AchatDAL
    {
        public AchatDAL(){}
        
        public static ObservableCollection<AchatDAO> selectAchats()
        {
            ObservableCollection<AchatDAO> l = new ObservableCollection<AchatDAO>();
            string query = "SELECT * FROM Achat;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AchatDAO p = new AchatDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2), reader.GetByte(3), reader.GetByte(4));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Achat : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateAchat(AchatDAO p)
        {
            string query = "UPDATE achat set prix=\"" + p.prix + "\", is_live=\"" + p.is_live + "\", is_telephone=\"" + p.is_telephone + "\" where id_acheteur=" + p.id_acheteur + " and id_produit=" + p.id_produit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertAchat(AchatDAO p)
        {
            string query = "INSERT INTO achat VALUES (\"" + p.id_acheteur + "\",\"" +  p.id_produit + "\",\"" +  p.prix + "\",\"" +  p.is_live + "\",\"" + p.is_telephone + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerAchat(int id_acheteur, int id_produit)
        {
            string query = "DELETE FROM achat WHERE id_acheteur = \"" + id_acheteur + "\" and id_produit=" + id_produit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        /*
        public static int getMaxIdAchat()
        {
            int maxIdAchat = 0;
            string query = "SELECT MAX(id_achat) FROM achat;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdAchat = reader.GetInt32(0);
                }
                else
                {
                    maxIdAchat = 0;
                }
            }
            reader.Close();
            return maxIdAchat;
        }
*/
        
        public static AchatDAO getAchat(int id_acheteur, int id_produit)
        {
            string query = "SELECT * FROM achat WHERE id_acheteur = \"" + id_acheteur + "\" and id_produit=" + id_produit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            AchatDAO pers = new AchatDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2), reader.GetByte(3), reader.GetByte(4));
            reader.Close();
            return pers;
        }
    }
}