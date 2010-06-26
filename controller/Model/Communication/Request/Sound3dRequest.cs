using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.Communication.Request
{
    public class Sound3dRequest : ARequest
    {
        #region Fields
        private Sound3d _sound3dProperties;
        #endregion

        #region Constructors
        public Sound3dRequest(): base(MessageType.Sound3d)
        {
            _sound3dProperties = new Sound3d();
        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string result = string.Empty;

            result += base.ParseToString();

            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.DoplerFactor);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.RolloffFactor);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.MinDistance);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.MaxDistance);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.SourceX);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.SourceY);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _sound3dProperties.SourceZ);

            return result;
        }
        #endregion

        #region Properties

        public Sound3d Sound3dProperties
        {
            get { return _sound3dProperties; }
            set { _sound3dProperties = value; }
        }
        #endregion

    }
}
