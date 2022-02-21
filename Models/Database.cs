using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcBoutique.Models
{
    public class Database
    {
        static string Sqlcon=@"Data Source=RILPT076;Initial Catalog=Boutique;User ID = sa;Password=sa123";
        public List<Boutique> GetBoutique()
        {
            List<Boutique> list = new List<Boutique>();
            using (SqlConnection con = new SqlConnection(Sqlcon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Select * from BoutiqueTable";
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        var bo = new Boutique();
                        bo.BoutiqueId = Convert.ToInt32(reader[0]);
                        bo.DColor = reader[1].ToString();
                        bo.DStyle = reader[2].ToString();
                        bo.DPrice = Convert.ToDouble(reader[3]);
                        list.Add(bo);
                    }


                }
                catch(SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }

        public void AddBoutique(Boutique bout)
        {
            using (SqlConnection con = new SqlConnection(Sqlcon))
            {
                var query = "insert into Boutique values(@DColor,@DStyle,@DPrice)";
                SqlCommand cmd = new SqlCommand(query,con);
               
                cmd.Parameters.AddWithValue("@DColor", bout.DColor);
                cmd.Parameters.AddWithValue("@DStyle", bout.DStyle);
                cmd.Parameters.AddWithValue("@DPrice", bout.DPrice);
                
                try
                {
                    con.Open();
                    int affectrows = cmd.ExecuteNonQuery();
                    if (affectrows == 0)
                        throw new Exception("Boutique details are not added");
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

        }

        public void UpdateBoutique(Boutique bout)
        {
            using (SqlConnection con = new SqlConnection(Sqlcon))
            {
                var query = $"update BoutiqueTable set DColor='{bout.DColor}',DStyle='{bout.DStyle}',DPrice='{bout.DPrice}' where BoutiqueId={bout.BoutiqueId}";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    int rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 0)
                        throw new Exception("No Details were updated");
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }
        }

        public Boutique FindBoutique(int id)
        {
            using (SqlConnection con = new SqlConnection(Sqlcon))
            {
                var bo = new Boutique();
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Select * From BoutiqueTable where BoutiqueId= " + id;
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        bo.BoutiqueId = Convert.ToInt32(reader[0]);
                        bo.DColor = reader[1].ToString();
                        bo.DStyle = reader[2].ToString();
                        bo.DPrice = Convert.ToDouble(reader[3]);
                       
                    }
                    else
                        throw new Exception("No details are found");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }

                return bo;
            }

        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Sqlcon))
            {
                var query = "delete from BoutiqueTable where BoutiqueId=" + id;
                SqlCommand cmd = new SqlCommand(query,con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}