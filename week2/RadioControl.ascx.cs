using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace week2
{
    public partial class RadioContrell : System.Web.UI.UserControl
    {
        public Label QuestionLabel {
            get
            {
                return questionLabel;
            }
            set
            {
                questionLabel = value;
            }
        }
        public RadioButtonList QuestionRadioList {
            get
            {
                return questionRadioList;
            }
            set
            {
                questionRadioList = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}