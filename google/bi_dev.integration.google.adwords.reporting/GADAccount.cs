using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADAccount
    {
        public string Id { get; set; }
        public GADAccount(string id)
        {
            this.Id = id;
        }
    }
}
