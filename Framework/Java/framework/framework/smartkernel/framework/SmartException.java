/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.io.*;

import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;
import javax.xml.parsers.*;

import org.w3c.dom.*;

import smartkernel.framework.computer.*;
import smartkernel.framework.web.*;

/**
 * 异常
 * 
 */
public class SmartException {
	/**
	 * 转换为Xml
	 * 
	 * @param exception
	 *            ，异常
	 * @return，结果
	 */
	public static String toXml(Throwable exception) {
		try {
			Document document = DocumentBuilderFactory.newInstance()
					.newDocumentBuilder().newDocument();
			Element root = document.createElement("ExceptionMessage");
			{
				Element element = document.createElement("OccurTime");
				element.appendChild(document.createTextNode(SmartDateTime.now()));
				root.appendChild(element);
			}
			{
				Element element = document.createElement("Message");
				element.appendChild(document.createTextNode(SmartHttpUtility
						.htmlEncode(exception.getMessage())));
				root.appendChild(element);
			}
			{
				Element element = document.createElement("Source");
				element.appendChild(document.createTextNode(""));
				root.appendChild(element);
			}
			{
				StringBuilder sb = new StringBuilder();
				StackTraceElement[] elements = exception.getStackTrace();
				for (StackTraceElement element : elements) {
					sb.append(element.toString() + SmartComputer.LineSeparator);
				}

				Element element = document.createElement("StackTrace");
				element.appendChild(document.createTextNode(SmartHttpUtility
						.htmlEncode(sb.toString())));
				root.appendChild(element);
			}

			Throwable innerException = exception.getCause();

			if (innerException != null) {
				Element innerRoot = document
						.createElement("InnerExceptionMessage");

				{
					Element element = document.createElement("OccurTime");
					element.appendChild(document.createTextNode(SmartDateTime
							.now()));
					innerRoot.appendChild(element);
				}
				{
					Element element = document.createElement("Message");
					element.appendChild(document
							.createTextNode(SmartHttpUtility
									.htmlEncode(exception.getMessage())));
					innerRoot.appendChild(element);
				}
				{
					Element element = document.createElement("Source");
					element.appendChild(document.createTextNode(""));
					innerRoot.appendChild(element);
				}
				{
					StringBuilder sb = new StringBuilder();
					StackTraceElement[] elements = exception.getStackTrace();
					for (StackTraceElement element : elements) {
						sb.append(element.toString()
								+ SmartComputer.LineSeparator);
					}

					Element element = document.createElement("StackTrace");
					element.appendChild(document
							.createTextNode(SmartHttpUtility.htmlEncode(sb
									.toString())));
					innerRoot.appendChild(element);
				}

				root.appendChild(innerRoot);
			}

			document.appendChild(root);

			TransformerFactory tf = TransformerFactory.newInstance();
			Transformer transformer = tf.newTransformer();
			transformer.setOutputProperty(OutputKeys.OMIT_XML_DECLARATION,
					"yes");
			StringWriter writer = new StringWriter();
			transformer.transform(new DOMSource(document), new StreamResult(
					writer));
			return String.format("<?xml version=\"1.0\" ?> %s", writer
					.getBuffer().toString());
		} catch (Exception err) {
			throw new RuntimeException(err);
		}

	}

	/**
	 * 异常Json对象
	 * 
	 */
	public static class SmartExceptionJson {
		private String occurTime;
		private String message;
		private String source;
		private String stackTrace;
		private SmartExceptionJson innerExceptionJson;

		/**
		 * 获取发生时间
		 * 
		 * @return，结果
		 */
		public String getOccurTime() {
			return occurTime;
		}

		/**
		 * 设置发生时间
		 * 
		 * @param occurTime
		 *            ，发生时间
		 */
		public void setOccurTime(String occurTime) {
			this.occurTime = occurTime;
		}

		/**
		 * 获取消息
		 * 
		 * @return，结果
		 */
		public String getMessage() {
			return message;
		}

		/**
		 * 设置消息
		 * 
		 * @param message
		 *            ，消息
		 */
		public void setMessage(String message) {
			this.message = message;
		}

		/**
		 * 获取源
		 * 
		 * @return，结果
		 */
		public String getSource() {
			return source;
		}

		/**
		 * 设置源
		 * 
		 * @param source
		 *            ，源
		 */
		public void setSource(String source) {
			this.source = source;
		}

		/**
		 * 获取堆栈信息
		 * 
		 * @return，结果
		 */
		public String getStackTrace() {
			return stackTrace;
		}

		/**
		 * 设置堆栈信息
		 * 
		 * @param stackTrace
		 *            ，堆栈信息
		 */
		public void setStackTrace(String stackTrace) {
			this.stackTrace = stackTrace;
		}

		/**
		 * 获取内部异常
		 * 
		 * @return，结果
		 */
		public SmartExceptionJson getInnerExceptionJson() {
			return innerExceptionJson;
		}

		/**
		 * 设置内部异常
		 * 
		 * @param innerExceptionJson
		 *            ，内部异常
		 */
		public void setInnerExceptionJson(SmartExceptionJson innerExceptionJson) {
			this.innerExceptionJson = innerExceptionJson;
		}
	}

	/**
	 * 转换为Json
	 * 
	 * @param exception
	 *            ，异常
	 * @return，结果
	 */
	public static String toJson(Throwable exception) {
		SmartExceptionJson exceptionJson = new SmartExceptionJson();
		exceptionJson.setMessage(SmartHttpUtility.htmlEncode(exception
				.getMessage()));
		exceptionJson.setOccurTime(SmartDateTime.now());
		exceptionJson.setSource("");
		{
			StringBuilder sb = new StringBuilder();
			StackTraceElement[] elements = exception.getStackTrace();
			for (StackTraceElement element : elements) {
				sb.append(element.toString() + SmartComputer.LineSeparator);
			}

			exceptionJson.setStackTrace(SmartHttpUtility.htmlEncode(sb
					.toString()));
		}

		Throwable innerException = exception.getCause();

		if (innerException != null) {
			SmartExceptionJson innerExceptionJson = new SmartExceptionJson();
			innerExceptionJson.setMessage(SmartHttpUtility
					.htmlEncode(innerException.getMessage()));
			innerExceptionJson.setOccurTime(SmartDateTime.now());
			innerExceptionJson.setSource("");
			{
				StringBuilder sb = new StringBuilder();
				StackTraceElement[] elements = innerException.getStackTrace();
				for (StackTraceElement element : elements) {
					sb.append(element.toString() + SmartComputer.LineSeparator);
				}

				innerExceptionJson.setStackTrace(SmartHttpUtility.htmlEncode(sb
						.toString()));
			}
			exceptionJson.setInnerExceptionJson(innerExceptionJson);
		}

		return SmartJson.toJson(exceptionJson);
	}

	/**
	 * 转换为字符串
	 * 
	 * @param exception
	 *            ，异常
	 * @return，结果
	 */
	public static String toString(Throwable exception) {
		StringBuilder exceptionMessage = new StringBuilder();
		exceptionMessage.append(exception.getMessage()
				+ SmartComputer.LineSeparator);

		{
			StringBuilder sb = new StringBuilder();
			StackTraceElement[] elements = exception.getStackTrace();
			for (StackTraceElement element : elements) {
				sb.append(element.toString() + SmartComputer.LineSeparator);
			}

			exceptionMessage.append(sb.toString());
		}

		Throwable innerException = exception.getCause();

		if (innerException != null) {
			exceptionMessage.append(SmartComputer.LineSeparator);

			{
				exceptionMessage.append(innerException.getMessage()
						+ SmartComputer.LineSeparator);

				StringBuilder sb = new StringBuilder();
				StackTraceElement[] elements = innerException.getStackTrace();
				for (StackTraceElement element : elements) {
					sb.append(element.toString() + SmartComputer.LineSeparator);
				}

				exceptionMessage.append(sb.toString());
			}
		}

		return exceptionMessage.toString();
	}
}
