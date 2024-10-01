using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace doga
{

    public class dataBaseHandler
    {

        MySqlConnection connection;
        string tablename = "bake";
        
        public dataBaseHandler()
        {

            string username = "root";
            string password = "";
            string host = "localhost";
            string dbname = "bakery";
            string connectdtring = $"username = {username};password = {password}; host = {host};database = {dbname}";
            connection = new MySqlConnection(connectdtring);

        }
        public void readaAll()
        {
            try
            {
                connection.Open();
                string querry = $"select * from {tablename}";
                MySqlCommand commnd = new MySqlCommand(querry, connection);
                MySqlDataReader read = commnd.ExecuteReader();

                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string name = read.GetString(read.GetOrdinal("name"));
                    int db = read.GetInt32(read.GetOrdinal("db"));
                    int price = read.GetInt32(read.GetOrdinal("price"));
                    bakery onebakery = new bakery();
                    onebakery.id = id;
                    onebakery.name = name;
                    onebakery.db = db;
                    onebakery.price = price;
                    
                    bakery.list.Add(onebakery);
                }
                read.Close();
                commnd.Dispose();
                connection.Close();
              
                MessageBox.Show("siker");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "valami nem jo");
            }

        }
        public void Addone(bakery onebakery)
        {
            try
            {
                connection.Open();
                string querry = $"insert into {tablename} (name,db,price) values('{onebakery.name}','{onebakery.db}','{onebakery.price}')";
                MySqlCommand command = new MySqlCommand(querry, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                bakery.list.Add(onebakery);
                MessageBox.Show("sikerult hozzaadni");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "valami nem jo");
            }


        }
        public void deleteOne(bakery onebakery)
        {
            try
            {
                connection.Open();
                string querry = $"delete from {tablename} where id = {onebakery.id})";
                MySqlCommand command = new MySqlCommand(querry, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                bakery.list.Remove(onebakery);
                MessageBox.Show("sikerult torolni");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "valami nem jo");
            }


        }

    }
}

