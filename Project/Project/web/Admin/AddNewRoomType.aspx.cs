using Project.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Admin
{
    public partial class AddNewRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        AdminDatabaseAccess ada = new AdminDatabaseAccess();
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoom.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            try
            {
                ada.openConnection();
                ada.AddNewRoomType(txtRoom.Text);
                MessageBox.Show(this, "Success");
            }
            catch
            {
                MessageBox.Show(this, "Already exist");
            }

        }
    }
}