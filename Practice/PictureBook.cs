using System;

namespace library_demo
{
    public class PictureBook : Book
    {
        private string _illustrator = "";

        public string GetIllustrator()
        {
            return _illustrator;
        }

        public void SetIllustrator(string illustrator)
        {
            _illustrator = illustrator;
        }

        public string GetPictureBookInfo()
        {
            return $"{GetBookInfo()}, Illustrator: {_illustrator}";
        }
    }
}   