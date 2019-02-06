using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.VideoLesson
{
    public class VideoLesson: IVideoLessonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

    }
}
