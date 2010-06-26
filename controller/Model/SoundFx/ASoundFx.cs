using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public abstract class ASoundFx : ISerializable
    {
        #region Fields
        SoundFxType _type;

        #endregion

        #region Constructors
        public ASoundFx(SoundFxType type)
        {
            _type = type;
        }
        #endregion

        #region ISerializable Members

        virtual public string ParseToString()
        {
            string result = string.Empty;

            try
            {
                // add delimiter
                result += Protocol.Instance.Delimiter;

                // add type
                switch (_type)
                {
                    case SoundFxType.Chorus:
                        result += Protocol.Instance.ChorusFxPartHeader;
                        break;
                    case SoundFxType.Compressor:
                        result += Protocol.Instance.CompressorFxPartHeader;
                        break;
                    case SoundFxType.Distortion:
                        result += Protocol.Instance.DistortionFxPartHeader;
                        break;
                    case SoundFxType.Echo:
                        result += Protocol.Instance.EchoFxPartHeader;
                        break;
                    case SoundFxType.Flanger:
                        result += Protocol.Instance.FlangerFxPartHeader;
                        break;
                    case SoundFxType.Gargle:
                        result += Protocol.Instance.GargleFxPartHeader;
                        break;
                    case SoundFxType.ParamEq:
                        result += Protocol.Instance.ParamEqFxPartHeader;
                        break;
                    case SoundFxType.Reverb:
                        result += Protocol.Instance.ReverbFxPartHeader;
                        break;
                    default:
                        // throw unsupported soundfx type. cannot serialize
                        break;
                }

            }
            catch (System.Exception)
            {
                // error
            }
            return result;
        }

        virtual public void ParseFromString(string textToParse)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties
        public SoundFxType Type
        {
            get { return _type; }

        }
        #endregion
    }
}
