using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.CommonControls
{
    public partial class PlayerSkinForm : Form
    {
        public PlayerSkinForm()
        {
            InitializeComponent();
        }

        private void PlayerSkinFormLoad(object sender, EventArgs e)
        {
            AlphaFormTransformer.TransformForm(255);
        }

        public void SetSkin(SkinInfo skin)
        {
            try
            {
                if (skin.GetName().Equals("None"))
                {
                    if (AlphaFormTransformer.IsVisible)
                    {
                        AlphaFormTransformer.Fade(AlphaForm.FadeType.FadeOut, true, false, 1000);
                    }                    
                }
                else
                {
                    Bitmap bitmap = new Bitmap(skin.ImageFilename);

                    this.Width = skin.FormLayout.SizeX;
                    this.Height = skin.FormLayout.SizeY;
                    AlphaFormTransformer.UpdateSkin(bitmap, null, 255);
                }
            }
            catch (System.Exception)
            {
            	
            }
        }
    }
}
