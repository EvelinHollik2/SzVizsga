using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp
{
    internal class Adatbazis
    {
        //Command & Connection létrhozása
        MySqlCommand sqlCommand;
        MySqlConnection connection;

        //constructor
        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost"; //hol található az adatbázis
            builder.UserID = "root"; //felhasználó azonosító
            builder.Password = ""; //jelszó
            builder.Database = "dolgozok"; //adatbázis
            connection = new MySqlConnection(builder.ConnectionString); //adatok rendezése
            sqlCommand = connection.CreateCommand(); //kapcsolat létrehozása
            try { //kapcsolat biztosítása
                kapcsolatNyit();
                kapcsolatZar();
            }
            catch (MySqlException ex)
            { //ha nincs akkor hibaüzenet
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }

        }

        private void kapcsolatZar()
        {
            if (connection.State != System.Data.ConnectionState.Closed) //megvizsgáljuk hogy zárt e a kapcsolat
            {
                connection.Close();
            }
        }

        //methodus 
        private void kapcsolatNyit()
        {
            if (connection.State != System.Data.ConnectionState.Open) //megvizsgáljuk hogy nyitott e a kapcsolat
            {
                connection.Open();
            }
        }

        internal List<Dolgozo> getAllDolgozo()
        {
            List<Dolgozo> dolgozok = new List<Dolgozo>();
            sqlCommand.CommandText = "SELECT `nev`,`neme`,`reszleg`,`belepesev`,`ber` FROM `dolgozok`"; //adatok hozzáadása az adatbázisból lekérdezéssel
            kapcsolatNyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dolgozo dolgozo = new Dolgozo(dr.GetString("nev"), dr.GetString("neme"),dr.GetString("reszleg"), dr.GetInt32("belepesev"), dr.GetInt32("ber"));
                    dolgozok.Add(dolgozo);
                }
                return dolgozok;
            }
                kapcsolatZar();
        }
        
    }
}
