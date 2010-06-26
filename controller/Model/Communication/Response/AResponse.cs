using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Resources.Communication;

namespace UltraPlayerController.Model.Communication.Response
{
    public abstract class AResponse : AMessage
    {
        #region Fields
        private ServerResponseType _responseType;
        private Dictionary<string, ServerResponseType> _serverResponseMapper;
        #endregion

        #region Constructors
        protected AResponse(MessageType type) : base(type)
        {
            // set mapper (response type string -> Server response type
            _serverResponseMapper = new Dictionary<string, ServerResponseType>();

            _serverResponseMapper.Add(Protocol.Instance.ResponseTypeSuccess, ServerResponseType.Success);
            _serverResponseMapper.Add(Protocol.Instance.ResponseTypeFailure, ServerResponseType.Failure);
            _serverResponseMapper.Add(Protocol.Instance.ResponseTypeBad, ServerResponseType.Bad);
        }
        #endregion

        #region AMessage Members

        public override string ParseToString()
        {
            // no need to support deserialization
            throw new NotImplementedException();
        }

        public override void ParseFromString(string textToParse)
        {
            try
            {
	            base.ParseFromString(textToParse);

	            // get text to parse
	            string responseTypeText = textToParse.Substring((int)Protocol.Instance.HeaderLength , (int)Protocol.Instance.ResponseTypeLength);

                _responseType = _serverResponseMapper[responseTypeText];
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Properties
        public ServerResponseType ResponseType
        {
            get { return _responseType; }
        }
        #endregion
    }
}
