using HoloLab.AzureKinect.NativeMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoloLab.AzureKinect
{
    public class Image : IDisposable
    {
        IntPtr image_handle = IntPtr.Zero;

        internal Image(IntPtr image_handle)
        {
            this.image_handle = image_handle;
        }

        void Close()
        {
            if (image_handle != IntPtr.Zero)
            {
                K4A.k4a_image_release(image_handle);
                image_handle = IntPtr.Zero;
            }
        }

        IntPtr getBuffer()
        {
            return K4A.k4a_image_get_buffer(image_handle);
        }

        UInt64 getSize() 
		{
			return K4A.k4a_image_get_size(image_handle);
    }

        ImageFormat getFormat() 
		{
            return (ImageFormat)K4A.k4a_image_get_format(image_handle);
        }

        int getWidth() 
		{
			return K4A.k4a_image_get_width_pixels(image_handle);
		}

		int getHeight() 
		{
			return K4A.k4a_image_get_height_pixels(image_handle);
		}

		int getStride() 
		{
			return K4A.k4a_image_get_stride_bytes(image_handle);
		}

		UInt64 getTimestamp()
		{
			return K4A.k4a_image_get_timestamp_usec(image_handle);
		}

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                }

                // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。
                Close();

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~Image()
        // {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
