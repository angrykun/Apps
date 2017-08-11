using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Common;
using Apps.DAL;
using Apps.IBLL;
using Apps.Models;
using Microsoft.Practices.Unity;

namespace Apps.Admin
{
    public static class LogHandler
    {
        [Dependency]
        public static ISysLogBLL LogBLL { get; set; }

        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="entity"></param>
        public static void WriteServiceLog(SysLog entity)
        {
            try
            {
                entity.ID = ResultHelper.NewId;
                entity.CreateTime = ResultHelper.NowTime;
                SysLogRepository log = new SysLogRepository();
                log.Create(entity);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
