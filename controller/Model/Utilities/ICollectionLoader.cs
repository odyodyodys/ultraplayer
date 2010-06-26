using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model.Utilities
{
    interface ICollectionLoader<T>
    {
        ICollection<T> Load();
    }
}
