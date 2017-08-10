using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IBLL;
using Apps.Models;
using Apps.IDAL;
using Apps.DAL;
using Microsoft.Practices.Unity;

namespace Apps.BLL
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(moduleId);
        }
    }
}
