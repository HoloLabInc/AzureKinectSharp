using System;
using System.Collections.Generic;
using System.Text;

namespace HoloLab.AzureKinect
{
    public enum DepthMode
    {
        OFF = 0,
        NarrowFOV_2x2_Binned, /**< Depth captured at 320x288. Passive IR is also captured at 320x288. */
        NarrowFOV_Unbinned,  /**< Depth captured at 640x576. Passive IR is also captured at 640x576. */
        WideFOV_2x2_Binned, /**< Depth captured at 512x512. Passive IR is also captured at 512x512. */
        WideFOV_Unbinned,  /**< Depth captured at 1024x1024. Passive IR is also captured at 1024x1024. */
        PassiveIr,
    }
}
