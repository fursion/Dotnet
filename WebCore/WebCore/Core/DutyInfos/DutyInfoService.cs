using System;
using System.Text.Json;
using System.Collections.Generic;
using WebCore.Core;
using WebCore.Core.Config;
namespace WebCore.Core.DutyInfos
{
    public class DutyInfoService : WebService<DutyInfoService>, IWebService
    {
        public Dictionary<string, string> ContactsDict;
        public DutyInfoService()
        {
            ConfigCore.AddConfig<DutyConfig>();
        }
        public void Refresh()
        {
            try
            {               
                ContactsDict = JsonSerializer.Deserialize<Dictionary<string, string>>(IO.ReadAllText( ConfigCore.GetConfigItem<DutyConfig>().ContactLinkPath));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        void IWebService.ReStartService()
        {
            throw new NotImplementedException();
        }

        void IWebService.StartService()
        {
            throw new NotImplementedException();
        }

        void IWebService.StopService()
        {
            throw new NotImplementedException();
        }
    }
}

