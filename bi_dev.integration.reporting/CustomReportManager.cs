using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting
{
    public abstract class CustomReportManager<T, IT, RT> where T: CustomReport<IT> where IT: ICustomReportInitializer where RT: ICustomReportReceiver<T, IT>
    {
        protected RT receiver;
        public CustomReportManager(RT receiver)
        {
            this.receiver = receiver;
        }
        public virtual T Get(IT initializer)
        {
            return this.receiver.Get(initializer);
        }
    }
}
