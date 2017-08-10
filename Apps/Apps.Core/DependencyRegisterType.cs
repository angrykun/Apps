using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IBLL;
using Apps.BLL;
using Apps.IDAL;
using Apps.DAL;
using Microsoft.Practices.Unity;

namespace Apps.Core
{
    public class DependencyRegisterType
    {
        public static void Container_Sys(ref UnityContainer container)
        {
            //注入样例
            container.RegisterType<ISysSampleBLL, SysSampleBLL>();
            container.RegisterType<ISysSampleRepository, SysSampleRepository>();

            container.RegisterType<IHomeBLL, HomeBLL>();
            container.RegisterType<IHomeRepository, HomeRepository>();

            container.RegisterType<ISysLogBLL, SysLogBLL>();
            container.RegisterType<ISysLogRepository, SysLogRepository>();

            container.RegisterType<ISysExceptionBLL, SysExceptionBLL>();
            container.RegisterType<ISysExceptionRepository, SysExceptionRepository>();
        }
    }
}
