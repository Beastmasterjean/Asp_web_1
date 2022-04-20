using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp5.Models;

namespace Tp5.DataAccessLayer.Factories
{
    public class ReservationFactory
    {
        private Reservation CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            int nbPersonne = (int)mySqlDataReader["NbPersonne"];
            int menuChoiceId = (int)mySqlDataReader["MenuChoiceId"];
            string nom = mySqlDataReader["Nom"].ToString();
            string courriel = mySqlDataReader["Courriel"].ToString();
            DateTime date = (DateTime)mySqlDataReader["DateReservation"];

            return new Reservation(id,nbPersonne,menuChoiceId,nom,courriel,date);
        }

        public Reservation CreateEmpty()
        {
            return new Reservation(0,0,0, string.Empty, string.Empty,DateTime.Now);
        }

        public Reservation[] GetAll()
        {
            List<Reservation> reservations = new List<Reservation>();
            MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations ORDER BY DateReservation Desc";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    reservations.Add(CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservations.ToArray();
        }

        public Reservation Get(int id)
        {
            Reservation reservation = null;
            MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    reservation = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservation;
        }
    }
}
