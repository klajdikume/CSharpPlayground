using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced.EventDelegate
{
    public class Video
    {
        public string Name { get; set; }
    }
    public class VideoEventArgs : EventArgs
    {
        public  Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // 1. Define a delegate
        // 2. Define an event based on that delegate
        // 3. Raise the event

        // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // EventHandler
        // EventHandler<TEventArgs>
        
        public event EventHandler<VideoEventArgs> VideoEncoded;
        // public event EventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs(){ Video = video });
        }
    }
}
