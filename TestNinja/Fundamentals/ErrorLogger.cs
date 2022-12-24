
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        
        public void Log(string error)
        {
            //Need to tested for 
            // for NULL
            // for "" empty
            //for " " white space   
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error; 
            
            // Write the log to a storage

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}