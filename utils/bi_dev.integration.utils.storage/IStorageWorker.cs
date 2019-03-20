using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.utils.storage
{
    public interface IStorageWorker<T, ST> where ST: IStorageInitializer
    {
        void Save(T obj, ST initializer);
    }
}
