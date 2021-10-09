using System;
namespace WebCore.Core.UserManage
{
    public class UserManage
    {
        public UserManage()
        {

        }
        public static void UserRegister()
        {
            /**用户注册方法
             * 获取昵称
             * 密码(加密保存)
             * 验证手机号
             * 分配ID
             **/
        }
        public static string CreateUUID()
        {
            var guid = Guid.NewGuid().ToString();
            return guid;
        }
        public static bool Check_SIM_NUmber()
        {

            return false;
        }
        public static bool Check_EMail_Address()
        {

            return false;
        }

    }
}
