using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model
{
    public class VisibleLayout : Layout
    {
        #region Fields
        private int _zOrder;
        private int _alphaValue;
        #endregion

        #region Constructors
        public VisibleLayout()
        {
            _zOrder = 0;
            _alphaValue = 255;

        }
        public VisibleLayout(int originX, int originY, int sizeX, int sizeY, int zOrder, int alphaValue)
            : base(originX, originY, sizeX, sizeY)
        {
            _zOrder = zOrder;
            _alphaValue = alphaValue;
        }
        #endregion

        #region Properties
        public int AlphaValue
        {
            get { return _alphaValue; }
            set { _alphaValue = value; }
        }
        public int ZOrder
        {
            get { return _zOrder; }
            set { _zOrder = value; }
        }

        #endregion

        #region Layout Members

        public override string ParseToString()
        {
            string data = string.Empty;
            try
            {
                data += base.ParseToString();

                data += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _alphaValue);
                
                // zOrder not supported yet
                //data += string.Format("{0:" + numericFormat + "}", _zOrder);
            }
            catch (System.Exception)
            {

            }
            return data;
        }

        public override void ParseFromString(string textToParse)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
