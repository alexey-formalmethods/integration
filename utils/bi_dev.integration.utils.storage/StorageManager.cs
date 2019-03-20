using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.utils.storage
{
    public class StorageManager<T, WT, PT> where WT: IStorageWorker<T, PT> where PT: IStorageInitializer
    {
        T objToSave;
        WT storageWorker;
        PT storageInitializer;
        public StorageManager(T objToSave, WT storageWorker, PT storageInitializer)
        {
            this.objToSave = objToSave;
            this.storageWorker = storageWorker;
            this.storageInitializer = storageInitializer;
        }
        public void Save()
        {
            this.storageWorker.Save(objToSave, storageInitializer);
        }
    }
}
