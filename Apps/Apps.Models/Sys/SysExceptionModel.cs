﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Apps.Models.Sys
{
    public class SysExceptionModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }
        [Display(Name = "帮助链接")]
        public string HelpLink { get; set; }
        [Display(Name = "异常信息")]
        public string Message { get; set; }
        [Display(Name = "来源")]
        public string Source { get; set; }
        [Display(Name = "堆栈")]
        public string StackTrace { get; set; }
        [Display(Name = "目标页")]
        public string TargetSite { get; set; }
        [Display(Name = "程序集")]
        public string Data { get; set; }
        [Display(Name = "发生时间")]
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
