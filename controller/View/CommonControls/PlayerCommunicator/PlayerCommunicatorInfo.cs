using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UltraPlayerController.View.CommonControls.PlayerCommunicator
{
    public partial class PlayerCommunicatorInfo : Form
    {
        #region Constructors

        public PlayerCommunicatorInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void WriteToLog(string message)
        {
            // insert at the beginning (top) of the listbox
            HistoryListbox.Items.Insert(0, message);
        }

        #endregion

        #region Events

        private void HistoryListboxDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            ListBox senderListbox = ((ListBox)sender);

            //
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.
            //
            e.DrawBackground();
            Brush myBrush = Brushes.Black;

            string message = senderListbox.Items[e.Index].ToString();

            if (message.StartsWith("Request"))
            {
                myBrush = Brushes.LightBlue;
            }
            else if (message.StartsWith("Response"))
            {
                myBrush = Brushes.LightGreen;
            }
            else
            {
                myBrush = Brushes.White;
            }

            // Draw the current item text based on the current 
            // Font and the custom brush settings.
            e.Graphics.DrawString(senderListbox.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.
            e.DrawFocusRectangle();
        }

        private void ClearMenuItemClick(object sender, EventArgs e)
        {
            // clear listbox
            HistoryListbox.Items.Clear();
        }

        #endregion

    }
}
