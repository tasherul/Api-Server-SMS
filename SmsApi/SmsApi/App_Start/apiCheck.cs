using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace SmsApi
{
    public class apiCheck
    {
        private string __cString = @"Data Source=DESKTOP-FOOHGE0;Initial Catalog=CMSTemplate;User ID=DesginMasterDB01;Password=Pi@sh885989";


        public string ErrorMessage { get; private set; }
        public int boolCount { get; private set; }
   
    
        //public string strCheck(string Query)
        //{
        //    __Connected();
        //    return __Check.stringCheck(Query);
        //}
        public int intCheck(string Query)
        {
            SqlConnection Con = new SqlConnection(__cString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = Query;

            Con.Open();
            int x = Convert.ToInt32(cmd.ExecuteScalar());
            Con.Close();
            return x;
        }
        //public bool boolCheck(string Query)
        //{
        //    __Connected();
        //    bool ReturnValue = __Check.boolCheck(Query);
        //    boolCount = __Check.BoolCount;
        //    return ReturnValue;
        //}
        public bool ExcutionNonQuery(string Query)
        {
            try
            {
                SqlConnection Con = new SqlConnection(__cString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = Query;

                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        //public SqlDataAdapter SqlDataAdapter(string Query)
        //{
        //    __Connected();
        //    return __Check.SqlDataAdapter(Query);
        //}
        //public SqlDataAdapter SqlDataAdapter(string StoredProcedure, bool Stored)
        //{
        //    __Connected();
        //    return __Check.SqlDataAdapter(StoredProcedure, Stored);
        //}
        public SqlDataReader SqlDataReader(string Query)
        {
            SqlConnection Con = new SqlConnection(__cString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = Query;

            Con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Con.Close();
           
            return dr;
        }
        //public SqlConnection SqlConnection { get; private set; }
   
    }
}