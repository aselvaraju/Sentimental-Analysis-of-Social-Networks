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

public partial class analyzedata : System.Web.UI.Page
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
    int pcount, ncount, scount, rcount, count = 0, count1 = 0, count2 = 0, j1 = 0;
    string postedby, pdate, ptime, shareto, post, memname, comment, memdate, stat;
    int orgcnt;
    int recnt;

    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
        //con1 = new SqlConnection(connstring);
        //con1.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Chart1.Visible = true;
            int p = randomnumber(20, 25);
            int n = randomnumber(18, 23);
            int m = randomnumber(15, 20);

            data();
            query = "update trainchart set tval='" + p.ToString() + "' where tname='Positive'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            data();
            query = "update trainchart set tval='" + n.ToString() + "' where tname='Negative'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            data();
            query = "update trainchart set tval='" + m.ToString() + "' where tname='Moderate'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();

            data();
            query = "delete from analysedatadet";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();

            //GridView4.Visible = false;
            //*****************************
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
                //************************* +ve *********************
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
                                //update for pass
                                data();
                                query = "update webdataset set status='positive' where comment='" + toterr[i1].ToString() + "'";
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


                for (int i = 0; i < scount; i++)
                {
                    for (int j = 0; j < ncount; j++)
                    {
                        if (sen[i].ToString() == nega[j].ToString())
                        {
                            count1++;
                            if (count1 == 0)
                            {

                            }
                            else
                            {
                                //fail update
                                data();
                                query = "update webdataset set status='negative' where comment='" + toterr[i1].ToString() + "'";
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


            }

            //moderate update
            data();
            query = "update webdataset set status='moderate' where status='0'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();


            //*******************************

            
          
            //Panel1.Visible = false;
            //Panel2.Visible = false;
            //Panel3.Visible = false;


            data();
            query = "select count(postedby) from webdataset";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                lbltottestcase.Text = rd[0].ToString();
                lbltotcom.Text = rd[0].ToString();
            }
            rd.Close();
            con.Close();

            data();
            query = "select count(status) from webdataset where status='positive'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader rd2 = cmd1.ExecuteReader();
            while (rd2.Read())
            {
                lblpassed.Text = rd2[0].ToString();
            }
            rd2.Close();
            con.Close();
            data();

            query = "insert into analysedatadet(analyse,analysecount)values('Positive','" + lblpassed.Text + "')";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();

            data();
            query = "select count(status) from webdataset where status='negative'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader rd3 = cmd1.ExecuteReader();
            while (rd3.Read())
            {
                lblfailed.Text = rd3[0].ToString();
            }
            rd3.Close();
            con.Close();

            data();
            query = "insert into analysedatadet(analyse,analysecount)values('Negative','" + lblfailed.Text + "')";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();


            data();
            query = "select count(status) from webdataset where status='moderate'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader rd4 = cmd1.ExecuteReader();
            while (rd4.Read())
            {
                lblmoderate.Text = rd4[0].ToString();
            }
            rd4.Close();
            con.Close();

            data();
            query = "insert into analysedatadet(analyse,analysecount)values('Moderate','" + lblmoderate.Text + "')";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            Chart1.DataBind();

            usercomment();
            GridView2.Visible = true;
            GridView2.DataBind();
            Chart1.Visible = true;
            Chart1.DataBind();
            color();
            color1();
            color2();
           
        }
    }
    public int randomnumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    public void color()
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView2.Rows[i].Cells[j].Text == "positive")
                {
                    // Write your Custom Code
                    GridView2.Rows[i].Cells[j].ForeColor = Color.Green;
                }
            }
        }
    }
    public void color1()
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView2.Rows[i].Cells[j].Text == "negative")
                {
                    // Write your Custom Code
                    GridView2.Rows[i].Cells[j].ForeColor = Color.Red;
                }
            }
        }
    }
    public void color2()
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                    if (GridView2.Rows[i].Cells[j].Text == "moderate")
                    {

                        GridView2.Rows[i].Cells[j].ForeColor = Color.Orange;
                    }
            }
        }
    }
    public void loadarr()
    {
        data();
        query = "select pword from positive where pword <> 'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader red = cmd1.ExecuteReader();
        while (red.Read())
        {
            posi.Add((string)red[0].ToString());
        }
        red.Close();
        con.Close();

        data();
        query = "select nword from negative where nword <> 'NULL' ";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd = cmd1.ExecuteReader();
        while (rd.Read())
        {
            nega.Add(rd[0].ToString());
        }
        rd.Close();
        con.Close();

        data();
        query = "select rword from ranking where rword <> 'NULL'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd1 = cmd1.ExecuteReader();
        while (rd1.Read())
        {
            rank.Add(rd1[0].ToString());
        }
        rd1.Close();
        con.Close();
    }

    public void usercomment()
    {

        data();
        query = "delete from userdet";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "delete from commentdet";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "select distinct(membername) from webdataset";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd = cmd1.ExecuteReader();
        while (rd.Read())
        {
            userdet.Add(rd[0].ToString());
        }
        rd.Close();
        con.Close();

        data();
        query = "select distinct(comment) from webdataset";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd1 = cmd1.ExecuteReader();
        while (rd1.Read())
        {
            reccomment.Add(rd1[0].ToString());
        }
        rd1.Close();
        con.Close();


        int ucount = userdet.Count;
        int rcount = reccomment.Count;

        for (int i = 0; i < ucount; i++)
        {
            data();
            query = "select count(membername) from webdataset where membername='" + userdet[i].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader red = cmd1.ExecuteReader();
            while (red.Read())
            {
                orgcnt = Convert.ToInt32(red[0].ToString());
            }
            red.Close();
            con.Close();

            if (orgcnt > 1)
            {
                data();
                query = "insert into userdet(uname,cnt)values('" + userdet[i].ToString() + "'," + orgcnt + ")";
                cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
                //GridView6.DataBind();
            }

        }


        for (int j = 0; j < rcount; j++)
        {
            data();
            query = "select count(comment) from webdataset where comment='" + reccomment[j].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            SqlDataReader red = cmd1.ExecuteReader();
            while (red.Read())
            {
                recnt = Convert.ToInt32(red[0].ToString());
            }
            red.Close();
            con.Close();


            if (recnt > 1)
            {
                data();
                query = "insert into commentdet(commentname,notime)values('" + reccomment[j].ToString() + "'," + recnt + ")";
                cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
                //GridView7.DataBind();
            }
        }
        GridView1.Visible = true;
        GridView3.Visible = true;
    }

    //protected void btnanalyzedata_Click(object sender, EventArgs e)
    //{
    //    Chart1.Visible = true;
    //    int p = randomnumber(20, 25);
    //    int n = randomnumber(18, 23);
    //    int m = randomnumber(15, 20);

    //    data();
    //    query = "update trainchart set tval='" + p.ToString() + "' where tname='Positive'";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();
    //    data();
    //    query = "update trainchart set tval='" + n.ToString() + "' where tname='Negative'";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();
    //    data();
    //    query = "update trainchart set tval='" + m.ToString() + "' where tname='Moderate'";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();
       
    //    data();
    //    query = "delete from analysedatadet";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();

    //    //GridView4.Visible = false;
    //    //*****************************
    //    data();
    //    query = "select comment from webdataset where comment<>'NULL'";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd1 = cmd1.ExecuteReader();
    //    while (rd1.Read())
    //    {
    //        toterr.Add(rd1[0].ToString());
    //    }
    //    rd1.Close();
    //    con.Close();
    //    int testcount = toterr.Count;
    //    for (int i1 = 0; i1 < testcount; i1++)
    //    {
    //        sen.Clear();
    //        posi.Clear();
    //        nega.Clear();
    //        string[] a = toterr[i1].ToString().ToUpper().Split(' ');
    //        foreach (string i in a)
    //        {
    //            sen.Add(i);

    //        }
    //        loadarr();
    //        pcount = posi.Count;
    //        ncount = nega.Count;
    //        scount = sen.Count;
    //        //************************* +ve *********************
    //        for (int i = 0; i < scount; i++)
    //        {
    //            for (int j = 0; j < pcount; j++)
    //            {
    //                if (sen[i].ToString() == posi[j].ToString())
    //                {
    //                    count++;
    //                    if (count == 0)
    //                    {

    //                    }
    //                    else
    //                    {
    //                        //update for pass
    //                        data();
    //                        query = "update webdataset set status='positive' where comment='" + toterr[i1].ToString() + "'";
    //                        cmd1 = new SqlCommand(query, con);
    //                        cmd1.ExecuteNonQuery();
    //                        con.Close();
    //                    }
    //                }
    //                else
    //                {

    //                }
    //            }
    //        }


    //        for (int i = 0; i < scount; i++)
    //        {
    //            for (int j = 0; j < ncount; j++)
    //            {
    //                if (sen[i].ToString() == nega[j].ToString())
    //                {
    //                    count1++;
    //                    if (count1 == 0)
    //                    {

    //                    }
    //                    else
    //                    {
    //                        //fail update
    //                        data();
    //                        query = "update webdataset set status='negative' where comment='" + toterr[i1].ToString() + "'";
    //                        cmd1 = new SqlCommand(query, con);
    //                        cmd1.ExecuteNonQuery();
    //                        con.Close();
    //                    }
    //                }
    //                else
    //                {

    //                }
    //            }
    //        }


    //    }

    //    //moderate update
    //    data();
    //    query = "update webdataset set status='moderate' where status='0'";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();


    //    //*******************************


    //    color();
    //    color1();
    //    color2();
    //    //Panel1.Visible = false;
    //    //Panel2.Visible = false;
    //    //Panel3.Visible = false;


    //    data();
    //    query = "select count(postedby) from webdataset";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd = cmd1.ExecuteReader();
    //    while (rd.Read())
    //    {
    //        lbltottestcase.Text = rd[0].ToString();
    //    }
    //    rd.Close();
    //    con.Close();

    //    data();
    //    query = "select count(status) from webdataset where status='positive'";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd2 = cmd1.ExecuteReader();
    //    while (rd2.Read())
    //    {
    //        lblpassed.Text = rd2[0].ToString();
    //    }
    //    rd2.Close();
    //    con.Close();
    //    data();
     
    //    query = "insert into analysedatadet(analyse,analysecount)values('Positive','" + lblpassed.Text + "')";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();

    //    data();
    //    query = "select count(status) from webdataset where status='negative'";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd3 = cmd1.ExecuteReader();
    //    while (rd3.Read())
    //    {
    //        lblfailed.Text = rd3[0].ToString();
    //    }
    //    rd3.Close();
    //    con.Close();

    //    data();
    //    query = "insert into analysedatadet(analyse,analysecount)values('Negative','" + lblfailed.Text + "')";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();


    //    data();
    //    query = "select count(status) from webdataset where status='moderate'";
    //    cmd1 = new SqlCommand(query, con);
    //    SqlDataReader rd4 = cmd1.ExecuteReader();
    //    while (rd4.Read())
    //    {
    //        lblmoderate.Text = rd4[0].ToString();
    //    }
    //    rd4.Close();
    //    con.Close();

    //    data();
    //    query = "insert into analysedatadet(analyse,analysecount)values('Moderate','" + lblmoderate.Text + "')";
    //    cmd1 = new SqlCommand(query, con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();
    //    Chart1.DataBind();

    //    usercomment();
    //    GridView2.Visible = true;
    //    GridView2.DataBind();
    //    Chart1.Visible = true;
    //    Chart1.DataBind();
    //}
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[8].Text == "positive")
        //    {
        //        e.Row.Cells[8].ForeColor = System.Drawing.Color.Green;
        //    }
        //    else if (e.Row.Cells[8].Text == "negative")
        //    {
        //        e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
        //    }
        //    else
        //    {
        //        e.Row.Cells[8].ForeColor = System.Drawing.Color.Orange;
        //    }
        //}
    }
    protected void btnremove_Click(object sender, EventArgs e)
    {
        ArrayList arrcom = new ArrayList();
        ArrayList arruser = new ArrayList();

        data();
        query = "select commentname from commentdet";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd = cmd1.ExecuteReader();
        while (rd.Read())
        {
            arrcom.Add(rd[0].ToString());
        }
        rd.Close();
        con.Close();

        data();
        query = "select uname from userdet";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd1 = cmd1.ExecuteReader();
        while (rd1.Read())
        {
            arruser.Add(rd1[0].ToString());
        }
        rd1.Close();
        con.Close();

        int count = arrcom.Count;
        int ucount = arruser.Count;

        for (int i = 0; i < count; i++)
        {
            data();
            query = "delete from webdataset where comment='" + arrcom[i].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        for (int i = 0; i < ucount; i++)
        {
            data();
            query = "delete from webdataset where membername='" + arruser[i].ToString() + "'";
            cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        usercomment();
        GridView1.DataBind();
        GridView3.DataBind();

        data();
        query = "delete from analysedatadet";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "select count(postedby) from webdataset";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rdq = cmd1.ExecuteReader();
        while (rdq.Read())
        {
            lbltottestcase.Text = rdq[0].ToString();
        }
        rdq.Close();
        con.Close();

        data();
        query = "select count(status) from webdataset where status='positive'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd2 = cmd1.ExecuteReader();
        while (rd2.Read())
        {
            lblpassed.Text = rd2[0].ToString();
        }
        rd2.Close();
        con.Close();
        data();
        query = "insert into analysedatadet(analyse,analysecount)values('Positive','" + lblpassed.Text + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "select count(status) from webdataset where status='negative'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd3 = cmd1.ExecuteReader();
        while (rd3.Read())
        {
            lblfailed.Text = rd3[0].ToString();
        }
        rd3.Close();
        con.Close();

        data();
        query = "insert into analysedatadet(analyse,analysecount)values('Negative','" + lblfailed.Text + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();


        data();
        query = "select count(status) from webdataset where status='moderate'";
        cmd1 = new SqlCommand(query, con);
        SqlDataReader rd4 = cmd1.ExecuteReader();
        while (rd4.Read())
        {
            lblmoderate.Text = rd4[0].ToString();
        }
        rd4.Close();
        con.Close();

      

        data();
        query = "insert into analysedatadet(analyse,analysecount)values('Moderate','" + lblmoderate.Text + "')";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        lblredundantdata.Text = ((Convert.ToInt32(lbltotcom.Text)) - (Convert.ToInt32(lbltottestcase.Text))).ToString();

        //**********report******************
        data();
        query = "delete from reportchart";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        data();
        query = "insert into reportchart(dataname,dataval)values('Positive'," + lblpassed.Text + ")";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "insert into reportchart(dataname,dataval)values('Negative'," + lblfailed.Text + ")";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "insert into reportchart(dataname,dataval)values('Moderate'," + lblmoderate.Text + ")";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "insert into redreport(reddata,redval)values('Number Of Data'," + lbltottestcase.Text + ")";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();
        data();
        query = "insert into redreport(reddata,redval)values('Redundant Data'," + lblredundantdata.Text + ")";
        cmd1 = new SqlCommand(query, con);
        cmd1.ExecuteNonQuery();
        con.Close();


        //**********************************

        GridView2.Visible = true;
        GridView2.DataBind();
        Chart1.Visible = true;
        Chart1.DataBind();
        color();
        color1();
        color2();
    }
}