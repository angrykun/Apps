using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Apps.Models.Sys
{
    public class SysSampleModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "名称")]
        public string Name { get; set; }
        [Display(Name = "年龄")]
        public Nullable<long> Age { get; set; }
        [Display(Name = "生日")]
        public string Bir { get; set; }
        [Display(Name = "照片")]
        public string Photo { get; set; }
        [Display(Name = "简介")]
        public string Note { get; set; }
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}
