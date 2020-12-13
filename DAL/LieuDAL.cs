using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class LieuDAL
    {
        public LieuDAL(){}
        
        public static ObservableCollection<LieuDAO> selectLieux()
        {
            ObservableCollection<LieuDAO> l = new ObservableCollection<LieuDAO>();
            string query = "SELECT * FROM lieu;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LieuDAO p = new LieuDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Lieu : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateLieu(LieuDAO p)
        {
            string query = "UPDATE lieu set nom=\"" + p.nom + "\", adresse=\"" + p.adresse + "\", ville=\"" + p.ville + "\", code_postal=\"" + p.code_postal + "\" where id_Lieu=" + p.id_lieu + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertLieu(LieuDAO p)
        {
            int id = getMaxIdLieu() + 1;
            string query = "INSERT INTO lieu VALUES (\"" + id + "\",\"" + p.nom + "\",\"" + p.adresse + "\",\"" + p.ville + "\",\"" + p.code_postal + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerLieu(int id)
        {
            string query = "DELETE FROM lieu WHERE id_lieu = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdLieu()
        {
            int maxIdLieu = 0;
            string query = "SELECT MAX(id_lieu) FROM lieu;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdLieu = reader.GetInt32(0);
                }
                else
                {
                    maxIdLieu = 0;
                }
            }
            reader.Close();
            return maxIdLieu;
        }

        public static LieuDAO getLieu(int idLieu)
        {
            string query = "SELECT * FROM Lieu WHERE id_Lieu=" + idLieu + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LieuDAO pers = new LieuDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
            reader.Close();
            return pers;
        }
    }
}