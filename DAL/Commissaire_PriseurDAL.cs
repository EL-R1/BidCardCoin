using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using BidCardCoin.DAO;
using MySql.Data.MySqlClient;

namespace BidCardCoin.DAL
{
    public class Commissaire_PriseurDAL
    {
        public Commissaire_PriseurDAL(){}
        
        public static ObservableCollection<Commissaire_PriseurDAO> selectCommissaire_Priseurs()
        {
            ObservableCollection<Commissaire_PriseurDAO> l = new ObservableCollection<Commissaire_PriseurDAO>();
            string query = "SELECT * FROM comissaire_priseur ORDER BY id_comissaire_priseur ASC;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Commissaire_PriseurDAO p = new Commissaire_PriseurDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Commissaire_Priseur : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateCommissaire_Priseur(Commissaire_PriseurDAO p)
        {
            string query = "UPDATE comissaire_priseur set id_produit=" + p.id_produit + ", id_personne=" + p.id_personne + " where id_comissaire_priseur=" + p.id_comissaire_priseur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCommissaire_Priseur(Commissaire_PriseurDAO p)
        {
            int id = getMaxIdCommissaire_Priseur() + 1;
            string query = "INSERT INTO comissaire_priseur VALUES ('" + id + "','" +  p.id_produit + "','" + p.id_personne + "');";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCommissaire_Priseur(int id)
        {
            string query = "DELETE FROM comissaire_priseur WHERE id_comissaire_priseur = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCommissaire_Priseur()
        {
            int maxIdCommissaire_Priseur = 0;
            string query = "SELECT MAX(id_comissaire_priseur) FROM comissaire_priseur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdCommissaire_Priseur = reader.GetInt32(0);
                }
                else
                {
                    maxIdCommissaire_Priseur = 0;
                }
            }
            reader.Close();
            return maxIdCommissaire_Priseur;
        }

        public static Commissaire_PriseurDAO getCommissaire_Priseur(int idCommissaire_Priseur)
        {
            string query = "SELECT * FROM comissaire_priseur WHERE id_comissaire_priseur=" + idCommissaire_Priseur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Commissaire_PriseurDAO pers = new Commissaire_PriseurDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
            reader.Close();
            return pers;
        }
    }
}