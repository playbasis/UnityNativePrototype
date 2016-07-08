using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using System.Runtime.InteropServices;
using AOT;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.InternalModel;
using Playbasis.Wrapper.Helper;

namespace Playbasis.Wrapper.iOS
{
	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP

	// auth()
	public class OnAuthResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool, bool>.resultCallback(userCallback, success);
		}
	}

	// renew()
	public class OnRenewResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool, bool>.resultCallback(userCallback, success);
		}
	}

	// login()
	public class OnLoginResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool, bool>.resultCallback(userCallback, success);
		}
	}

	// logout()
	public class OnLogoutResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool, bool>.resultCallback(userCallback, success);
		}
	}

	// register()
	public class OnRegisterResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool, bool>.resultCallback(userCallback, success);
		}
	}

	// playerPublic()
	public class OnPlayerPublicResult
	{
		public static OnUserDataResultDelegate<playerPublicWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<playerPublicWr, _playerPublicWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// player()
	public class OnPlayerResult
	{
		public static OnUserDataResultDelegate<playerWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<playerWr, _playerWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// pointOfPlayer()
	public class OnPointOfPlayerResult
	{
		public static OnUserDataResultDelegate<pointRWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<pointRWr, _pointRWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizList()
	public class OnQuizListResult
	{
		public static OnUserDataResultDelegate<quizListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizListWr, _quizListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizListOfPlayer()
	public class OnQuizListOfPlayerResult
	{
		public static OnUserDataResultDelegate<quizListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizListWr, _quizListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizDetail()
	public class OnQuizDetailResult
	{
		public static OnUserDataResultDelegate<quizWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizWr, _quizWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizRandom()
	public class OnQuizRandomResult
	{
		public static OnUserDataResultDelegate<quizBasicWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizBasicWr, _quizBasicWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizDoneList()
	public class OnQuizDoneListResult
	{
		public static OnUserDataResultDelegate<List<quizDoneWr>> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<List<quizDoneWr>, _quizDoneListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizPendingList()
	public class OnQuizPendingListResult
	{
		public static OnUserDataResultDelegate<List<quizPendingWr>> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<List<quizPendingWr>, _quizPendingListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizQuestion()
	public class OnQuizQuestionResult
	{
		public static OnUserDataResultDelegate<questionWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questionWr, _questionWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizAnswer()
	public class OnQuizAnswerResult
	{
		public static OnUserDataResultDelegate<questionAnsweredWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questionAnsweredWr, _questionAnsweredWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// rule()
	public class OnRuleResult
	{
		public static OnUserDataResultDelegate<ruleWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<ruleWr, _ruleWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// badge()
	public class OnBadgeResult
	{
		public static OnUserDataResultDelegate<badgeWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<badgeWr, _badgeWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// badges()
	public class OnBadgesResult
	{
		public static OnUserDataResultDelegate<badgesWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<badgesWr, _badgesWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// cancelQuest()
	public class OnCancelQuestResult
	{
		public static OnUserDataResultDelegate<cancelQuestWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<cancelQuestWr, _cancelQuestWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// goodsInfo()
	public class OnGoodsInfoResult
	{
		public static OnUserDataResultDelegate<goodsInfoWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<goodsInfoWr, _goodsInfoWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// goodsInfoList()
	public class OnGoodsInfoListResult
	{
		public static OnUserDataResultDelegate<goodsInfoListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<goodsInfoListWr, _goodsInfoListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// joinAllQuests()
	public class OnJoinAllQuestsResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool, bool>.resultCallback(userCallback, success);
		}
	}

	// joinQuest()
	public class OnJoinQuestResult
	{
		public static OnUserDataResultDelegate<joinQuestWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<joinQuestWr, _joinQuestWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// missionInfo()
	public class OnMissionInfoResult
	{
		public static OnUserDataResultDelegate<missionInfoWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<missionInfoWr, _missionInfoWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// questAvailableForPlayer()
	public class OnQuestAvailableForPlayerResult
	{
		public static OnUserDataResultDelegate<questAvailableForPlayerWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questAvailableForPlayerWr, _questAvailableForPlayerWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// questInfo()
	public class OnQuestInfoResult
	{
		public static OnUserDataResultDelegate<questInfoWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questInfoWr, _questInfoWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// questInfoList()
	public class OnQuestInfoListResult
	{
		public static OnUserDataResultDelegate<questInfoListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questInfoListWr, _questInfoListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// questInfoListForPlayer()
	public class OnQuestInfoListForPlayerResult
	{
		public static OnUserDataResultDelegate<questInfoListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questInfoListWr, _questInfoListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}
	

	#endif
}