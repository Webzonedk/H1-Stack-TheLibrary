using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrary
{
    class Book
    {
        #region Field
        private string title;
        private string authorLastname;
        private string authorFirstname;

        #endregion




        #region Properties

        public string Title
        {
            get { return title; }
            set { title = value; }
        } 
        
        public string AuthorFirstname
        {
            get { return authorFirstname; }
            set { authorFirstname = value; }
        }
        public string Authorlastname
        {
            get { return authorLastname; }
            set { authorLastname = value; }
        }

        #endregion




        #region Constructors
        public Book()
        {

        }
        public Book(string title,string authorLastname, string authorFirstname)
        {
            this.title = title;
            this.authorFirstname = authorFirstname;
            this.authorLastname = authorLastname;
        }

        #endregion
    }
}
