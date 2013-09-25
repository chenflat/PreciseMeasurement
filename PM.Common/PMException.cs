using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Common
{
    /// <summary>
    /// Dotnet Exception
    /// </summary>
    public class PMException : Exception
    {
        public PMException() { 
        
        }

        public PMException(string msg) : base(msg)
        {

        }
    }
}
