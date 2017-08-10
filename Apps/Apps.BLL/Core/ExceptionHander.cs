using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Apps.Common;
using Apps.Models;
using System.Data.Entity;
using System.Web;

namespace Apps.BLL.Core
{
    /// <summary>
    /// 写入一个异常错误
    /// </summary>
    public static class ExceptionHander
    {
        /// <summary>
        /// 写入异常  数据库，文本
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteException(Exception ex)
        {
            try
            {
                using (DbContainer db = new DbContainer())
                {
                    SysException model = new SysException()
                    {
                        ID = ResultHelper.NewId,
                        HelpLink = ex.HelpLink,
                        Message = ex.Message,
                        Source = ex.Source,
                        StackTrace = ex.StackTrace,
                        TargetSite = ex.TargetSite.ToString(),
                        Data = ex.Data.ToString(),
                        CreateTime = ResultHelper.NowTime
                    };
                    db.SysException.Add(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ep)
            {
                try
                {
                    //异常失败写入txt
                    string path = @"~/exceptionLog.txt";
                    string txtPath = System.Web.HttpContext.Current.Server.MapPath(path);//获取绝对路径
                    using (StreamWriter sw = new StreamWriter(txtPath, true, Encoding.Default))
                    {
                        sw.WriteLine((ex.Message + "|" + ex.StackTrace + "|" + ep.Message + "|" + DateTime.Now.ToString()).ToString());
                        sw.Dispose();
                        sw.Close();
                    }
                    return;
                }
                catch { return; }
            }
        }
    }
}
