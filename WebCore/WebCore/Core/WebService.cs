using System;
namespace WebCore.Core
{
    public interface IWebService:IDisposable
    {
        /// <summary>
        /// 启动服务
        /// </summary>
        protected void StartService();
        /// <summary>
        /// 暂停服务
        /// </summary>
        protected void StopService();
        /// <summary>
        /// 重启服务
        /// </summary>
        protected void ReStartService();
    }
    public abstract class WebService<T>where T:IWebService
    {
        public static T Service { get; set; }
    }
}

