using System;
using System.Collections.Generic;
using BusinessObjects;

namespace DataObjects
{
    public interface IFlashHomeDao
    {
        int CreateFlashHomeImage(FlashHome _FlashHome);
        IList<FlashHome> GetFlashHomeImages(bool _ShowAll);
        FlashHome GetFlashHomeImage(int _ID);
        int UpdateFlashHomeImage(FlashHome _FlashHome);
        int DeleteFlashHomeImage(int _ID);
    }
}
