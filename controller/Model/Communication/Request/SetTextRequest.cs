using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Communication;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Communication
{
    public class SetTextRequest : ARequest
    {
        #region Fields
        string _text;
        private VisibleObject _imageProperties;

        #endregion

        #region Constructors
        public SetTextRequest() : base(MessageType.SetText)
        {

        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = base.ParseToString();

            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, (int)_imageProperties.Id);
            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _imageProperties.Layout.OriginX);
            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _imageProperties.Layout.OriginY);
            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _imageProperties.Layout.SizeX);
            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _imageProperties.Layout.SizeY);
            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _imageProperties.Layout.AlphaValue);
            request += _text;

            return request;
        }
        #endregion

        #region Properties
        public VisibleObject ObjectProperties
        {
            set
            {
                _imageProperties = value;
            }
            get
            {
                return _imageProperties;
            }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion
    }
}
