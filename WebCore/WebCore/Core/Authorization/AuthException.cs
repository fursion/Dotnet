using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Core.Authorization
{
    public class AuthException : Exception
    {
        /// <summary>
        /// 鉴权系统状态码
        /// </summary>
        public int Code { get; set; }
    }
}
