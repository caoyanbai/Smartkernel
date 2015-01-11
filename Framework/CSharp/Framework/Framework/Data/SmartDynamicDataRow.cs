/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Data;
using System.Dynamic;

namespace Smartkernel.Framework.Data
{
	/// <summary>
	/// DataRow动态类型
	/// </summary>
	public class SmartDynamicDataRow : DynamicObject
	{
		private readonly DataRow dataRow;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dataRow">数据行</param>
		public SmartDynamicDataRow(DataRow dataRow)
		{
			this.dataRow = dataRow;
		}

		/// <summary>
		/// 尝试获取成员的值
		/// </summary>
		/// <param name="binder">绑定器</param>
		/// <param name="result">成员的值</param>
		/// <returns>是否获取成功</returns>
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = null;
			if (dataRow.Table.Columns.Contains(binder.Name))
			{
				result = dataRow[binder.Name];
				return true;
			}
			return false;
		}

		/// <summary>
		/// 尝试设置成员的值
		/// </summary>
		/// <param name="binder">绑定器</param>
		/// <param name="value">成员的值</param>
		/// <returns>是否设置成功</returns>
		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			if (dataRow.Table.Columns.Contains(binder.Name))
			{
				dataRow[binder.Name] = value;
				return true;
			}
			return false;
		}
	}
}
