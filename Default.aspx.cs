using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployeeData();
        }
    }
    private void BindEmployeeData()
    {
        String sqlconnection = "Data Source=DRIMESHLAPTOP\\SQLEXPRESS;Initial Catalog=CURD;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True";
        using (SqlConnection conn = new SqlConnection(sqlconnection))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindEmployeeData();
    }

}



    
