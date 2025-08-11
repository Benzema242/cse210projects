using System;

namespace Homework
{
    public class Assignment
    {
        protected string _studentName = "";
        private string _topic = "";

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
        public string GetStudentName()
        {
            return _studentName;
        }

        public void SetTopic(string topic)
        {
            _topic = topic;
        }

        public string GetTopic()
        {
            return _topic;
        }
    }
}