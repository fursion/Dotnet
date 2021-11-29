using System;
namespace WebCore.Core.SQL
{
    public class Authorize:Attribute
    {
        public int PermissionLevel { get; set; }
        public Authorize(int PermissionLevel)
        {
            this.PermissionLevel = PermissionLevel;
        }
    }
}
