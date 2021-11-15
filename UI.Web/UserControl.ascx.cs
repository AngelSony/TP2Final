using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Text
        {
            get
            {
                return txtBox.Text;

            }
            set { txtBox.Text = value; }
        }

        public bool Enable
        {
            get
            {
                return txtBox.Enabled;
            }

            set { txtBox.Enabled = value; }

        }

        public string labelText
        {
            get
            {
                return label1.Text;

            }
            set { label1.Text = value; }
        }





    }
}