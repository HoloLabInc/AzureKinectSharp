using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HoloLab.AzureKinect
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DeviceConfiguration
    {
        [MarshalAs(UnmanagedType.I4)]
        public ImageFormat ColorFormat;

        [MarshalAs(UnmanagedType.I4)]
        public ColorResolution ColorResolution;

        [MarshalAs(UnmanagedType.I4)]
        public DepthMode DepthMode;

        [MarshalAs(UnmanagedType.I4)]
        public Fps CameraFps;

        [MarshalAs(UnmanagedType.U1)]
        public bool SynchronizedImagesOnly;

        [MarshalAs(UnmanagedType.I4)]
        public Int32 DepthDelayOffColorUsec;

        [MarshalAs(UnmanagedType.I4)]
        public WiredSyncMode WiredSyncMode;

        [MarshalAs(UnmanagedType.I4)]
        public UInt32 SubordinateDelayOffMasterUsec;

        [MarshalAs(UnmanagedType.U1)]
        public bool DisableStreamingIndicator;
    }
}
