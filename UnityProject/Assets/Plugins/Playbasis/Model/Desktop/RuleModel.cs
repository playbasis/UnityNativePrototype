using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _ruleWr : Migrateable<ruleWr>
	{
		public List<_ruleEventWr> events {get; set;}
		public List<_ruleEventMissionWr> events_missions {get; set;}
		public List<_ruleEventQuestWr> events_quests {get; set;}

		public ruleWr Migrate()
		{
			ruleWr newc = new ruleWr();
			newc.ruleEventArray = DesktopHelper.MigrateList<ruleEventWr, _ruleEventWr>(events);
			newc.ruleEventMissionArray = DesktopHelper.MigrateList<ruleEventMissionWr, _ruleEventMissionWr>(events_missions);
			newc.ruleEventQuestArray = DesktopHelper.MigrateList<ruleEventQuestWr, _ruleEventQuestWr>(events_quests);
			return newc;
		}
	}

	public class _ruleEventWr : Migrateable<ruleEventWr>
	{
		public string event_type {get; set;}
		public string reward_type {get; set;}
		public string value {get; set;}
		public _ruleEventSharedRewardDataWr reward_data {get; set;}

		public ruleEventWr Migrate()
		{
			ruleEventWr newc = new ruleEventWr();
			newc.eventType = event_type;
			newc.rewardType = reward_type;
			newc.value = value;

			// migrate to appropriate reward data
			if (reward_type == "badge")
			{
				newc.badgeData = reward_data.MigrateToBadgeData();
			}
			else if (reward_type == "goods")
			{
				newc.goodsData = reward_data.MigrateToGoodsData();
			}
			return newc;
		}
	}

	public class _ruleEventSharedRewardDataWr
	{
		// common
		public string image {get; set;}
		public string name {get; set;}
		public string description {get; set;}

		// for badge
		public string badge_id {get; set;}
		public string hint {get; set;}

		// for goods
		public string goods_id {get; set;}
		public uint per_user {get; set;}
		public string code {get; set;}

		public ruleEventBadgeRewardDataWr MigrateToBadgeData()
		{
			ruleEventBadgeRewardDataWr newc = new ruleEventBadgeRewardDataWr();
			newc.badgeId = badge_id;
			newc.image = image;
			newc.name = name;
			newc.description_ = description;
			newc.hint = hint;
			return newc;
		}

		public ruleEventGoodsRewardDataWr MigrateToGoodsData()
		{
			ruleEventGoodsRewardDataWr newc = new ruleEventGoodsRewardDataWr();
			newc.goodsId = goods_id;
			newc.image = image;
			newc.name = name;
			newc.description_ = description;
			newc.perUser = per_user;
			newc.code = code;
			return newc;
		}
	}

	public class _ruleEventMissionWr : Migrateable<ruleEventMissionWr>
	{
		public List<_ruleEventWr> events {get; set;}
		public string mission_id {get; set;}
		public string mission_number {get; set;}
		public string mission_name {get; set;}
		public string description {get; set;}
		public string hint {get; set;}
		public string image {get; set;}
		public string quest_id {get; set;}

		public ruleEventMissionWr Migrate()
		{
			ruleEventMissionWr newc = new ruleEventMissionWr();
			newc.eventArray = DesktopHelper.MigrateList<ruleEventWr, _ruleEventWr>(events);
			newc.missionId = mission_id;
			newc.missionNumber = mission_number;
			newc.missionName = mission_name;
			newc.description_ = description;
			newc.hint = hint;
			newc.image = image;
			newc.questId = quest_id;
			return newc;
		}
	}

	public class _ruleEventQuestWr : Migrateable<ruleEventQuestWr>
	{
		public List<_ruleEventWr> events {get; set;}
		public string quest_id;
		public string quest_name;
		public string description;
		public string hint;
		public string image;

		public ruleEventQuestWr Migrate()
		{
			ruleEventQuestWr newc = new ruleEventQuestWr();
			newc.eventArray = DesktopHelper.MigrateList<ruleEventWr, _ruleEventWr>(events);
			newc.questId = quest_id;
			newc.questName = quest_name;
			newc.description_ = description;
			newc.hint = hint;
			newc.image = image;
			return newc;
		}
	}

	#endif
}