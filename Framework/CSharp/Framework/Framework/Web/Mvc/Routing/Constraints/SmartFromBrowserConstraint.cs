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
    /// 请求来自浏览器约束，请求必须来自浏览器
    /// </summary>
    public class SmartFromBrowserConstraint : IRouteConstraint
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
            return string.IsNullOrWhiteSpace(httpContext.Request.UserAgent) ? false : true;
        }
        #endregion
    }
}
