using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class sentimental : System.Web.UI.MasterPage
{
    SqlConnection con;
    SqlCommand cmd, cmd1;
    string query;

    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //lblusername.Text = Session["username"].ToString();
        lblusername.Text = "admin";
        lbldate.Text = System.DateTime.Now.ToShortDateString();
        lbltime.Text = System.DateTime.Now.ToLongTimeString();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        data();
        query = "delete from webdataset";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "delete from rankdet";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "update performdet set pval='0'";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "update trainchart set tval='0'";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Dataset Cleared from DB");
        Response.Redirect("adhome.aspx");
    }
}
