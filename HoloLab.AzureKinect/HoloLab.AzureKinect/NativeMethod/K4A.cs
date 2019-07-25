// Copyright(c) 2019 HoloLab Inc.
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HoloLab.AzureKinect.NativeMethod
{
    public class K4A
    {
        const string k4a = "k4a.dll";

        [DllImport(k4a)]
        public extern static UInt32 k4a_device_get_installed_count();

        [DllImport(k4a)]
        public extern static k4a_result_t k4a_device_open(UInt32 index, out IntPtr device_handle);

        [DllImport(k4a)]
        public extern static void k4a_device_close(IntPtr device_handle);

        [DllImport(k4a)]
        public extern static k4a_wait_result_t k4a_device_get_capture(IntPtr device_handle, out IntPtr capture_handle, Int32 timeout_in_ms);

        [DllImport(k4a)]
        public extern static k4a_wait_result_t k4a_device_get_imu_sample(IntPtr device_handle, out IntPtr imu_sample, Int32 timeout_in_ms);

        [DllImport(k4a)]
        public extern static k4a_result_t k4a_capture_create(out IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static void k4a_capture_release(IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static void k4a_capture_reference(IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static IntPtr k4a_capture_get_color_image(IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static IntPtr k4a_capture_get_depth_image(IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static IntPtr k4a_capture_get_ir_image(IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static void k4a_capture_set_color_image(IntPtr capture_handle, IntPtr image_handle);

        [DllImport(k4a)]
        public extern static void k4a_capture_set_depth_image(IntPtr capture_handle, IntPtr image_handle);

        [DllImport(k4a)]
        public extern static void k4a_capture_set_ir_image(IntPtr capture_handle, IntPtr image_handle);

        [DllImport(k4a)]
        public extern static void k4a_capture_set_temperature_c(IntPtr capture_handle, float temperature_c);

        [DllImport(k4a)]
        public extern static float k4a_capture_get_temperature_c(IntPtr capture_handle);

        [DllImport(k4a)]
        public extern static k4a_result_t k4a_image_create(k4a_image_format_t format, int width_pixels, int height_pixels, int stride_bytes, out IntPtr image_handle);

        [DllImport(k4a)]
        public extern static k4a_result_t k4a_image_create_from_buffer(k4a_image_format_t format, int width_pixels, int height_pixels, int stride_bytes,
                out IntPtr buffer, Int64 buffer_size, k4a_memory_destroy_cb_t buffer_release_cb, IntPtr buffer_release_cb_context, out IntPtr image_handle);

        [DllImport(k4a)]
        public extern static IntPtr k4a_image_get_buffer(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static UInt64 k4a_image_get_size(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static k4a_image_format_t k4a_image_get_format(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static int k4a_image_get_width_pixels(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static int k4a_image_get_height_pixels(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static int k4a_image_get_stride_bytes(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static UInt64 k4a_image_get_timestamp_usec(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static UInt64 k4a_image_get_exposure_usec(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static UInt32 k4a_image_get_white_balance(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static UInt32 k4a_image_get_iso_speed(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static void k4a_image_set_timestamp_usec(IntPtr image_handle, UInt64 timestamp_usec);

        [DllImport(k4a)]
        public extern static void k4a_image_set_exposure_time_usec(IntPtr image_handle, UInt64 exposure_usec);

        [DllImport(k4a)]
        public extern static void k4a_image_set_white_balance(IntPtr image_handle, UInt32 white_balance);

        [DllImport(k4a)]
        public extern static void k4a_image_set_iso_speed(IntPtr image_handle, UInt32 iso_speed);

        [DllImport(k4a)]
        public extern static void k4a_image_reference(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static void k4a_image_release(IntPtr image_handle);

        [DllImport(k4a)]
        public extern static k4a_result_t k4a_device_start_cameras(IntPtr device_handle, ref DeviceConfiguration config);

        [DllImport(k4a)]
        public extern static void k4a_device_stop_cameras(IntPtr device_handle);
        //        K4A_EXPORT k4a_result_t k4a_device_start_imu(k4a_device_t device_handle);
        //        K4A_EXPORT void k4a_device_stop_imu(k4a_device_t device_handle);

        [DllImport(k4a)]
        public extern static k4a_buffer_result_t k4a_device_get_serialnum(IntPtr device_handle, IntPtr serial_number, ref UInt64 serial_number_size);

        //        K4A_EXPORT k4a_result_t k4a_device_get_version(k4a_device_t device_handle, k4a_hardware_version_t* version);
        //        K4A_EXPORT k4a_result_t k4a_device_get_color_control(k4a_device_t device_handle,
        //                                                             k4a_color_control_command_t command,
        //                                                             k4a_color_control_mode_t* mode,
        //                                                             int32_t* value);
        //        K4A_EXPORT k4a_result_t k4a_device_set_color_control(k4a_device_t device_handle,
        //                                                             k4a_color_control_command_t command,
        //                                                             k4a_color_control_mode_t mode,
        //                                                             int32_t value);
        //        K4A_EXPORT k4a_buffer_result_t k4a_device_get_raw_calibration(k4a_device_t device_handle,
        //                                                                      uint8_t* data,
        //                                                                      size_t* data_size);
        //        K4A_EXPORT k4a_result_t k4a_device_get_calibration(k4a_device_t device_handle,
        //                                                   const k4a_depth_mode_t depth_mode,
        //                                                   const k4a_color_resolution_t color_resolution,
        //                                                   k4a_calibration_t *calibration);
        //        K4A_EXPORT k4a_result_t k4a_device_get_sync_jack(k4a_device_t device_handle,
        //                                                         bool* sync_in_jack_connected,
        //                                                         bool* sync_out_jack_connected);

        //        K4A_EXPORT k4a_result_t k4a_calibration_get_from_raw(char* raw_calibration,
        //                                                             size_t raw_calibration_size,
        //                                                     const k4a_depth_mode_t depth_mode,
        //                                                     const k4a_color_resolution_t color_resolution,
        //                                                     k4a_calibration_t *calibration);
        //    K4A_EXPORT k4a_result_t k4a_calibration_3d_to_3d(const k4a_calibration_t* calibration,
        //                                                     const k4a_float3_t* source_point3d,
        //                                                     const k4a_calibration_type_t source_camera,
        //                                                     const k4a_calibration_type_t target_camera,
        //                                                     k4a_float3_t *target_point3d);
        //K4A_EXPORT k4a_result_t k4a_calibration_2d_to_3d(const k4a_calibration_t* calibration,
        //                                                 const k4a_float2_t* source_point2d,
        //                                                 const float source_depth,
        //                                                 const k4a_calibration_type_t source_camera,
        //                                                 const k4a_calibration_type_t target_camera,
        //                                                 k4a_float3_t *target_point3d,
        //                                                 int* valid);
        //        K4A_EXPORT k4a_result_t k4a_calibration_3d_to_2d(const k4a_calibration_t* calibration,
        //                                                 const k4a_float3_t* source_point3d,
        //                                                 const k4a_calibration_type_t source_camera,
        //                                                 const k4a_calibration_type_t target_camera,
        //                                                 k4a_float2_t *target_point2d,
        //                                                 int* valid);
        //        K4A_EXPORT k4a_result_t k4a_calibration_2d_to_2d(const k4a_calibration_t* calibration,
        //                                                 const k4a_float2_t* source_point2d,
        //                                                 const float source_depth,
        //                                                 const k4a_calibration_type_t source_camera,
        //                                                 const k4a_calibration_type_t target_camera,
        //                                                 k4a_float2_t *target_point2d,
        //                                                 int* valid);
        //        K4A_EXPORT k4a_transformation_t k4a_transformation_create(const k4a_calibration_t* calibration);
        //        K4A_EXPORT void k4a_transformation_destroy(k4a_transformation_t transformation_handle);
        //        K4A_EXPORT k4a_result_t k4a_transformation_depth_image_to_color_camera(k4a_transformation_t transformation_handle,
        //                                                                       const k4a_image_t depth_image,
        //                                                                       k4a_image_t transformed_depth_image);
        //K4A_EXPORT k4a_result_t k4a_transformation_color_image_to_depth_camera(k4a_transformation_t transformation_handle,
        //                                                                       const k4a_image_t depth_image,
        //                                                                       const k4a_image_t color_image,
        //                                                                       k4a_image_t transformed_color_image);
        //K4A_EXPORT k4a_result_t k4a_transformation_depth_image_to_point_cloud(k4a_transformation_t transformation_handle,
        //                                                                      const k4a_image_t depth_image,
        //                                                                      const k4a_calibration_type_t camera,
        //                                                                      k4a_image_t xyz_image);
    }
}
