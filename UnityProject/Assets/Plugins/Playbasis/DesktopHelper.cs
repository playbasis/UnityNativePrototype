using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Model;
using Playbasis.Wrapper.Desktop.Net;
using Newtonsoft.Json;

namespace Playbasis.Wrapper.Desktop.Helper
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	/// <summary>Helper class</summary>
	public class DesktopHelper
	{
		/// <summary>Migrate internal data model from request type to appropriate type in final form</summary>
		/// <typeparam name="T">Type of data response that should be returned</typeparam>
		/// <param name="json">Json string at immediate data level</param>
		/// <returns>T</returns>
		public static R Migrate<R, I>(string json)
			where R : class
		{
			if (json == null)
				return null;

			// convert to json object
			I jsonObj = JsonConvert.DeserializeObject<I>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

			if (jsonObj == null)
				return null;

			// cast to Migrateable and call its Migrate() method to get result migrated data
			Migrateable<R> mig = (Migrateable<R>)jsonObj;
			if (mig != null)
			{
				return mig.Migrate();
			}
			else
				return null;
		}

		/// <summary>Migrate into list from json string</summary>
		/// <typeparam name="R,I">R,I</typeparam>
		/// <param name="json">json</param>
		/// <returns>List<R></returns>
		public static List<R> MigrateList<R,I>(string json)
			where R : class
			where I : class
		{
			if (json == null)
				return null;

			// convert to json object
			List<I> jsonObjList = JsonConvert.DeserializeObject<List<I>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

			if (jsonObjList == null)
				return null;

			return MigrateList<R,I>(jsonObjList);
		}

		/// <summary>Migrate from List (type I) to List (type R)</summary>
		/// <typeparam name="R,I">R,I</typeparam>
		/// <param name="input">List to be migrated</param>
		/// <returns>List<R></returns>
		public static List<R> MigrateList<R,I>(List<I> input)
			where R : class
			where I : class
		{
			List<R> list = new List<R>();

			if (input != null)
			{
				for (int i=0; i<input.Count; i++)
				{
					Migrateable<R> mig = (Migrateable<R>)input[i];
					list.Add(mig.Migrate());
				}
			}

			return list;
		}

		/// <summary>Get elapsed time since 1970, January 1 in seconds</summary>
		/// <returns>Int64</returns>
		public static Int64 GetTime(DateTime datetime)
		{				
			Int64 retval=0;
			var  st=  new DateTime(1970,1,1);
			TimeSpan t= (datetime.ToUniversalTime()-st);
			retval= (Int64)((t.TotalMilliseconds+0.5) / 1000);
			return retval;
		}
	} 

	#endif
}