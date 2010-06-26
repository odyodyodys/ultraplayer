using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model.Exceptions
{
    public class ParserException : BaseException
    {
        #region Constructors

        public ParserException(string error)
        {
            _error = error;
        }
        #endregion
    }
}
