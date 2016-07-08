using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _conditionWr : Migrateable<conditionWr>
	{
		public string condition_id {get; set;}
		public string condition_type {get; set;}
		public string condition_value {get; set;}
		public _conditionDataWr condition_data {get; set;}

		public conditionWr Migrate()
		{
			conditionWr newc = new conditionWr();
			newc.conditionId = condition_id;
			newc.conditionType = condition_type;
			newc.conditionValue = condition_value;
			newc.conditionData = condition_data != null ? condition_data.Migrate() : null;
			return newc;
		}
	}

	public class _conditionDataWr : Migrateable<conditionDataWr>
	{
		public string quest_name {get; set;}
		public string description {get; set;}
		public string hint {get; set;}
		public string image {get; set;}

		public conditionDataWr Migrate()
		{
			conditionDataWr newc = new conditionDataWr();
			newc.questName = quest_name;
			newc.description = description;
			newc.hint = hint;
			newc.image = image;
			return newc;
		}
	}

	#endif
}