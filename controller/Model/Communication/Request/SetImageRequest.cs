using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Communication;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Communication
{
    public class SetImageRequest : ARequest
    {
        #region Fields
        private VisibleObject _imageProperties;
        private string _filename;
        #endregion

        #region Properties
        public VisibleObject ImageProperties
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

        public string Filename
        {
            set
            {
                _filename = value;
            }
            get
            {
                return _filename;
            }
        }
        #endregion

        #region Constructors
        public SetImageRequest(): base(MessageType.SetImage)
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
            request += _filename;

            return request;
        }
        #endregion
    }
}
