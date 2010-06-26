using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model.Exceptions
{
    public class GeneralException: BaseException
    {
                #region Constructors

        public GeneralException(string error)
        {
            _error = error;
        }
        #endregion
    }
}
