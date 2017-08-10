using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Models
{
    public class ValidationError
    {
        public ValidationError() { }
        public string ErrorMessage { get; set; }
    }

    public class ValidationErrors : List<ValidationError>
    {
        //添加错误
        public void Add(string errorMessage)
        {
            base.Add(new ValidationError { ErrorMessage = errorMessage });
        }
        /// <summary>
        /// 获取错误集合
        /// </summary>
        public string Error
        {
            get
            {
                string error = "";
                this.All(a =>
                {
                    error += a.ErrorMessage;
                    return true;
                });
                return error;
            }
        }
    }


}
