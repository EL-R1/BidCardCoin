using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class LotDAL
    {
        public LotDAL(){}
        
        public static ObservableCollection<LotDAO> selectLots()
        {
            ObservableCollection<LotDAO> l = new ObservableCollection<LotDAO>();
            string query = "SELECT * FROM lot ORDER BY id_lot ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LotDAO p = new LotDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Lot : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateLot(LotDAO p)
        {
            string query = "UPDATE Lot set id_vente_enchere=\"" + p.id_vente_enchere + "\", description=\"" + p.description + "\" where id_lot=" + p.id_lot + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertLot(LotDAO p)
        {
            int id = getMaxIdLot() + 1;
            string query = "INSERT INTO Lot VALUES (\"" + id + "\",\"" +  p.id_vente_enchere + "\",\"" + p.description + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerLot(int id)
        {
            string query = "DELETE FROM Lot WHERE id_lot = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Votre lot ne doit pas avoir de produits");
            }
        }
        public static int getMaxIdLot()
        {
            int maxIdLot = 0;
            string query = "SELECT MAX(id_lot) FROM Lot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdLot = reader.GetInt32(0);
                }
                else
                {
                    maxIdLot = 0;
                }
            }
            reader.Close();
            return maxIdLot;
        }

        public static LotDAO getLot(int idLot)
        {
            string query = "SELECT * FROM lot WHERE id_lot=" + idLot + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LotDAO pers = new LotDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
    }
}