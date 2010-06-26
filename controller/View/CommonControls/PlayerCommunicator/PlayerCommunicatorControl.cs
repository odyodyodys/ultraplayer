using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Communication.Response;

namespace UltraPlayerController.View.CommonControls.PlayerCommunicator
{
    public partial class PlayerCommunicatorControl : UserControl
    {
        #region Fields
        private TCPClient _client;
        private Dictionary<ServerResponseType, Color> _statusColors;
        private PlayerCommunicatorInfo _historyControl;
        #endregion

        #region Constructors
        public PlayerCommunicatorControl()
        {
            InitializeComponent();

            // get port number from settings
            _client = new TCPClient(Properties.Settings.Default.DefaultCommunicationPort);

            // initialize status colors
            _statusColors = new Dictionary<ServerResponseType, Color>();
            _statusColors.Add(ServerResponseType.Success, Color.LightGreen);
            _statusColors.Add(ServerResponseType.Failure, Color.Gold);
            _statusColors.Add(ServerResponseType.Bad, Color.Tomato);

            // initialize history info
            _historyControl = new PlayerCommunicatorInfo();
            _historyControl.Visible = false;
        }
        #endregion

        #region Methods
        public AResponse SendRequest(ARequest request)
        {
            AResponse response = null;

            try
            {
                _historyControl.WriteToLog("Request: " + request.ParseToString());

                response = _client.Send(request);

                _historyControl.WriteToLog("Response: " + response.ResponseType.ToString());

                // update status
                SuccessPanel.BackColor = _statusColors[response.ResponseType];
            }
            catch (System.Exception e)
            {
                _historyControl.WriteToLog("Error:" + e.Message);
                SuccessPanel.BackColor = _statusColors[ServerResponseType.Bad];
            }

            return response;
        }
        public void NotifyHide()
        {
            // this fires when the parent form is closing or hiding. The control must hide its visible parts.
            _historyControl.Visible = false;
        }
        #endregion

        #region Events
        private void InfoButtonClick(object sender, EventArgs e)
        {
            _historyControl.Visible = !_historyControl.Visible;
        }
        #endregion
    }
}
