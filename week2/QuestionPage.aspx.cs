using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//reference namespace 
using System.Data.SqlClient;
using System.Configuration;//webconfig

namespace week2
{
    public partial class QuestionPage : System.Web.UI.Page
    {
        static string TEXTBOX_ID = "textBoxControl";
        static string CHECKBOX_ID = "checkBoxControl";
        static string RADIOBOX_ID = "radioBoxControl";

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentQuestionLabel.Text = "Question " + AppSession.getquestionnumberLabel();
            int currentQuestion = AppSession.getCurrentQuestionID();
            //extrl question setting 
            List<int> extraQuestion = AppSession.getExtraQuestionsList();
            using (SqlConnection connection = GetConnection())
            {
               
                string commandStr = "select * from question where question.qid = " + currentQuestion;
                SqlCommand command = new SqlCommand(commandStr, connection);

                SqlDataReader reader = command.ExecuteReader();
                //read question type and question label from question DB
                if (reader.Read()) {
                    string questionText = (string)reader["qdescription"];
                    string questionType = (string)reader["qtype"].ToString().ToLower();

                    if (questionType.Equals("text"))
                    {
                        TextBoxControl textBoxControl = (TextBoxControl)LoadControl("~/TextBoxControl.ascx");

                        textBoxControl.ID = TEXTBOX_ID;
                        textBoxControl.QuestionLabel.Text = questionText;
                        questionPlaceHolder.Controls.Add(textBoxControl);

                    }
                    else if (questionType.Equals("check"))
                    {
                        CheckBoxControl checkBoxControl = (CheckBoxControl)LoadControl("~/CheckBoxControl.ascx"); //需要手动导入
                        checkBoxControl.ID = CHECKBOX_ID;
                        checkBoxControl.QuestionLabel.Text = questionText;
                        //
                        try {
                            SqlCommand optionCommand = new SqlCommand("select * from options Where qid=" + currentQuestion, connection);
                            //find all the options in option table with same question id 
                            SqlDataReader optionReader = optionCommand.ExecuteReader();

                            while (optionReader.Read())
                            {
                                ListItem item = new ListItem(optionReader["description"].ToString(), optionReader["oid"].ToString());
                                checkBoxControl.QuestionCheckBoxList.Items.Add(item);
                            }
                            //
                            questionPlaceHolder.Controls.Add(checkBoxControl);
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Error: " + ex);
                        }
                       
                    }
                    else if (questionType.Equals("radio"))
                    {
                        RadioContrell radioBoxCoontrol = (RadioContrell)LoadControl("~/RadioControl.ascx");
                        radioBoxCoontrol.ID = RADIOBOX_ID;
                        radioBoxCoontrol.QuestionLabel.Text = questionText;

                        try {
                            SqlCommand optionCommand = new SqlCommand("select * from options Where qid=" + currentQuestion, connection);
                            //find all the options in option table with same question id 

                            SqlDataReader optionReader = optionCommand.ExecuteReader();

                            while (optionReader.Read())
                            {
                                ListItem item = new ListItem(optionReader["description"].ToString(), optionReader["oid"].ToString());
                                radioBoxCoontrol.QuestionRadioList.Items.Add(item);
                            }
                            //
                            questionPlaceHolder.Controls.Add(radioBoxCoontrol);
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Error: " + ex);
                        }
                        
                    }
                }
            }
           
        }
        private static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["questionConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //connection to question DB
            return connection;
        }
        


        protected void NextButton_Click(object sender, EventArgs e)
        {
            int currentQuestion = AppSession.getCurrentQuestionID();
            List<int> extraQuestion=AppSession.getExtraQuestionsList();
            //save Answers in session
            

            //setup DB connection 
            using (SqlConnection connection = GetConnection())
            {
                //check for answers user has filled in on the form 
                //check t osee if previously a textbox conto the screen
                TextBoxControl textBoxControl = (TextBoxControl)questionPlaceHolder.FindControl(TEXTBOX_ID);
                
                if (textBoxControl != null)
                {
                    string typeAnswer = textBoxControl.QuestionTextBox.Text;
                    Answer answer = new Answer();
                    answer.UserID = AppSession.getSavedUserId();
                    answer.questionType = "text";
                    answer.answerText = typeAnswer;
                    answer.questionID = currentQuestion;
                    AppSession.SaveAnswersInSession(answer);
                }
                CheckBoxControl checkBoxControl = (CheckBoxControl)questionPlaceHolder.FindControl(CHECKBOX_ID);
                if (checkBoxControl != null) {
                    foreach (ListItem item in checkBoxControl.QuestionCheckBoxList.Items)
                    {
                        if (item.Selected)
                        {
                            try
                            {
                                SqlCommand optionCommand = new SqlCommand("select * from options Where oid=" + item.Value, connection);
                                //find all the options in option table with same option id 
                                SqlDataReader optionReader = optionCommand.ExecuteReader();
                                int optionindex = optionReader.GetOrdinal("next_question");
                                if (optionReader.Read())
                                {
                                    if (!optionReader.IsDBNull(optionindex))
                                    {
                                        int extraquestionID = int.Parse(optionReader["next_question"].ToString());
                                        if (!extraQuestion.Contains(extraquestionID))
                                            extraQuestion.Add(extraquestionID);
                                    }
                                }
                            }
                            catch (SqlException ex) {
                                Console.WriteLine("Error: " + ex);
                            }
                            Answer answer = new Answer();
                            answer.UserID = AppSession.getSavedUserId();
                            answer.questionType = "check";
                            answer.optionID = int.Parse(item.Value);
                            answer.questionID = currentQuestion;
                            AppSession.SaveAnswersInSession(answer);

                        }
                    }
                }
                RadioContrell radioContrell = (RadioContrell)questionPlaceHolder.FindControl(RADIOBOX_ID);
                if (radioContrell != null) {
                    foreach (ListItem item in radioContrell.QuestionRadioList.Items)
                    {
                        if (item.Selected)
                        {
                            try
                            {
                                SqlCommand optionCommand = new SqlCommand("select * from options Where oid=" + item.Value, connection);
                                //find all the options in option table with same option id 
                                SqlDataReader optionReader = optionCommand.ExecuteReader();
                                int optionindex = optionReader.GetOrdinal("next_question");
                                if (optionReader.Read())
                                {
                                    if (!optionReader.IsDBNull(optionindex))
                                    {
                                        int extraquestionID = int.Parse(optionReader["next_question"].ToString());
                                        if (!extraQuestion.Contains(extraquestionID))
                                            extraQuestion.Add(extraquestionID);
                                    }
                                }
                                Answer answer = new Answer();
                                answer.UserID = AppSession.getSavedUserId();
                                answer.questionType = "radio";
                                answer.optionID = int.Parse(item.Value);
                                answer.questionID = currentQuestion;
                                AppSession.SaveAnswersInSession(answer);
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("Error: " + ex);
                            }


                        }
                    }
                }

                //if (currentQuestion == 1) {
                //    extraQuestion.Add(3);
                //    extraQuestion.Add(4);
                //}
                if (extraQuestion.Count > 0)
                {
                    int nextQuestion = extraQuestion[0];
                    extraQuestion.Remove(nextQuestion);
                    AppSession.setExtraQuestionsList(extraQuestion); 
                    AppSession.setCurrentQuestionID(nextQuestion);
                    Response.Redirect("QuestionPage.aspx");
                }

                //use sql comd to get next question 
                //Go to next question  18510862276
                SqlCommand command = new SqlCommand("SELECT * FROM question WHERE qid = " + currentQuestion, connection);
                SqlDataReader reader = command.ExecuteReader();
                //read first row (dont care if ,ultiple are returned
                if (reader.Read())
                {
                    //get index of column want tot check
                    int nextQuestionColumnIndex = reader.GetOrdinal("next_question");
                    //check if this column's value is null
                    if (reader.IsDBNull(nextQuestionColumnIndex))
                    {
                        //读取答案 要改
                        List<Answer> useranswers = AppSession.getAnswerList();
                        foreach (Answer item in useranswers) {
                            if (item.questionType == "text")
                            {
                                try {
                                    SqlCommand answerinsertCommmand = new SqlCommand("INSERT INTO answer (answer, qid, uid) VALUES (@answertext,@Qid,@Uid);", connection);
                                    SqlParameter answertext = new SqlParameter();
                                    answertext.ParameterName = "@answertext";
                                    answertext.Value = item.answerText;
                                    SqlParameter QuestionID = new SqlParameter();
                                    QuestionID.ParameterName = "@Qid";
                                    QuestionID.Value = item.questionID;
                                    SqlParameter userID = new SqlParameter();
                                    userID.ParameterName = "@Uid";
                                    userID.Value = item.UserID;
                                    answerinsertCommmand.Parameters.Add(answertext);
                                    answerinsertCommmand.Parameters.Add(QuestionID);
                                    answerinsertCommmand.Parameters.Add(userID);
                                    answerinsertCommmand.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine("Error: " + ex);
                                }
                                
                            }
                            else if (item.questionType == "check" || item.questionType=="radio")
                            {
                                if(item.questionID == 8){
                                    if (item.optionID == null) {
                                        try {
                                            SqlCommand answerinsertCommmand = new SqlCommand("INSERT INTO answer (qid, uid) VALUES (@Qid,@Uid);", connection);
                                            SqlParameter QuestionID = new SqlParameter();
                                            QuestionID.ParameterName = "@Qid";
                                            QuestionID.Value = item.questionID;
                                            SqlParameter userID = new SqlParameter();
                                            userID.ParameterName = "@Uid";
                                            userID.Value = item.UserID;
                                            answerinsertCommmand.Parameters.Add(QuestionID);
                                            answerinsertCommmand.Parameters.Add(userID);
                                            answerinsertCommmand.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine("Error: " + ex);
                                        }
                                        
                                    }
                                }
                                else
                                {
                                    try {
                                        SqlCommand answerinsertCommmand = new SqlCommand("INSERT INTO answer (oid, qid, uid) VALUES (@Optionid,@Qid,@Uid);", connection);
                                        SqlParameter answertext = new SqlParameter();
                                        answertext.ParameterName = "@Optionid";
                                        answertext.Value = item.optionID;
                                        SqlParameter QuestionID = new SqlParameter();
                                        QuestionID.ParameterName = "@Qid";
                                        QuestionID.Value = item.questionID;
                                        SqlParameter userID = new SqlParameter();
                                        userID.ParameterName = "@Uid";
                                        userID.Value = item.UserID;
                                        answerinsertCommmand.Parameters.Add(answertext);
                                        answerinsertCommmand.Parameters.Add(QuestionID);
                                        answerinsertCommmand.Parameters.Add(userID);
                                        answerinsertCommmand.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine("Error: " + ex);
                                    }
                                   
                                }
                                
                            }
                            
                            
                        }

                       Server.Transfer("FinishPage.aspx");

                    }
                    else
                    {
                        //next question
                        AppSession.setCurrentQuestionID((int)reader["next_question"]);
                        //reload the page so that pageLoad loads correct new question up 
                        AppSession.setquestionnumberlabel();
                        Response.Redirect("QuestionPage.aspx");
                    }

                }
                else
                {
                    //exceptions

                }
            }
        }
    }
}