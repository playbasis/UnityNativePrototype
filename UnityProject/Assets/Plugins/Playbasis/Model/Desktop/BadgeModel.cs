using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _badgeWr : Migrateable<badgeWr>
	{
		public string badge_id {get; set;}
		public string image {get; set;}
		public uint sort_order {get; set;}
		public string name {get; set;}
		public string description {get; set;}
		public string hint {get; set;}
		public bool sponsor {get; set;}

		public badgeWr Migrate()
		{
			badgeWr newc = new badgeWr();
			newc.badgeId = badge_id;
			newc.image = image;
			newc.sortOrder = sort_order;
			newc.description_ = description;
			newc.hint = hint;
			newc.sponsor = sponsor;
			return newc;
		}
	}

	public class _badgesWr : Migrateable<badgesWr>
	{
		public List<_badgeWr> badges;

		public badgesWr Migrate()
		{
			badgesWr newc = new badgesWr();
				newc.badgeArray = DesktopHelper.MigrateList<badgeWr, _badgeWr>(badges);
			return newc;
		}
	}

	#endif
}