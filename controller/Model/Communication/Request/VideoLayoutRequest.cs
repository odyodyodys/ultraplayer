using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model;

namespace UltraPlayerController.Communication
{
    public class VideoLayoutRequest:ARequest
    {
        #region Fields
        	private List<VisibleLayout> _tracksLayout;
        #endregion

        #region Properties
	        public List<VisibleLayout> TracksLayout
	        {
	            set
	            {
	                _tracksLayout = value;
	            }
	            get
	            {
	                return _tracksLayout;
	            }
	        }
        #endregion

        #region Constructors
	        public VideoLayoutRequest():base(MessageType.VideoLayout)
	        {
	            // to avoid exception if no tracksLayout is given
	            _tracksLayout = new List<VisibleLayout>();
	        }
        #endregion

        #region ARequest members
	        public override string ParseToString()
	        {
	            // get header
	            string request = base.ParseToString();
	
	            // add layout parts
	            for (int i = 0; i < _tracksLayout.Count; i++ )
	            {
	                request += _tracksLayout[i].ParseToString();
	            }
	
	            return request;
	        }
        #endregion
    }
}
