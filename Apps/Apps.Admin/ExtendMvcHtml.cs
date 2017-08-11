using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Apps.Models.Sys;

namespace Apps.Admin
{
    /// <summary>
    /// Html 扩展类
    /// </summary>
    public static class ExtendMvcHtml
    {
        /// <summary>
        /// button Html扩展方法
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id"></param>
        /// <param name="icon"></param>
        /// <param name="text"></param>
        /// <param name="hr"></param>
        /// <returns></returns>
        public static MvcHtmlString ToolButton(this HtmlHelper helper, string id, string icon, string text, bool hr = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<a id={id}  href='javascript:void(0);' ");
            sb.Append($" class='easyui-linkbutton'");
            sb.Append($" data-options='iconCls:\"{icon}\"'>");
            sb.Append($"{text}</a>");
            if (hr)
            {
                sb.Append("<div class=\"datagrid-btn-separator\"></div>");
            }
            return new MvcHtmlString(sb.ToString());
        }

    }
}
