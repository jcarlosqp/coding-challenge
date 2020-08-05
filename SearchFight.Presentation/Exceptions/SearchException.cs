using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Presentation.Exceptions
{
    public class SearchException: Exception
    {
        public SearchException(string message)
        {
            Console.WriteLine($"SearchException: {message}");
            //Log error details here, later.
            throw new ArgumentException();
        }
    }
}
