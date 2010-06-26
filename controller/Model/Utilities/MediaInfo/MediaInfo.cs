using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace UltraPlayerController.Model.Utilities.MediaInfo
{
    public class MediaInfo
    {
        #region Fields
        private bool _useAnsi;

        private IntPtr Handle;

        #endregion

        #region Constructors/Destructor
        public MediaInfo()
        {
            Handle = MediaInfo_New();
            if (Environment.OSVersion.ToString().IndexOf("Windows") == -1)
            {
                _useAnsi = true;
            }
            else
            {
                _useAnsi = false;
            }

            Option("CodePage", "UTF-8");

            // do not let it connect to the internet for info and updates
            Option("Internet", "No");

        }
        ~MediaInfo()
        {
            MediaInfo_Delete(Handle);
        }
        #endregion

        #region DLL Methods

        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfo_New();
        [DllImport("MediaInfo.dll")]
        private static extern void MediaInfo_Delete(IntPtr Handle);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfo_Open(IntPtr Handle, [MarshalAs(UnmanagedType.LPWStr)] string FileName);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfoA_Open(IntPtr Handle, IntPtr FileName);
        [DllImport("MediaInfo.dll")]
        private static extern void MediaInfo_Close(IntPtr Handle);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfo_Option(IntPtr Handle, [MarshalAs(UnmanagedType.LPWStr)] string Option, [MarshalAs(UnmanagedType.LPWStr)] string Value);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfoA_Option(IntPtr Handle, IntPtr Option, IntPtr Value);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfo_Inform(IntPtr Handle, IntPtr Reserved);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfoA_Inform(IntPtr Handle, IntPtr Reserved);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfo_GetI(IntPtr Handle, IntPtr StreamKind, IntPtr StreamNumber, IntPtr Parameter, IntPtr KindOfInfo);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfoA_GetI(IntPtr Handle, IntPtr StreamKind, IntPtr StreamNumber, IntPtr Parameter, IntPtr KindOfInfo);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfo_Get(IntPtr Handle, IntPtr StreamKind, IntPtr StreamNumber, [MarshalAs(UnmanagedType.LPWStr)] string Parameter, IntPtr KindOfInfo, IntPtr KindOfSearch);
        [DllImport("MediaInfo.dll")]
        private static extern IntPtr MediaInfoA_Get(IntPtr Handle, IntPtr StreamKind, IntPtr StreamNumber, IntPtr Parameter, IntPtr KindOfInfo, IntPtr KindOfSearch);

        #endregion

        #region Methods

        public int Open(String fileName)
        {
            return (int)MediaInfo_Open(Handle, fileName);
        }
        public String Option(String option, String value)
        {
            string result;

            if (_useAnsi)
            {
                IntPtr optionPtr = Marshal.StringToHGlobalAnsi(option);
                IntPtr valuePtr = Marshal.StringToHGlobalAnsi(value);
                result = Marshal.PtrToStringAnsi(MediaInfoA_Option(Handle, optionPtr, valuePtr));
                Marshal.FreeHGlobal(optionPtr);
                Marshal.FreeHGlobal(valuePtr);
            }
            else
            {
                result = Marshal.PtrToStringUni(MediaInfo_Option(Handle, option, value));
            }
            return result;
        }
        public String Option(String option)
        {
            return Option(option, "");
        }

        public String Get(StreamKindType StreamKind, int StreamNumber, String Parameter, InfoKindType KindOfInfo, InfoKindType KindOfSearch)
        {
            if (_useAnsi)
            {
                IntPtr Parameter_Ptr = Marshal.StringToHGlobalAnsi(Parameter);
                String ToReturn = Marshal.PtrToStringAnsi(MediaInfoA_Get(Handle, (IntPtr)StreamKind, (IntPtr)StreamNumber, Parameter_Ptr, (IntPtr)KindOfInfo, (IntPtr)KindOfSearch));
                Marshal.FreeHGlobal(Parameter_Ptr);
                return ToReturn;
            }
            else
                return Marshal.PtrToStringUni(MediaInfo_Get(Handle, (IntPtr)StreamKind, (IntPtr)StreamNumber, Parameter, (IntPtr)KindOfInfo, (IntPtr)KindOfSearch));
        }

        public String Get(StreamKindType StreamKind, int StreamNumber, int Parameter, InfoKindType KindOfInfo)
        {
            if (_useAnsi)
                return Marshal.PtrToStringAnsi(MediaInfoA_GetI(Handle, (IntPtr)StreamKind, (IntPtr)StreamNumber, (IntPtr)Parameter, (IntPtr)KindOfInfo));
            else
                return Marshal.PtrToStringUni(MediaInfo_GetI(Handle, (IntPtr)StreamKind, (IntPtr)StreamNumber, (IntPtr)Parameter, (IntPtr)KindOfInfo));
        }
        public String Get(StreamKindType StreamKind, int StreamNumber, String Parameter, InfoKindType KindOfInfo)
        {
            return Get(StreamKind, StreamNumber, Parameter, KindOfInfo, InfoKindType.Name);
        }
        public String Get(StreamKindType StreamKind, int StreamNumber, String Parameter)
        {
            return Get(StreamKind, StreamNumber, Parameter, InfoKindType.Text, InfoKindType.Name);
        }
        public String Get(StreamKindType StreamKind, int StreamNumber, int Parameter)
        {
            return Get(StreamKind, StreamNumber, Parameter, InfoKindType.Text);
        }

        public int GetDuration()
        {
            return int.Parse(Get(StreamKindType.General, 0, "Duration"));
        }

        public void Close()
        {
            MediaInfo_Close(Handle);
        }
        #endregion
    }
}
