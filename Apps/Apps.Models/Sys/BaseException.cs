using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Apps.Models.Sys
{
    /// <summary>
    /// 异常基类
    /// </summary>
    public class BaseException
    {
        #region 属性
        public string ExceptionMessage { get; set; }
        public string ExceptionName { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string InnerExceptionName { get; set; }
        public bool IsShow { get; set; }
        public Exception OutermostException { get; set; }
        public string SourceErrorFile { get; set; }
        public string SourceErrorRowID { get; set; }
        public string StackInfo { get; set; }
        public string TargetSite { get; set; }
        public Exception Exception
        {
            get
            {
                return (HttpContext.Current.Session["Exception"] as Exception);
            }
            private set
            {
                HttpContext.Current.Session["Exception"] = value;
            }
        }
        public string ErrorPageUrl
        {
            get
            {
                return GetExceptionUrl();
            }
        }
        public bool IsShowStackInfo
        {
            get
            {
                return IsShow;
            }
            private set
            {
                IsShow = value;
            }
        }
        #endregion

        public BaseException()
        {
            OutermostException = null;
            ExceptionName = null;
            ExceptionMessage = null;
            InnerExceptionMessage = null;
            InnerExceptionName = null;
            TargetSite = null;
            StackInfo = null;
            SourceErrorFile = null;
            SourceErrorRowID = null;
            IsShow = false;
            try
            {
                Exception = HttpContext.Current.Application["LastError"] as Exception;

                if (Exception != null)
                {
                    OutermostException = Exception;
                    if (Exception is HttpUnhandledException && Exception.InnerException != null)
                    {
                        Exception = Exception.InnerException;
                    }
                    ExceptionName = GetExceptionName(Exception);
                    ExceptionMessage = GetExceptionMessage(Exception);
                    if (Exception.InnerException != null)
                    {
                        InnerExceptionName = GetExceptionName(Exception.InnerException);
                        InnerExceptionMessage = GetExceptionMessage(Exception.InnerException);
                    }
                    TargetSite = GetTargetSite(Exception);
                    StackInfo = GetStackInfo(Exception);
                    if ((OutermostException is HttpUnhandledException) && (OutermostException.InnerException != null))
                    {
                        StackInfo = StackInfo + "\r\n<a href='#' onclick=\"if(document.getElementById('phidden').style.display=='none') document.getElementById('phidden').style.display='block'; else document.getElementById('phidden').style.display='none'; return false;\"><b>[" + OutermostException.GetType().ToString() + "]</b></a>\r\n";
                        StackInfo = StackInfo + "<pre id='phidden' style='display:none;'>" + OutermostException.StackTrace + "</pre>";
                    }
                    SourceErrorFile = GetSourceErrorFile();
                    SourceErrorRowID = GetSourceErrorRowID();
                    IsShowStackInfo = true;
                }
                HttpContext.Current.Session["LastError"] = null;
            }
            catch (Exception exception)
            {
                this.ExceptionMessage = "异常基页出错" + exception.Message;
            }
        }

        private string GetExceptionMessage(Exception ex)
        {
            return ex.Message;
        }
        private string GetExceptionMessageForLog()
        {
            StringBuilder builder = new StringBuilder(50);
            builder.AppendFormat("<ExceptionName>{0}</ExceptionName>", ExceptionName);
            builder.AppendFormat("<ExceptionMessage>{0}</ExceptionMessage>", ExceptionMessage);
            builder.AppendFormat("<InnerExceptionName>{0}</InnerExceptionName>", InnerExceptionName);
            builder.AppendFormat("<InnerExceptionMessage>{0}</InnerExceptionMessage>", InnerExceptionMessage);
            builder.AppendFormat("<TargetSite>{0}</TargetSite>", TargetSite);
            builder.AppendFormat("<ErrorPageUrl>{0}</ErrorPageUrl>", ErrorPageUrl);
            builder.AppendFormat("<SourceErrorFile>{0}</SourceErrorFile>", SourceErrorFile);
            builder.AppendFormat("<SourceErrorRowID>{0}</SourceErrorRowID>", SourceErrorRowID);
            return builder.ToString();
        }

        private string GetExceptionMessageForMail()
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append("<ExceptionInfo>");
            builder.Append(GetExceptionMessageForLog());
            builder.AppendFormat("<StackInfo><![CDATA[{0}]]></StackInfo>", StackInfo);
            builder.Append("</ExceptionInfo>");
            return builder.ToString();
        }

        private string GetExceptionName(Exception ex)
        {
            string str = null;
            if (ex != null)
            {
                str = ex.GetType().FullName;
            }
            return str;
        }
        private string GetExceptionUrl()
        {
            string str = null;
            if (HttpContext.Current.Request["ErrorUrl"] != null)
            {
                str = HttpContext.Current.Request["ErrorUrl"].ToString();
            }
            return str;
        }

        private string GetSourceErrorFile()
        {
            string stackInfo = this.StackInfo;
            string[] strArray = new string[0];
            if (stackInfo == null)
            {
                return stackInfo;
            }
            strArray = stackInfo.Split(new string[] { "位置", "行号" }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length >= 3)
            {
                stackInfo = strArray[1];
                if (stackInfo.LastIndexOf(":") == (stackInfo.Length - 1))
                {
                    stackInfo = stackInfo.Substring(0, stackInfo.Length - 1);
                }
                return stackInfo;
            }
            return "";
        }
        private string GetSourceErrorRowID()
        {
            string stackInfo = this.StackInfo;
            string[] strArray = new string[0];
            if (stackInfo == null)
            {
                return stackInfo;
            }
            strArray = stackInfo.Split(new string[] { "行号" }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length >= 2)
            {
                stackInfo = strArray[1].Trim();
                string[] strArray2 = stackInfo.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (strArray2.Length >= 2)
                {
                    stackInfo = strArray2[0];
                }
                return stackInfo;
            }
            return "";
        }
        private string GetStackInfo(Exception ex)
        {
            string str = null;
            if (ex != null)
            {
                str = "<b>[" + ex.GetType().ToString() + "]</b>\r\n" + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    str = this.GetStackInfo(ex.InnerException) + "\r\n" + str;
                }
            }
            return str;
        }
        private string GetTargetSite(Exception ex)
        {
            string str = null;
            if (ex != null)
            {
                ex = this.GetBenmostException(ex);
                MethodBase targetSite = ex.TargetSite;
                if (targetSite != null)
                {
                    str = string.Format("{0}.{1}", targetSite.DeclaringType, targetSite.Name);
                }
            }
            return str;
        }
        protected Exception GetBenmostException(Exception ex)
        {
            while (true)
            {
                if (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                else
                {
                    return ex;
                }
            }
        }
    }
}
