using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model.Exceptions
{
    public abstract class BaseException : ApplicationException
    {
        #region Fields
        protected string _error;
        #endregion

        #region Properties
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        #endregion
    }
}
