using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ELibraryManagement
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            GetUserById();
        }
        //active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateUserStatusByID("active");
        }
        //pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateUserStatusByID("pending");
        }
        //deactivate button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            updateUserStatusByID("Deactive");
        }
        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteUserByID();
        }

        // user defined function

        
        

        void updateUserStatusByID(string status)
        {
           
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                   
                    SqlCommand cmd = new SqlCommand("UPDATE user_master_tbl SET account_status='" + status + "' WHERE user_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();            
                    GridView1.DataBind();
                    Response.Write("<script>alert('User Status Updated');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
           
        }

        void deleteUserByID()
        {
            
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from user_master_tbl WHERE user_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('User Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

           
            
        }

        void GetUserById()
        {

            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT* from user_master_tbl where user_id='" + TextBox1.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(2).ToString();
                        TextBox4.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();


                    }


                }
                else
                {
                    Response.Write("<script>alert('invalid credentials');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

          
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}