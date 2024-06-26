﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTap
{
    public partial class api : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=127.0.0.1\\SQLEXPRESS;Initial Catalog=chuchua;User Id=sa;Password=123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Chart", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        object kq = command.ExecuteScalar();
                        string json = (string)kq;
                        this.Response.ContentType = "application/json";
                        this.Response.Write(json);
                    }
                    catch (Exception ex)
                    {
                        this.Response.ContentType = "application/json";
                        this.Response.Write("{\"ok\":0,\"msg\":\"" + ex.Message + "\"}");
                    }
                }
            }
        }
    }
}
