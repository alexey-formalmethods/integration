using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bi_dev.integration.utils.storage
{
    public interface ISaveable
    {
		void Save(DataTable dataTable);
    }
}
