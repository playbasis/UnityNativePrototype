using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper.Android
{
	#if UNITY_ANDROID && !DEBUG_DESKTOP

	// base classes
	// 1. result (bool) returning type
	public class OnResult : AndroidJavaProxy
	{
		public OnResultDelegate userCallback;

		public OnResult(OnResultDelegate callback) : base("com.playbasis.android.playbasissdk.api.OnResult") {
			userCallback = callback;
		}

		public void onSuccess(bool success)
		{
			if (userCallback != null)
			{
				userCallback(success);
			}
		}

		public void onSuccess(AndroidJavaObject result)
		{
			if (userCallback != null)
			{
				userCallback(true);
			}
		}

		public void onError(AndroidJavaObject error)
		{
			if (userCallback != null)
			{
				userCallback(false);
			}
		}
	}

	// 2. data returning type
	public class OnDataResult<T> : AndroidJavaProxy
		where T : new()
	{
		public OnUserDataResultDelegate<T> userCallback;

		public OnDataResult(OnUserDataResultDelegate<T> callback) : base("com.playbasis.android.playbasissdk.api.OnResult") {
			userCallback = callback;
		}

		public void onSuccess(AndroidJavaObject result)
		{
			if (userCallback != null)
			{
				userCallback(onSuccess_user(result), -1);
			}
		}

		// will create an empty struct and return it if user doesn't override it
		public virtual T onSuccess_user(AndroidJavaObject result) {
			T data = new T();
			return data;
		}

		public void onError(AndroidJavaObject error)
		{
			AndroidJavaObject requestError = error.Get<AndroidJavaObject>("requestError");
			int errorCode = requestError.Get<int>("errorCode");

			onError_user(errorCode);

			if (userCallback != null)
			{
				userCallback(new T(), errorCode);
			}
		}

		// do nothing here, allow user to override it
		public virtual void onError_user(int errorCode) {}
	}

	/* Proxy class */
	public class OnAuthTokenResult : OnResult
	{
		public OnAuthTokenResult(OnResultDelegate callback) : base(callback) {}
	}

	public class OnRenewResult : OnResult
	{
		public OnRenewResult(OnResultDelegate callback) : base(callback) {}
	}

	public class OnLoginResult : OnResult
	{
		public OnLoginResult(OnResultDelegate callback) : base(callback) {}
	}

	public class OnLogoutResult : OnResult
	{
		public OnLogoutResult(OnResultDelegate callback) : base(callback) {}
	}

	public class OnRegisterResult : OnResult{
		public OnRegisterResult(OnResultDelegate callback) : base(callback) {}
	}

	public class OnJoinAllQuestsResult : OnResult{
		public OnJoinAllQuestsResult(OnResultDelegate callback) : base(callback) {}
	}

	public class OnPlayerPublicResult : OnDataResult<playerPublicWr>
	{
		public OnPlayerPublicResult(OnUserDataResultDelegate<playerPublicWr> callback) : base(callback) {}

		public override playerPublicWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulatePlayerPublic(result);
		}
	}

	public class OnPlayerResult : OnDataResult<playerWr>
	{
		public OnPlayerResult(OnUserDataResultDelegate<playerWr> callback) : base(callback) {}

		public override playerWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulatePlayer(result);
		}
	}

	public class OnPointOfPlayerResult : OnDataResult<pointRWr>
	{
		public OnPointOfPlayerResult(OnUserDataResultDelegate<pointRWr> callback) : base(callback) {}

		public override pointRWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulatePointOfPlayer(result);
		}
	}

	public class OnQuizListResult : OnDataResult<quizListWr>
	{
		public OnQuizListResult(OnUserDataResultDelegate<quizListWr> callback) : base(callback) {}

		public override quizListWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuizList(result);
		}
	}

	public class OnQuizListOfPlayerResult : OnDataResult<quizListWr>
	{
		public OnQuizListOfPlayerResult(OnUserDataResultDelegate<quizListWr> callback) : base(callback) {}

		public override quizListWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuizList(result);
		}
	}

	public class OnQuizDetailResult : OnDataResult<quizWr>
	{
		public OnQuizDetailResult(OnUserDataResultDelegate<quizWr> callback) : base(callback) {}
		
		public override quizWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuiz(result);
		}
	}

	public class OnQuizRandomResult : OnDataResult<quizBasicWr>
	{
		public OnQuizRandomResult(OnUserDataResultDelegate<quizBasicWr> callback) : base(callback) {}

		public override quizBasicWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuizBasic(result);
		}
	}

	public class OnQuizQuestionResult : OnDataResult<questionWr>
	{
		public OnQuizQuestionResult(OnUserDataResultDelegate<questionWr> callback) : base(callback) {}

		public override questionWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuestion(result);
		}
	}

	public class OnQuizAnswerResult : OnDataResult<questionAnsweredWr>
	{
		public OnQuizAnswerResult(OnUserDataResultDelegate<questionAnsweredWr> callback) : base(callback) {}

		public override questionAnsweredWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuestionAnswered(result);
		}
	}

	public class OnQuizPendingListResult : OnDataResult<List<quizPendingWr>>
	{
		public OnQuizPendingListResult(OnUserDataResultDelegate<List<quizPendingWr>> callback) : base(callback) {}

		public override List<quizPendingWr> onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateArrayData<quizPendingWr>(result);
		}
	}

	public class OnQuizDoneListResult : OnDataResult<List<quizDoneWr>>
	{
		public OnQuizDoneListResult(OnUserDataResultDelegate<List<quizDoneWr>> callback) : base(callback) {}

		public override List<quizDoneWr> onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateArrayData<quizDoneWr>(result);
		}
	}

	public class OnRuleResult : OnDataResult<ruleWr>
	{
		public OnRuleResult(OnUserDataResultDelegate<ruleWr> callback) : base(callback) {}

		public override ruleWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateRule(result);
		}
	}

	public class OnBadgeResult : OnDataResult<badgeWr>
	{
		public OnBadgeResult(OnUserDataResultDelegate<badgeWr> callback) : base(callback) {}

		public override badgeWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateBadge(result);
		}
	}

	public class OnBadgesResult : OnDataResult<badgesWr>
	{
		public OnBadgesResult(OnUserDataResultDelegate<badgesWr> callback) : base(callback) {}

		public override badgesWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateBadges(result);
		}
	}

	public class OnGoodsInfoResult : OnDataResult<goodsInfoWr>
	{
		public OnGoodsInfoResult(OnUserDataResultDelegate<goodsInfoWr> callback) : base(callback) {}

		public override goodsInfoWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateGoodsInfo(result);
		}
	}

	public class OnGoodsInfoListResult : OnDataResult<goodsInfoListWr>
	{
		public OnGoodsInfoListResult(OnUserDataResultDelegate<goodsInfoListWr> callback) : base(callback) {}

		public override goodsInfoListWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateGoodsInfoList(result);
		}
	}

	public class OnQuestInfoResult : OnDataResult<questInfoWr>
	{
		public OnQuestInfoResult(OnUserDataResultDelegate<questInfoWr> callback) : base(callback) {}

		public override questInfoWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuestInfo(result);
		}
	}

	public class OnQuestInfoListResult : OnDataResult<questInfoListWr>
	{
		public OnQuestInfoListResult(OnUserDataResultDelegate<questInfoListWr> callback) : base(callback) {}

		public override questInfoListWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuestInfoList(result);
		}
	}

	public class OnMissionInfoResult : OnDataResult<missionInfoWr>
	{
		public OnMissionInfoResult(OnUserDataResultDelegate<missionInfoWr> callback) : base(callback) {}

		public override missionInfoWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateMissionInfo(result);
		}
	}

	public class OnQuestInfoListForPlayerResult : OnDataResult<questInfoListWr>
	{
		public OnQuestInfoListForPlayerResult(OnUserDataResultDelegate<questInfoListWr> callback) : base(callback) {}

		public override questInfoListWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuestInfoListForPlayer(result);
		}
	}

	public class OnQuestAvailableForPlayerResult : OnDataResult<questAvailableForPlayerWr>
	{
		public OnQuestAvailableForPlayerResult(OnUserDataResultDelegate<questAvailableForPlayerWr> callback) : base(callback) {}

		public override questAvailableForPlayerWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateQuestAvailableForPlayer(result);
		}
	}

	public class OnJoinQuestResult : OnDataResult<joinQuestWr>
	{
		public OnJoinQuestResult(OnUserDataResultDelegate<joinQuestWr> callback) : base(callback) {}

		public override joinQuestWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateJoinQuest(result);
		}
	}

	public class OnCancelQuestResult : OnDataResult<cancelQuestWr>
	{
		public OnCancelQuestResult(OnUserDataResultDelegate<cancelQuestWr> callback) : base(callback) {}

		public override cancelQuestWr onSuccess_user(AndroidJavaObject result)
		{
			return AndroidPopulator.PopulateCancelQuest(result);
		}
	}

	#endif
}