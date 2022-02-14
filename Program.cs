using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDB
{   
    class Program
    {
        private static Products[] p = { new Products("100", "Laptop",  800, "Ships to Romania", "best seller"),
                                        new Products("101", "Desktop", 700, "Ships to Romania", "best seller"),
                                        new Products("102", "Mobile",  400, "Ships to Romania", "no"),
                                        new Products("103", "TV",      300, "Ships to Romania", "best seller"),
                                        new Products("104", "SSD",     100, "Ships to Romania", "no")
        };
        private static Clients[] cl = { new Clients(1, "100", "Voievod Ion",     "Privighetorii 3", "0711000001"),
                                        new Clients(2, "101", "Patrascu Teodor", "Ciocarliei 5",    "0711000002"),
                                        new Clients(3, "102", "Buteanu Remus",   "Randunicii 7",    "0711000003"),
                                        new Clients(4, "103", "Chira Dan",       "Berzei 9",        "0711000004"),
                                        new Clients(5, "104", "Bora Florin",     "Cocorului 11",    "0711000005")
        };
        private static Comments[] co = { new Comments(1, 1, "5", "Excellent"),
                                         new Comments(2, 2, "5", "Fantastic!!!"),
                                         new Comments(3, 3, "5", "Wonderful!!!"),
                                         new Comments(4, 4, "5", "Beautiful!!!"),
                                         new Comments(5, 5, "5", "Super!!!")
        };
        static void Main(string[] args)
        {
            CreateTables();
            PopulateTables();

            Console.ReadLine();
        }
        static private void CreateTables()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\IAP\PAC#\Exemple\ServerProducts\App_Data\Database1.mdf;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].[Products]([cod_prod] VARCHAR(10) NOT NULL PRIMARY KEY, [name] TEXT NOT NULL, [price] INT NOT NULL, [availability] TEXT NOT NULL, [best_seller] TEXT NOT NULL)", con);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("The table Products is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                cmd.CommandText = "CREATE TABLE [dbo].[Clients]([Id_cl] INT NOT NULL PRIMARY KEY, [cod_prod] VARCHAR(10) NOT NULL, [name] TEXT NOT NULL, [address] TEXT NOT NULL, [phone] TEXT NOT NULL, CONSTRAINT[FK_Clients_Products] FOREIGN KEY([cod_prod]) REFERENCES[Products]([cod_prod]))";
                cmd.ExecuteNonQuery();
                Console.WriteLine("The table Clients is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                cmd.CommandText = "CREATE TABLE [dbo].[Comments]([Id_cm] INT NOT NULL PRIMARY KEY, [Id_cl] INT NOT NULL, [Rating] CHAR NOT NULL,  [Comment] TEXT NOT NULL)";
                cmd.ExecuteNonQuery();
                Console.WriteLine("The table Comments is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void PopulateTables()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\IAP\PAC#\Exemple\ServerProducts\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = con.CreateCommand();
            com.CommandText = "INSERT INTO Products (cod_prod, name, price, availability, best_seller) VALUES (@cod_prod, @name, @price, @availability, @best_seller)";
            
            SqlTransaction tx = con.BeginTransaction();
            com.Transaction = tx;
            try
            {
                for (int i = 0; i < p.Length; i++)
                {
                    com.Parameters.AddWithValue("@cod_prod", p[i].cod_prod);
                    com.Parameters.AddWithValue("@price", p[i].price);
                    com.Parameters.AddWithValue("@name", p[i].name);
                    com.Parameters.AddWithValue("@availability", p[i].availability);
                    com.Parameters.AddWithValue("@best_seller", p[i].best_seller);
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
                Console.WriteLine("The table Products is filled");

                com.CommandText = "INSERT INTO Clients (Id_cl, cod_prod, name, address, phone) VALUES (@Id_cl, @cod_prod, @name, @address, @phone)";
                for (int i = 0; i < cl.Length; i++)
                {
                    com.Parameters.AddWithValue("@Id_cl", cl[i].Id_cl);
                    com.Parameters.AddWithValue("@cod_prod", cl[i].cod_prod);
                    com.Parameters.AddWithValue("@name", cl[i].name);
                    com.Parameters.AddWithValue("@address", cl[i].address);
                    com.Parameters.AddWithValue("@phone", cl[i].phone);
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
                Console.WriteLine("The Clients table is filled");

                com.CommandText = "INSERT INTO Comments (Id_cm, Id_cl, Rating, Comment) VALUES (@Id_cm, @Id_cl, @Rating, @Comment)";
                for (int i = 0; i < co.Length; i++)
                {
                    com.Parameters.AddWithValue("@Id_cm", co[i].Id_cm);
                    com.Parameters.AddWithValue("@Id_cl", co[i].Id_cl);
                    com.Parameters.AddWithValue("@Rating", co[i].Rating);
                    com.Parameters.AddWithValue("@Comment", co[i].Comment);
                    com.ExecuteNonQuery();
                    com.Parameters.Clear();
                }
                Console.WriteLine("The Comments table is filled");
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tx.Rollback();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
