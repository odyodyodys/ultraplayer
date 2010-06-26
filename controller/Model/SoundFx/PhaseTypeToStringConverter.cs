using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Convert;

namespace UltraPlayerController.Model.SoundFx
{
    public class PhaseTypeToStringConverter: IConverter<string, PhaseType>
    {
        #region IConverter<string,PhaseType> Members

        public string Convert(PhaseType data)
        {
            string result = string.Empty;

            int degrees = 0;

            switch (data)
            {
                case PhaseType.Minus180:
                    degrees = -180;
                    break;
                case PhaseType.Minus90:
                    degrees = -90;
                    break;
                case PhaseType.Zero:
                    degrees = 0;
                    break;
                case PhaseType.Plus90:
                    degrees = 90;
                    break;
                case PhaseType.Plus180:
                    degrees = 180;
                    break;
                default:
                    break;
            }

            string positiveNumericFormat = new string('0', (int)Protocol.Instance.LongNumericParameterLength);
            string negativeNumericFormat = new string('0', (int)Protocol.Instance.LongNumericParameterLength - 1);

            result += string.Format("{0:" + positiveNumericFormat + ";-" + negativeNumericFormat + "}", degrees);

            return result;

        }

        public PhaseType Convert(string data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
