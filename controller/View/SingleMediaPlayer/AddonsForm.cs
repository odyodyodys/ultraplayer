using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.Addon;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model.Exceptions;
using System.IO;

namespace UltraPlayerController.View.SingleMediaPlayer
{
    public partial class AddonsForm : Form
    {
        #region Fields

        private List<D3dVisibleAddon> _addons;
        private ImageAddonPropertiesControl _imageAddonPropertiesControl;
        private TextAddonPropertiesControl _textAddonPropertiesControl;

        public event Delegates.AddonEventHandler AddonSetEvent;
        public event Delegates.IntegerValueActionEventHandler AddonRemovedEvent;

        #endregion
        #region Constructors

        public AddonsForm()
        {
            InitializeComponent();

            _addons = new List<D3dVisibleAddon>();

            _imageAddonPropertiesControl = new ImageAddonPropertiesControl();
            _imageAddonPropertiesControl.Dock = DockStyle.Fill;
            _imageAddonPropertiesControl.ImageFileChangedEvent += new Delegates.FileChangedEventHandler(OnImageFileChangedEvent);
            _imageAddonPropertiesControl.LayoutChangedEvent += new Delegates.VisibleLayoutChangedEventHandler(OnLayoutChangedEvent);

            _textAddonPropertiesControl = new TextAddonPropertiesControl();
            _textAddonPropertiesControl.Dock = DockStyle.Fill;
            _textAddonPropertiesControl.LayoutChangedEvent +=new Delegates.VisibleLayoutChangedEventHandler(OnLayoutChangedEvent);
            _textAddonPropertiesControl.TextChangedEvent += new Delegates.TextChangedEventHandler(OnTextChangedEvent);

            // add available addons to combo box
            // TODO add enum friendly names
            foreach (AddonType item in Enum.GetValues(typeof(AddonType)))
            {
                SelectNewAddonTypeComboBox.Items.Add(item.ToString());
            }
        }

        #endregion
        #region Events

        private void removeToolStripMenuItemClick(object sender, EventArgs e)
        {

            try
            {
                uint currentAddonId = GetSelectedAddonId();

                // find appropriate addon
                D3dVisibleAddon foundAddon = null;
                foreach (D3dVisibleAddon addon in _addons)
                {
                    if (addon.Id == currentAddonId)
                    {
                        foundAddon = addon;
                        break;
                    }
                }

                // remove both
                if (foundAddon != null)
                {
                    _addons.Remove(foundAddon);
                    AddonsListBox.Items.Remove(AddonsListBox.SelectedItem);

                    if (AddonRemovedEvent != null)
                    {
                        AddonRemovedEvent((int)foundAddon.Id);
                    }
                }

                //if it was the last one, empty properties control
                if (_addons.Count == 0)
                {
                    AddonPropertiesPanel.Controls.Clear();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddNewAddonButtonClick(object sender, EventArgs e)
        {
            // create empty instance of specified type
            if (SelectNewAddonTypeComboBox.SelectedIndex == -1)
            {
                return;
            }

            try
            {
                D3dVisibleAddon newAddon = null;
                Control controlToAdd = null;
                AddonType addonType = (AddonType)Enum.Parse(typeof(AddonType), SelectNewAddonTypeComboBox.SelectedItem.ToString());

                switch (addonType)
                {
                    case AddonType.D3dImage:
                        newAddon = new ImageD3dVisibleAddon(GetNextAvailableAddonId(), AddonType.D3dImage, new VisibleLayout());
                        controlToAdd = _imageAddonPropertiesControl;
                        break;
                    case AddonType.D3dText:
                        //check if already a text exists. only 1 allowed
                        foreach (object item in AddonsListBox.Items)
                        {
                            if (item.ToString().Contains(AddonType.D3dText.ToString()))
                            {
                                throw new GeneralException("Cannot add more than one text addond");
                            }
                        }

                        newAddon = new TextD3dVisibleAddon(GetNextAvailableAddonId(), AddonType.D3dText, new VisibleLayout());
                        controlToAdd = _textAddonPropertiesControl;
                        break;
                    default:
                        break;
                }

                // set correct properties panel
                SetAddonPropertiesControl(newAddon);

                // add control to lists
                _addons.Add(newAddon);
                AddonsListBox.Items.Add(newAddon.Id.ToString() + ". " + addonType.ToString());

                // throw event for new addon created
                if (AddonSetEvent != null)
                {
                    AddonSetEvent(newAddon);
                }
            }
            catch (System.Exception)
            {

            }
        }

        private void AddonsListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // find addon Id
                uint currentAddonId = GetSelectedAddonId();

                D3dVisibleAddon currentAddon = null;
                foreach (D3dVisibleAddon addon in _addons)
                {
                    if (addon.Id == currentAddonId)
                    {
                        currentAddon = addon;
                        break;
                    }
                }

                // set appropriate addon properties control
                SetAddonPropertiesControl(currentAddon);
            }
            catch (System.Exception)
            {

            }
        }

        void OnImageFileChangedEvent(FileInfo imageFile)
        {
            try
            {
                D3dVisibleAddon addon = GetCurrentAddon();

                if (addon.Type != AddonType.D3dImage)
                {
                    // Problem!
                }

                ((ImageD3dVisibleAddon)addon).ImageFilename = imageFile.FullName;

                // forward event
                if (AddonSetEvent != null)
                {
                    AddonSetEvent(addon);
                }

            }
            catch (System.Exception)
            {

            }
        }

        private void OnLayoutChangedEvent(VisibleLayout layout)
        {
            try
            {
                D3dVisibleAddon addon = GetCurrentAddon();
                addon.Layout = layout;

                // forward event
                if (AddonSetEvent != null)
                {
                    AddonSetEvent(addon);
                }

            }
            catch (System.Exception)
            {

            }
        }

        private void OnTextChangedEvent(string text)
        {
            try
            {
                D3dVisibleAddon addon = GetCurrentAddon();
                ((TextD3dVisibleAddon)addon).Text = text;

                // forward event
                if (AddonSetEvent != null)
                {
                    AddonSetEvent(addon);
                }

            }
            catch (System.Exception)
            {

            }

        }

        #endregion

        #region Methods

        private uint GetSelectedAddonId()
        {
            // find selected item on addons list box
            if (AddonsListBox.SelectedIndex == -1)
            {
                throw new GeneralException("Nothing selected in AddonsListBox");
            }

            return uint.Parse(AddonsListBox.SelectedItem.ToString().Substring(0, AddonsListBox.SelectedItem.ToString().IndexOf('.')));
        }

        private uint GetNextAvailableAddonId()
        {
            // create a list with all taken Ids
            List<uint> takenIds = new List<uint>();
            foreach (D3dVisibleAddon addon in _addons)
            {
                takenIds.Add(addon.Id);
            }

            // loop from 1 to max to find an available number
            // note: max = 10^numberOfDigits - 1
            uint availId = 0;
            int max = (int)(Math.Pow(10, Protocol.Instance.NumericParameterLength) - 1);
            for (uint i = 0; i < max; i++)
            {
                if (!takenIds.Contains(i))
                {
                    availId = i;
                    break;
                }
            }

            return availId;
        }

        private void SetAddonPropertiesControl(D3dVisibleAddon addon)
        {
            AddonPropertiesPanel.Controls.Clear();

            switch (addon.Type)
            {
                case AddonType.D3dImage:
                    _imageAddonPropertiesControl.Layout = addon.Layout;
                    _imageAddonPropertiesControl.ImageFilename = ((ImageD3dVisibleAddon)addon).ImageFilename;
                    AddonPropertiesPanel.Controls.Add(_imageAddonPropertiesControl);
                    break;
                case AddonType.D3dText:
                    AddonPropertiesPanel.Controls.Add(_textAddonPropertiesControl);
                    break;
                default:
                    break;
            }
        }

        private D3dVisibleAddon GetCurrentAddon()
        {
            // get selected addon
            D3dVisibleAddon currentAddon = null;
            try
            {
                uint currentAddonId = GetSelectedAddonId();
                foreach (D3dVisibleAddon addon in _addons)
                {
                    if (addon.Id == currentAddonId)
                    {
                        currentAddon = addon;
                        break;
                    }
                }
            }
            catch (System.Exception)
            {

            }

            return currentAddon;
        }

        public void PlaybackStarted()
        {
            _textAddonPropertiesControl.StartSubtitles();
        }
        public void PlaybackStopped()
        {
            _textAddonPropertiesControl.StopSubtitles();
        }

        #endregion
    }
}
