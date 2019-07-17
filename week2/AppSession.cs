using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week2
{
    public class AppSession
    {
        public const string SESSION_QUESTION_NUMBER = "questionNumber";
        public const string SESSION_EXTRA_QUESTIONS = "extraQuestions";
        public const string SESSION_USER = "currentUser";
        public const string SESSION_ANSWERS = "answers";
        public const string SESSION_QUESTION_LABEL = "questionlabel";
        


       

        public static int getquestionnumberLabel() {
            if (HttpContext.Current.Session[SESSION_QUESTION_LABEL] == null)
            {
                int q = 1;
                HttpContext.Current.Session[SESSION_QUESTION_LABEL] = q;
                return q;
            }
            else {
             
                return (int)HttpContext.Current.Session[SESSION_QUESTION_LABEL];
            }
            
        }
        public static void setquestionnumberlabel() {
            int q = (int)HttpContext.Current.Session[SESSION_QUESTION_LABEL] + 1;
            HttpContext.Current.Session[SESSION_QUESTION_LABEL] = q;
        }

        public static int getCurrentQuestionID()
        {
            //is there not a current question id stored in session for this client/user
            if (HttpContext.Current.Session[SESSION_QUESTION_NUMBER] == null)
                HttpContext.Current.Session[SESSION_QUESTION_NUMBER] = 1; //set it for first time
                                                                   //NOTE: this creates a slot in session called questionNumber and stores the value 1

            return (int)HttpContext.Current.Session[SESSION_QUESTION_NUMBER];
        }

        public static void setCurrentQuestionID(int q) {
            HttpContext.Current.Session[SESSION_QUESTION_NUMBER] = q;
        }
        public static void incrementQuestionID()
        {
            int q = getCurrentQuestionID();
            q++;
            //save new number over the old number we had in session
            HttpContext.Current.Session[SESSION_QUESTION_NUMBER] = q;
        }
        public static List<int> getExtraQuestionsList()
        {
            if (HttpContext.Current.Session[SESSION_EXTRA_QUESTIONS] != null)
                return (List<int>)HttpContext.Current.Session[SESSION_EXTRA_QUESTIONS];
            return new List<int>();
        }
        public static void setExtraQuestionsList(List<int> extraquestions) {
            HttpContext.Current.Session[SESSION_EXTRA_QUESTIONS] = extraquestions;
        }
        public static void saveUserInSession(User user) {
            HttpContext.Current.Session[SESSION_USER] = user;
            //save user in session
        }
        public static int getSavedUserId() {
            User user = (User)HttpContext.Current.Session[SESSION_USER];
            return user.getUserID();
        }
        public static void SaveAnswersInSession(Answer answer)
        {
            if (HttpContext.Current.Session[SESSION_ANSWERS] == null)
            {
                //put in
                HttpContext.Current.Session[SESSION_ANSWERS] = new List<Answer>();

            }
            //get out
            List<Answer> answers = (List<Answer>)HttpContext.Current.Session[SESSION_ANSWERS];
            answers.Add(answer);
            //save back to session
            HttpContext.Current.Session[SESSION_ANSWERS] = answers;
            //todo save object list in session?
        }
        public static List<Answer> getAnswerList() {
            return (List<Answer>)HttpContext.Current.Session[SESSION_ANSWERS];
        }
            //写到 读取答案 存到 db 然后 跳到结束页面




    }
}