using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

public partial class deepanalysis : System.Web.UI.Page
{
    SqlConnection con, con1;
    SqlCommand cmd1;
    string query;
    ArrayList reccomment = new ArrayList();
    ArrayList userdet = new ArrayList();
    ArrayList posi = new ArrayList();
    ArrayList nega = new ArrayList();
    ArrayList rank = new ArrayList();
    ArrayList sen = new ArrayList();
    ArrayList toterr = new ArrayList();
    ArrayList rough = new ArrayList();
    ArrayList pos = new ArrayList();
    ArrayList neg = new ArrayList();
    ArrayList pass = new ArrayList();
    ArrayList negg = new ArrayList();

    int pcount, ncount, scount, rcount, count = 0, count1 = 0, count2 = 0, j1 = 0, rrcount;
    string postedby, pdate, ptime, shareto, post, memname, comment, memdate, stat;
    int orgcnt;
    int recnt;

   protected string srch_word = string.Empty;

    public void data()
    {       
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }
    public void data1()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con1 = new SqlConnection(connstring);
        con1.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GridView1.DataBind();
        }
           

        data();
        query = "delete from poscount";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        
        data();
        query = "delete from negcount";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "delete from modcount";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close(); 

        data();
        query = "select comment from webdataset where comment<>'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd1 = cmd1.ExecuteReader();
        while (rd1.Read())
        {
            toterr.Add(rd1[0].ToString());
        }
        rd1.Close();
        con.Close();

        int testcount = toterr.Count;

        for (int i1 = 0; i1 < testcount; i1++)
        {
            sen.Clear();
            posi.Clear();
            nega.Clear();
            string[] a = toterr[i1].ToString().ToUpper().Split(' ');
            foreach (string i in a)
            {
                sen.Add(i);

            }
            loadarr();
            pcount = posi.Count;
            ncount = nega.Count;
            scount = sen.Count;
            //************************* Positive *********************
            for (int i = 0; i < scount; i++)
            {
                for (int j = 0; j < pcount; j++)
                {
                    if (sen[i].ToString() == posi[j].ToString())
                    {
                        count++;
                        if (count == 0)
                        {

                        }
                        else
                        {                            
                            data();
                            query = "insert into poscount(positive,comment)values('" + sen[i].ToString() + "','" + toterr[i1].ToString() + "')";
                            cmd1 = new SqlCommand(query, con);
                            cmd1.ExecuteNonQuery();
                            con.Close();                          
                        }
                    }
                    else
                    {

                    }
                }
            }
            //************************* End Positive *********************
            //************************* Negative *********************
            for (int i = 0; i < scount; i++)
            {
                for (int j = 0; j < ncount; j++)
                {
                    if (sen[i].ToString() == nega[j].ToString())
                    {
                        count++;
                        if (count == 0)
                        {

                        }
                        else
                        {
                            data();
                            query = "insert into negcount(negative,comment)values('" + sen[i].ToString() + "','" + toterr[i1].ToString() + "')";
                            cmd1 = new SqlCommand(query, con);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else
                    {

                    }
                }
            }
            //************************* End Negative *********************
            //************************* Moderate *********************
            //************************* End Moderate *********************
        }
    }
    public void loadarr()
    {
        data();
        query = "select pword from positive";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader red = cmd1.ExecuteReader();
        while (red.Read())
        {
            posi.Add((string)red[0].ToString());
        }
        red.Close();
        con.Close();

        data();
        query = "select nword from negative ";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd = cmd1.ExecuteReader();
        while (rd.Read())
        {
            nega.Add(rd[0].ToString());
        }
        rd.Close();
        con.Close();
    }
    public void color()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView1.Rows[i].Cells[j].Text == "positive")
                {
                    // Write your Custom Code
                    GridView1.Rows[i].Cells[j].ForeColor = Color.Green;
                }
            }
        }
    }
    public void color1()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView1.Rows[i].Cells[j].Text == "negative")
                {
                    // Write your Custom Code
                    GridView1.Rows[i].Cells[j].ForeColor = Color.Red;
                }
            }
        }
    }
    public void color2()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView1.Rows[i].Cells[j].Text == "moderate")
                {

                    GridView1.Rows[i].Cells[j].ForeColor = Color.Orange;
                }
            }
        }
    }
    protected void btnpositive_Click(object sender, EventArgs e)
    {
        data();
        query = "select comment from webdataset where comment<>'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd12 = cmd1.ExecuteReader();
        while (rd12.Read())
        {
            toterr.Add(rd12[0].ToString());
        }
        rd12.Close();
        con.Close();

        int testcount = toterr.Count;

        for (int i1 = 0; i1 < testcount; i1++)
        {
            data();
            query = "select count(positive) from poscount where positive<>'' and comment='" + toterr[i1].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader rd11 = cmd1.ExecuteReader();
            if (rd11.Read())
            {
                string pcount;
                pcount = rd11[0].ToString();

                data();
                query = "update webdataset set positive='" + pcount + "' where comment='" + toterr[i1].ToString() + "'";
                cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            con.Close();
            rd11.Close();
        }

        GridView1.DataBind();
    }
    protected void btnnegative_Click1(object sender, EventArgs e)
    {
        data();
        query = "select comment from webdataset where comment<>'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd12 = cmd1.ExecuteReader();
        while (rd12.Read())
        {
            toterr.Add(rd12[0].ToString());
        }
        rd12.Close();
        con.Close();

        int testcount = toterr.Count;

        for (int i1 = 0; i1 < testcount; i1++)
        {
            data();
            query = "select count(negative) from negcount where negative<>'' and comment='" + toterr[i1].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader rd13 = cmd1.ExecuteReader();
            if (rd13.Read())
            {
                string ncount;
                ncount = rd13[0].ToString();

                data();
                query = "update webdataset set negative='" + ncount + "' where comment='" + toterr[i1].ToString() + "'";
                cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            con.Close();
            rd13.Close();
        }
        GridView1.DataBind();
    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    data();
    //    query = "select distinct(positive) from poscount where positive<>' '";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd11 = cmd1.ExecuteReader();
    //    while (rd11.Read())
    //    {
    //        pass.Add(rd11[0].ToString());
    //    }
    //    rd11.Close();
    //    con.Close();

    //    int passcount = pass.Count;

    //    for (int i = 0; i < passcount; i++)
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            e.Row.Cells[6].Text = Regex.Replace(e.Row.Cells[6].Text, (" " + pass[i].ToString().Trim() + " "), delegate(Match match)
    //            {
    //                return string.Format(@"<span style = 'background-color:#006600'>{0}</span>", match.Value);
    //            }, RegexOptions.IgnoreCase);
    //            e.Row.Cells[6].Text = Regex.Replace(e.Row.Cells[6].Text, (" " + pass[i].ToString().Trim()), delegate(Match match)
    //            {
    //                return string.Format(@"<span style = 'background-color:#006600'>{0}</span>", match.Value);
    //            }, RegexOptions.IgnoreCase);
    //            e.Row.Cells[6].Text = Regex.Replace(e.Row.Cells[6].Text, (pass[i].ToString().Trim() + " "), delegate(Match match)
    //            {
    //                return string.Format(@"<span style = 'background-color:#006600'>{0}</span>", match.Value);
    //            }, RegexOptions.IgnoreCase);
    //        }
    //    }
    //    pass.Clear();


    //    data();
    //    query = "select distinct(negative) from negcount where negative<>' '";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd12 = cmd1.ExecuteReader();
    //    while (rd12.Read())
    //    {
    //        negg.Add(rd12[0].ToString());
    //    }
    //    rd11.Close();
    //    con.Close();

    //    int neggcount = negg.Count;

    //    for (int i = 0; i < neggcount; i++)
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            e.Row.Cells[6].Text = Regex.Replace(e.Row.Cells[6].Text, (" " + negg[i].ToString().Trim() + " "), delegate(Match match)
    //            {
    //                return string.Format(@"<span style = 'background-color:#FF3300'>{0}</span>", match.Value);
    //            }, RegexOptions.IgnoreCase);
    //            e.Row.Cells[6].Text = Regex.Replace(e.Row.Cells[6].Text, (" " + negg[i].ToString().Trim()), delegate(Match match)
    //            {
    //                return string.Format(@"<span style = 'background-color:#FF3300'>{0}</span>", match.Value);
    //            }, RegexOptions.IgnoreCase);
    //            e.Row.Cells[6].Text = Regex.Replace(e.Row.Cells[6].Text, (negg[i].ToString().Trim() + " "), delegate(Match match)
    //            {
    //                return string.Format(@"<span style = 'background-color:#FF3300'>{0}</span>", match.Value);
    //            }, RegexOptions.IgnoreCase);
    //        }
    //    }
    //    negg.Clear();
    //}
}