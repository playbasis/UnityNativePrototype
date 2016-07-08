using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _rewardWr : Migrateable<rewardWr>
	{
		public string reward_value {get; set;}
		public string reward_type {get; set;}
		public string reward_id {get; set;}
		public _rewardData_subWr reward_data {get; set;}

		public rewardWr Migrate()
		{
			rewardWr newc = new rewardWr();
			newc.rewardValue = reward_value;
			newc.rewardType = reward_type;
			newc.rewardId = reward_id;
			newc.rewardName = reward_data.name;
			return newc;
		}
	}

	public class _rewardData_subWr
	{
		public string name {get; set;}
	}

	#endif
}