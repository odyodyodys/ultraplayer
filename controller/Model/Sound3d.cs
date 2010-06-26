using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model
{
    public class Sound3d
    {
        #region Fields
        private float _doplerFactor;
        private float _rolloffFactor;
        private float _minDistance;
        private float _maxDistance;
        private float _sourceX;
        private float _sourceY;
        private float _sourceZ;
        #endregion

        #region Constructors
        public Sound3d()
        {
            _minDistance = 5;
            _maxDistance = 10;
        }
        #endregion

        #region Properties

        public float DoplerFactor
        {
            get { return _doplerFactor; }
            set { _doplerFactor = value; }
        }
        public float RolloffFactor
        {
            get { return _rolloffFactor; }
            set { _rolloffFactor = value; }
        }
        public float MinDistance
        {
            get { return _minDistance; }
            set { _minDistance = value; }
        }
        public float MaxDistance
        {
            get { return _maxDistance; }
            set { _maxDistance = value; }
        }
        public float SourceX
        {
            get { return _sourceX; }
            set { _sourceX = value; }
        }
        public float SourceY
        {
            get { return _sourceY; }
            set { _sourceY = value; }
        }
        public float SourceZ
        {
            get { return _sourceZ; }
            set { _sourceZ = value; }
        }
        #endregion
    }
}
