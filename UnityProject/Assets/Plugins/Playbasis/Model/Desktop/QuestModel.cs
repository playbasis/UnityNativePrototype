using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _questBasicWr : Migrateable<questBasicWr>
	{
		public string quest_name {get; set;}
		public string description {get; set;}
		public string hint {get; set;}
		public string image {get; set;}
		public bool mission_order {get; set;}
		public bool status {get; set;}
		public string sort_order {get; set;}
		public List<_rewardWr> rewards {get; set;}
		public List<_missionBasicWr> missions {get; set;}
		public DateTime date_added {get; set;}
		public string client_id {get; set;}
		public string site_id {get; set;}
		public List<_conditionWr> condition {get; set;}
		public DateTime date_modified {get; set;}
		public string quest_id {get; set;}

		public questBasicWr Migrate()
		{
			questBasicWr newc = new questBasicWr();
			newc.questName = quest_name;
			newc.description = description;
			newc.hint = hint;
			newc.image = image;
			newc.missionOrder = mission_order;
			newc.status = status;
			// issue #3
			newc.sortOrder = (sort_order == null || sort_order == "") ? 0 : UInt32.Parse(sort_order);
			newc.rewardArray = DesktopHelper.MigrateList<rewardWr, _rewardWr>(rewards);
			newc.missionBasicArray = DesktopHelper.MigrateList<missionBasicWr, _missionBasicWr>(missions);
			newc.dateAdded = DesktopHelper.GetTime(date_added);
			newc.clientId = client_id;
			newc.siteId = site_id;
			newc.conditionArray = DesktopHelper.MigrateList<conditionWr, _conditionWr>(condition);
			newc.dateModified = DesktopHelper.GetTime(date_modified);
			newc.questId = quest_id;
			return newc;
		}
	}

	public class _questInfoWr : _questBasicWr, Migrateable<questInfoWr>
	{
		// don't worry, there're just nothing here :)
		public questInfoWr Migrate()
		{
			questInfoWr newc = new questInfoWr();
			newc.questBasic = base.Migrate();
			return newc;
		}
	}

	public class _missionBasicWr : Migrateable<missionBasicWr>
	{
		public string mission_name {get; set;}
		public string mission_number {get; set;}
		public string description {get; set;}
		public string hint {get; set;}
		public string image {get; set;}
		public List<_completionWr> completion {get; set;}
		public List<_rewardWr> rewards {get; set;}
		public string mission_id {get; set;}

		public missionBasicWr Migrate()
		{
			missionBasicWr newc = new missionBasicWr();
			newc.missionName = mission_name;
			newc.missionNumber = mission_number;
			newc.description = description;
			newc.hint = hint;
			newc.image = image;
			newc.completionArray = DesktopHelper.MigrateList<completionWr, _completionWr>(completion);
			newc.rewardArray = DesktopHelper.MigrateList<rewardWr, _rewardWr>(rewards);
			newc.missionId = mission_id;
			return newc;
		}
	}

	public class _missionInfoWr : _missionBasicWr, Migrateable<missionInfoWr>
	{
		public string quest_id {get; set;}

		public missionInfoWr Migrate()
		{
			missionInfoWr newc = new missionInfoWr();
			newc.missionBasic = base.Migrate();
			newc.questId = quest_id;
			return newc;
		}
	}

	public class _questInfoListWr : Migrateable<questInfoListWr>
	{
		public List<_questBasicWr> quests {get; set;}

		public questInfoListWr Migrate()
		{
			questInfoListWr newc = new questInfoListWr();
			newc.questBasicArray = DesktopHelper.MigrateList<questBasicWr, _questBasicWr>(quests);
			return newc;
		}
	}

	public class _questAvailableForPlayerWr : Migrateable<questAvailableForPlayerWr>
	{
		public string event_type {get; set;}
		public string event_message {get; set;}
		public bool event_status {get; set;}

		public questAvailableForPlayerWr Migrate()
		{
			questAvailableForPlayerWr newc = new questAvailableForPlayerWr();
			newc.eventType = event_type;
			newc.eventMessage = event_message;
			newc.eventStatus = event_status;
			return newc;
		}
	}

	public class _joinQuestWr : Migrateable<joinQuestWr>
	{
		public string event_type {get; set;}
		public string quest_id {get; set;}

		public joinQuestWr Migrate()
		{
			joinQuestWr newc = new joinQuestWr();
			newc.eventType = event_type;
			newc.questId = quest_id;
			return newc;
		}
	}

	public class _cancelQuestWr : Migrateable<cancelQuestWr>
	{
		public string event_type {get; set;}
		public string quest_id {get; set;}

		public cancelQuestWr Migrate()
		{
			cancelQuestWr newc = new cancelQuestWr();
			newc.eventType = event_type;
			newc.questId = quest_id;
			return newc;
		}
	}

	#endif
}