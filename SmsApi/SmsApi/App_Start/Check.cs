using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using ECMS;
using ECMS.Design;
using System.Configuration;
namespace SmsApi
{
    public class Check
    {
        ECMS.Check _CK = new ECMS.Check();
        //ECMS.Connection  = new Connection();
        ECMS.Sqlconnection _CON = new Sqlconnection();
        private string DataBaseName = "AnkurSMS";
        private string DataSource = "DESKTOP-FOOHGE0";
        private string UserName = "1etMM2oJvAizNF6QDQNx";
        private string Password = "pnfT8?p*o3U0N~cR@*nA";


        public string Message { get; private set; }
        public string Server_Message { get; private set; }
        public bool isconneced { get; set; }

        public void Connect()
        {
            //_CON.DatabaseName = DataBaseName;
            //_CON.DataSource = DataSource;
            //_CON.UserID = UserName;
            //_CON.Password = Password;

            string s = ConfigurationManager.ConnectionStrings["AnkurSMS"].ConnectionString;
            _CK.IsConnected = true;
            _CON.ConnectionStringEnable = true;
            _CON.ConnectionString = s;
            _CK.Conected = _CON.Configuration();
            isconneced = _CON.SqlConnectStatus();
        }
        public bool ExcutionNonQuery(string Query)
        {
            Connect();
            bool x = _CK.ExcutionNonQuery(Query);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
        public bool ExcutionNonQuery(string Query, T_Parameter[] Parameter)
        {
            Connect();
            bool x = _CK.ExcutionNonQuery(Query, Parameter);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
        public string stringCheck(String Query)
        {
            Connect();
            string x = _CK.stringCheck(Query);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
        public string stringCheck(String Query, T_Parameter[] Parameter)
        {
            Connect();
            string x = _CK.stringCheck(Query, Parameter);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
        public int int32Check(String Query)
        {
            Connect();
            int x = _CK.int32Check(Query);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
        public int int32Check(String Query, T_Parameter[] Parameter)
        {
            Connect();
            int x = _CK.int32Check(Query, Parameter);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
        public DataTable SqlDataTable(string Query)
        {
            Connect();
            SqlDataAdapter sda = _CK.SqlDataAdapter(Query);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return dt;
        }
        public SqlDataReader SqlDataReader(string Query)
        {
            Connect();
            SqlDataReader x = _CK.SqlDataReader(Query);
            Message = _CK.Messege;
            Server_Message = _CK.ServerMessage;
            return x;
        }
    }
}