/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.Xml
{
    /// <summary>
    /// XML文件中节点与实体对象字段或属性的映射标识类
    /// </summary>
    [SerializableAttribute]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class SmartNodeMappingAttribute : Attribute
    {
        private readonly string nodeName;

        /// <summary>
        /// 映射到XML文件中的节点，不区分大小写
        /// </summary>
        public string NodeName { get { return nodeName; } }

        private object defaultValue;

        /// <summary>
        /// 如果XML文件中没有对应的值时，所赋给实体字段或属性的默认值，如果没有设置默认值，则取字段或属性初始化时的默认值
        /// </summary>
        public object DefaultValue { get { return defaultValue; } set { defaultValue = value; } }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nodeName">映射到XML文件中的节点，不区分大小写</param>
        public SmartNodeMappingAttribute(string nodeName)
        {
            this.nodeName = nodeName;
        }
    }
}