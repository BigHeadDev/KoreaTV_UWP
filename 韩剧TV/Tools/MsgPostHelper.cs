using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Tools
{
    public delegate void NavigateHandel(Type page,params object[] par);//跳转页面委托
    public delegate void HomePivotHandel(int index);
    public static class MsgPostHelper
    {
        public static event NavigateHandel MianNavigateToEvent;
        public static event HomePivotHandel HomePivotEvent;
        public static void MainNavigateTo(Type page,params object[] par)
        {
            MianNavigateToEvent(page, par);
        }
        public static void ChangeHomePivotIndex(int index)
        {
            HomePivotEvent(index);
        }
    }
}
