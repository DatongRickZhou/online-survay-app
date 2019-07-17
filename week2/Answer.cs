using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week2
{
    public class Answer
    {
        public int UserID { get; set; }
        public string answerText { get; set; }
        public int optionID { get; set; }
        public int questionID { get; set; }
        public string questionType { get; set; }
    }
}