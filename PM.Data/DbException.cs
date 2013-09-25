using System;
using System.Collections.Generic;
using System.Text;
using PM.Common;

namespace PM.Data
{
    public class DbException : PMException
    {
        public DbException(string message)
            : base(message)
        {

        }

        public int Number
        {
            get { return 0; }
        }

    }
}
