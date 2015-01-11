/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 电话
	/// </summary>
	public class SmartMobilePhone
	{
		/// <summary>
		/// 所有
		/// </summary>
		public static readonly Dictionary<int, SmartMobilePhone> All = new Dictionary<int, SmartMobilePhone>();

		/// <summary>
		/// 静态构造函数
		/// </summary>
		static SmartMobilePhone()
		{
			using (MemoryStream memoryStream = new MemoryStream(SmartResource.MobilePhone))
			{
				using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
				{
					using (StreamReader streamReader = new StreamReader(gzipStream))
					{
						while (!streamReader.EndOfStream)
						{
							var line = streamReader.ReadLine();
							var fileds = line.Split('^');
							var mobilePhone = new SmartMobilePhone()
							{
								MobilePhone = int.Parse(fileds[0]),
								Country = fileds[1],
								Province = fileds[2],
								City = fileds[3],
								Type = fileds[4]
							};
							All.Add(mobilePhone.MobilePhone, mobilePhone);
						}
					}
				}
			}
		}

		/// <summary>
		/// 电话（前7位）
		/// </summary>
		public int MobilePhone { get; set; }

		/// <summary>
		/// 国家
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// 省份
		/// </summary>
		public string Province { get; set; }

		/// <summary>
		/// 城市
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// 找到电话信息
		/// </summary>
		/// <param name="mobilePhone">电话</param>
		/// <returns>结果</returns>
		public static SmartMobilePhone Find(string mobilePhone)
		{
			try
			{
				return All[int.Parse(mobilePhone.Substring(0, 7))];
			}
			catch
			{
			}
			return null;
		}
	}
}
