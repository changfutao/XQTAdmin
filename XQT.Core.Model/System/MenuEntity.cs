using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;

namespace XQT.Core.Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Comment("菜单表")]
    public class MenuEntity: EntityFull
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Comment("菜单名称")]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Comment("菜单编码")]
        public string? MenuCode { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public long ParentId { get; set; }
        /// <summary>
        /// 路由地址(按钮权限没有) 具体前端SPA页面的路由
        /// </summary>
        [Comment("路由地址")]
        public string? RoutePath { get; set; }
        /// <summary>
        /// 权限地址
        /// </summary>
        [Comment("权限地址")]
        public string? MenuPath { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        [Comment("是否隐藏")]
        public bool IsHidden { get; set; } = false;
        /// <summary>
        /// 是否开启新窗口
        /// </summary>
        [Comment("是否开启新窗口")]
        public bool IsOpenWindow { get; set; } = false;
        /// <summary>
        /// 菜单类型
        /// </summary>
        [Comment("菜单类型")]
        public MenuTypeEnum MenuType { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Comment("图标")]
        public string? Icon { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        public string? Remark { get; set; }
    }
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuTypeEnum
    {
        目录,
        页面,
        按钮
    }
}
