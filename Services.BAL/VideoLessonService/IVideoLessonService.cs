using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public interface IVideoLessonService: IBaseService
    {
        bool AddFreeVideo();
    }
}
