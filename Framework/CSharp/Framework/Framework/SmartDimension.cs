/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 维度
    /// </summary>
    public static class SmartDimension
    {
        /// <summary>
        /// 获得可能
        /// </summary>
        /// <param name="totalCount">总维度数</param>
        /// <param name="joinCount">参与维度数（几个为true）</param>
        /// <returns>结果</returns>
        public static List<Dictionary<int, bool>> GetPossibly(int totalCount, int joinCount)
        {
            var result = new List<Dictionary<int, bool>>();

            var maxFormat = string.Empty;
            var minFormat = string.Empty;

            for (int i = 0; i < totalCount; i++)
            {
                maxFormat = maxFormat + "1";
                minFormat = minFormat + "0";
            }

            var max = Convert.ToInt32(maxFormat, 2);
            var min = Convert.ToInt32(minFormat, 2);

            var count = 0;

            for (var i = min; i < max; i++)
            {
                count = 0;
                var current = Convert.ToInt32(Convert.ToString(i, 2)).ToString(minFormat);
                var array = current.ToCharArray();
                var item = new Dictionary<int, bool>();

                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == '1')
                    {
                        count++;
                    }
                    item.Add(j, array[j] == '1');
                }
                if (count == joinCount)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
