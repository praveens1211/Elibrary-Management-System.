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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        // add event
        protected void Button2_Click(object sender, EventArgs e)
        {
            
                if (CheckIfPublisherExists())
                {
                    Response.Write("<script>alert('Publisher  with this ID already Exist. You cannot add another Publisher with the same Publisher ID');</script>");
                }
                else
                {
                    AddNewPublisher();
                }
                ClearForm();

           


        }
        // go event
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetbyPublisherid();
        }


        // update event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
            ClearForm();
            
        }



        //delete event
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (CheckIfPublisherExists())
            {
                DeletePublisher(); 
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
            ClearForm();
            
        }




        //user defined events
        void GetbyPublisherid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Redirect("<script>alert(No Publisher Found);</script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }

        }



        void DeletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM  publisher_master_tbl  WHERE publisher_id='" +TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            
        }


        void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE  publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);


                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Updated Successfully');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




        void AddNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher added Successfully');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        bool CheckIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

                return false;
            }


        }



        void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }






    }
}