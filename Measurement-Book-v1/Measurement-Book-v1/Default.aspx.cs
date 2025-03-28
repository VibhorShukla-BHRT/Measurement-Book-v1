using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Measurement_Book_v1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        private void LoadUsers()
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select Id, Username, Email FROM Users", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                foreach (GridViewRow row in GridView2.Rows)
                {
                    int componentId = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Value);
                    TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
                    Label lblPercentage = (Label)row.FindControl("lblPercentage");

                    if (double.TryParse(txtAmount.Text, out double amount) &&
                        double.TryParse(lblPercentage.Text.Replace("%", ""), out double percentage))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Progress (ComponenetId, Amount, Percntage) VALUES (@ComponentId, @Amount, @Percentage)", conn);
                        cmd.Parameters.AddWithValue("@ComponentId", componentId);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Percentage", percentage);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        protected void LoadFilteredComponents(bool? issvs, bool? isretro, bool? issolar)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT Id, ComponentName, Unit FROM Master WHERE 1=1";

                if (issvs.HasValue) query += " AND IsSVS = @issvs";
                if (isretro.HasValue) query += " AND IsRetro = @isretro";
                if (issolar.HasValue) query += " AND IsSolar = @issolar";

                SqlCommand cmd = new SqlCommand(query, conn);

                if (issvs.HasValue) cmd.Parameters.AddWithValue("@issvs", issvs);
                if (isretro.HasValue) cmd.Parameters.AddWithValue("@isretro", isretro);
                if (issolar.HasValue) cmd.Parameters.AddWithValue("@issolar", issolar);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            bool? issvs = chkSVS.Checked ? true : (bool?)null;
            bool? isretro = chkRetro.Checked ? true : (bool?)null;
            bool? issolar = chkSolar.Checked ? true : (bool?)null;

            LoadFilteredComponents(issvs, isretro, issolar);
        }
        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            TextBox txtAmount = (TextBox)sender;
            GridViewRow row = (GridViewRow)txtAmount.NamingContainer;
            Label lblPercentage = (Label)row.FindControl("lblPercentage");

            if (double.TryParse(txtAmount.Text, out double amount))
            {
                double percentage = (amount / 10000) * 100;
                lblPercentage.Text = percentage.ToString("0.00") + "%";
            }
        }

    }
}