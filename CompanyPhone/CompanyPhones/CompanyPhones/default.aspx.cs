using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyPhones
{
    public partial class _default : System.Web.UI.Page
    {
        public DrumbiDataContext db = new DrumbiDataContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {



            if (dropCompany.SelectedValue == "" )
            {
                int count;
                count = 1;
                List<tbl_Company> companies = (from c in db.tbl_Companies
                                               select c).ToList();
                ListItem[] items = new ListItem[companies.Count() +1];
                items[0] = new ListItem("", "0");
                
                companies.ForEach(delegate(tbl_Company company)
                {
                   
                    items[count] = new ListItem(company.CompanyName, company.CompanyId.ToString());
                    count++;
                    
                });

                dropCompany.Items.AddRange(items);
                dropCompany.DataBind();
                
            }
        }

        protected void Selected_Change(object sender, EventArgs e)
        {
            dropAgent.Items.Clear();
            int count;
            Label2.Visible = true;
            count = 1;
            List<tbl_CompanyAgent> agents = (from a in db.tbl_CompanyAgents
                                             where a.CompanyID == int.Parse(dropCompany.SelectedValue)
                                             select a).ToList();

           
            ListItem[] items = new ListItem[agents.Count() + 1];
            items[0] = new ListItem("", "0");
            agents.ForEach(delegate(tbl_CompanyAgent agent)
            {
                items[count] = new ListItem(agent.FirstName, agent.AgentID.ToString());

                count++;
            });

            dropAgent.Items.AddRange(items);
            dropAgent.DataBind();
            txtPhone.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
           
        }

        protected void Selected_ChangeInAgent(object sender, EventArgs e)
        {

             Label4.Text = "Current Phone Number: " + db.tbl_CompanyAgents.SingleOrDefault(a => a.AgentID == int.Parse(dropAgent.Text)).Phone;

             if (Label4.Text != "Current Phone Number: ")
             {
                 txtPhone.Visible = true;
                 Label3.Visible = true;
                 Label4.Visible = true;
             }
             else
             {

                 txtPhone.Visible = false;
                 Label3.Visible = false;
                 Label4.Visible = false;

             }
            
            
        }

        protected void dropCompany_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int agentID;

           

            try
            {
                if (!string.IsNullOrEmpty(dropAgent.SelectedValue) && !string.IsNullOrEmpty(txtPhone.Text))
                {

                    int.TryParse(dropAgent.SelectedValue, out agentID);
                    var agent = db.sp_ChangeAgentPhoneNumber((int)agentID, txtPhone.Text);


                    if (agent.ReturnValue.ToString() == "0")
                        MessageBox("Error in Changing Agent Phone");
                    else
                        Response.Redirect(Request.RawUrl);

                }
                else
                {
                    MessageBox("Fill In All Fields.");
                }


            }
            catch (Exception)
            {

                MessageBox("Error in Changing Agent Phone");
            }

        
        }


        private void MessageBox(string message)
        {

            string tmp = "";
            tmp = "<script language='javascript'>";
            tmp += "alert('" + message + "');";
            tmp += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", tmp);

        }

        
    }
}