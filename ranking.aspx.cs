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

public partial class ranking : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd,cmd1;
    string query;
    ArrayList reccomment = new ArrayList();
    ArrayList userdet = new ArrayList();
    ArrayList posi = new ArrayList();
    ArrayList nega = new ArrayList();
    ArrayList rank = new ArrayList();
    ArrayList sen = new ArrayList();
    ArrayList toterr = new ArrayList();
    int pcount, ncount, scount, rcount, count = 0, count1 = 0, count2 = 0, j1 = 0;
    string postedby, pdate, ptime, shareto, post, memname, comment, memdate, stat,tot, pass, neg, mod;
    int orgcnt;
    int recnt;

    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void color()
    {
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            for (int j = 0; j < GridView3.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView3.Rows[i].Cells[j].Text == "positive")
                {
                    // Write your Custom Code
                    GridView3.Rows[i].Cells[j].ForeColor = Color.Green;
                }
            }
        }
    }
    public void color1()
    {
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            for (int j = 0; j < GridView3.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView3.Rows[i].Cells[j].Text == "negative")
                {
                    // Write your Custom Code
                    GridView3.Rows[i].Cells[j].ForeColor = Color.Red;
                }
            }
        }
    }
    public void color2()
    {
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            for (int j = 0; j < GridView3.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView3.Rows[i].Cells[j].Text == "moderate")
                {

                    GridView3.Rows[i].Cells[j].ForeColor = Color.Orange;
                }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        data();
        query = "insert into ranking(rword) values('" + txtranking.Text.ToUpper() + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        txtranking.Text = "";
        GridView1.DataBind();
        GridView2.Visible = false;
        GridView3.Visible = false;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string rid = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        data();
        query = "delete from ranking where rword='" + rid + "'";
        SqlDataSource1.DeleteCommand = query;
        SqlDataSource1.Delete();
        con.Close();
        GridView1.DataBind();
        Chart1.Visible = false;
        Chart1.DataBind();
        GridView2.Visible = false;
        GridView2.DataBind();
        GridView3.Visible = false;
        GridView3.DataBind();
        GridView4.Visible = false;
        GridView4.DataBind();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        data();
        query = "delete from ranking";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "delete from rankkeyselect";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        GridView1.DataBind();
        GridView2.Visible = false;
        GridView2.DataBind();
        GridView3.Visible = false;
        GridView3.DataBind();
        GridView4.Visible = false;
        GridView4.DataBind();
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        //data();
        //query = "delete from rankkeyselect";
        //cmd1 = new SqlCommand(query, con);
        //cmd1.ExecuteNonQuery();
        //con.Close();

        //GridView2.Visible = true;
        //data();
        //query = "select rword from ranking ";
        //cmd1 = new SqlCommand(query, con);
        //SqlDataReader rd1 = cmd1.ExecuteReader();
        //while (rd1.Read())
        //{
        //    rank.Add(rd1[0].ToString());
        //}
        //rd1.Close();
        //con.Close();

        //rcount = rank.Count;
        //for (int i = 0; i < rcount; i++)
        //{
        //    data();
        //    query = "insert into rankkeyselect(rankkeyword,numtime)values('" + rank[i].ToString() + "','0')";
        //    cmd1 = new SqlCommand(query, con);
        //    cmd1.ExecuteNonQuery();
        //    con.Close();
        //}

        ////counting ranking keywords
        //data();
        //query = "select comment from webdataset where comment<>'NULL'";
        //cmd1 = new SqlCommand(query, con);
        //SqlDataReader rd11 = cmd1.ExecuteReader();
        //while (rd11.Read())
        //{
        //    toterr.Add(rd11[0].ToString());
        //}
        //rd11.Close();
        //con.Close();

        //int testcount = toterr.Count;
        //for (int i1 = 0; i1 < testcount; i1++)
        //{
        //    // sen.Clear();
        //    // rank.Clear();
        //    string[] a = toterr[i1].ToString().ToUpper().Split(' ');
        //    foreach (string i in a)
        //    {

        //        sen.Add(i);

        //    }
        //}

        //scount = sen.Count;
        //// loadarr();
        //int j1;
        //for (int i = 0; i < rcount; i++)
        //{
        //    count2 = 0;
        //    for (j1 = 0; j1 < scount; j1++)
        //    {
        //        if (sen[j1].ToString() == rank[i].ToString())
        //        {
        //            count2++;
        //        }
        //    }

        //    data();
        //    query = "update rankkeyselect set numtime='" + count2.ToString() + "' where rankkeyword='" + rank[i].ToString() + "'";
        //    cmd1 = new SqlCommand(query, con);
        //    cmd1.ExecuteNonQuery();
        //    con.Close();
        //}
        //GridView2.DataBind();

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

        data();
        query = "select rword from ranking ";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd1 = cmd1.ExecuteReader();
        while (rd1.Read())
        {
            rank.Add(rd1[0].ToString());
        }
        rd1.Close();
        con.Close();
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        //***************Show Result Button Gridview2*********************

        data();
        query = "delete from rankkeyselect";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        GridView2.Visible = true;
        data();
        query = "select rword from ranking ";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd1 = cmd1.ExecuteReader();
        while (rd1.Read())
        {
            rank.Add(rd1[0].ToString());
        }
        rd1.Close();
        con.Close();

        rcount = rank.Count;
        for (int i = 0; i < rcount; i++)
        {
            data();
            query = "insert into rankkeyselect(rankkeyword,numtime)values('" + rank[i].ToString() + "','0')";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        //counting ranking keywords
        data();
        query = "select comment from webdataset where comment<>'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd11 = cmd1.ExecuteReader();
        while (rd11.Read())
        {
            toterr.Add(rd11[0].ToString());
        }
        rd11.Close();
        con.Close();

        int testcount = toterr.Count;
        for (int i1 = 0; i1 < testcount; i1++)
        {
            // sen.Clear();
            // rank.Clear();
            string[] a = toterr[i1].ToString().ToUpper().Split(' ');
            foreach (string i in a)
            {

                sen.Add(i);

            }
        }

        scount = sen.Count;
        // loadarr();
        int j1;
        for (int i = 0; i < rcount; i++)
        {
            count2 = 0;
            for (j1 = 0; j1 < scount; j1++)
            {
                if (sen[j1].ToString() == rank[i].ToString())
                {
                    count2++;
                }
            }

            data();
            query = "update rankkeyselect set numtime='" + count2.ToString() + "' where rankkeyword='" + rank[i].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        Chart1.Visible = true;
        Chart1.DataBind();
        GridView2.Visible = true;
        GridView2.DataBind();

        //************End Show Button Gridview2***************

        data();
        query = "delete from rankdet";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        //*****************************
        data();
        query = "select comment from webdataset where comment<>'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd2 = cmd1.ExecuteReader();
        while (rd2.Read())
        {
            toterr.Add(rd2[0].ToString());
        }
        rd1.Close();
        con.Close();
        int testcount1 = toterr.Count;
        for (int i1 = 0; i1 < testcount; i1++)
        {
            sen.Clear();
            rank.Clear();
            string[] a = toterr[i1].ToString().ToUpper().Split(' ');
            foreach (string i in a)
            {
                sen.Add(i);

            }
            loadarr();
            scount = sen.Count;
            rcount = rank.Count;
            //************************* +ve *********************
            for (int i = 0; i < scount; i++)
            {
                for (int j = 0; j < rcount; j++)
                {
                    if (sen[i].ToString() == rank[j].ToString())
                    {
                        count2++;
                        if (count2 == 0)
                        {

                        }
                        else
                        {

                            //inserting into rankdet

                            data();
                            query = "select * from webdataset where comment='" + toterr[i1].ToString() + "'";
                            cmd1 = new SqlCommand(query, con);
                            SqlDataReader rd = cmd1.ExecuteReader();
                            while (rd.Read())
                            {
                                postedby = rd[0].ToString();
                                pdate = rd[1].ToString();
                                ptime = rd[2].ToString();
                                shareto = rd[3].ToString();
                                post = rd[4].ToString();
                                memname = rd[5].ToString();
                                comment = rd[6].ToString();
                                memdate = rd[7].ToString();
                                stat = rd[8].ToString();
                                data();
                                query = "insert into rankdet(postedby,posteddate,postedtime,sharedto,post,membername,comment,memberdatetime,status)values('" + postedby + "','" + pdate + "','" + ptime + "','" + shareto + "','" + post + "','" + memname + "','" + comment + "','" + memdate + "','" + stat + "')";
                                cmd1 = new SqlCommand(query, con);
                                cmd1.ExecuteNonQuery();
                                con.Close();
                            }
                            rd.Close();
                            con.Close();

                        }
                    }
                    else
                    {

                    }
                }
            }

        }
        GridView3.Visible = true;
        GridView3.DataBind();
        color();
        color1();
        color2();
    }
    protected void btnanalyse_Click(object sender, EventArgs e)
    {
        data();
        query = "delete from analysedatadet";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "select count(postedby) from rankdet";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rdq = cmd1.ExecuteReader();
        while (rdq.Read())
        {
           tot = rdq[0].ToString();
        }
        rdq.Close();
        con.Close();

        data();
        query = "select count(status) from rankdet where status='positive'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd2 = cmd1.ExecuteReader();
        while (rd2.Read())
        {
            pass = rd2[0].ToString();
        }
        rd2.Close();
        con.Close();
        data();
        query = "insert into analysedatadet(analyse,analysecount)values('Positive','" + pass + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "select count(status) from rankdet where status='negative'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd3 = cmd1.ExecuteReader();
        while (rd3.Read())
        {
            neg = rd3[0].ToString();
        }
        rd3.Close();
        con.Close();

        data();
        query = "insert into analysedatadet(analyse,analysecount)values('Negative','" + neg + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();


        data();
        query = "select count(status) from rankdet where status='moderate'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd4 = cmd1.ExecuteReader();
        while (rd4.Read())
        {
            mod = rd4[0].ToString();
        }
        rd4.Close();
        con.Close();

        data();
        query = "insert into analysedatadet(analyse,analysecount)values('Moderate','" + mod + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        Chart1.Visible = true;
        Chart1.DataBind();
        Chart2.Visible = true;
        Chart2.DataBind();
        GridView2.Visible = true;
        GridView2.DataBind();      
        GridView3.Visible = true;
        GridView3.DataBind();
        GridView4.Visible = true;
        GridView4.DataBind();
        color();
        color1();
        color2();
    }
}