using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UltraPlayerController.Model.Utilities;
using System.Windows.Forms;
using Utilities.Pattern;

namespace UltraPlayerController.Model
{
    public class SkinLoader : ICollectionLoader<SkinInfo>
    {
        #region Fields
        private List<SkinInfo> _skins;
        #endregion

        #region Constructors
        private SkinLoader()
        {
            _skins = new List<SkinInfo>();
        }
        public static SkinLoader Instance
        {
            get
            {
                return Singleton<SkinLoader>.Instance;
            }
        }
        #endregion

        #region Methods
        public SkinInfo GetByName(string skinName)
        {
            Load();

            return _skins.Find(delegate(SkinInfo skin)
                               {
                                   return skin.GetName().Equals(skinName);
                               }
            );
        }
        #endregion

        #region ICollectionLoader<SkinInfo> Members

        public ICollection<SkinInfo> Load()
        {
            if (!_skins.Count.Equals(0))
            {
                return _skins;
            }

            _skins = new List<SkinInfo>();

            // add the "None" skin
            SkinInfo noneSkin = new SkinInfo();
            noneSkin.ImageFilename = "None";
            _skins.Add(noneSkin);

            try
            {
                DirectoryInfo skinsDir = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Properties.Settings.Default.SkinsFolder));

                if (!skinsDir.Exists)
                {
                    throw new Exception("Skins directory is missing");
                }

                FileInfo[] skinFiles = skinsDir.GetFiles("*." + Properties.Settings.Default.SkinsExtension);

                foreach (FileInfo skinFile in skinFiles)
                {
                    try
                    {
                        // validate image existence
                        FileInfo imageFile = new FileInfo(Path.Combine(skinFile.DirectoryName, skinFile.Name.Replace(skinFile.Extension, ".png")));
                        if (!imageFile.Exists)
                        {
                            throw new Exception();
                        }

                        // validate skin details
                        TextReader stream = new StreamReader(skinFile.FullName);
                        Layout skinLayout = new Layout();
                        skinLayout.ParseFromString(stream.ReadLine());
                        Layout videoArea = new Layout();
                        videoArea.ParseFromString(stream.ReadLine());

                        // if no exception so far, skin is ok
                        SkinInfo newSkin = new SkinInfo();
                        newSkin.FormLayout = skinLayout;
                        newSkin.VideoArea = videoArea;
                        newSkin.ImageFilename = imageFile.FullName;

                        _skins.Add(newSkin);

                    }
                    catch (System.Exception)
                    {
                        // move to next skin, this is missing image
                        continue;
                    }
                }

            }
            catch (System.Exception)
            {

            }

            return _skins;
        }

        #endregion
    }
}
