using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Utilities;

namespace UltraPlayerController.Model.Communication.Request
{
    public class SetPlayerTypeRequest: ARequest
    {
    #region Fields
        private PlayerType _playerType;
    #endregion

    #region Constructors
    public SetPlayerTypeRequest():base(MessageType.SetPlayerType)
    {

    }
    #endregion

    #region ARequest members
    public override string ParseToString()
    {
        string request = string.Empty;
        try
        {
            request += base.ParseToString();
            request += PlayerTypeToStringConverter.Instance.Convert(_playerType);
        }
        catch (System.Exception)
        {

        }
        return request;
    }
    #endregion

	#region Properties
    public PlayerType PlayerType
    {
        set { _playerType = value; }
    }
	#endregion

    }
}
