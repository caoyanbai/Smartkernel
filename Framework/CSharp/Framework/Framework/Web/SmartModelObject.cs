/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// 模型数据
    /// </summary>
    public class SmartModelObject
    {
        /// <summary>
        /// 将对象转换为模型数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static ExpandoObject ToModelObject(object obj)
        {
            IDictionary<string, object> dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(obj);
            IDictionary<string, object> expandoObject = new ExpandoObject();
            foreach (var item in dictionary)
            {
                expandoObject.Add(item);
            }
            return (ExpandoObject)expandoObject;
        }
    }
}
