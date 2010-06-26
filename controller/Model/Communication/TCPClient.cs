using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using UltraPlayerController.Model.Communication.Response;
using UltraPlayerController.Model.Settings;

namespace UltraPlayerController.Communication
{
    public class TCPClient
    {
        #region Fields
	        private uint _port;
        #endregion

        #region Constructors
	        public TCPClient(uint port)
	        {
	            _port = port;
	        }
        #endregion

        #region Methods
	        public AResponse Send(ARequest request)
	        {
                string messageToSend = request.ParseToString();
                AResponse response = null;
	
	            try
	            {
	                TcpClient client = new TcpClient();
	                
	                // connect to the server
                    client.Connect(SettingsManager.Instance.PlayerSettings.Ip.ToString(), (int)_port);
	
	                // Send stream
	                Stream stream = client.GetStream();
	                ASCIIEncoding encoding = new ASCIIEncoding();
	                byte[] requestByteArray = encoding.GetBytes(messageToSend);
	                
	                // Transmitting data
	                stream.Write(requestByteArray, 0, requestByteArray.Length);
	                
	                // Get response
	                byte[] responseByteArray = new byte[500];
	                int responseLength = stream.Read(responseByteArray, 0, 500);
	
	                string responseMessage = string.Empty;
	                for (int i = 0; i < responseLength; i++)
	                {
	                    responseMessage += Convert.ToChar(responseByteArray[i]);
	                }
	
	                // close connection to server
	                client.Close();
	
	                // get response
	                response = ResponseFactory.Instance.CreateResponse(responseMessage);
	
	            }
	            catch(Exception e)
	            {
                    throw e;
	            }
	
	
	            return response;
	        }
        #endregion

    }
}
