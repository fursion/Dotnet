using System;
using MySql;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace WebCore.Core.SQL
{
    public static class IO
    {
        public static void ConnectSql()
        {
            
        }

        public static void WriteToSQL()
        {


        }
        public static void PossingFile(HttpContext httpContext)
        {
           var f= httpContext.Request.Form.Files.FirstOrDefault();
            Console.WriteLine($"IO :{f.FileName}");
        }
    }
}
