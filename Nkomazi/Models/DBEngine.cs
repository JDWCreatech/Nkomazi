using Microsoft.Data.SqlClient;
using System.Data;

namespace Nkomazi.Models
{
    public class DBEngine
    {
        //Set up all required variables, but do not instantiate 
        SqlConnection _con;
        SqlCommand cmd;
        SqlDataAdapter _dAdapter;
        DataTable dt;
        public DBEngine()
        {
            // Update this with your actual DB connection info
            //connectionString = "Server=41.76.213.61,1533;Database=NkomaziFuel;User Id=sa;Password=Cre@tech1234!;TrustServerCertificate=True";

            _con = new SqlConnection("Server=41.76.213.61,1633;Database=CTech_Nkomazi;User Id=sa;Password=sql2017;TrustServerCertificate=True");
        }
        public DataTable Qry(string sQry)
        {
            try
            {
                _con.Open();
                cmd = new SqlCommand(sQry, _con);
                cmd.CommandTimeout = 240;
                _dAdapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                _dAdapter.Fill(dt);
                _con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                if (_con.State == ConnectionState.Open) { _con.Close(); }
                throw;
            }
        }
        public bool ValidateCredentials(string userName, string password)
        {
            try
            {
                _con.Open();
                string query = "SELECT COUNT(*) FROM tUser WHERE username = @user AND password = @pass";
                cmd = new SqlCommand(query, _con);
                cmd.Parameters.AddWithValue("@user", userName);
                cmd.Parameters.AddWithValue("@pass", password); 

                int result = (int)cmd.ExecuteScalar();
                _con.Close();
                return result > 0;
            }
            catch (Exception ex)
            {
                if (_con.State == ConnectionState.Open) _con.Close();
                throw;
            }
        }

    }
}
