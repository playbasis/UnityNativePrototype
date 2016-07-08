using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper.Android
{
	public partial class AndroidPopulator {

		#if UNITY_ANDROID

		public static playerBasicWr PopulatePlayerBasic(AndroidJavaObject result)
		{
			if (result == null) return null;

			playerBasicWr data = new playerBasicWr();

			data.image = GetValue<string>("getImage", result);
			data.userName = GetValue<string>("getUsername", result);
			data.exp = (uint)GetValue<int>("getExp", result);
			data.level = (uint)GetValue<int>("getLevel", result);
			data.firstName = GetValue<string>("getFirstName", result);
			data.lastName = GetValue<string>("getLastName", result);

			AndroidJavaObject genderObj = GetAJO("getGender", result);
			data.gender = (uint)GetValue<int>("getGender", genderObj);

			data.clPlayerId = GetValue<string>("getClPlayerId", result);

			return data;
		}

		/*
			Populate playerPublic from AndroidJavaObject.
		*/
		public static playerPublicWr PopulatePlayerPublic(AndroidJavaObject result)
		{
			if (result == null) return null;

			playerPublicWr data = new playerPublicWr();

			data.basic = PopulatePlayerBasic(result);
			data.registered = GetTime("getDateRegistered", result);
			data.lastLogin = GetTime("getDateLastLogin", result);
			data.lastLogout = GetTime("getDateLastLogout", result);

			return data;
		}

		/*
			Populate detailed player info.
		*/
		public static playerWr PopulatePlayer(AndroidJavaObject result)
		{
			if (result == null) return null;

			playerWr data = new playerWr();

			data.playerPublic = PopulatePlayerPublic(result);
			data.email = GetValue<string>("getEmail", result);
			data.phoneNumber = GetValue<string>("getPhoneNumber", result);

			return data;
		}

		/*
			Populate point
		*/
		public static pointWr PopulatePoint(AndroidJavaObject result)
		{
			if (result == null) return null;

			pointWr data = new pointWr();

			data.rewardId = GetValue<string>("getRewardId", result);
			data.rewardName = GetValue<string>("getRewardName", result);
			data.value = (uint)GetValue<int>("getValue", result);

			return data;
		}

		/*
			Populate specified point name of player.
		*/
		public static pointRWr PopulatePointOfPlayer(AndroidJavaObject result)
		{
			if (result == null) return null;

			pointRWr data = new pointRWr();

			data.pointArray = PopulateArrayData<pointWr>(result);

			return data;
		}

		public static ruleEventWr PopulateRuleEvent(AndroidJavaObject result)
		{
			if (result == null) return null;

			ruleEventWr data = new ruleEventWr();

			data.eventType = GetValue<string>("getType", result);
			data.rewardType = GetValue<string>("getRewardType", result);
			data.value = GetValue<string>("getValue", result);

			// get specific rewardData according to rewardType
			if (data.rewardType == "badge")
			{
				data.badgeData = PopulateRuleEventBadgeRewardData(result.Call<AndroidJavaObject>("getBadgeData"));
			}
			else if (data.rewardType == "goods")
			{
				data.goodsData = PopulateRuleEventGoodsRewardData(result.Call<AndroidJavaObject>("getGood"));
			}

			return data;
		}

		public static ruleEventMissionWr PopulateRuleEventMission(AndroidJavaObject result)
		{
			if (result == null) return null;

			ruleEventMissionWr data = new ruleEventMissionWr();

			data.eventArray = PopulateArrayData<ruleEventWr>(GetAJO("getEvents", result));
			data.missionId = GetValue<string>("getMissionId", result);
			data.missionNumber = GetValue<string>("getMissionNumber", result);
			data.missionName = GetValue<string>("getMissionName", result);
			data.description_ = GetValue<string>("getDescrition", result);
			data.hint = GetValue<string>("getHint", result);
			data.image = GetValue<string>("getImage", result);
			data.questId = GetValue<string>("getQuestId", result);
			// TODO: Add missing questId in SDK
			 
			return data;
		}

		public static ruleEventQuestWr PopulateRuleEventQuest(AndroidJavaObject result)
		{
			if (result == null) return null;

			ruleEventQuestWr data = new ruleEventQuestWr();

			// TODO: Add missing eventArray in ruleEventQuestWr
			data.questId = GetValue<string>("getQuestId", result);
			data.questName = GetValue<string>("getQuestName", result);
			data.description_ = GetValue<string>("getDescrition", result);
			data.hint = GetValue<string>("getHint", result);
			data.image = GetValue<string>("getImage", result);

			return data;
		}

		public static ruleEventBadgeRewardDataWr PopulateRuleEventBadgeRewardData(AndroidJavaObject result)
		{
			if (result == null) return null;

			ruleEventBadgeRewardDataWr data = new ruleEventBadgeRewardDataWr();

			data.badgeId = GetValue<string>("getBadgeId", result);
			data.image = GetValue<string>("getImage", result);
			data.name = GetValue<string>("getName", result);
			data.description_ = GetValue<string>("getDescription", result);
			data.hint = GetValue<string>("getHint", result);
			// ignore sponsor, claim, and redeem field
			 
			return data;
		}

		public static ruleEventGoodsRewardDataWr PopulateRuleEventGoodsRewardData(AndroidJavaObject result)
		{
			if (result == null) return null;

			ruleEventGoodsRewardDataWr data = new ruleEventGoodsRewardDataWr();

			data.goodsId = GetValue<string>("getGoodsId", result);
			data.image = GetValue<string>("getImage", result);
			data.name = GetValue<string>("getName", result);
			data.description_ = GetValue<string>("getDescription", result);
			data.perUser = (uint)GetValue<int>("getPerUser", result);
			data.code = GetValue<string>("getCode", result);

			return data;
		}

		public static customWr PopulateCustom(AndroidJavaObject result)
		{
			if (result == null) return null;

			customWr data = new customWr();

			data.customId = GetValue<string>("getCustomId", result);
			data.customName = GetValue<string>("getCustomName", result);
			data.customValue = GetValue<string>("getCustomValue", result);

			return data;
		}

		public static badgeWr PopulateBadge(AndroidJavaObject result)
		{
			if (result == null) return null;

			badgeWr data = new badgeWr();

			data.badgeId = GetValue<string>("getBadgeId", result);
			data.image = GetValue<string>("getImage", result);
			data.sortOrder = (uint)GetValue<int>("getShortOrder", result);
			data.name = GetValue<string>("getName", result);
			data.description_ = GetValue<string>("getDescription", result);
			data.hint = GetValue<string>("getHint", result);
			data.sponsor = GetValue<bool>("getSponsor", result);

			return data;
		}

		public static goodsWr PopulateGoods(AndroidJavaObject result)
		{
			if (result == null) return null;

			goodsWr data = new goodsWr();

			data.goodsId = GetValue<string>("getGoodsId", result);
			data.quantity = (uint)GetValue<int>("getQuantity", result);
			data.image = GetValue<string>("getImage", result);
			data.sortOrder = (uint)GetValue<int>("getSortOrder", result);
			data.name = GetValue<string>("getName", result);
			data.description_ = GetValue<string>("getDescription", result);
			data.redeem = PopulateRedeem(GetAJO("getRedeem", result));
			data.code = GetValue<string>("getCode", result);
			data.sponsor = GetValue<bool>("getSponsor", result);
			data.dateStart = GetTime("getDateDateStart", result);
			data.dateExpire = GetTime("getDateDateExpire", result);

			return data;
		}

		public static goodsInfoWr PopulateGoodsInfo(AndroidJavaObject result)
		{
			if (result == null) return null;

			goodsInfoWr data = new goodsInfoWr();

			data.goods = PopulateGoods(result);
			// TODO: add missing 'amount' field as not available in SDK
			data.perUser = (uint)GetValue<int>("getPerUser", result);
			data.isGroup = GetValue<bool>("getIsGroup", result);

			return data;
		}

		public static goodsInfoListWr PopulateGoodsInfoList(AndroidJavaObject result)
		{
			if (result == null) return null;

			goodsInfoListWr data = new goodsInfoListWr();

			data.goodsInfoArray = PopulateArrayData<goodsInfoWr>(result);

			return data;
		}

		public static redeemBadgeWr PopulateRedeemBadge(AndroidJavaObject result)
		{
			if (result == null) return null;

			redeemBadgeWr data = new redeemBadgeWr();

			data.badgeId = GetValue<string>("getBadgeId", result);
			data.badgeValue = (uint)GetValue<int>("getValue", result);

			return data;
		}

		public static redeemWr PopulateRedeem(AndroidJavaObject result)
		{
			if (result == null) return null;

			redeemWr data = new redeemWr();

			// get point value
			AndroidJavaObject javaObj = GetAJO("getPoint", result);
			data.pointValue = (uint)GetValue<int>("getValue", javaObj);

			// get customArray
			javaObj = GetAJO("getCustomPoints", result);
			data.customArray = PopulateArrayData<customWr>(javaObj);

			// get redeemBadgeArray
			javaObj = GetAJO("getBadge", result);
			data.redeemBadgeArray = PopulateArrayData<redeemBadgeWr>(javaObj);

			return data;
		}

		public static quizBasicWr PopulateQuizBasic(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizBasicWr data = new quizBasicWr();

			data.name = GetValue<string>("getName", result);
			data.image = GetValue<string>("getImage", result);
			data.weight = Int32.Parse(GetValue<string>("getWeight", result));
			data.description_ = GetValue<string>("getDescription", result);
			data.descriptionImage = GetValue<string>("getDescriptionImage", result);
			data.quizId = GetValue<string>("getQuizId", result);

			return data;
		}

		public static gradeRewardCustomWr PopulateGradeRewardCustom(AndroidJavaObject result)
		{
			if (result == null) return null;

			gradeRewardCustomWr data = new gradeRewardCustomWr();

			data.customId = GetValue<string>("getCustomId", result);
			data.customValue = GetValue<string>("getCustomValue", result);

			return data;
		}

		public static gradeRewardsWr PopulateGradeRewards(AndroidJavaObject result)
		{
			if (result == null) return null;

			gradeRewardsWr data = new gradeRewardsWr();

			// get Exp object
			AndroidJavaObject expJavaObj = GetAJO("getExp", result);
			data.expValue = GetValue<string>("getValue", expJavaObj);

			// get Point object
			AndroidJavaObject pointJavaObj = GetAJO("getPoint", result);
			data.pointValue = GetValue<string>("getValue", pointJavaObj);

			// ignore gradeRewardCustomArrayWr

			return data;
		}

		public static gradeWr PopulateGrade(AndroidJavaObject result)
		{
			if (result == null) return null;

			gradeWr data = new gradeWr();

			data.gradeId = GetValue<string>("getGradeId", result);
			data.start = GetValue<string>("getStart", result);
			data.end = GetValue<string>("getEnd", result);
			data.grade = GetValue<string>("getGrade", result);
			data.rank = GetValue<string>("getRank", result);
			data.rankImage = GetValue<string>("getRankImage", result);

			return data;
		}

		public static quizWr PopulateQuiz(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizWr data = new quizWr();

			data.basic = PopulateQuizBasic(result);
			data.dateStart = GetTime("getDateDateStart", result);
			data.dateExpire = GetTime("getDateDateExpire", result);
			data.status = GetValue<bool>("getStatus", result);

			// get Grades object to pass and populate data
			AndroidJavaObject gradesJavaObject = GetAJO("getGrades", result);
			data.gradeArray = PopulateArrayData<gradeWr>(gradesJavaObject);

			data.deleted = GetValue<bool>("getDeleted", result);
			data.totalMaxScore = (uint)GetValue<int>("getTotalMaxScore", result);
			data.totalQuestion = (uint)GetValue<int>("getTotalQuestions", result);

			return data;
		}

		public static quizListWr PopulateQuizList(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizListWr data = new quizListWr();

			data.quizBasicArray = PopulateArrayData<quizBasicWr>(result);

			return data;
		}

		public static questionWr PopulateQuestion(AndroidJavaObject result)
		{
			if (result == null) return null;

			questionWr data = new questionWr();

			data.question = GetValue<string>("getQuestion", result);
			data.questionImage = GetValue<string>("getQuestionImage", result);
			data.optionArray = PopulateArrayData<questionOptionWr>(GetAJO("getOptions", result));
			data.index = (uint)GetValue<int>("getIndex", result);
			data.total = (uint)GetValue<int>("getTotal", result);
			data.questionId = GetValue<string>("getQuestionId", result);

			return data;
		}

		public static questionOptionWr PopulateQuestionOption(AndroidJavaObject result)
		{
			if (result == null) return null;

			questionOptionWr data = new questionOptionWr();

			data.option = GetValue<string>("getOption", result);
			data.optionImage = GetValue<string>("getOptionImage", result);
			data.optionId = GetValue<string>("getOptionId", result);

			return data;
		}

		public static questionAnsweredOptionWr PopulateQuestionAnsweredOption(AndroidJavaObject result)
		{
			if (result == null) return null;

			questionAnsweredOptionWr data = new questionAnsweredOptionWr();

			data.option = GetValue<string>("getOption", result);
			data.score = GetValue<string>("getScore", result);
			data.explanation = GetValue<string>("getExplanation", result);
			data.optionImage = GetValue<string>("getOptionImage", result);
			data.optionId = GetValue<string>("getOptionId", result);

			return data;
		}

		public static questionAnsweredGradeDoneWr PopulateQuestionAnsweredGradeDone(AndroidJavaObject result)
		{
			if (result == null) return null;

			questionAnsweredGradeDoneWr data = new questionAnsweredGradeDoneWr();

			data.gradeId = GetValue<string>("getGradeId", result);
			data.start = GetValue<string>("getStart", result);
			data.end = GetValue<string>("getEnd", result);
			data.grade = GetValue<string>("getGrade", result);
			data.rank = GetValue<string>("getRank", result);
			data.rankImage = GetValue<string>("getRankImage", result);
			data.score = (uint)GetValue<int>("getScore", result);
			data.maxScore = GetValue<string>("getMaxScore", result);
			data.totalScore = (uint)GetValue<int>("getTotalScore", result);
			data.totalMaxScore = (uint)GetValue<int>("getTotalMaxScore", result);

			return data;
		}

		public static gradeDoneRewardWr PopulateGradeDoneReward(AndroidJavaObject result)
		{
			if (result == null) return null;

			gradeDoneRewardWr data = new gradeDoneRewardWr();

			// android sdk doesn't have eventType field, so we manually set it
			data.eventType = "REWARD_RECEIVED";
			data.rewardType = GetValue<string>("getRewardType", result);
			data.rewardId = GetValue<string>("getRewardId", result);
			data.value = GetValue<string>("getRewardValue", result);

			return data;
		}

		public static questionAnsweredWr PopulateQuestionAnswered(AndroidJavaObject result)
		{
			if (result == null) return null;

			questionAnsweredWr data = new questionAnsweredWr();

			data.optionArray = PopulateArrayData<questionAnsweredOptionWr>(GetAJO("getOptions", result));
			data.score = (uint)GetValue<int>("getScore", result);
			data.maxScore = GetValue<string>("getMaxScore", result);
			data.explanation = GetValue<string>("getExplanation", result);
			data.totalScore = (uint)GetValue<int>("getTotalScore", result);
			data.totalMaxScore = (uint)GetValue<int>("getTotalMaxScore", result);
			data.gradeDone = PopulateQuestionAnsweredGradeDone(GetAJO("getGrade", result));
			data.gradeDoneRewardArray = PopulateArrayData<gradeDoneRewardWr>(GetAJO("getRewards", result));

			return data;
		}

		public static quizPendingGradeRewardWr PopulateQuizPendingGradeReward(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizPendingGradeRewardWr data = new quizPendingGradeRewardWr();

			// android sdk doesn't have eventType field, so we manually set it
			data.eventType = "REWARD_RECEIVED";
			data.rewardType = GetValue<string>("getRewardType", result);
			data.rewardId = GetValue<string>("getRewardId", result);
			data.value = GetValue<string>("getRewardValue", result);

			return data;
		}

		public static quizPendingGradeWr PopulateQuizPendingGrade(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizPendingGradeWr data = new quizPendingGradeWr();

			data.score = (uint)GetValue<int>("getScore", result);
			data.quizPendingGradeRewardArray = PopulateArrayData<quizPendingGradeRewardWr>(GetAJO("getRewards", result));
			data.maxScore = GetValue<string>("getMaxScore", result);
			data.totalScore = (uint)GetValue<int>("getTotalScore", result);
			data.totalMaxScore = (uint)GetValue<int>("getTotalMaxScore", result);

			return data;
		}

		public static quizPendingWr PopulateQuizPending(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizPendingWr data = new quizPendingWr();

			data.value = (uint)GetValue<int>("getValue", result);
			data.grade = PopulateQuizPendingGrade(GetAJO("getGrade", result));
			data.totalCompletedQuestions = (uint)GetValue<int>("getTotalCompletedQuestions", result);
			data.totalPendingQuestions = (uint)GetValue<int>("getTotalPendingQuestions", result);
			data.quizId = GetValue<string>("getQuizId", result);

			return data;
		}

		public static gradeDoneWr PopulateGradeDone(AndroidJavaObject result)
		{
			if (result == null) return null;

			gradeDoneWr data = new gradeDoneWr();

			data.gradeId = GetValue<string>("getGradeId", result);
			data.start = GetValue<string>("getStart", result);
			data.end = GetValue<string>("getEnd", result);
			data.grade = GetValue<string>("getGrade", result);
			data.rank = GetValue<string>("getRank", result);
			data.rankImage = GetValue<string>("getRankImage", result);
			data.rewardArray = PopulateArrayData<gradeDoneRewardWr>(GetAJO("getRewards", result));
			data.score = (uint)GetValue<int>("getScore", result);
			data.maxScore = GetValue<string>("getMaxScore", result);
			data.totalScore = (uint)GetValue<int>("getTotalScore", result);
			data.totalMaxScore = (uint)GetValue<int>("getTotalMaxScore", result);

			return data;
		}

		public static quizDoneWr PopulateQuizDone(AndroidJavaObject result)
		{
			if (result == null) return null;

			quizDoneWr data = new quizDoneWr();

			data.value = (uint)GetValue<int>("getValue", result);
			data.gradeDone = PopulateGradeDone(GetAJO("getGrade", result));
			data.totalCompletedQuestions = (uint)GetValue<int>("getTotalCompletedQuestions", result);
			data.quizId = GetValue<string>("getQuizId", result);

			return data;
		}

		/*
			Populate rule.
		*/
		public static ruleWr PopulateRule(AndroidJavaObject result)
		{
			if (result == null) return null;

			ruleWr data = new ruleWr();

			data.ruleEventArray = PopulateArrayData<ruleEventWr>(GetAJO("getEvents", result));
			data.ruleEventMissionArray = PopulateArrayData<ruleEventMissionWr>(GetAJO("getMissions", result));
			data.ruleEventQuestArray = PopulateArrayData<ruleEventQuestWr>(GetAJO("getQuests", result));

			return data;
		}

		public static badgesWr PopulateBadges(AndroidJavaObject result)
		{
			if (result == null) return null;

			badgesWr data = new badgesWr();

			data.badgeArray = PopulateArrayData<badgeWr>(result);

			return data;
		}

		public static rewardWr PopulateReward(AndroidJavaObject result)
		{
			if (result == null) return null;

			rewardWr data = new rewardWr();

			data.rewardValue = GetValue<string>("getRewardValue", result);
			data.rewardType = GetValue<string>("getRewardType", result);
			data.rewardId = GetValue<string>("getRewardId", result);
			// TODO: add missing 'rewardName' from reward object in sdk

			return data;
		}

		public static filteredParamWr PopulateFilteredParam(AndroidJavaObject result)
		{
			if (result == null) return null;

			filteredParamWr data = new filteredParamWr();

			data.url = PopulateUrl(GetAJO("getUrl", result));

			return data;
		}

		public static urlWr PopulateUrl(AndroidJavaObject result)
		{
			if (result == null) return null;

			urlWr data = new urlWr();

			data.operation = GetValue<string>("getOperation", result);
			data.completionString = GetValue<string>("getCompletionString", result);

			return data;
		}

		public static completionWr PopulateCompletion(AndroidJavaObject result)
		{
			if (result == null) return null;

			completionWr data = new completionWr();

			data.completionOp = GetValue<string>("", result);

			return data;
		}

		public static missionBasicWr PopulateMissionBasic(AndroidJavaObject result)
		{
			if (result == null) return null;

			missionBasicWr data = new missionBasicWr();

			data.missionName = GetValue<string>("getMissionName", result);
			data.missionNumber = GetValue<string>("getMissionNumber", result);
			data.description = GetValue<string>("getDescription", result);
			data.hint = GetValue<string>("getHint", result);
			data.image = GetValue<string>("getImage", result);
			data.completionArray = PopulateArrayData<completionWr>(GetAJO("getCompletion", result));
			data.rewardArray = PopulateArrayData<rewardWr>(GetAJO("getRewards", result));
			data.missionId = GetValue<string>("getMissionId", result);

			return data;
		}

		public static conditionDataWr PopulateConditionData(AndroidJavaObject result)
		{
			if (result == null) return null;

			conditionDataWr data = new conditionDataWr();

			return data;
		}

		public static conditionWr PopulateCondition(AndroidJavaObject result)
		{
			if (result == null) return null;

			conditionWr data = new conditionWr();

			data.conditionId = GetValue<string>("getId", result);
			data.conditionType = GetValue<string>("getCategory", result);
			data.conditionValue = GetValue<string>("getValue", result);
			// TODO: Add getting conditinoData later, when we fix and make it support all kind of condition data

			return data;
		}

		public static questBasicWr PopulateQuestBasic(AndroidJavaObject result)
		{
			if (result == null) return null;

			questBasicWr data = new questBasicWr();

			data.questName = GetValue<string>("getQuestName", result);
			data.description = GetValue<string>("getDescription", result);
			data.hint = GetValue<string>("getHint", result);
			data.image = GetValue<string>("getImage", result);
			data.missionOrder = GetValue<bool>("getMissionOrder", result);
			data.status = GetValue<bool>("getStatus", result);
			data.sortOrder = (uint)GetValue<int>("getSortOrder", result);
			data.rewardArray = PopulateArrayData<rewardWr>(GetAJO("getRewards", result));
			data.missionBasicArray = PopulateArrayData<missionBasicWr>(GetAJO("getMissions", result));
			data.dateAdded = GetTime("getDateDateAdded", result);
			data.clientId = GetValue<string>("getClientId", result);
			data.siteId = GetValue<string>("getSiteId", result);
			data.conditionArray = PopulateArrayData<conditionWr>(GetAJO("getConditions", result));
			data.dateModified = GetTime("getDateDateModified", result);
			data.questId = GetValue<string>("getQuestId", result);

			return data;
		}

		public static questInfoWr PopulateQuestInfo(AndroidJavaObject result)
		{
			if (result == null) return null;

			questInfoWr data = new questInfoWr();

			data.questBasic = PopulateQuestBasic(result);

			return data;
		}

		public static missionInfoWr PopulateMissionInfo(AndroidJavaObject result)
		{
			if (result == null) return null;

			missionInfoWr data = new missionInfoWr();

			data.missionBasic = PopulateMissionBasic(result);
			data.questId = GetValue<string>("getQuestId", result);

			return data;
		}

		public static questInfoListWr PopulateQuestInfoList(AndroidJavaObject result)
		{
			if (result == null) return null;

			questInfoListWr data = new questInfoListWr();

			data.questBasicArray = PopulateArrayData<questBasicWr>(result);

			return data;
		}

		public static questInfoListWr PopulateQuestInfoListForPlayer(AndroidJavaObject result)
		{
			if (result == null) return null;

			questInfoListWr data = new questInfoListWr();

			return data;
		}

		public static questAvailableForPlayerWr PopulateQuestAvailableForPlayer(AndroidJavaObject result)
		{
			if (result == null) return null;

			questAvailableForPlayerWr data = new questAvailableForPlayerWr();

			data.eventType = GetValue<string>("getType", result);
			data.eventMessage = GetValue<string>("getMessage", result);
			data.eventStatus = GetValue<bool>("getStatus", result);

			return data;
		}

		public static joinQuestWr PopulateJoinQuest(AndroidJavaObject result)
		{
			if (result == null) return null;

			joinQuestWr data = new joinQuestWr();

			data.eventType = GetValue<string>("getType", result);
			data.questId = GetValue<string>("getQuestId", result);

			return data;
		}

		public static cancelQuestWr PopulateCancelQuest(AndroidJavaObject result)
		{
			if (result == null) return null;

			cancelQuestWr data = new cancelQuestWr();

			data.eventType = GetValue<string>("getType", result);
			data.questId = GetValue<string>("getQuestId", result);

			return data;
		}

		#endif

	}
}