using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.SoundFx;

namespace UltraPlayerController.Model.Communication.Request
{
    public class SoundFxRequest : ARequest
    {
        #region Fields
        List<ASoundFx> _effects;

        #endregion

        #region Constructors
        public SoundFxRequest() : base(MessageType.SoundFx)
        {
            _effects = new List<ASoundFx>();
        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = base.ParseToString();

            foreach (ASoundFx soundFx in _effects)
            {
                request += soundFx.ParseToString();
            }

            return request;
        }
        #endregion

        #region Properties
        public List<ASoundFx> Effects
        {
            get { return _effects; }
            set { _effects = value; }
        }
        #endregion
    }
}
