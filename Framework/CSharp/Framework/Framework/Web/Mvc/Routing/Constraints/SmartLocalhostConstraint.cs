/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Web;
using System.Web.Routing;

namespace Smartkernel.Framework.Web.Mvc.Routing.Constraints
{
    /// <summary>
    /// 本地路由约束（只允许本机访问）
    /// </summary>
    public class SmartLocalhostConstraint : IRouteConstraint
    {
        #region IRouteConstraint Members

        /// <summary>
        /// 是否匹配
        /// </summary>
        /// <param name="httpContext">上下文</param>
        /// <param name="route">路由对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">路由参数</param>
        /// <param name="routeDirection">路由方向</param>
        /// <returns>是否匹配</returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.IsLocal;
        }

        #endregion
    }
}
