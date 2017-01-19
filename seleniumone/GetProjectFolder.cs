using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace seleniumone

{
    class GetProjectFolder
    {

        public static string getpath()
        {
            string execpath;

            execpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            execpath = execpath.Substring(6);
            string newpath = Path.GetFullPath(Path.Combine(execpath, @"..\..\"));
            return newpath;
        }

    }
}
