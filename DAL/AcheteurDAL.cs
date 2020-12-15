using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class AcheteurDAL
    {
        public AcheteurDAL(){}
        
        public static ObservableCollection<AcheteurDAO> selectAcheteurs()
        {
            ObservableCollection<AcheteurDAO> l = new ObservableCollection<AcheteurDAO>();
            string query = "SELECT * FROM acheteur ORDER BY id_acheteur ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AcheteurDAO p = new AcheteurDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetByte(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Acheteur : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateAcheteur(AcheteurDAO p)
        {
            string query = "UPDATE acheteur set id_personne=\"" + p.id_personne + "\", is_solvable=\"" + p.is_solvable + "\" where id_acheteur=" + p.id_acheteur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertAcheteur(AcheteurDAO p)
        {
            int id = getMaxIdAcheteur() + 1;
            string query = "INSERT INTO acheteur VALUES (\"" + id + "\",\"" +  p.id_personne + "\",\"" + p.is_solvable + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerAcheteur(int id)
        {
            string query = "DELETE FROM acheteur WHERE id_acheteur = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdAcheteur()
        {
            int maxIdAcheteur = 0;
            string query = "SELECT MAX(id_acheteur) FROM acheteur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdAcheteur = reader.GetInt32(0);
                }
                else
                {
                    maxIdAcheteur = 0;
                }
            }
            reader.Close();
            return maxIdAcheteur;
        }

        public static AcheteurDAO getAcheteur(int idAcheteur)
        {
            string query = "SELECT * FROM acheteur WHERE id_acheteur=" + idAcheteur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            AcheteurDAO pers = new AcheteurDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetByte(2));
            reader.Close();
            return pers;
        }
    }
}