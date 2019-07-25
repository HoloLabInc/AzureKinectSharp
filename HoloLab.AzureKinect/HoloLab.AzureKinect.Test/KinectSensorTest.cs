using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoloLab.AzureKinect.Test
{
    [TestClass]
    public class KinectSensorTest
    {
        [TestMethod]
        public void �f�o�C�X�����擾����()
        {
            Assert.AreEqual(1U, KinectSensor.SensorCount);
        }

        [TestMethod]
        public void �Z���T�[���J��()
        {
            try
            {
                using (var targert = new KinectSensor())
                {
                    targert.Open(0);
                }
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Dispose����邱�Ƃ��m�F����()
        {
            KinectSensor target = null;
            using (target = new KinectSensor())
            {
                target.Open(0);
                Assert.IsTrue(target.IsOpened);
            }

            Assert.IsNotNull(target);
            Assert.IsFalse(target.IsOpened);
        }

        [TestMethod]
        public void �V���A���i���o�[���擾����()
        {
            using (var target = new KinectSensor())
            {
                target.Open();
                Assert.AreEqual("000327292312", target.GetSerialNumber());
            }
        }

        [TestMethod]
        public void �J�������J�n����()
        {
            using (var target = new KinectSensor())
            {
                target.Open();

                var config = new DeviceConfiguration();
                config.ColorFormat = ImageFormat.ColorBGRA32;
                config.ColorResolution = ColorResolution._1080P;
                config.CameraFps = Fps._30;
                config.DepthMode = DepthMode.NarrowFOV_2x2_Binned;
                config.SynchronizedImagesOnly = true;
                config.SubordinateDelayOffMasterUsec = 0;
                config.WiredSyncMode = WiredSyncMode.Standalone;
                config.SubordinateDelayOffMasterUsec = 0;
                config.DisableStreamingIndicator = false;
                target.StartCamera(config);

                target.StopCamera();
            }

        }
    }
}
