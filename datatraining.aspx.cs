using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class datatraining : System.Web.UI.Page
{
    SqlConnection con,con1;
    SqlCommand cmd;
    string query;

    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
        con1 = new SqlConnection(connstring);
        con1.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView2.DataBind();
            GridView1.DataBind();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        data();
        query = "delete from positive";
        cmd = new SqlCommand(query, con1);
        cmd.ExecuteNonQuery();
        con1.Close();

        if ((FileUpload1.HasFile))
        {

            if (!Convert.IsDBNull(FileUpload1.PostedFile) &
                FileUpload1.PostedFile.ContentLength > 0)
            {

                //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload1.SaveAs(Server.MapPath(".") + "\\" + FileUpload1.FileName);

                SqlBulkCopy oSqlBulk = null;

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + FileUpload1.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    // SET THE CONNECTION STRING.
                    string sCon = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(sCon))
                    {
                        con.Open();

                        // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                        oSqlBulk = new SqlBulkCopy(con);
                        oSqlBulk.DestinationTableName = "positive"; // TABLE NAME.
                        oSqlBulk.WriteToServer(objBulkReader);
                    }
                    //lblConfirm.Visible = true;
                    //lblConfirm.Text = "Successfully Uploaded";
                    //lblConfirm.Attributes.Add("style", "color:green");
                    lblack.Visible = true;
                }
                catch (Exception ex)
                {
                    lblack.Visible = true;
                    lblack.Text = ex.Message;
                    //lblConfirm.Attributes.Add("style", "color:red");
                }
                finally
                {
                    // CLEAR.
                    oSqlBulk.Close();
                    oSqlBulk = null;
                    myExcelConn.Close();
                    myExcelConn = null;
                }
            }
        }
        GridView1.DataBind();
    }
    protected void btnnegsubmit_Click(object sender, EventArgs e)
    {
        data();
        query = "delete from negative";
        cmd = new SqlCommand(query, con1);
        cmd.ExecuteNonQuery();
        con1.Close();

        if ((FileUpload2.HasFile))
        {

            if (!Convert.IsDBNull(FileUpload2.PostedFile) &
                FileUpload2.PostedFile.ContentLength > 0)
            {

                //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload2.SaveAs(Server.MapPath(".") + "\\" + FileUpload2.FileName);

                SqlBulkCopy oSqlBulk = null;

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + FileUpload2.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    // SET THE CONNECTION STRING.
                    string sCon = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(sCon))
                    {
                        con.Open();

                        // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                        oSqlBulk = new SqlBulkCopy(con);
                        oSqlBulk.DestinationTableName = "negative"; // TABLE NAME.
                        oSqlBulk.WriteToServer(objBulkReader);
                    }
                    //lblConfirm.Visible = true;
                    //lblConfirm.Text = "Successfully Uploaded";
                    //lblConfirm.Attributes.Add("style", "color:green");
                    lblack1.Visible = true;
                }
                catch (Exception ex)
                {
                    lblack1.Visible = true;
                    lblack1.Text = ex.Message;
                    //lblConfirm.Attributes.Add("style", "color:red");
                }
                finally
                {
                    // CLEAR.
                    oSqlBulk.Close();
                    oSqlBulk = null;
                    myExcelConn.Close();
                    myExcelConn = null;
                }
            }
        }
        GridView2.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string pid = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        data();
        query = "delete from positive where pword='" + pid + "'";
        SqlDataSource1.DeleteCommand = query;
        SqlDataSource1.Delete();
        con.Close();
        GridView1.DataBind();
        lblack.Visible = false;
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string nid = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
        data();
        query = "delete from negative where nword='" + nid + "'";
        SqlDataSource2.DeleteCommand = query;
        SqlDataSource2.Delete();
        con.Close();
        GridView2.DataBind();
        lblack1.Visible = false;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        lblack.Visible = false;
    }
    protected void btnnegcancel_Click(object sender, EventArgs e)
    {
        lblack1.Visible = false;
    }
}