using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Playbasis.Wrapper.Helper;

namespace Playbasis.Wrapper.Model {

	public class playerBasicWr : ToStringable {
		public string image;
		public string userName;
		public uint exp;
		public uint level;
		public string firstName;
		public string lastName;
		public uint gender;
		public string clPlayerId;

		public string toString()
		{
			return "playerBasicWr{" +
					"image='" + image + "'" +
					", userName='" + userName + "'" +
					", exp='" + exp + "'" +
					", level='" + level + "'" +
					", firstName='" + firstName + "'" +
					", lastName='" + lastName + "'" +
					", gender='" + gender + "'" +
					", clPlayerId='" + clPlayerId + "'" +
					"}";
		}
	};

	public class playerPublicWr : ToStringable {
		public playerBasicWr basic;
		public long registered;
		public long lastLogin;
		public long lastLogout;

		public string toString()
		{
			return "playerPublicWr{" + ToStringBuilder.build(basic) +
					", registered='" + registered + "'" +
					", lastLogin='" + lastLogin + "'" +
					", lastLogout='" + lastLogout + "'" +
					"}";
		}
	};

	public class playerWr : ToStringable {
		public playerPublicWr playerPublic;
		public string email;
		public string phoneNumber;

		public string toString()
		{
			return "playerWr{" + ToStringBuilder.build(playerPublic) +
					", email='" + email + "'" +
					", phoneNumber='" + phoneNumber + "'" +
					"}";
		}
	};

	public class pointWr : ToStringable {
		public string rewardId;
		public string rewardName;
		public uint value;

		public string toString()
		{
			return "pointWr{" +
					"rewardId='" + rewardId + "'" +
					", rewardName='" + rewardName + "'" +
					", value='" + value + "'" +
					"}";
		}
	};

	public class pointRWr : ToStringable {
		public List<pointWr> pointArray;

		public string toString()
		{
			return "pointRWr{" + ToStringBuilder.buildList<pointWr>(pointArray) +
					"}";
		}
	};

	public class quizBasicWr : ToStringable {
		public string name;
		public string image;
		public int weight;
		public string description_;
		public string descriptionImage;
		public string quizId;

		public string toString()
		{
			return "quizBasicWr{" +
					"name='" + name + "'" +
					", image='" + image + "'" +
					", weight='" + weight + "'" +
					", description_='" + description_ + "'" +
					", descriptionImage='" + descriptionImage + "'" +
					", quizId='" + quizId + "'" +
					"}";
		}
	};

	public class gradeRewardCustomWr : ToStringable {
		public string customId;
		public string customValue;

		public string toString()
		{
			return "gradeRewardCustomWr{" +
					"customId='" + customId + "'" +
					", customValue='" + customValue + "'" +
					"}";
		}
	};

	public class gradeRewardsWr : ToStringable {
		public string expValue;
		public string pointValue;
		public List<gradeRewardCustomWr> gradeRewardCustomArray;

		public string toString()
		{
			return "gradeRewardsWr{" +
					"expValue='" + expValue + "'" +
					", pointValue='" + pointValue + "'" +
					", gradeRewardCustomArray='" + ToStringBuilder.buildList<gradeRewardCustomWr>(gradeRewardCustomArray) + "'" +
					"}";
		}
	};

	public class gradeWr : ToStringable {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public gradeRewardsWr rewards;

		public string toString()
		{
			return "gradeWr{" +
					"gradeId='" + gradeId + "'" +
					", start='" + start + "'" +
					", end='" + end + "'" +
					", grade='" + grade + "'" + 
					", rank='" + rank + "'" +
					", rankImage='" + rankImage + "'" +
					", rewards='" + ToStringBuilder.build(rewards) + "'" +
					"}";
		}
	};

	public class quizWr : ToStringable {
		public quizBasicWr basic;
		public long dateStart;
		public long dateExpire;
		public bool status;
		public List<gradeWr> gradeArray;
		public bool deleted;
		public uint totalMaxScore;
		public uint totalQuestion;

		public string toString()
		{
			return "quizWr{" +
					"basic='" + ToStringBuilder.build(basic) + "'" +
					", dateStart='" + dateStart + "'" +
					", dateExpire='" + dateExpire + "'" +
					", status='" + status + "'" +
					", gradeArray='" + ToStringBuilder.buildList<gradeWr>(gradeArray) + "'" +
					", deleted='" + deleted + "'" +
					", totalMaxScore='" + totalMaxScore + "'" +
					", totalQuestion='" + totalQuestion + "'" +
					"}";
		}
	};

	public class quizListWr : ToStringable {
		public List<quizBasicWr> quizBasicArray;

		public string toString()
		{
			return "quizListWr{" +
					"quizBasicArray='" + ToStringBuilder.buildList<quizBasicWr>(quizBasicArray) + "'" +
					"}";
		}
	};

	public class gradeDoneRewardWr : ToStringable {
		public string eventType;
		public string rewardType;
		public string rewardId;
		public string value;

		public string toString()
		{
			return "gradeDoneRewardWr{" +
					"eventType='" + eventType + "'" +
					", rewardType='" + rewardType + "'" +
					", rewardId='" + rewardId + "'" +
					", value='" + value + "'" +
					"}";
		}
	};

	public class gradeDoneWr : ToStringable {
		public string gradeId;
		public string start;
		public string end;
		public string grade;
		public string rank;
		public string rankImage;
		public List<gradeDoneRewardWr> rewardArray;
		public uint score;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;

		public string toString()
		{
			return "gradeDoneWr{" +
					"gradeId='" + gradeId + "'" +
					", start='" + start + "'" +
					", end='" + end + "'" +
					", grade='" + grade + "'" +
					", rank='" + rank + "'" +
					", rankImage='" + rankImage + "'" +
					", rewardArray='" + ToStringBuilder.buildList<gradeDoneRewardWr>(rewardArray) + "'" +
					", score='" + score + "'" +
					", maxScore='" + maxScore + "'" +
					", totalScore='" + totalScore + "'" +
					", totalMaxScore='" + totalMaxScore + "'" +
					"}";
		}
	};

	public class quizDoneWr : ToStringable {
		public uint value;
		public gradeDoneWr gradeDone;
		public uint totalCompletedQuestions;
		public string quizId;

		public string toString()
		{
			return "quizDoneWr{" +
					"value='" + value + "'" +
					", gradeDone='" + ToStringBuilder.build(gradeDone) + "'" +
					", totalCompletedQuestions='" + totalCompletedQuestions + "'" +
					", quizId='" + quizId + "'" +
					"}";
		}
	};

	public class quizPendingGradeRewardWr : ToStringable {
		public string eventType;
		public string rewardType;
		public string rewardId;
		public string value;

		public string toString()
		{
			return "quizPendingGradeRewardWr{" +
					"eventType='" + eventType + "'" +
					", rewardType='" + rewardType + "'" +
					", rewardId='" + rewardId + "'" +
					", value='" + value + "'" +
					"}";
		}
	};

	public class quizPendingGradeWr : ToStringable {
		public uint score;
		public List<quizPendingGradeRewardWr> quizPendingGradeRewardArray;
		public string maxScore;
		public uint totalScore;
		public uint totalMaxScore;

		public string toString()
		{
			return "quizPendingGradeWr{" +
					"score='" + score + "'" +
					", quizPendingGradeRewardArray='" + ToStringBuilder.buildList<quizPendingGradeRewardWr>(quizPendingGradeRewardArray) + "'" +
					", maxScore='" + maxScore + "'" +
					", totalScore='" + totalScore + "'" +
					", totalMaxScore='" + totalMaxScore + "'" +
					"}";
		}
	};

	public class quizPendingWr : ToStringable {
		public uint value;
		public quizPendingGradeWr grade;
		public uint totalCompletedQuestions;
		public uint totalPendingQuestions;
		public string quizId;

		public string toString()
		{
			return "quizPendingWr{" +
					"value='" + value + "'" +
					", grade='" + ToStringBuilder.build(grade) + "'" +
					", totalCompletedQuestions='" + totalCompletedQuestions + "'" +
					", totalPendingQuestions='" + totalPendingQuestions + "'" +
					", quizId='" + quizId + "'" +
					"}";
		}
	};

	public class questionOptionWr : ToStringable {
		public string option;
		public string optionImage;
		public string optionId;

		public string toString()
		{
			return "questionOptionWr{" +
					"option='" + option + "'" +
					", optionImage='" + optionImage + "'" +
					", optionId='" + optionId + "'" +
					"}";
 		}
	};

	public class questionWr : ToStringable {
		public string question;
		public string questionImage;
		public List<questionOptionWr> optionArray;
		public uint index;
		public uint total;
		public string questionId;

		public string toString()
		{
			return "questionWr{" +
					"question='" + question + "'" +
					", questionImage='" + questionImage + "'" +
					", optionArray='" + ToStringBuilder.buildList<questionOptionWr>(optionArray) + "'" +
					", index='" + index + "'" +
					", total='" + total + "'" +
					", questionId='" + questionId + "'" +
					"}";
		}
	};

	public class questionAnsweredGradeDoneWr : ToStringable {
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

		public string toString()
		{
			return "questionAnsweredGradeDoneWr{" +
					"gradeId='" + gradeId + "'" +
					", start='" + start + "'" +
					", end='" + end + "'" +
					", grade-'" + grade + "'" +
					", rank='" + rank + "'" +
					", rankImage='" + rankImage + "'" +
					", score='" + score + "'" +
					", maxScore='" + maxScore + "'" +
					", totalScore='" + totalScore + "'" +
					", totalMaxScore='" + totalMaxScore + "'" +
					"}";
		}
	}

	public class questionAnsweredOptionWr : ToStringable {
		public string option;
		public string score;
		public string explanation;
		public string optionImage;
		public string optionId;

		public string toString()
		{
			return "questionAnsweredOptionWr{" +
					"option='" + option + "'" + 
					", score='" + score + "'" +
					", explanation='" + explanation + "'" +
					", optionImage='" + optionImage + "'" +
					", optionId='" + optionId + "'" +
					"}";
		}
	}

	public class questionAnsweredWr : ToStringable {
		public List<questionAnsweredOptionWr> optionArray;
		public uint score;
		public string maxScore;
		public string explanation;
		public uint totalScore;
		public uint totalMaxScore;
		public questionAnsweredGradeDoneWr gradeDone;
		public List<gradeDoneRewardWr> gradeDoneRewardArray;

		public string toString()
		{
			return "questionAnsweredWr{" +
					"optionArray='" + ToStringBuilder.buildList<questionAnsweredOptionWr>(optionArray) + "'" +
					", score='" + score + "'" +
					", maxScore='" + maxScore + "'" +
					", explanation='" + explanation + "'" +
					", totalScore='" + totalScore + "'" +
					", totalMaxScore='" + totalMaxScore + "'" +
					", gradeDone='" + ToStringBuilder.build(gradeDone) + "'" +
					", gradeDoneRewardArray='" + ToStringBuilder.buildList<gradeDoneRewardWr>(gradeDoneRewardArray) + "'" +
					"}";
		}
	}

	public class customWr : ToStringable {
		public string customId;
		public string customName;
		public string customValue;

		public string toString()
		{
			return "customWr{" +
					"customId='" + customId + "'" +
					", customName='" + customName + "'" +
					", customValue='" + customValue + "'" +
					"}";
		}
	}

	public class redeemBadgeWr : ToStringable {
		public string badgeId;
		public uint badgeValue;

		public string toString()
		{
			return "redeemBadgeWr{" +
					"badgeId='" + badgeId + "'" +
					", badgeValue='" + badgeValue + "'" +
					"}";
		}
	}

	public class redeemWr : ToStringable {
		public uint pointValue;
		public List<customWr> customArray;
		public List<redeemBadgeWr> redeemBadgeArray;

		public string toString()
		{
			return "redeemWr{" +
					"pointValue='" + pointValue + "'" +
					", customArray='" + ToStringBuilder.buildList<customWr>(customArray) + "'" +
					", redeemBadgeArray='" + ToStringBuilder.buildList<redeemBadgeWr>(redeemBadgeArray) + "'" +
					"}";
		}
	}

	public class goodsWr : ToStringable {
		public string goodsId;
		public uint quantity;
		public string image;
		public uint sortOrder;
		public string name;
		public string description_;
		public redeemWr redeem;
		public string code;
		public bool sponsor;
		public long dateStart;
		public long dateExpire;

		public string toString()
		{
			return "goodsWr{" +
					"goodsId='" + goodsId + "'" +
					", quantity='" + quantity + "'" +
					", image='" + image + "'" +
					", sortOrder='" + sortOrder + "'" +
					", name='" + name + "'" +
					", description_='" + description_ + "'" +
					", redeem='" + ToStringBuilder.build(redeem) + "'" +
					", code='" + code + "'" +
					", sponsor='" + sponsor + "'" +
					", dateStart='" + dateStart + "'" +
					", dateExpire='" + dateExpire + "'" +
					"}";
		}
	}
	
	public class goodsInfoWr : ToStringable {
		public goodsWr goods;
		public uint amount;
		public uint perUser;
		public bool isGroup;

		public string toString() {
			return "goodsInfoWr{" +
				"goods='" + ToStringBuilder.build(goods) + "'" +
				", amount='" + amount + "'" +
				", perUser='" + perUser + "'" +
				", isGroup='" + isGroup + "'" +
				"}";
		}
	}
	
	public class goodsInfoListWr : ToStringable {
		public List<goodsInfoWr> goodsInfoArray;

		public string toString() {
			return "goodsInfoListWr{" +
				"goodsInfoArray='" + ToStringBuilder.buildList<goodsInfoWr>(goodsInfoArray) + "'" +
				"}";
		}
	}

	public class badgeWr : ToStringable {
		public string badgeId;
		public string image;
		public uint sortOrder;
		public string name;
		public string description_;
		public string hint;
		public bool sponsor;

		public string toString()
		{
			return "badgeWr{" +
					"badgeId='" + badgeId + "'" +
					", image='" + image + "'" +
					", sortOrder='" + sortOrder + "'" +
					", name='" + name + "'" +
					", description_='" + description_ + "'" +
					", hint='" + hint + "'" +
					", sponsor='" + sponsor + "'" +
					"}";
		}
	}
	
	public class badgesWr : ToStringable {
		public List<badgeWr> badgeArray;
		
		public string toString() {
			return "badgesWr{" +
					"badgeArray='" + ToStringBuilder.buildList<badgeWr>(badgeArray) + "'" +
					"}";
		}
	}

	public class ruleEventBadgeRewardDataWr : ToStringable {
		public string badgeId;
		public string image;
		public string name;
		public string description_;
		public string hint;

		public string toString()
		{
			return 	"ruleEventBadgeRewardDataWr{" +
						"badgeId='" + badgeId + "'" +
						", image='" + image + "'" +
						", name='" + name + "'" +
						", description_='" + description_ + "'" +
						", hint='" + hint + "'" +
						"}";
		}
	}

	public class ruleEventGoodsRewardDataWr : ToStringable {
		public string goodsId;
		public string image;
		public string name;
		public string description_;
		public uint perUser;
		public string code;

		public string toString()
		{
			return "ruleEventGoodsRewardDataWr{" +
					"goodsId='" + goodsId + "'" +
					", image='" + image + "'" +
					", name='" + name + "'" +
					", description_='" + description_ + "'" +
					", perUser='" + perUser + "'" +
					", code='" + code + "'" +
					"}"; 
		}
	}

	public class ruleEventWr : ToStringable {
		public string eventType;
		public string rewardType;
		public string value;
		public ruleEventBadgeRewardDataWr badgeData;
		public ruleEventGoodsRewardDataWr goodsData;

		public string toString()
		{
			string s = "ruleEventWr{" +
				"eventType='" + eventType + "'" +
				", rewardType='" + rewardType + "'" +
				", value='" + value + "'";
			if (rewardType == "badge")
			{
				s += ", rewardData='" + ToStringBuilder.build(badgeData) + "'";
			}
			else if(rewardType == "goods")
			{
				s += ", rewardData='" + ToStringBuilder.build(goodsData) + "'";
			}
			else
			{
				s += ", rewardData='null'";
			}

			s += "}";

			return s;
		}
	}

	public class ruleEventMissionWr : ToStringable {
		public List<ruleEventWr> eventArray;
		public string missionId;
		public string missionNumber;
		public string missionName;
		public string description_;
		public string hint;
		public string image;
		public string questId;

		public string toString()
		{
			return "ruleEventMissionWr{" +
					"eventArray='" + ToStringBuilder.buildList<ruleEventWr>(eventArray) + "'" +
					", missionId='" + missionId + "'" +
					", missionNumber='" + missionNumber + "'" +
					", missionName='" + missionName + "'" +
					", description_='" + description_ + "'" +
					", hint='" + hint + "'" +
					", image='" + image + "'" +
					", questId='" + questId + "'" +
					"}";
		}
	}

	public class ruleEventQuestWr : ToStringable {
		public List<ruleEventWr> eventArray;
		public string questId;
		public string questName;
		public string description_;
		public string hint;
		public string image;

		public string toString()
		{
			return "ruleEventQuestWr{" +
					"eventArray='" + ToStringBuilder.buildList<ruleEventWr>(eventArray) + "'" + 
					", questId='" + questId + "'" +
					", questName='" + questName + "'" +
					", description_='" + description_ + "'" +
					", hint='" + hint + "'" +
					", image='" + image + "'" +
					"}";
		}
	}

	public class ruleWr : ToStringable {
		public List<ruleEventWr> ruleEventArray;
		public List<ruleEventMissionWr> ruleEventMissionArray;
		public List<ruleEventQuestWr> ruleEventQuestArray;

		public string toString()
		{
			return "ruleWr{" +
					"ruleEventArray='" + ToStringBuilder.buildList<ruleEventWr>(ruleEventArray) + "'" +
					", ruleEventMissionArrayWr='" + ToStringBuilder.buildList<ruleEventMissionWr>(ruleEventMissionArray) + "'" +
					", ruleEventQuestArray='" + ToStringBuilder.buildList<ruleEventQuestWr>(ruleEventQuestArray) + "'" +
					"}";
		}
	}
	
	public class urlWr : ToStringable {
		public string operation;
		public string completionString;
		
		public string toString() {
			return "urlWr{" +
					"operation='" + operation + "'" +
					", completionString='" + completionString + "'" +
					"}";
		}
	}
	
	public class filteredParamWr : ToStringable {
		public urlWr url;
		
		public string toString() {
			return "filteredParamWr{" +
					"url='" + ToStringBuilder.build(url) + "'" +
					"}";
		}
	}
	
	public class completionDataWr : ToStringable {
		public string actionId;
		public string name;
		public string description;
		public string icon;
		public string color;
		
		public string toString() {
			return "completionDataWr{" +
					"actionId='" + actionId + "'" +
					", name='" + name + "'" +
					", description='" + description + "'" +
					", icon='" + icon + "'" +
					", color='" + color + "'" +
					"}";
		}
	}
	
	public class completionWr : ToStringable {
		public string completionOp;
		public string completionFilter;
		public string completionValue;
		public string completionId;
		public string completionType;
		public string completionElementId;
		public string completionTitle;
		public filteredParamWr filteredParam;
		public completionDataWr completionData;
		
		public string toString() {
			return "completionWr{" +
					"completionOp='" + completionOp + "'" +
					", completionFilter='" + completionFilter + "'" +
					", completionValue='" + completionValue + "'" +
					", completionId='" + completionId + "'" +
					", completionType='" + completionType + "'" +
					", completionElementId='" + completionElementId + "'" +
					", completionTitle='" + completionTitle + "'" +
					", filteredParam='" + ToStringBuilder.build(filteredParam) + "'" +
					", completionData='" + ToStringBuilder.build(completionData) + "'" +
					"}";
		}
	}
	
	public class rewardWr : ToStringable {
		public string rewardValue;
		public string rewardType;
		public string rewardId;
		public string rewardName;
		
		public string toString() {
			return "rewardWr{" +
					"rewardValue='" + rewardValue + "'" +
					", rewardType='" + rewardType + "'" +
					", rewardId='" + rewardId + "'" +
					", rewardName='" + rewardName + "'" +
					"}";
		}
	}
	
	public class missionBasicWr : ToStringable {
		public string missionName;
		public string missionNumber;
		public string description;
		public string hint;
		public string image;
		public List<completionWr> completionArray;
		public List<rewardWr> rewardArray;
		public string missionId;
		
		public string toString() {
			return "missionBasicWr{" +
					"missionName='" + missionName + "'" +
					", missionNumber='" + missionNumber + "'" +
					", description='" + description + "'" +
					", hint='" + hint + "'" +
					", image='" + image + "'" +
					", completionArray='" + ToStringBuilder.buildList<completionWr>(completionArray) + "'" +
					", rewardArray='" + ToStringBuilder.buildList<rewardWr>(rewardArray) + "'" +
					", missionId='" + missionId + "'" +
					"}";
		}
	}
	
	public class missionWr : ToStringable {
		public missionBasicWr missionBasic;
		
		public string toString() {
			return "missionWr{" +
					"missionBasic='" + ToStringBuilder.build(missionBasic) + "'" +
					"}";
		}
	}
	
	public class missionInfoWr : ToStringable {
		public missionBasicWr missionBasic;
		public string questId;
		
		public string toString() {
			return "missionInfoWr{" +
					"missionBasic='" + ToStringBuilder.build(missionBasic) + "'" +
					", questId='" + questId + "'" +
					"}";
		}
	}
	
	public class conditionDataWr : ToStringable {
		public string questName;
		public string description;
		public string hint;
		public string image;
		
		public string toString() {
			return "conditionDataWr{" +
					"questName='" + questName + "'" +
					", description='" + description + "'" +
					", hint='" + hint + "'" +
					", image='" + image + "'" +
					"}";
		}
	}
	
	public class conditionWr : ToStringable {
		public string conditionId;
		public string conditionType;
		public string conditionValue;
		public conditionDataWr conditionData;
		
		public string toString() {
			return "conditionWr{" +
					"conditionId='" + conditionId + "'" +
					", conditionType='" + conditionType + "'" +
					", conditionValue='" + conditionValue + "'" +
					", conditionData='" + ToStringBuilder.build(conditionData) + "'" +
					"}";
		}
	}
	
	public class questBasicWr : ToStringable {
		public string questName;
		public string description;
		public string hint;
		public string image;
		public bool missionOrder;
		public bool status;
		public uint sortOrder;
		public List<rewardWr> rewardArray;
		public List<missionBasicWr> missionBasicArray;
		public long dateAdded;
		public string clientId;
		public string siteId;
		public List<conditionWr> conditionArray;
		public long dateModified;
		public string questId;
		
		public string toString() {
			return "questBasicWr{" +
					"questName='" + questName + "'" +
					", description='" + description + "'" +
					", hint='" + hint + "'" +
					", image='" + image + "'" + 
					", missionOrder='" + missionOrder + "'" +
					", status='" + status + "'" +
					", sortOrder='" + sortOrder + "'" +
					", rewardArray='" + ToStringBuilder.buildList<rewardWr>(rewardArray) + "'" +
					", missionBasicArray='" + ToStringBuilder.buildList<missionBasicWr>(missionBasicArray) + "'" +
					", dateAdded='" + dateAdded + "'" +
					", clientId='" + clientId + "'" +
					", siteId='" + siteId + "'" +
					", conditionArray='" + ToStringBuilder.buildList<conditionWr>(conditionArray) + "'" +
					", dateModified='" + dateModified + "'" +
					", questId='" + questId + "'" +
					"}";
		}
	}
	
	public class questInfoWr : ToStringable {
		public questBasicWr questBasic;
		
		public string toString() {
			return "questInfoWr{" +
					"questBasic='" + ToStringBuilder.build(questBasic) + "'" +
					"}";

		}
	}
	
	public class questInfoListWr : ToStringable {
		public List<questBasicWr> questBasicArray;

		public string toString() {
			return "questInfoListWr{" +
				"questBasicArray='" + ToStringBuilder.buildList<questBasicWr>(questBasicArray) + "'" +
				"}";
		}
	}
	
	public class questAvailableForPlayerWr : ToStringable {
		public string eventType;
		public string eventMessage;
		public bool eventStatus;

		public string toString() {
			return "questAvailableForPlayerWr{" +
				"eventType='" + eventType + "'" +
				", eventMessage='" + eventMessage + "'" +
				", eventStatus='" + eventStatus + "'" +
				"}";
		}
	}
	
	public class joinQuestWr : ToStringable {
		public string eventType;
		public string questId;

		public string toString() {
			return "joinQuestWr{" +
				"eventType='" + eventType + "'" +
				", questId='" + questId + "'" +
				"}";
		}
	}
	
	public class cancelQuestWr : ToStringable {
		public string eventType;
		public string questId;

		public string toString() {
			return "cancelQuestWr{" +
				"eventType='" + eventType + "'" +
				", questId='" + questId + "'" +
				"}";
		}
	}
}