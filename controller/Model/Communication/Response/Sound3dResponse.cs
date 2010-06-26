using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Communication.Response
{
    public class Sound3dResponse: AResponse
    {
#region Constructors
	public Sound3dResponse():base(MessageType.Sound3d)
    {

    }
#endregion

    #region AResponse Members

    public override string ParseToString()
    {
        // no need to support deserialization
        throw new NotImplementedException();
    }

    public override void ParseFromString(string textToParse)
    {
        base.ParseFromString(textToParse);
    }

    #endregion
    }
}
