using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Playbasis.Wrapper.Android;
using Playbasis.Wrapper.iOS;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Mono;

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
using Playbasis.Wrapper.Desktop;
using Playbasis.Wrapper.Desktop.Net;
#endif

namespace Playbasis.Wrapper {

	/* Interface to native implementations */
	public delegate void OnResultDelegate(bool success);
	public delegate void OnDataResultDelegate(IntPtr data, int errorCode);
	public delegate void OnUserDataResultDelegate<T>(T data, int errorCode);

	/// <summary>Playbasis wrapper class</summary>
	public class PlaybasisWrapper : MonoBehaviour {

		private static PlaybasisWrapper instance = null;
		private PlaybasisWrapper()	{ }

		public static PlaybasisWrapper Instance
		{
			get { return instance; }
			// to allow setting of instance in unit test
			// in run time, users should not use this setter
			set { instance = value; }
		}

		#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
		private DesktopNet desktopNetInstance = null;
		public DesktopNet DesktopNet
		{
			get {
				if (instance == null)
					return null;

				if (desktopNetInstance == null)
				{
					desktopNetInstance = new DesktopNet();
				}

				return desktopNetInstance;
			}
		}
		#endif

		void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(this.gameObject);
			}
			else
			{
				instance = this;
			}

			// trick to load os x desktop library if needed
			#if UNITY_STANDALONE_OSX || UNITY_IOS && !DEBUG_DESKTOP
			PlaybasisWrapper.Instance.loadMacOSXLib();
			Debug.Log("loaded Playbasis plugin osx desktop library");
			#endif

			DontDestroyOnLoad(this.gameObject);
		}		

		#if UNITY_ANDROID
		private AndroidJavaClass javaUnityPlayer;
		private AndroidJavaObject currentActivity;
		private AndroidJavaObject playbasis = null;
		#endif

		// init environment for both Android and iOS
		public void initialize()
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			// do nothing for initialization for these both platforms as of now
			#elif UNITY_ANDROID
			javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			playbasis = new AndroidJavaObject("io.wasin.wrapper.playbasis.PlaybasisAndroidWrapper", currentActivity);
			#endif

			Debug.Log("Initialized PlaybasisWrapper successfully");
		}

		/*
			Playbasis classes
		*/
		#if UNITY_STANDALONE_OSX || UNITY_IOS
		[DllImport ("pblibx86-unitywrapper", EntryPoint = "_version")]
		private static extern string _loadMacOSXLib();
		#endif

		[DllImport ("__Internal")]
		private static extern string _version();

		[DllImport ("__Internal")]
		private static extern string _getServerUrl();

		[DllImport ("__Internal")]
		private static extern void _setServerUrl(string url);

		[DllImport ("__Internal")]
		private static extern string _getServerAsyncUrl();

		[DllImport ("__Internal")]
		private static extern void _setServerAsyncUrl(string url);

		[DllImport ("__Internal")]
		private static extern void _auth(string apikey, string apisecret, string bundleId, OnResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _renew(string apikey, string apisecret, OnResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _login(string playerId, OnResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _logout(string playerId, OnResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _register(string playerId, string userName, string email, string imageUrl, OnResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _playerPublic(string playerId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _player(string playerId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _pointOfPlayer(string playerId, string pointName, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizList(OnDataResultDelegate callack);

		[DllImport ("__Internal")]
		private static extern void _quizListOfPlayer(string playerId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizDetail(string quizId, string playerId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizRandom(string playerId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizDoneList(string playerId, int limit, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizPendingList(string playerId, int limit, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizQuestion(string quizId, string playerId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _quizAnswer(string quizId, string optionId, string playerId, string questionId, OnDataResultDelegate callback);

		[DllImport ("__Internal")]
		private static extern void _rule(string playerId, string action, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
	    private static extern void _badges(OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
	    private static extern void _badge(string badgeId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
	    private static extern void _goodsInfo(string goodsId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
	    private static extern void _goodsInfoList(string playerId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _questInfo(string questId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
	    private static extern void _questInfoList(OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _missionInfo(string questId, string missionId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _questInfoListForPlayer(string playerId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _questAvailableForPlayer(string questId, string playerId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _joinQuest(string questId, string playerId, OnDataResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _joinAllQuests(string playerId, OnResultDelegate callback);
		
		[DllImport ("__Internal")]
		private static extern void _cancelQuest(string questId, string playerId, OnDataResultDelegate callback);

		/*
			All implementation of api methods are non-blocking call, but synchronized call for Playbasis Platform.
		*/
		#if UNITY_STANDALONE_OSX || UNITY_IOS
		// user needs to call this method first when targeting for iOS or Mac OSX
		private void loadMacOSXLib()
		{

			_loadMacOSXLib();
		}
		#endif

		public string version()
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			return _version();
			#elif UNITY_ANDROID
			return playbasis.Call<string>("version");
			#else
			return null;
			#endif
		}

		public string getServerUrl()
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			return _getServerUrl();
			#elif UNITY_ANDROID
			return null;
			#else
			return null;
			#endif
		}

		public void setServerUrl(string url)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			_setServerUrl(url);
			#elif UNITY_ANDROID

			#endif
		}

		public string getServerAsyncUrl()
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			return _getServerAsyncUrl();
			#elif UNITY_ANDROID
			return null;
			#else
			return null;
			#endif
		}

		public void setServerAsyncUrl(string url)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			_setServerAsyncUrl(url);
			#elif UNITY_ANDROID
			#endif
		}

		public void auth(string apikey, string apisecret, string bundleId, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnAuthResult.userCallback = callback;
			_auth(apikey, apisecret, bundleId, OnAuthResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("auth", apikey, apisecret, new OnAuthTokenResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Auth(apikey, apisecret, callback);
			#endif
		}

		public void renew(string apikey, string apisecret, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnRenewResult.userCallback = callback;
			_renew(apikey, apisecret, OnRenewResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("renew", apikey, apisecret, new OnRenewResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Renew(apikey, apisecret, callback);
			#endif
		}

		public void login(string playerId, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnLoginResult.userCallback = callback;
			_login(playerId, OnLoginResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("login", playerId, new OnLoginResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Login(playerId, callback);
			#endif
		}

		public void logout(string playerId, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnLogoutResult.userCallback = callback;
			_logout(playerId, OnLogoutResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("logout", playerId, new OnLogoutResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Logout(playerId, callback);
			#endif
		}

		public void register(string playerId, string userName, string email, string imageUrl, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnRegisterResult.userCallback = callback;
			_register(playerId, userName, email, imageUrl, OnRegisterResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("register", playerId, userName, email, imageUrl, new OnRegisterResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Register(playerId, userName, email, imageUrl, callback);
			#endif
		}

		public void playerPublic(string playerId, OnUserDataResultDelegate<playerPublicWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnPlayerPublicResult.userCallback = callback;
			_playerPublic(playerId, OnPlayerPublicResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("playerPublic", playerId, new OnPlayerPublicResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.PlayerPublic(playerId, callback);
			#endif
		}

		public void player(string playerId, OnUserDataResultDelegate<playerWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnPlayerResult.userCallback = callback;
			_player(playerId, OnPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("player", playerId, new OnPlayerResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Player(playerId, callback);
			#endif
		}

		public void pointOfPlayer(string playerId, string pointName, OnUserDataResultDelegate<pointRWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnPointOfPlayerResult.userCallback = callback;
			_pointOfPlayer(playerId, pointName, OnPointOfPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("pointOfPlayer", playerId, pointName, new OnPointOfPlayerResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.PointOfPlayer(playerId, pointName, callback);
			#endif
		}

		public void quizList(OnUserDataResultDelegate<quizListWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizListResult.userCallback = callback;
			_quizList(OnQuizListResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizList", new OnQuizListResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizList(callback);
			#endif
		}

		public void quizListOfPlayer(string playerId, OnUserDataResultDelegate<quizListWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizListOfPlayerResult.userCallback = callback;
			_quizListOfPlayer(playerId, OnQuizListOfPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizListOfPlayer", playerId, new OnQuizListOfPlayerResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizListOfPlayer(playerId, callback);
			#endif
		}

		public void quizDetail(string quizId, string playerId, OnUserDataResultDelegate<quizWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizDetailResult.userCallback = callback;
			_quizDetail(quizId, playerId, OnQuizDetailResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizDetail", quizId, playerId, new OnQuizDetailResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizDetail(quizId, playerId, callback);
			#endif
		}

		public void quizRandom(string playerId, OnUserDataResultDelegate<quizBasicWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizRandomResult.userCallback = callback;
			_quizRandom(playerId, OnQuizRandomResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizRandom", playerId, new OnQuizRandomResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizRandom(playerId, callback);
			#endif
		}

		public void quizDoneList(string playerId, int limit, OnUserDataResultDelegate<List<quizDoneWr>> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizDoneListResult.userCallback = callback;
			_quizDoneList(playerId, limit, OnQuizDoneListResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizDoneList", playerId, limit, new OnQuizDoneListResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizDoneList(playerId, limit, callback);
			#endif
		}

		public void quizPendingList(string playerId, int limit, OnUserDataResultDelegate<List<quizPendingWr>> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizPendingListResult.userCallback = callback;
			_quizPendingList(playerId, limit, OnQuizPendingListResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizPendingList", playerId, limit, new OnQuizPendingListResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizPendingList(playerId, limit, callback);
			#endif
		}

		public void quizQuestion(string quizId, string playerId, OnUserDataResultDelegate<questionWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizQuestionResult.userCallback = callback;
			_quizQuestion(quizId, playerId, OnQuizQuestionResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizQuestion", quizId, playerId, new OnQuizQuestionResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizQuestion(quizId, playerId, callback);
			#endif
		}

		public void quizAnswer(string quizId, string optionId, string playerId, string questionId, OnUserDataResultDelegate<questionAnsweredWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuizAnswerResult.userCallback = callback;
			_quizAnswer(quizId, optionId, playerId, questionId, OnQuizAnswerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("quizAnswer", quizId, optionId, playerId, questionId, new OnQuizAnswerResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuizAnswer(quizId, optionId, playerId, questionId, callback);
			#endif
		}

		public void rule(string playerId, string action, OnUserDataResultDelegate<ruleWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnRuleResult.userCallback = callback;
			_rule(playerId, action, OnRuleResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("rule", playerId, action, new OnRuleResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Rule(playerId, action, callback);
			#endif
		}
		
	    public void badge(string badgeId, OnUserDataResultDelegate<badgeWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnBadgeResult.userCallback = callback;
			_badge(badgeId, OnBadgeResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("badge", badgeId, new OnBadgeResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Badge(badgeId, callback);
			#endif
	    }
		
		public void badges(OnUserDataResultDelegate<badgesWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnBadgesResult.userCallback = callback;
			_badges(OnBadgesResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("badges", new OnBadgesResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.Badges(callback);
			#endif
		}
		
	    public void goodsInfo(string goodsId, OnUserDataResultDelegate<goodsInfoWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnGoodsInfoResult.userCallback = callback;
			_goodsInfo(goodsId, OnGoodsInfoResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("goodsInfo", goodsId, null, new OnGoodsInfoResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.GoodsInfo(goodsId, callback);
			#endif
	    }
		
	    public void goodsInfoList(string playerId, OnUserDataResultDelegate<goodsInfoListWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnGoodsInfoListResult.userCallback = callback;
			_goodsInfoList(playerId, OnGoodsInfoListResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("goodsInfoList", playerId, new OnGoodsInfoListResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.GoodsInfoList(playerId, callback);
			#endif
	    }
		
		public void questInfo(string questId, OnUserDataResultDelegate<questInfoWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuestInfoResult.userCallback = callback;
			_questInfo(questId, OnQuestInfoResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("questInfo", questId, new OnQuestInfoResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuestInfo(questId, callback);
			#endif
		}
		
	    public void questInfoList(OnUserDataResultDelegate<questInfoListWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuestInfoListResult.userCallback = callback;
			_questInfoList(OnQuestInfoListResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("questInfoList", new OnQuestInfoListResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuestInfoList(callback);
			#endif
	    }
		
		public void missionInfo(string questId, string missionId, OnUserDataResultDelegate<missionInfoWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnMissionInfoResult.userCallback = callback;
			_missionInfo(questId, missionId, OnMissionInfoResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("missionInfo", questId, missionId, new OnMissionInfoResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.MissionInfo(questId, missionId, callback);
			#endif
		}
		
		public void questInfoListForPlayer(string playerId, OnUserDataResultDelegate<questInfoListWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuestInfoListForPlayerResult.userCallback = callback;
			_questInfoListForPlayer(playerId, OnQuestInfoListForPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("questInfoListForPlayer", playerId, new OnQuestInfoListForPlayerResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuestInfoListForPlayer(playerId, callback);
			#endif
		}
		
		public void questAvailableForPlayer(string questId, string playerId, OnUserDataResultDelegate<questAvailableForPlayerWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnQuestAvailableForPlayerResult.userCallback = callback;
			_questAvailableForPlayer(questId, playerId, OnQuestAvailableForPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("questAvailableForPlayer", questId, playerId, new OnQuestAvailableForPlayerResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.QuestAvailableForPlayer(questId, playerId, callback);
			#endif
		}
		
		public void joinQuest(string questId, string playerId, OnUserDataResultDelegate<joinQuestWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnJoinQuestResult.userCallback = callback;
			_joinQuest(questId, playerId, OnJoinQuestResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("joinQuest", questId, playerId, new OnJoinQuestResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.JoinQuest(questId, playerId, callback);
			#endif
		}
		
		public void joinAllQuests(string playerId, OnResultDelegate callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnJoinAllQuestsResult.userCallback = callback;
			_joinAllQuests(playerId, OnJoinAllQuestsResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("joinAllQuests", playerId, new OnJoinAllQuestsResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.JoinAllQuests(playerId, callback);
			#endif
		}
		
		public void cancelQuest(string questId, string playerId, OnUserDataResultDelegate<cancelQuestWr> callback) {
	    	#if UNITY_IOS || UNITY_STANDALONE_OSX && !DEBUG_DESKTOP
			OnCancelQuestResult.userCallback = callback;
			_cancelQuest(questId, playerId, OnCancelQuestResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("cancelQuest", questId, playerId, new OnCancelQuestResult(callback));
			#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP
			this.DesktopNet.CancelQuest(questId, playerId, callback);
			#endif
		}
	}
}