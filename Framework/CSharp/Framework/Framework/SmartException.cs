/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 异常
	/// </summary>
	public static class SmartException
	{
		/// <summary>
		/// 转换为Xml
		/// </summary>
		/// <param name="exception">异常</param>
		/// <returns>结果</returns>
		public static string ToXml(Exception exception)
		{
			var exceptionMessage = new XElement("ExceptionMessage",
				                                new XElement("OccurTime") { Value = SmartDateTime.Now },
				                                new XElement("Message") { Value = HttpUtility.HtmlEncode(exception.Message ?? string.Empty) },
				                                new XElement("Source") { Value = HttpUtility.HtmlEncode(exception.Source ?? string.Empty) },
				                                new XElement("StackTrace") { Value = HttpUtility.HtmlEncode(exception.StackTrace ?? string.Empty) });

			var aggregateException = exception.InnerException as AggregateException;

			var innerExceptionMessages = new XElement("InnerExceptionMessages");

			if (aggregateException != null)
			{
				foreach (var oneException in aggregateException.InnerExceptions)
				{
					var InnerExceptionMessage = new XElement("InnerExceptionMessage",
						                                           new XElement("OccurTime") { Value = SmartDateTime.Now },
						                                           new XElement("Message") { Value = HttpUtility.HtmlEncode(oneException.Message ?? string.Empty) },
						                                           new XElement("Source") { Value = HttpUtility.HtmlEncode(oneException.Source ?? string.Empty) },
						                                           new XElement("StackTrace") { Value = HttpUtility.HtmlEncode(oneException.StackTrace ?? string.Empty) });
					innerExceptionMessages.Add(InnerExceptionMessage);
				}
			}
			else
			{
				if (exception.InnerException != null)
				{
					var InnerExceptionMessage = new XElement("InnerExceptionMessage",
						                                           new XElement("OccurTime") { Value = SmartDateTime.Now },
						                                           new XElement("Message") { Value = HttpUtility.HtmlEncode(exception.InnerException.Message ?? string.Empty) },
						                                           new XElement("Source") { Value = HttpUtility.HtmlEncode(exception.InnerException.Source ?? string.Empty) },
						                                           new XElement("StackTrace") { Value = HttpUtility.HtmlEncode(exception.InnerException.StackTrace ?? string.Empty) });
					innerExceptionMessages.Add(InnerExceptionMessage);
				}
			}

			exceptionMessage.Add(innerExceptionMessages);

			return string.Format("<?xml version=\"1.0\" ?> {0}", exceptionMessage.ToString());
		}

		/// <summary>
		/// 转换为Json
		/// </summary>
		/// <param name="exception">异常</param>
		/// <returns>结果</returns>
		public static string ToJson(Exception exception)
		{
			var innerExceptionMessages = new List<object>();

			var exceptionMessage = new
            {
                OccurTime = SmartDateTime.Now,
                Message = HttpUtility.HtmlEncode(exception.Message ?? string.Empty),
                Source = HttpUtility.HtmlEncode(exception.Source ?? string.Empty),
                StackTrace = HttpUtility.HtmlEncode(exception.StackTrace ?? string.Empty),
                InnerExceptionMessages = innerExceptionMessages
            };

			var aggregateException = exception.InnerException as AggregateException;

			if (aggregateException != null)
			{
				foreach (var oneException in aggregateException.InnerExceptions)
				{
					innerExceptionMessages.Add(new
                    {
                        OccurTime = SmartDateTime.Now,
                        Message = HttpUtility.HtmlEncode(oneException.Message ?? string.Empty),
                        Source = HttpUtility.HtmlEncode(oneException.Source ?? string.Empty),
                        StackTrace = HttpUtility.HtmlEncode(oneException.StackTrace ?? string.Empty)
                    });
				}
			}
			else
			{
				if (exception.InnerException != null)
				{
					innerExceptionMessages.Add(new
                    {
                        OccurTime = SmartDateTime.Now,
                        Message = HttpUtility.HtmlEncode(exception.InnerException.Message ?? string.Empty),
                        Source = HttpUtility.HtmlEncode(exception.InnerException.Source ?? string.Empty),
                        StackTrace = HttpUtility.HtmlEncode(exception.InnerException.StackTrace ?? string.Empty)
                    });
				}
			}

			return SmartJson.ToJson(exceptionMessage);
		}

		/// <summary>
		/// 转换为字符串
		/// </summary>
		/// <param name="exception">异常</param>
		/// <returns>结果</returns>
		public static string ToString(Exception exception)
		{
			var exceptionMessage = new StringBuilder();
			exceptionMessage.AppendLine(exception.Message ?? string.Empty);
			exceptionMessage.AppendLine(exception.Source ?? string.Empty);
			exceptionMessage.Append(exception.StackTrace ?? string.Empty);

			var aggregateException = exception.InnerException as AggregateException;

			if (aggregateException != null)
			{
				foreach (var oneException in aggregateException.InnerExceptions)
				{
					exceptionMessage.AppendLine("");
					exceptionMessage.AppendLine(oneException.Message ?? string.Empty);
					exceptionMessage.AppendLine(oneException.Source ?? string.Empty);
					exceptionMessage.Append(oneException.StackTrace ?? string.Empty);
				}
			}
			else
			{
				if (exception.InnerException != null)
				{
					exceptionMessage.AppendLine("");
					exceptionMessage.AppendLine(exception.InnerException.Message ?? string.Empty);
					exceptionMessage.AppendLine(exception.InnerException.Source ?? string.Empty);
					exceptionMessage.Append(exception.InnerException.StackTrace ?? string.Empty);
				}
			}

			return exceptionMessage.ToString();
		}
	}
}
