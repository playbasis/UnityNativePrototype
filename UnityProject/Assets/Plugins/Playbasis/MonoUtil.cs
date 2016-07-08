using UnityEngine;
using System;
using Playbasis.Wrapper;

namespace Playbasis.Wrapper.Mono
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	/// <summary>Mono utility class</summary>
	public class MonoUtil
	{
		/// <summary>Get mono behavior object</summary>
		/// <returns>MonoBehavior</returns>
		public static MonoBehaviour GetMainObj()
		{
			return PlaybasisWrapper.Instance;
		}
	}

	#endif
}