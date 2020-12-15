using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class Ordre_AchatDAL
    {
        public Ordre_AchatDAL(){}
        
        public static ObservableCollection<Ordre_AchatDAO> selectOrdre_Achats()
        {
            ObservableCollection<Ordre_AchatDAO> l = new ObservableCollection<Ordre_AchatDAO>();
            string query = "SELECT * FROM ordre_achat ORDER BY id_ordre_achat ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ordre_AchatDAO p = new Ordre_AchatDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetString(4));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Ordre_Achat : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateOrdre_Achat(Ordre_AchatDAO p)
        {
            string query = "UPDATE ordre_achat set id_produit=\"" + p.id_produit + "\", id_acheteur=\"" + p.id_acheteur + "\", montant=\"" + p.montant + "\", date_achat=\"" + p.date_achat + "\" where id_ordre_achat=" + p.id_ordre_achat + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertOrdre_Achat(Ordre_AchatDAO p)
        {
            int id = getMaxIdOrdre_Achat() + 1;
            string query = "INSERT INTO ordre_achat VALUES (\"" + id + "\",\"" +  p.id_produit + "\",\"" + p.id_acheteur + "\",\"" + p.montant + "\",\"" + p.date_achat + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerOrdre_Achat(int id)
        {
            string query = "DELETE FROM ordre_achat WHERE id_ordre_achat = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdOrdre_Achat()
        {
            int maxIdOrdre_Achat = 0;
            string query = "SELECT MAX(id_ordre_achat) FROM ordre_achat;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdOrdre_Achat = reader.GetInt32(0);
                }
                else
                {
                    maxIdOrdre_Achat = 0;
                }
            }
            reader.Close();
            return maxIdOrdre_Achat;
        }

        public static Ordre_AchatDAO getOrdre_Achat(int idOrdre_Achat)
        {
            string query = "SELECT * FROM ordre_achat WHERE id_ordre_achat=" + idOrdre_Achat + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Ordre_AchatDAO pers = new Ordre_AchatDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetString(4));
            reader.Close();
            return pers;
        }
    }
}