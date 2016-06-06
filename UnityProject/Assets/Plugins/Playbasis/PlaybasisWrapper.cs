using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Playbasis.Wrapper.Android;
using Playbasis.Wrapper.iOS;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper {

	/* Interface to native implementations */
	public delegate void OnResultDelegate(bool success);
	public delegate void OnDataResultDelegate(IntPtr data, int errorCode);
	public delegate void OnUserDataResultDelegate<T>(T data, int errorCode);

	public class PlaybasisWrapper : MonoBehaviour {

		// prevent from creating a new object
		private PlaybasisWrapper()
		{
			// nothing here
		}

		#if UNITY_ANDROID
		private static AndroidJavaClass javaUnityPlayer;
		private static AndroidJavaObject currentActivity;
		private static AndroidJavaObject playbasis = null;
		#endif

		// init environment for both Android and iOS
		public static void initialize()
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
		#if UNITY_EDITOR_OSX
		[DllImport ("pblibx86-unitywrapper", EntryPoint = "_version")]
		private static extern string _loadMacOSXLib();
		#endif

		[DllImport ("__Internal")]
		private static extern string _version();

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

		/*
			All implementation of api methods are non-blocking call, but synchronized call for Playbasis Platform.
		*/
		#if UNITY_EDITOR_OSX
		// user needs to call this method first when targeting for iOS or Mac OSX
		public static void loadMacOSXLib()
		{
			_loadMacOSXLib();
		}
		#endif

		public static string version()
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			return _version();
			#elif UNITY_ANDROID
			return playbasis.Call<string>("version");
			#else
			return null;
			#endif
		}

		public static void auth(string apikey, string apisecret, string bundleId, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnAuthResult.userCallback = callback;
			_auth(apikey, apisecret, bundleId, OnAuthResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("auth", apikey, apisecret, new OnAuthTokenResult(callback));
			#endif
		}

		public static void renew(string apikey, string apisecret, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnRenewResult.userCallback = callback;
			_renew(apikey, apisecret, OnRenewResult.onResult);
			#elif UNITY_ANDROID
			playbasis.Call("renew", apikey, apisecret, new OnRenewResult(callback));
			#endif
		}

		public static void login(string playerId, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnLoginResult.userCallback = callback;
			_login(playerId, OnLoginResult.onResult);

			#elif UNITY_ANDROID
			playbasis.Call("login", playerId, new OnLoginResult(callback));
			#endif
		}

		public static void logout(string playerId, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnLogoutResult.userCallback = callback;
			_logout(playerId, OnLogoutResult.onResult);

			#elif UNITY_ANDROID
			playbasis.Call("logout", playerId, new OnLogoutResult(callback));
			#endif
		}

		public static void register(string playerId, string userName, string email, string imageUrl, OnResultDelegate callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnRegisterResult.userCallback = callback;
			_register(playerId, userName, email, imageUrl, OnRegisterResult.onResult);

			#elif UNITY_ANDROID
			playbasis.Call("register", playerId, userName, email, imageUrl, new OnRegisterResult(callback));
			#endif
		}

		public static void playerPublic(string playerId, OnUserDataResultDelegate<playerPublicWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnPlayerPublicResult.userCallback = callback;
			_playerPublic(playerId, OnPlayerPublicResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("playerPublic", playerId, new OnPlayerPublicResult(callback));
			#endif
		}

		public static void player(string playerId, OnUserDataResultDelegate<playerWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnPlayerResult.userCallback = callback;
			_player(playerId, OnPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("player", playerId, new OnPlayerResult(callback));
			#endif
		}

		public static void pointOfPlayer(string playerId, string pointName, OnUserDataResultDelegate<pointRWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnPointOfPlayerResult.userCallback = callback;
			_pointOfPlayer(playerId, pointName, OnPointOfPlayerResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("pointOfPlayer", playerId, pointName, new OnPointOfPlayerResult(callback));
			#endif
		}

		public static void quizList(OnUserDataResultDelegate<quizListWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizListResult.userCallback = callback;
			_quizList(OnQuizListResult.onDataResult);
			#endif
		}

		public static void quizListOfPlayer(string playerId, OnUserDataResultDelegate<quizListWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizListOfPlayerResult.userCallback = callback;
			_quizListOfPlayer(playerId, OnQuizListOfPlayerResult.onDataResult);
			#endif
		}

		public static void quizDetail(string quizId, string playerId, OnUserDataResultDelegate<quizWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizDetailResult.userCallback = callback;
			_quizDetail(quizId, playerId, OnQuizDetailResult.onDataResult);
			#endif
		}

		public static void quizRandom(string playerId, OnUserDataResultDelegate<quizBasicWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizRandomResult.userCallback = callback;
			_quizRandom(playerId, OnQuizRandomResult.onDataResult);
			#endif
		}

		public static void quizDoneList(string playerId, int limit, OnUserDataResultDelegate<quizDoneListWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizDoneListResult.userCallback = callback;
			_quizDoneList(playerId, limit, OnQuizDoneListResult.onDataResult);
			#endif
		}

		public static void quizPendingList(string playerId, int limit, OnUserDataResultDelegate<quizPendingListWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizPendingListResult.userCallback = callback;
			_quizPendingList(playerId, limit, OnQuizPendingListResult.onDataResult);
			#endif
		}

		public static void quizQuestion(string quizId, string playerId, OnUserDataResultDelegate<questionWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizQuestionResult.userCallback = callback;
			_quizQuestion(quizId, playerId, OnQuizQuestionResult.onDataResult);
			#endif
		}

		public static void quizAnswer(string quizId, string optionId, string playerId, string questionId, OnUserDataResultDelegate<questionAnsweredWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnQuizAnswerResult.userCallback = callback;
			_quizAnswer(quizId, optionId, playerId, questionId, OnQuizAnswerResult.onDataResult);
			#endif
		}

		public static void rule(string playerId, string action, OnUserDataResultDelegate<ruleWr> callback)
		{
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			OnRuleResult.userCallback = callback;
			_rule(playerId, action, OnRuleResult.onDataResult);
			#elif UNITY_ANDROID
			playbasis.Call("rule", playerId, action, new OnDataResult<ruleWr>(callback));
			#endif
		}
	}
}