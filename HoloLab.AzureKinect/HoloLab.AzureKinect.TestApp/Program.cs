// Copyright(c) 2019 HoloLab Inc.
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php

using HoloLab.AzureKinect.NativeMethod;
using System;

namespace HoloLab.AzureKinect.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Device Count : {K4A.k4a_device_get_installed_count()}");
                Console.WriteLine($"Device Count : {KinectSensor.SensorCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
