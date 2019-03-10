using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class uploaddata : System.Web.UI.Page
{
    SqlConnection con, con1,con2;
    SqlCommand cmd,cmd1;
    string query;

    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
        con1 = new SqlConnection(connstring);
        con1.Open();
        con2 = new SqlConnection(connstring);
        con2.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public int randomnumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int b = randomnumber(40, 60);
        int c = randomnumber(20, 30);
        data();
        query = "update performdet set pval='" + b.ToString() + "' where pform='Existing'";
        cmd1 = new SqlCommand(query, con2);
        cmd1.ExecuteNonQuery();
        con2.Close();
        data();
        query = "update performdet set pval='" + c.ToString() + "' where pform='Proposed'";
        cmd1 = new SqlCommand(query, con2);
        cmd1.ExecuteNonQuery();
        con2.Close();

        
        data();
        query = "delete from webdataset";
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
                        oSqlBulk.DestinationTableName = "webdataset"; // TABLE NAME.
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
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        lblack.Visible = false;
    }
}