using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class VideoLessonService: IService<object>
    {
        public bool AddFreeVideo()
        {
            Console.WriteLine(nameof(AddFreeVideo));
            return true;
        }
        //object because parameter don't use
        public void CallService(object obj)
        {
            AddFreeVideo();
        }
    }
}
