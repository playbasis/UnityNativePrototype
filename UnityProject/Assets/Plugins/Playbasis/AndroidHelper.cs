using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using AOT;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.InternalModel;

namespace Playbasis.Wrapper.Android {

	#if UNITY_ANDROID

	public partial class AndroidPopulator
	{
		/**
			Helper to get primitive value from primitive wrapper class on Java.
		*/
		public static T GetValue<T>(string methodName, AndroidJavaObject javaObj)
		{
			if (javaObj == null)
			{
				return default(T);
			}

			try
			{
				// string, has special case of handle it
				if (typeof(T) == typeof(string))
				{
					return javaObj.Call<T>(methodName);
				}

				// otherwise return other normal primitive types
				AndroidJavaObject obj = javaObj.Call<AndroidJavaObject>(methodName);

				if (obj == null)
				{
					return default(T);
				}

				string getValMethodName = "";
				if (typeof(T) == typeof(int))
				{
					getValMethodName = "intValue";
				}
				else if (typeof(T) == typeof(long))
				{
					getValMethodName = "longValue";
				}
				else if (typeof(T) == typeof(bool))
				{
					getValMethodName = "booleanValue";
				}
				else
				{
					// no support type
					return default(T);
				}

				return obj.Call<T>(getValMethodName);
			}
			catch(Exception e)
			{
				Debug.Log("[GetValue] It does't have value for '" + methodName + "'. Ignore it and move on");
				return default(T);
			}
		}

		/*
			Helper to get AndroidJavaObject
		*/
		public static AndroidJavaObject GetAJO(string methodName, AndroidJavaObject javaObj)
		{
			if (javaObj == null)
				return null;

			try
			{
				AndroidJavaObject obj = javaObj.Call<AndroidJavaObject>(methodName);
				return obj;
			}
			catch(Exception e)
			{
				Debug.Log("[GetAJO] It does't have value for '" + methodName + "'. Ignore it and move on");
				return null;
			}
		}

		/**
			Get elapsed time in seconds from Date java object.
		*/
		public static long GetTime(string methodName, AndroidJavaObject javaObj)
		{
			if (javaObj == null)
				return 0;

			try
			{
				AndroidJavaObject obj = javaObj.Call<AndroidJavaObject>(methodName);

				if (obj == null)
				{
					return 0;
				}

				return obj.Call<long>("getTime") / 1000;
			}
			catch (Exception e)
			{
				Debug.Log("[GetTime] It does't have value for '" + methodName + "'. Ignore it and move on");
				return 0;
			}
		}

		/// <summary>Populate array data and return it as a result</summary>
		/// <typeparam name="T">Type of data element that List manages</typeparam>
		/// <param name="from">Java class object that contains element to populate data from</param>
		/// <returns>List<T>Newly created list contains all populated elements inside</returns>
		public static List<T> PopulateArrayData<T>(AndroidJavaObject from)
			where T : class
		{
			// result list that will be returned
			List<T> list = new List<T>();

			if (from != null)
			{
				int size = from.Call<int>("size");
				if (size > 0)
				{
					// temp
					T element;
					AndroidJavaObject pJavaObj;

					for (int i=0; i<size; i++)
					{
						pJavaObj = from.Call<AndroidJavaObject>("get", i);
						element = PopulateData<T>(pJavaObj);
						list.Add(element);
					}
				}
			}

			return list;
		}

		/// <summary>Populate data based on its data type</summary>
		/// <typeparam name="T">Type of which the data is being populated</typeparam>
		/// <param name="from">Object data to populated data from</param>
		/// <returns>T</returns>
		public static T PopulateData<T>(AndroidJavaObject from)
			where T : class
		{
			if (from == null)
				return null;

			// to hold result from populating
			T t;

			if (typeof(T) == typeof(pointWr))
			{
				t = (T)(object)PopulatePoint(from);
			}
			else if (typeof(T) == typeof(ruleEventWr))
			{
				t = (T)(object)PopulateRuleEvent(from);
			}
			else if (typeof(T) == typeof(goodsWr))
			{
				t = (T)(object)PopulateGoods(from);
			}
			else if (typeof(T) == typeof(customWr))
			{
				t = (T)(object)PopulateCustom(from);
			}
			else if (typeof(T) == typeof(redeemBadgeWr))
			{
				t = (T)(object)PopulateRedeemBadge(from);
			}
			else if (typeof(T) == typeof(quizWr))
			{
				t = (T)(object)PopulateQuiz(from);
			}
			else if (typeof(T) == typeof(quizBasicWr))
			{
				t = (T)(object)PopulateQuizBasic(from);
			}
			else if (typeof(T) == typeof(gradeWr))
			{
				t = (T)(object)PopulateGrade(from);
			}
			else if (typeof(T) == typeof(questionWr))
			{
				t = (T)(object)PopulateQuestion(from);
			}
			else if (typeof(T) == typeof(questionOptionWr))
			{
				t = (T)(object)PopulateQuestionOption(from);
			}
			else if (typeof(T) == typeof(questionAnsweredOptionWr))
			{
				t = (T)(object)PopulateQuestionAnsweredOption(from);
			}
			else if (typeof(T) == typeof(questionAnsweredGradeDoneWr))
			{
				t = (T)(object)PopulateQuestionAnsweredGradeDone(from);
			}
			else if (typeof(T) == typeof(gradeDoneRewardWr))
			{
				t = (T)(object)PopulateGradeDoneReward(from);
			}
			else if (typeof(T) == typeof(quizPendingGradeRewardWr))
			{
				t = (T)(object)PopulateQuizPendingGradeReward(from);
			}
			else if (typeof(T) == typeof(quizPendingWr))
			{
				t = (T)(object)PopulateQuizPending(from);
			}
			else if (typeof(T) == typeof(gradeDoneWr))
			{
				t = (T)(object)PopulateGradeDone(from);
			}
			else if (typeof(T) == typeof(quizDoneWr))
			{
				t = (T)(object)PopulateQuizDone(from);
			}
			else if (typeof(T) == typeof(ruleEventMissionWr))
			{
				t = (T)(object)PopulateRuleEventMission(from);
			}
			else if (typeof(T) == typeof(ruleEventQuestWr))
			{
				t = (T)(object)PopulateRuleEventQuest(from);
			}
			else if (typeof(T) == typeof(badgeWr))
			{
				t = (T)(object)PopulateBadge(from);
			}
			else if (typeof(T) == typeof(goodsInfoWr))
			{
				t = (T)(object)PopulateGoodsInfo(from);
			}
			else if (typeof(T) == typeof(rewardWr))
			{
				t = (T)(object)PopulateReward(from);
			}
			else if (typeof(T) == typeof(missionBasicWr))
			{
				t = (T)(object)PopulateMissionBasic(from);
			}
			else if (typeof(T) == typeof(conditionWr))
			{
				t = (T)(object)PopulateCondition(from);
			}
			else if (typeof(T) == typeof(questBasicWr))
			{
				t = (T)(object)PopulateQuestBasic(from);
			}
			else if (typeof(T) == typeof(completionWr))
			{
				t = (T)(object)PopulateCompletion(from);
			}
			else
			{
				throw new Exception("populate from object type that doesn't support");
			}

			return t;
		}
	}

	#endif
}