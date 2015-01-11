/*
 * ��Ŀ��Smartkernel.Framework
 * ���ߣ����ް�
 * ���䣺caoyanbai@139.com
 */
using System;
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// ��Ϣ��Ļ���
	/// </summary>
	public class SmartInfo
	{
		/// <summary>
		/// ��Ϣ�б�
		/// </summary>
		protected Dictionary<string, string> Infos;

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="infos">��Ϣ�б�</param>
		public SmartInfo(Dictionary<string, string> infos)
		{
			Infos = infos;
		}
	}
}