using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS_App_CodeTests.DataAccess;

namespace TMS_App_CodeTests.Auto.DataAccess
{
    public class Db
    {
        public static readonly Database Helper = new Database("TMSConn");
    }
}
