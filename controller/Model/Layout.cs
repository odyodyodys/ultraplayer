using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Model
{
    public class Layout : ISerializable
    {
        #region Fields
        protected int _originX;
        protected int _originY;
        protected int _sizeX;
        protected int _sizeY;
        #endregion

        #region Constructors
        public Layout()
        {
            _originX = 0;
            _originY = 0;
            _sizeX = 1000;
            _sizeY = 1000;
        }
        public Layout(int originX, int originY, int sizeX, int sizeY)
        {
            _originX = originX;
            _originY = originY;
            _sizeX = sizeX;
            _sizeY = sizeY;
        }
        #endregion
        #region Properties
        public int OriginX
        {
            get { return _originX; }
            set { _originX = value; }
        }

        public int OriginY
        {
            get { return _originY; }
            set { _originY = value; }
        }

        public int SizeX
        {
            get { return _sizeX; }
            set { _sizeX = value; }
        }

        public int SizeY
        {
            get { return _sizeY; }
            set { _sizeY = value; }
        }
        #endregion

        #region Methods
        public Rectangle GetRectangle()
        {
            Rectangle rect = new Rectangle(_originX, _originY, _sizeX, _sizeY);

            return rect;
        }
        #endregion

        #region ISerializable Members

        public virtual string ParseToString()
        {
            string data = string.Empty;
            try
            {
                data += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _originX);
                data += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _originY);
                data += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _sizeX);
                data += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _sizeY);
            }
            catch (System.Exception)
            {
            	
            }

            return data;
        }

        public virtual void ParseFromString(string textToParse)
        {
            try
            {
                //validate size
                if (textToParse.Length != 4 * Protocol.Instance.NumericParameterLength)
                {
                    throw new Exception("Invalid length");
                }

                int index = 0;
                _originX = int.Parse(textToParse.Substring(index, (int)Protocol.Instance.NumericParameterLength));
                index += (int)Protocol.Instance.NumericParameterLength;
                _originY = int.Parse(textToParse.Substring(index, (int)Protocol.Instance.NumericParameterLength));
                index += (int)Protocol.Instance.NumericParameterLength;
                _sizeX = int.Parse(textToParse.Substring(index, (int)Protocol.Instance.NumericParameterLength));
                index += (int)Protocol.Instance.NumericParameterLength;
                _sizeY = int.Parse(textToParse.Substring(index, (int)Protocol.Instance.NumericParameterLength));
            }
            catch (System.Exception)
            {
            	
            }
        }

        #endregion
    }
}
