using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.iOS;
using Playbasis.Wrapper.Helper;
using AOT;

namespace Playbasis.Wrapper.InternalModel {
	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP

	public interface Migrateable<R> { R migrate(); }

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventQuestArrayWr : Migrateable<List<ruleEventQuestWr>> {
		public IntPtr data;
		public int count;

		public List<ruleEventQuestWr> migrate()
		{
			return Migrator.migrateToList<ruleEventQuestWr, _ruleEventQuestWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventMissionArrayWr : Migrateable<List<ruleEventMissionWr>> {
		public IntPtr data;
		public int count;

		public List<ruleEventMissionWr> migrate()
		{
			return Migrator.migrateToList<ruleEventMissionWr, _ruleEventMissionWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventArrayWr : Migrateable<List<ruleEventWr>> {
		public IntPtr data;
		public int count;

		public List<ruleEventWr> migrate()
		{
			return Migrator.migrateToList<ruleEventWr, _ruleEventWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionAnsweredGradeDoneArrayWr : Migrateable<List<questionAnsweredGradeDoneWr>> {
		public IntPtr data;
		public int count;

		public List<questionAnsweredGradeDoneWr> migrate()
		{
			return Migrator.migrateToList<questionAnsweredGradeDoneWr, _questionAnsweredGradeDoneWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionAnsweredOptionArrayWr : Migrateable<List<questionAnsweredOptionWr>> {
		public IntPtr data;
		public int count;

		public List<questionAnsweredOptionWr> migrate()
		{
			return Migrator.migrateToList<questionAnsweredOptionWr, _questionAnsweredOptionWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionOptionArrayWr : Migrateable<List<questionOptionWr>> {
		public IntPtr data;
		public int count;

		public List<questionOptionWr> migrate()
		{
			return Migrator.migrateToList<questionOptionWr, _questionOptionWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizPendingGradeRewardArrayWr : Migrateable<List<quizPendingGradeRewardWr>> {
		public IntPtr data;
		public int count;

		public List<quizPendingGradeRewardWr> migrate()
		{
			return Migrator.migrateToList<quizPendingGradeRewardWr, _quizPendingGradeRewardWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizPendingListWr : Migrateable<List<quizPendingWr>> {
		public IntPtr data;
		public int count;

		public List<quizPendingWr> migrate()
		{
			return Migrator.migrateToList<quizPendingWr, _quizPendingWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeDoneRewardArrayWr : Migrateable<List<gradeDoneRewardWr>> {
		public IntPtr data;
		public int count;

		public List<gradeDoneRewardWr> migrate()
		{
			return Migrator.migrateToList<gradeDoneRewardWr, _gradeDoneRewardWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizDoneListWr : Migrateable<List<quizDoneWr>> {
		public IntPtr data;
		public int count;

		public List<quizDoneWr> migrate()
		{
			return Migrator.migrateToList<quizDoneWr, _quizDoneWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeRewardCustomArrayWr : Migrateable<List<gradeRewardCustomWr>> {
		public IntPtr data;
		public int count;

		public List<gradeRewardCustomWr> migrate()
		{
			return Migrator.migrateToList<gradeRewardCustomWr, _gradeRewardCustomWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeArrayWr : Migrateable<List<gradeWr>> {
		public IntPtr data;
		public int count;

		public List<gradeWr> migrate()
		{
			return Migrator.migrateToList<gradeWr, _gradeWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _pointArrayWr : Migrateable<List<pointWr>> {
		public IntPtr data;
		public int count;

		public List<pointWr> migrate()
		{
			return Migrator.migrateToList<pointWr, _pointWr>(data, count);
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizBasicArrayWr : Migrateable<List<quizBasicWr>> {
		public IntPtr data;
		public int count;

		public List<quizBasicWr> migrate()
		{
			return Migrator.migrateToList<quizBasicWr, _quizBasicWr>(data, count);
		}
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _conditionArrayWr : Migrateable<List<conditionWr>> {
		public IntPtr data;
		public int count;

		public List<conditionWr> migrate()
		{
			return Migrator.migrateToList<conditionWr, _conditionWr>(data, count);
		}
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _goodsArrayWr : Migrateable<List<goodsWr>> {
		public IntPtr data;
		public int count;

		public List<goodsWr> migrate() {
			return Migrator.migrateToList<goodsWr, _goodsWr>(data, count);
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _customArrayWr : Migrateable<List<customWr>> {
		public IntPtr data;
		public int count;

		public List<customWr> migrate() {
			return Migrator.migrateToList<customWr, _customWr>(data, count);
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _redeemBadgeArrayWr : Migrateable<List<redeemBadgeWr>> {
		public IntPtr data;
		public int count;

		public List<redeemBadgeWr> migrate() {
			return Migrator.migrateToList<redeemBadgeWr, _redeemBadgeWr>(data, count);
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _goodsInfoArrayWr : Migrateable<List<goodsInfoWr>> {
		public IntPtr data;
		public int count;

		public List<goodsInfoWr> migrate() {
			return Migrator.migrateToList<goodsInfoWr, _goodsInfoWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizBasicWr : Migrateable<quizBasicWr> {
		public string name;
		public string image;
		public int weight;
		public string description_;
		public string descriptionImage;
		public string quizId;

		public quizBasicWr migrate()
		{
			quizBasicWr newSt = new quizBasicWr();
			newSt.name = name;
			newSt.image = image;
			newSt.weight = weight;
			newSt.description_ = description_;
			newSt.descriptionImage = descriptionImage;
			newSt.quizId = quizId;
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizListWr : Migrateable<quizListWr> {
		public _quizBasicArrayWr quizBasicArray;

		public quizListWr migrate()
		{
			quizListWr newSt = new quizListWr();
			newSt.quizBasicArray = quizBasicArray.migrate();
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _pointWr : Migrateable<pointWr> {
		public string rewardId;
		public string rewardName;
		public uint value;

		public pointWr migrate()
		{
			pointWr newSt = new pointWr();
			newSt.rewardId = rewardId;
			newSt.rewardName = rewardName;
			newSt.value = value;
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _pointRWr : Migrateable<pointRWr> {
		public _pointArrayWr pointArray;

		public pointRWr migrate()
		{
			pointRWr newSt = new pointRWr();
			newSt.pointArray = pointArray.migrate();
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _playerBasicWr : Migrateable<playerBasicWr> {
		public string image;
		public string userName;
		public uint exp;
		public uint level;
		public string firstName;
		public string lastName;
		public uint gender;
		public string clPlayerId;

		public playerBasicWr migrate()
		{
			playerBasicWr newSt = new playerBasicWr();
			newSt.image = image;
			newSt.userName = userName;
			newSt.exp = exp;
			newSt.level = level;
			newSt.firstName = firstName;
			newSt.lastName = lastName;
			newSt.gender = gender;
			newSt.clPlayerId = clPlayerId;
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _playerPublicWr : Migrateable<playerPublicWr> {
		public _playerBasicWr basic;
		public long registered;
		public long lastLogin;
		public long lastLogout;

		public playerPublicWr migrate()
		{
			playerPublicWr newSt = new playerPublicWr();
			newSt.basic = basic.migrate();
			newSt.registered = registered;
			newSt.lastLogin = lastLogin;
			newSt.lastLogout = lastLogout;
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _playerWr : Migrateable<playerWr> {
		public _playerPublicWr playerPublic;
		public string email;
		public string phoneNumber;

		public playerWr migrate()
		{
			playerWr newSt = new playerWr();
			newSt.playerPublic = playerPublic.migrate();
			newSt.email = email;
			newSt.phoneNumber = phoneNumber;
			return newSt;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizWr : Migrateable<quizWr> {
		public _quizBasicWr basic;
		public long dateStart;
		public long dateExpire;
		[MarshalAs(UnmanagedType.U1)]	public bool status;
		public _gradeArrayWr gradeArray;
		[MarshalAs(UnmanagedType.U1)]	public bool deleted;
		public uint totalMaxScore;
		public uint totalQuestion;

		public quizWr migrate()
		{
			quizWr newst = new quizWr();
			newst.basic = basic.migrate();
			newst.dateStart = dateStart;
			newst.dateExpire = dateExpire;
			newst.status = status;
			newst.gradeArray = gradeArray.migrate();
			newst.deleted = deleted;
			newst.totalMaxScore = totalMaxScore;
			newst.totalQuestion = totalQuestion;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeRewardCustomWr : Migrateable<gradeRewardCustomWr> {
		public string customId;
		public string customValue;

		public gradeRewardCustomWr migrate()
		{
			gradeRewardCustomWr newst = new gradeRewardCustomWr();
			newst.customId = customId;
			newst.customValue = customValue;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeRewardsWr : Migrateable<gradeRewardsWr> {
		public string expValue;
		public string pointValue;
		public _gradeRewardCustomArrayWr gradeRewardCustomArray;

		public gradeRewardsWr migrate()
		{
			gradeRewardsWr newst = new gradeRewardsWr();
			newst.expValue = expValue;
			newst.pointValue = pointValue;
			newst.gradeRewardCustomArray = gradeRewardCustomArray.migrate();
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeWr : Migrateable<gradeWr> {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public _gradeRewardsWr rewards;

		public gradeWr migrate()
		{
			gradeWr newst = new gradeWr();
			newst.gradeId = gradeId;
			newst.start = start;
			newst.end = end;
			newst.grade = grade;
			newst.rank = rank;
			newst.rankImage = rankImage;
			newst.rewards = rewards.migrate();
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeDoneRewardWr : Migrateable<gradeDoneRewardWr> {
		public string eventType;
		public string rewardType;
		public string rewardId;
		public string value;

		public gradeDoneRewardWr migrate()
		{
			gradeDoneRewardWr newst = new gradeDoneRewardWr();
			newst.eventType = eventType;
			newst.rewardType = rewardType;
			newst.rewardId = rewardId;
			newst.value = value;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _gradeDoneWr : Migrateable<gradeDoneWr> {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public _gradeDoneRewardArrayWr rewardArray;
		public uint score;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;

		public gradeDoneWr migrate()
		{
			gradeDoneWr newst = new gradeDoneWr();
			newst.gradeId = gradeId;
			newst.start = start;
			newst.end = end;
			newst.grade = grade;
			newst.rank = rank;
			newst.rankImage = rankImage;
			newst.rewardArray = rewardArray.migrate();
			newst.score = score;
			newst.maxScore = maxScore;
			newst.totalScore = totalScore;
			newst.totalMaxScore = totalMaxScore;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizDoneWr : Migrateable<quizDoneWr> {
		public uint value;
		public _gradeDoneWr gradeDone;
		public uint totalCompletedQuestions;
		public string quizId;

		public quizDoneWr migrate()
		{
			quizDoneWr newst = new quizDoneWr();
			newst.value = value;
			newst.gradeDone = gradeDone.migrate();
			newst.totalCompletedQuestions = totalCompletedQuestions;
			newst.quizId = quizId;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizPendingGradeRewardWr : Migrateable<quizPendingGradeRewardWr> {
		public string eventType;
		public string rewardType;
		public string rewardId;
		public string value;

		public quizPendingGradeRewardWr migrate()
		{
			quizPendingGradeRewardWr newst = new quizPendingGradeRewardWr();
			newst.eventType = eventType;
			newst.rewardType = rewardType;
			newst.rewardId = rewardId;
			newst.value = value;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizPendingGradeWr : Migrateable<quizPendingGradeWr> {
		public uint score;
		public _quizPendingGradeRewardArrayWr quizPendingGradeRewardArray;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;

		public quizPendingGradeWr migrate()
		{
			quizPendingGradeWr newst = new quizPendingGradeWr();
			newst.score = score;
			newst.quizPendingGradeRewardArray = quizPendingGradeRewardArray.migrate();
			newst.maxScore = maxScore;
			newst.totalScore = totalScore;
			newst.totalMaxScore = totalMaxScore;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _quizPendingWr : Migrateable<quizPendingWr> {
		public uint value;
		public _quizPendingGradeWr grade;
		public uint totalCompletedQuestions;
		public uint totalPendingQuestions;
		public string quizId;

		public quizPendingWr migrate()
		{
			quizPendingWr newst = new quizPendingWr();
			newst.value = value;
			newst.grade = grade.migrate();
			newst.totalCompletedQuestions = totalCompletedQuestions;
			newst.totalPendingQuestions = totalPendingQuestions;
			newst.quizId = quizId;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionWr : Migrateable<questionWr> {
		public string question;
		public string questionImage;
		public _questionOptionArrayWr optionArray;
		public uint index;
		public uint total;
		public string questionId;

		public questionWr migrate()
		{
			questionWr newst = new questionWr();
			newst.question = question;
			newst.questionImage = questionImage;
			newst.optionArray = optionArray.migrate();
			newst.index = index;
			newst.total = total;
			newst.questionId = questionId;
			return newst;
		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionOptionWr : Migrateable<questionOptionWr> {
		public string option;
		public string optionImage;
		public string optionId;

		public questionOptionWr migrate()
		{
			questionOptionWr newst = new questionOptionWr();
			newst.option = option;
			newst.optionImage = optionImage;
			newst.optionId = optionId;
			return newst;
 		}
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionAnsweredOptionWr : Migrateable<questionAnsweredOptionWr> {
		public string option;
		public string score;
		public string explanation;
		public string optionImage;
		public string optionId;

		public questionAnsweredOptionWr migrate()
		{
			questionAnsweredOptionWr newst = new questionAnsweredOptionWr();
			newst.option = option;
			newst.score = score;
			newst.explanation = explanation;
			newst.optionImage = optionImage;
			newst.optionId = optionId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionAnsweredGradeDoneWr : Migrateable<questionAnsweredGradeDoneWr> {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public uint score;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;

		public questionAnsweredGradeDoneWr migrate()
		{
			questionAnsweredGradeDoneWr newst = new questionAnsweredGradeDoneWr();
			newst.gradeId = gradeId;
			newst.start = start;
			newst.end = end;
			newst.grade = grade;
			newst.rank = rank;
			newst.rankImage = rankImage;
			newst.score = score;
			newst.maxScore = maxScore;
			newst.totalScore = totalScore;
			newst.totalMaxScore = totalMaxScore;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questionAnsweredWr : Migrateable<questionAnsweredWr> {
		public _questionAnsweredOptionArrayWr optionArray;
		public uint score;
		public string maxScore;
		public string explanation;
		public uint totalScore;
		public uint totalMaxScore;
		public _questionAnsweredGradeDoneWr gradeDone;
		public _gradeDoneRewardArrayWr gradeDoneRewardArray;

		public questionAnsweredWr migrate()
		{
			questionAnsweredWr newst = new questionAnsweredWr();
			newst.optionArray = optionArray.migrate();
			newst.score = score;
			newst.maxScore = maxScore;
			newst.explanation = explanation;
			newst.totalScore = totalScore;
			newst.totalMaxScore = totalMaxScore;
			newst.gradeDone = gradeDone.migrate();
			newst.gradeDoneRewardArray = gradeDoneRewardArray.migrate();
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _customWr : Migrateable<customWr> {
		public string customId;
		public string customName;
		public string customValue;

		public customWr migrate() {
			customWr newst = new customWr();
			newst.customId = customId;
			newst.customName = customName;
			newst.customValue = customValue;
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _redeemBadgeWr : Migrateable<redeemBadgeWr> {
		public string badgeId;
		public uint badgeValue;

		public redeemBadgeWr migrate() {
			redeemBadgeWr newst = new redeemBadgeWr();
			newst.badgeId = badgeId;
			newst.badgeValue = badgeValue;
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _redeemWr : Migrateable<redeemWr> {
		public uint pointValue;
		public _customArrayWr customArray;
		public _redeemBadgeArrayWr redeemBadgeArray;

		public redeemWr migrate() {
			redeemWr newst = new redeemWr();
			newst.pointValue = pointValue;
			newst.customArray = customArray.migrate();
			newst.redeemBadgeArray = redeemBadgeArray.migrate();
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _goodsWr : Migrateable<goodsWr> {
		public string goodsId;
		public uint quantity;
		public string image;
		public uint sortOrder;
		public string name;
		public string description_;
		public _redeemWr redeem;
		public string code;
		[MarshalAs(UnmanagedType.U1)]	public bool sponsor;
		public long dateStart;
		public long dateExpire;

		public goodsWr migrate() {
			goodsWr newst = new goodsWr();
			newst.goodsId = goodsId;
			newst.quantity = quantity;
			newst.image = image;
			newst.sortOrder = sortOrder;
			newst.name = name;
			newst.description_ = description_;
			newst.redeem = redeem.migrate();
			newst.code = code;
			newst.sponsor = sponsor;
			newst.dateStart = dateStart;
			newst.dateExpire = dateExpire;
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _goodsInfoWr : Migrateable<goodsInfoWr> {
		public _goodsWr goods;
		public uint amount;
		public uint perUser;
		[MarshalAs(UnmanagedType.U1)]	public bool isGroup;

		public goodsInfoWr migrate() {
			goodsInfoWr newst = new goodsInfoWr();
			newst.goods = goods.migrate();
			newst.amount = amount;
			newst.perUser = perUser;
			newst.isGroup = isGroup;
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _goodsInfoListWr : Migrateable<goodsInfoListWr> {
		public _goodsInfoArrayWr goodsInfoArray;

		public goodsInfoListWr migrate() {
			goodsInfoListWr newst = new goodsInfoListWr();
			newst.goodsInfoArray = goodsInfoArray.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventBadgeRewardDataWr : Migrateable<ruleEventBadgeRewardDataWr> {
		public string badgeId;
		public string image;
		public string name;
		public string description_;
		public string hint;

		public ruleEventBadgeRewardDataWr migrate()
		{
			ruleEventBadgeRewardDataWr newst = new ruleEventBadgeRewardDataWr();
			newst.badgeId = badgeId;
			newst.image = image;
			newst.name = name;
			newst.description_ = description_;
			newst.hint = hint;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventGoodsRewardDataWr : Migrateable<ruleEventGoodsRewardDataWr> {
		public string goodsId;
		public string image;
		public string name;
		public string description_;
		public uint perUser;
		public string code;

		public ruleEventGoodsRewardDataWr migrate()
		{
			ruleEventGoodsRewardDataWr newst = new ruleEventGoodsRewardDataWr();
			newst.goodsId = goodsId;
			newst.image = image;
			newst.name = name;
			newst.description_ = description_;
			newst.perUser = perUser;
			newst.code = code;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventWr : Migrateable<ruleEventWr> {
		public string eventType;
		public string rewardType;
		public string value;
		public _ruleEventBadgeRewardDataWr badgeData;
		public _ruleEventGoodsRewardDataWr goodsData;

		public ruleEventWr migrate()
		{
			ruleEventWr newst = new ruleEventWr();
			newst.eventType = eventType;
			newst.rewardType = rewardType;
			newst.value = value;
			newst.badgeData = badgeData.migrate();
			newst.goodsData = goodsData.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventMissionWr : Migrateable<ruleEventMissionWr> {
		public _ruleEventArrayWr eventArray;
		public string missionId;
		public string missionNumber;
		public string missionName;
		public string description_;
		public string hint;
		public string image;
		public string questId;

		public ruleEventMissionWr migrate()
		{
			ruleEventMissionWr newst = new ruleEventMissionWr();
			newst.eventArray = eventArray.migrate();
			newst.missionId = missionId;
			newst.missionNumber = missionNumber;
			newst.missionName = missionName;
			newst.description_ = description_;
			newst.hint = hint;
			newst.image = image;
			newst.questId = questId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleEventQuestWr : Migrateable<ruleEventQuestWr> {
		public _ruleEventArrayWr eventArray;
		public string questId;
		public string questName;
		public string description_;
		public string hint;
		public string image;

		public ruleEventQuestWr migrate()
		{
			ruleEventQuestWr newst = new ruleEventQuestWr();
			newst.eventArray = eventArray.migrate();
			newst.questId = questId;
			newst.questName = questName;
			newst.description_ = description_;
			newst.hint = hint;
			newst.image = image;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _ruleWr : Migrateable<ruleWr> {
		public _ruleEventArrayWr ruleEventArray;
		public _ruleEventMissionArrayWr ruleEventMissionArray;
		public _ruleEventQuestArrayWr ruleEventQuestArray;

		public ruleWr migrate()
		{
			ruleWr newst = new ruleWr();
			newst.ruleEventArray = ruleEventArray.migrate();
			newst.ruleEventMissionArray = ruleEventMissionArray.migrate();
			newst.ruleEventQuestArray = ruleEventQuestArray.migrate();
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _badgeWr : Migrateable<badgeWr> {
		public string badgeId;
		public string image;
		public uint sortOrder;
		public string name;
		public string description_;
		public string hint;
		[MarshalAs(UnmanagedType.U1)]	public bool sponsor;

		public badgeWr migrate() {
			badgeWr newst = new badgeWr();
			newst.badgeId = badgeId;
			newst.image = image;
			newst.sortOrder = sortOrder;
			newst.name = name;
			newst.description_ = description_;
			newst.hint = hint;
			newst.sponsor = sponsor;
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _badgesWr : Migrateable<badgesWr> {
		public _badgeArrayWr badgeArray;

		public badgesWr migrate() {
			badgesWr newst = new badgesWr();
			newst.badgeArray = badgeArray.migrate();
			return newst;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct _urlWr : Migrateable<urlWr> {
		public string operation;
		public string completionString;

		public urlWr migrate() {
			urlWr newst = new urlWr();
			newst.operation = operation;
			newst.completionString = completionString;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _filteredParamWr : Migrateable<filteredParamWr> {
		public _urlWr url;

		public filteredParamWr migrate() {
			filteredParamWr newst = new filteredParamWr();
			newst.url = url.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _completionDataWr : Migrateable<completionDataWr> {
		public string actionId;
		public string name;
		public string description;
		public string icon;
		public string color;

		public completionDataWr migrate() {
			completionDataWr newst = new completionDataWr();
			newst.actionId = actionId;
			newst.name = name;
			newst.description = description;
			newst.icon = icon;
			newst.color = color;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _completionWr : Migrateable<completionWr> {
		public string completionOp;
		public string completionFilter;
		public string completionValue;
		public string completionId;
		public string completionType;
		public string completionElementId;
		public string completionTitle;
		public _filteredParamWr filteredParam;
		public _completionDataWr completionData;

		public completionWr migrate() {
			completionWr newst = new completionWr();
			newst.completionOp = completionOp;
			newst.completionFilter = completionFilter;
			newst.completionValue = completionValue;
			newst.completionId = completionId;
			newst.completionType = completionType;
			newst.completionElementId = completionElementId;
			newst.completionTitle = completionTitle;
			newst.filteredParam = filteredParam.migrate();
			newst.completionData = completionData.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _rewardWr : Migrateable<rewardWr> {
		public string rewardValue;
		public string rewardType;
		public string rewardId;
		public string rewardName;

		public rewardWr migrate() {
			rewardWr newst = new rewardWr();
			newst.rewardValue = rewardValue;
			newst.rewardType = rewardType;
			newst.rewardId = rewardId;
			newst.rewardName = rewardName;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _missionBasicWr : Migrateable<missionBasicWr> {
		public string missionName;
		public string missionNumber;
		public string description;
		public string hint;
		public string image;
		public _completionArrayWr completionArray;
		public _rewardArrayWr rewardArray;
		public string missionId;

		public missionBasicWr migrate() {
			missionBasicWr newst = new missionBasicWr();
			newst.missionName = missionName;
			newst.missionNumber = missionNumber;
			newst.description = description;
			newst.hint = hint;
			newst.image = image;
			newst.completionArray = completionArray.migrate();
			newst.rewardArray = rewardArray.migrate();
			newst.missionId = missionId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _missionWr : Migrateable<missionWr> {
		public _missionBasicWr missionBasic;

		public missionWr migrate() {
			missionWr newst = new missionWr();
			newst.missionBasic = missionBasic.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _missionInfoWr : Migrateable<missionInfoWr> {
		public _missionBasicWr missionBasic;
		public string questId;

		public missionInfoWr migrate() {
			missionInfoWr newst = new missionInfoWr();
			newst.missionBasic = missionBasic.migrate();
			newst.questId = questId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _conditionDataWr : Migrateable<conditionDataWr> {
		public string questName;
		public string description;
		public string hint;
		public string image;

		public conditionDataWr migrate() {
			conditionDataWr newst = new conditionDataWr();
			newst.questName = questName;
			newst.description = description;
			newst.hint = hint;
			newst.image = image;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _conditionWr : Migrateable<conditionWr> {
		public string conditionId;
		public string conditionType;
		public string conditionValue;
		public _conditionDataWr conditionData;

		public conditionWr migrate() {
			conditionWr newst = new conditionWr();
			newst.conditionId = conditionId;
			newst.conditionType = conditionType;
			newst.conditionValue = conditionValue;
			newst.conditionData = conditionData.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questBasicWr : Migrateable<questBasicWr> {
		public string questName;
		public string description;
		public string hint;
		public string image;
		[MarshalAs(UnmanagedType.U1)]	public bool missionOrder;
		[MarshalAs(UnmanagedType.U1)]	public bool status;
		public uint sortOrder;
		public _rewardArrayWr rewardArray;
		public _missionBasicArrayWr missionBasicArray;
		public long dateAdded;
		public string clientId;
		public string siteId;
		public _conditionArrayWr conditionArray;
		public long dateModified;
		public string questId;

		public questBasicWr migrate() {
			questBasicWr newst = new questBasicWr();
			newst.questName = questName;
			newst.description = description;
			newst.hint = hint;
			newst.image = image;
			newst.missionOrder = missionOrder;
			newst.status = status;
			newst.sortOrder = sortOrder;
			newst.rewardArray = rewardArray.migrate();
			newst.missionBasicArray = missionBasicArray.migrate();
			newst.dateAdded = dateAdded;
			newst.clientId = clientId;
			newst.siteId = siteId;
			newst.conditionArray = conditionArray.migrate();
			newst.dateModified = dateModified;
			newst.questId = questId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questInfoWr : Migrateable<questInfoWr> {
		public _questBasicWr questBasic;

		public questInfoWr migrate() {
			questInfoWr newst = new questInfoWr();
			newst.questBasic = questBasic.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questInfoListWr : Migrateable<questInfoListWr> {
		public _questBasicArrayWr questBasicArray;

		public questInfoListWr migrate() {
			questInfoListWr newst = new questInfoListWr();
			newst.questBasicArray = questBasicArray.migrate();
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questAvailableForPlayerWr : Migrateable<questAvailableForPlayerWr> {
		public string eventType;
		public string eventMessage;
		[MarshalAs(UnmanagedType.U1)]	public bool eventStatus;

		public questAvailableForPlayerWr migrate() {
			questAvailableForPlayerWr newst = new questAvailableForPlayerWr();
			newst.eventType = eventType;
			newst.eventMessage = eventMessage;
			newst.eventStatus = eventStatus;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _joinQuestWr : Migrateable<joinQuestWr> {
		public string eventType;
		public string questId;

		public joinQuestWr migrate() {
			joinQuestWr newst = new joinQuestWr();
			newst.eventType = eventType;
			newst.questId = questId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _cancelQuestWr : Migrateable<cancelQuestWr> {
		public string eventType;
		public string questId;

		public cancelQuestWr migrate() {
			cancelQuestWr newst = new cancelQuestWr();
			newst.eventType = eventType;
			newst.questId = questId;
			return newst;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _badgeArrayWr : Migrateable<List<badgeWr>> {
		public IntPtr data;
		public int count;

		public List<badgeWr> migrate() {
			return Migrator.migrateToList<badgeWr, _badgeWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _completionArrayWr : Migrateable<List<completionWr>> {
		public IntPtr data;
		public int count;

		public List<completionWr> migrate() {
			return Migrator.migrateToList<completionWr, _completionWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _rewardArrayWr : Migrateable<List<rewardWr>> {
		public IntPtr data;
		public int count;

		public List<rewardWr> migrate() {
			return Migrator.migrateToList<rewardWr, _rewardWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _missionBasicArrayWr : Migrateable<List<missionBasicWr>> {
		public IntPtr data;
		public int count;

		public List<missionBasicWr> migrate() {
			return Migrator.migrateToList<missionBasicWr, _missionBasicWr>(data, count);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct _questBasicArrayWr : Migrateable<List<questBasicWr>> {
		public IntPtr data;
		public int count;

		public List<questBasicWr> migrate() {
			return Migrator.migrateToList<questBasicWr, _questBasicWr>(data, count);
		}
	}

	#endif
}