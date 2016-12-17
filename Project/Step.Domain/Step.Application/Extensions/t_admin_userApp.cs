using Step.Code;
using Step.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step.Application
{
    public partial class t_admin_userApp
    {
        public bool ValidUserPsw(string user_name,string user_psw,ref t_admin_userEntity user)
        {
            bool result = false;

            user = service.FindEntity(u => u.user_name == user_name);
            if (user != null)
            {
                string strPsw = Md5.PswProcess(user_psw,user.user_salt);//Md5.md5(user_psw + "2016" + user.user_salt, 32);
                if (strPsw == user.user_psw)
                {
                    user.last_login_time = DateTime.Now;
                    service.Update(user);

                    
                    result = true;
                }
            }

            return result;
        }

    }
}
