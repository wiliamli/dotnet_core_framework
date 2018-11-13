using System;
using System.Collections.Generic;
using System.Text;

namespace Jwell.Framework.Paging
{
    public class PageParam
    {
        /// <summary>
        /// 分页序号
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 排序规则
        /// </summary>
        public SortDirection SortDirection { get; set; }
    }
}
