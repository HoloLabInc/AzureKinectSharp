// Copyright(c) 2019 HoloLab Inc.
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php

using System;
using System.Collections.Generic;
using System.Text;

namespace HoloLab.AzureKinect.NativeMethod
{

    public delegate void k4a_memory_destroy_cb_t(IntPtr buffer, IntPtr context);


    public enum k4a_result_t
    {
        K4A_RESULT_SUCCEEDED = 0, /**< The result was successful */
        K4A_RESULT_FAILED,        /**< The result was a failure */
    }

    public enum k4a_wait_result_t
    {
        K4A_WAIT_RESULT_SUCCEEDED = 0, /**< The result was successful */
        K4A_WAIT_RESULT_FAILED,        /**< The result was a failure */
        K4A_WAIT_RESULT_TIMEOUT,       /**< The operation timed out */
    }

    public enum k4a_image_format_t
    {
        /** Color image type MJPG.
         *
         * \details
         * The buffer for each image is encoded as a JPEG and can be decoded by a JPEG decoder.
         *
         * \details
         * Because the image is compressed, the stride parameter for the \ref k4a_image_t is not applicable.
         *
         * \details
         * Each MJPG encoded image in a stream may be of differing size depending on the compression efficiency.
         */
        K4A_IMAGE_FORMAT_COLOR_MJPG = 0,

        /** Color image type NV12.
         *
         * \details
         * NV12 images separate the luminance and chroma data such that all the luminance is at the
         * beginning of the buffer, and the chroma lines follow immediately after.
         *
         * \details
         * Stride indicates the length of each line in bytes and should be used to determine the start location of each line
         * of the image in memory. Chroma has half as many lines of height and half the width in pixels of the luminance.
         * Each chroma line has the same width in bytes as a luminance line.
         */
        K4A_IMAGE_FORMAT_COLOR_NV12,

        /** Color image type YUY2.
         *
         * \details
         * YUY2 stores chroma and luminance data in interleaved pixels.
         *
         * \details
         * Stride indicates the length of each line in bytes and should be used to determine the start location of each
         * line of the image in memory.
         */
        K4A_IMAGE_FORMAT_COLOR_YUY2,

        /** Color image type BGRA32.
         *
         * \details
         * Each pixel of BGRA32 data is four bytes. The first three bytes represent Blue, Green,
         * and Red data. The fourth byte is the alpha channel and is unused in the Azure Kinect APIs.
         *
         * \details
         * Stride indicates the length of each line in bytes and should be used to determine the start location of each
         * line of the image in memory.
         *
         * \details
         * The Azure Kinect device does not natively capture in this format. Requesting images of this format
         * requires additional computation in the API.
         *
         */
        K4A_IMAGE_FORMAT_COLOR_BGRA32,

        /** Depth image type DEPTH16.
         *
         * \details
         * Each pixel of DEPTH16 data is two bytes of little endian unsigned depth data. The unit of the data is in
         * millimeters from the origin of the camera.
         *
         * \details
         * Stride indicates the length of each line in bytes and should be used to determine the start location of each
         * line of the image in memory.
         */
        K4A_IMAGE_FORMAT_DEPTH16,

        /** Image type IR16.
         *
         * \details
         * Each pixel of IR16 data is two bytes of little endian unsigned depth data. The value of the data represents
         * brightness.
         *
         * \details
         * This format represents infrared light and is captured by the depth camera.
         *
         * \details
         * Stride indicates the length of each line in bytes and should be used to determine the start location of each
         * line of the image in memory.
         */
        K4A_IMAGE_FORMAT_IR16,

        /** Custom image format.
         *
         * \details
         * Used in conjunction with user created images or images packing non-standard data.
         *
         * \details
         * See the originator of the custom formatted image for information on how to interpret the data.
         */
        K4A_IMAGE_FORMAT_CUSTOM,
    }

    public enum k4a_color_resolution_t
    {
        K4A_COLOR_RESOLUTION_OFF = 0, /**< Color camera will be turned off with this setting */
        K4A_COLOR_RESOLUTION_720P,    /**< 1280 * 720  16:9 */
        K4A_COLOR_RESOLUTION_1080P,   /**< 1920 * 1080 16:9 */
        K4A_COLOR_RESOLUTION_1440P,   /**< 2560 * 1440 16:9 */
        K4A_COLOR_RESOLUTION_1536P,   /**< 2048 * 1536 4:3  */
        K4A_COLOR_RESOLUTION_2160P,   /**< 3840 * 2160 16:9 */
        K4A_COLOR_RESOLUTION_3072P,   /**< 4096 * 3072 4:3  */
    }

    enum k4a_depth_mode_t
    {
        K4A_DEPTH_MODE_OFF = 0,        /**< Depth sensor will be turned off with this setting. */
        K4A_DEPTH_MODE_NFOV_2X2BINNED, /**< Depth captured at 320x288. Passive IR is also captured at 320x288. */
        K4A_DEPTH_MODE_NFOV_UNBINNED,  /**< Depth captured at 640x576. Passive IR is also captured at 640x576. */
        K4A_DEPTH_MODE_WFOV_2X2BINNED, /**< Depth captured at 512x512. Passive IR is also captured at 512x512. */
        K4A_DEPTH_MODE_WFOV_UNBINNED,  /**< Depth captured at 1024x1024. Passive IR is also captured at 1024x1024. */
        K4A_DEPTH_MODE_PASSIVE_IR,     /**< Passive IR only, captured at 1024x1024. */
    }

    enum k4a_fps_t
    {
        K4A_FRAMES_PER_SECOND_5 = 0, /**< 5 FPS */
        K4A_FRAMES_PER_SECOND_15,    /**< 15 FPS */
        K4A_FRAMES_PER_SECOND_30,    /**< 30 FPS */
    }

    enum k4a_wired_sync_mode_t
    {
        K4A_WIRED_SYNC_MODE_STANDALONE, /*< Neither 'Sync In' or 'Sync Out' connections are used. */
        K4A_WIRED_SYNC_MODE_MASTER,     /*< The 'Sync Out' jack is enabled and synchronization data it driven out the
                                       connected wire.*/
        K4A_WIRED_SYNC_MODE_SUBORDINATE /*< The 'Sync In' jack is used for synchronization and 'Sync Out' is driven for the
                                       next device in the chain. 'Sync Out' is a mirror of 'Sync In' for this mode. */
    }

    public struct k4a_device_configuration_t
    {
        /** Image format to capture with the color camera.
         *
         * The color camera does not natively produce BGRA32 images.
         * Setting ::K4A_IMAGE_FORMAT_COLOR_BGRA32 for color_format will result in higher CPU utilization. */
        k4a_image_format_t color_format;

        /** Image resolution to capture with the color camera. */
        k4a_color_resolution_t color_resolution;

        /** Capture mode for the depth camera. */
        k4a_depth_mode_t depth_mode;

        /** Desired frame rate for the color and depth camera. */
        k4a_fps_t camera_fps;

        /** Only produce k4a_capture_t objects if they contain synchronized color and depth images.
         *
         * \details
         * This setting controls the behavior in which images are dropped when images are produced faster than they can be
         * read, or if there are errors in reading images from the device.
         *
         * \details
         * If set to true, \ref k4a_capture_t objects will only be produced with both color and depth images.
         * If set to false, \ref k4a_capture_t objects may be produced only a single image when the corresponding image is
         * dropped.
         *
         * \details
         * Setting this to false ensures that the caller receives all of the images received from the camera, regardless of
         * whether the corresponding images expected in the capture are available.
         *
         * \details
         * If either the color or depth camera are disabled, this setting has no effect.
         */
        bool synchronized_images_only;

        /**
         * Desired delay between the capture of the color image and the capture of the depth image.
         *
         * \details
         * A negative value indicates that the depth image should be captured before the color image.
         *
         * \details
         * Any value between negative and positive one capture period is valid.
         */
        Int32 depth_delay_off_color_usec;

        /** The external synchronization mode. */
        k4a_wired_sync_mode_t wired_sync_mode;

        /**
         * The external synchronization timing.
         *
         * If this camera is a subordinate, this sets the capture delay between the color camera capture and the external
         * input pulse. A setting of zero indicates that the master and subordinate color images should be aligned.
         *
         * This setting does not effect the 'Sync out' connection.
         *
         * This value must be positive and range from zero to one capture period.
         *
         * If this is not a subordinate, then this value is ignored. */
        UInt32 subordinate_delay_off_master_usec;

        /**
         * Streaming indicator automatically turns on when the color or depth camera's are in use.
         *
         * This setting disables that behavior and keeps the LED in an off state. */
        bool disable_streaming_indicator;
    }
}

public enum k4a_buffer_result_t
{
    K4A_BUFFER_RESULT_SUCCEEDED = 0, /**< The result was successful */
    K4A_BUFFER_RESULT_FAILED,        /**< The result was a failure */
    K4A_BUFFER_RESULT_TOO_SMALL,     /**< The input buffer was too small */
}
