using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
public partial class Intrusiondetection : System.Web.UI.Page
{ SqlConnection con;
    SqlCommand cmd;
    string query;
    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int num = Convert.ToInt32( GridView1.DataKeys[e.RowIndex].Values[0].ToString());
        data();
        query = "delete from hackerdet where id=" + num + "";
        SqlDataSource1.DeleteCommand = query;
        SqlDataSource1.Delete();
        con.Close();
        GridView1.DataBind();
    }
}