using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Collections;
public partial class index : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    string query, ip, pwd, result;
    ArrayList arr = new ArrayList();
    ArrayList arr1 = new ArrayList();
    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        ip = (Request.ServerVariables["REMOTE_ADDR"].ToString());
        data();
        query = "select username,password from adlogintbl where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'";
        cmd = new SqlCommand(query, con);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            Session["username"] = txtusername.Text.ToString();
            Response.Redirect("adhome.aspx");
        }
        else
        {
            data();
            query = "select password from adlogintbl where username='" + txtusername.Text + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader rd1 = cmd.ExecuteReader();
            if (rd1.Read())
            {
                pwd = rd1[0].ToString();
            }

            int a, b;
            a = txtpassword.Text.Length;
            for (int i = 0; i < a; i++)
            {
                arr.Add(txtpassword.Text.Substring(i, 1));

            }
            b = pwd.Length;
            for (int j = 0; j < b; j++)
            {
                arr1.Add(pwd.Substring(j, 1));
            }
            int div1, cnt, cnt1, div2;
            div1 = a / 100;
            div2 = b / 100;
            cnt = arr.Count;
            cnt1 = arr1.Count;
            int r, l, m;
            int r1, l1;
            r1 = 100 / cnt1;
            l1 = r1;
            r = 100 / cnt;
            l = r;

            if (cnt < cnt1)
            {
                //list1
                for (int h = 0; h < cnt; h++)
                {
                    if (arr[h].ToString() == arr1[h].ToString())
                    {
                        if (h == 0)
                        {
                            h = 1;
                        }
                        m = l * h;
                        result = m.ToString() + "%";
                    }
                    if (result == null)
                    {
                        result = "0%";
                    }

                }
            }
            else
            {
                //list2
                for (int h = 0; h < cnt1; h++)
                {
                    if (arr1[h].ToString() == arr[h].ToString())
                    {
                        if (h == 0)
                        {
                            h = 1;
                        }
                        m = l1 * h;
                        result = m.ToString() + "%";
                    }
                    if (result == null)
                    {
                        result = "0%";
                    }

                }
            }

            //hacker code
            data();
            query = "insert into hackerdet(uname,triedpwd,triedip,adate,atime,matchper)values('" + txtusername.Text + "','" + txtpassword.Text + "','" + ip + "','" + System.DateTime.Today.ToShortDateString() + "','" + System.DateTime.Now.ToShortTimeString() + "','" + result + "')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            lblmes.Visible = true;
            lblmes.Text = "Invalid User";
            txtpassword.Text = "";
            txtpassword.Focus();
        }
        rd.Close();
        con.Close();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtusername.Text = "";
        txtpassword.Text = "";
        txtusername.Focus();
    }
}