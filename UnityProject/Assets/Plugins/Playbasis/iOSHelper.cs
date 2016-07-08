using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using AOT;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.InternalModel;

namespace Playbasis.Wrapper.Helper {

	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
	public class Helper<T, I>
		where T : new()
	{
		public static void resultCallback(OnResultDelegate userCallback, bool success)
		{
			if (userCallback != null)
			{
				userCallback(success);
			}
		}

		public static void dataResultCallback(OnUserDataResultDelegate<T> userCallback, IntPtr result, int errorCode)
		{
			if (result != IntPtr.Zero)
			{
				if (userCallback != null)
				{
					userCallback(onSuccess_user(result), -1);
				}
			}
			else
			{
				if (userCallback != null)
				{
					userCallback(new T(), errorCode);
				}
			}
		}

		private static T onSuccess_user(IntPtr result)
		{
			I st = (I)Marshal.PtrToStructure(result, typeof(I));
			return Migrator.migrate<T,I>(ref st);
		}
	}

	public class Migrator
	{
		/*
			Migrate data of type I to List<R>.
		*/
		public static List<R> migrateToList<R,I>(IntPtr data, int count)
			where R : new()
		{
			List<R> list = new List<R>();
			
			for (int i=0; i<count; i++)
			{
				IntPtr ptr = (IntPtr)((long)data + Marshal.SizeOf(typeof(I))*i);
				I item = (I)Marshal.PtrToStructure(ptr, typeof(I));
				R cItem = migrate<R,I>(ref item);
				list.Add(cItem);
			}

			return list;
		}

		/*
			Migrate data of type N to R.
		*/
		public static R migrate<R,I>(ref I input)
			where R : new()
		{
			Migrateable<R> mig = input as Migrateable<R>;
			if (mig == null)
			{
				throw new Exception("input data has no migrate ability");
			}

			return (R)(object)mig.migrate();
		}
	}
	#endif
}