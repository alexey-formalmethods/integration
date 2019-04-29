using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.auth
{
    public interface IAuthInitializer
    {
    }
    public interface IAuthInitializerFile: IAuthInitializer
    {
        string FilePath { get; }
    }
}
