using Services.BLL.BooksService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL.VideoLessonService
{
    public interface IVideoLessonService: IBaseService
    {
        bool AddFreeVideo();
    }
}
