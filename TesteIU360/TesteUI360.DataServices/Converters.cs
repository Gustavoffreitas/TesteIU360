using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TesteUI360.DataServices
{
	public class Converters
	{
		public Converters()
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
		}

		public static S DoReflection<T, S>(T dataObject, S resultObject) where S : class
		{

			Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

			try
			{
				foreach (PropertyInfo dataInfo in dataObject.GetType().GetProperties())
				{
					if (dataInfo == null ||
						dataInfo.PropertyType.Namespace.Equals("TesteIU360.Model"))
						continue;

					var current_property_name = dataInfo.Name;

					foreach (PropertyInfo resultInfo in resultObject.GetType().GetProperties())
					{
						if (resultInfo.Name.ToLower().Equals(current_property_name.ToLower()))
						{
							try
							{

								var value = dataInfo.GetValue(dataObject, null);

								if (value != null)
								{
									if (value.GetType().Name.Equals("DateTime"))
									{
										resultInfo.SetValue(resultObject, DateTime.Parse(((DateTime)value).ToString("dd/MM/yyyy")));
									}
									else
									{
										resultInfo.SetValue(resultObject, value);
									}
								}

								break;
							}
							catch (Exception err)
							{
								continue;
							}
						}
					}
				}

				return resultObject;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{

			}
		}


		public static List<S> DoReflectionList<T, S>(List<T> dataObject, List<S> resultObject) where S : class
		{
			try
			{

				foreach (PropertyInfo dataInfo in dataObject.GetType().GetProperties())
				{
					if (dataInfo == null ||
						dataInfo.PropertyType.Namespace.Equals("TesteIU360.Model"))
						continue;

					var current_property_name = dataInfo.Name;

					foreach (PropertyInfo resultInfo in resultObject.GetType().GetProperties())
					{
						if (resultInfo.Name.ToLower().Equals(current_property_name.ToLower()))
						{
							try
							{
								resultInfo.SetValue(resultObject, dataInfo.GetValue(dataObject, null));
								break;
							}
							catch
							{
								continue;
							}
						}
					}
				}

				return resultObject;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{

			}
		}
	}
}
