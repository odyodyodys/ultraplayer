using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Convert;

namespace UltraPlayerController.Model.SoundFx
{
    public class WaveformToStringConverter: IConverter<string, WaveformType>
    {
        #region IConverter<string,WaveformType> Members

        public string Convert(WaveformType data)
        {
            string result = string.Empty;

            try
            {
                switch (data)
                {
                    case WaveformType.Sine:
                        result = Protocol.Instance.SineWaveformParameter;
                        break;
                    case WaveformType.Square:
                        result = Protocol.Instance.SquareWaveformParameter;
                        break;
                    case WaveformType.Triangle:
                        result = Protocol.Instance.TriangleWaveformParameter;
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception)
            {
            	
            }

            return result;
        }

        public WaveformType Convert(string data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
