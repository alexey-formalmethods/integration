using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting
{
    public interface ICustomReportReceiver<T, IT> where T: CustomReport<IT> where IT: ICustomReportInitializer
    {
        T Get(IT initializer);
    }
}
