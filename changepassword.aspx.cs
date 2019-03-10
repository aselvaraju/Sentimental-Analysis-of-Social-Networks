using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class changepassword : System.Web.UI.Page
{
    SqlConnection con;
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
        lblusername.Text = "admin";
    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        data();
        query = "select password from adlogintbl where  password='" + txtoldpassword.Text + "' and username='" + lblusername.Text + "'";
        cmd = new SqlCommand(query, con);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            data();
            query = "update adlogintbl set password='" + txtretypepassword.Text + "' where password='" + txtoldpassword.Text + "' and username='" + lblusername.Text + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmes.Visible = true;
            lblmes.Text = "Password Changed Successfully";

            txtoldpassword.Text = "";
            txtnewpassword.Text = "";
            txtretypepassword.Text = "";
        }
        else
        {
            lblmes.Visible = true;
            lblmes.Text = "Old Password Incorect";
            txtoldpassword.Text = "";
            txtoldpassword.Focus();
        }
        rd.Close();
        con.Close();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        lblmes.Visible = false;
        txtoldpassword.Text = "";
        txtnewpassword.Text = "";
        txtretypepassword.Text = "";
        txtoldpassword.Focus();
    }
}