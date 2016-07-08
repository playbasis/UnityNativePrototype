using UnityEngine;
using System;

namespace Playbasis.Wrapper.Desktop.Model
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _basicResult
	{
		public bool success {get; set;}
		public string error_code {get; set;}
	}

	#endif
}