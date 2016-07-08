using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _completionWr : Migrateable<completionWr>
	{
		public string completion_op {get; set;}
		public string completion_filter {get; set;}
		public string completion_value {get; set;}
		public string completion_id {get; set;}
		public string completion_type {get; set;}
		public string completion_element_id {get; set;}
		public string completion_title {get; set;}
		public _filteredParamWr filtered_param {get; set;}
		public _completionDataWr completion_data {get; set;}

		public completionWr Migrate()
		{
			completionWr newc = new completionWr();
			newc.completionOp = completion_op;
			newc.completionFilter = completion_filter;
			newc.completionValue = completion_value;
			newc.completionId = completion_id;
			newc.completionType = completion_type;
			newc.completionElementId = completion_element_id;
			newc.completionTitle = completion_title;
			newc.filteredParam = filtered_param.Migrate();
			newc.completionData = completion_data.Migrate();
			return newc;
		}
	}

	public class _filteredParamWr : Migrateable<filteredParamWr>
	{
		public _urlWr url {get; set;}

		public filteredParamWr Migrate()
		{
			filteredParamWr newc = new filteredParamWr();
			newc.url = url.Migrate();
			return newc;
		}
	}

	public class _urlWr : Migrateable<urlWr>
	{
		public string operation {get; set;}
		public string completion_string {get; set;}

		public urlWr Migrate()
		{
			urlWr newc = new urlWr();
			newc.operation = operation;
			newc.completionString = completion_string;
			return newc;
		}
	}

	public class _completionDataWr : Migrateable<completionDataWr>
	{
		public string action_id {get; set;}
		public string name {get; set;}
		public string description {get; set;}
		public string icon {get; set;}
		public string color {get; set;}

		public completionDataWr Migrate()
		{
			completionDataWr newc = new completionDataWr();
			newc.actionId = action_id;
			newc.name = name;
			newc.description = description;
			newc.icon = icon;
			newc.color = color;
			return newc;
		}
	}

	#endif
}