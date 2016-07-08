using UnityEngine;
using System;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

    public class _authWr
    {
        public string token {get; set;}
        public string date_expire {get; set;}
    }

	#endif
}