using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Model;
using Playbasis.Wrapper.Desktop.Helper;
using Playbasis.Wrapper.Mono;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Playbasis.Wrapper.Desktop.Net
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public partial class DesktopNet
	{
		public static string BASE_URL = "https://api.pbapp.net/";
		private string apiKeyParam;
		private string token;

		public delegate void OnWWWComplete(WWW result);

		public void Auth(string apiKey, string apiSecret, OnResultDelegate callback)
		{
			// form apikey-param to append to address later when execute async call
			apiKeyParam = "api_key=" + apiKey;

			WWWForm form = new WWWForm();
			form.AddField("api_key", apiKey);
			form.AddField("api_secret", apiSecret);
			CallWWW_result_async("Auth", form, callback, RequestType.Auth);
		}

		public void Renew(string apiKey, string apiSecret, OnResultDelegate callback)
		{
			// form apikey-param to append to address later when execute async call
			apiKeyParam = "api_key=" + apiKey;

			WWWForm form = new WWWForm();
			form.AddField("api_key", apiKey);
			form.AddField("api_secret", apiSecret);
			CallWWW_result_async("Auth/renew", form, callback, RequestType.Renew);
		}

		public void Login(string playerId, OnResultDelegate callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			CallWWW_result_async("Player/" + playerId + "/login", form, callback, RequestType.Login);
		}

		public void Logout(string playerId, OnResultDelegate callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			CallWWW_result_async("Player/" + playerId + "/logout", form, callback, RequestType.Logout);
		}

		public void Register(string playerId, string userName, string email, string imageUrl, OnResultDelegate callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			form.AddField("username", playerId);
			form.AddField("email", email);
			form.AddField("image", imageUrl);

			CallWWW_result_async("Player/" + playerId + "/register", form, callback, RequestType.Register);
		}

		public void PlayerPublic(string playerId, OnUserDataResultDelegate<playerPublicWr> callback)
		{
			CallWWW_resultData_async("Player/" + playerId, null, callback, RequestType.PlayerPublic);
		}

		public void Player(string playerId, OnUserDataResultDelegate<playerWr> callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			CallWWW_resultData_async("Player/" + playerId, form, callback, RequestType.Player);
		}

		public void PointOfPlayer(string playerId, string pointName, OnUserDataResultDelegate<pointRWr> callback)
		{
			CallWWW_resultData_async("Player/" + playerId + "/point/" + pointName, null, callback, RequestType.PointOfPlayer);
		}

		public void QuizList(OnUserDataResultDelegate<quizListWr> callback)
		{
			CallWWW_resultData_async("Quiz/list", null, callback, RequestType.QuizList);
		}

		public void QuizListOfPlayer(string playerId, OnUserDataResultDelegate<quizListWr> callback)
		{
			CallWWW_resultData_async("Quiz/list?player_id=" + playerId, null, callback, RequestType.QuizListOfPlayer);
		}

		public void QuizDetail(string quizId, string playerId, OnUserDataResultDelegate<quizWr> callback)
		{
			CallWWW_resultData_async("Quiz/" + quizId + "/detail?player_id=" + playerId, null, callback, RequestType.QuizDetail);
		}

		public void QuizRandom(string playerId, OnUserDataResultDelegate<quizBasicWr> callback)
		{
			CallWWW_resultData_async("Quiz/random?player_id=" + playerId, null, callback, RequestType.QuizRandom);
		}

		public void QuizDoneList(string playerId, int limit, OnUserDataResultDelegate<List<quizDoneWr>> callback)
		{
			CallWWW_resultData_async("Quiz/player/" + playerId + "/" + limit, null, callback, RequestType.QuizDoneList);
		}

		public void QuizPendingList(string playerId, int limit, OnUserDataResultDelegate<List<quizPendingWr>> callback)
		{
			CallWWW_resultData_async("Quiz/player/" + playerId + "/pending/" + limit, null, callback, RequestType.QuizPendingList);
		}

		public void QuizQuestion(string quizId, string playerId, OnUserDataResultDelegate<questionWr> callback)
		{
			CallWWW_resultData_async("Quiz/" + quizId + "/question?player_id=" + playerId, null, callback, RequestType.QuizQuestion);
		}

		public void QuizAnswer(string quizId, string optionId, string playerId, string questionId, OnUserDataResultDelegate<questionAnsweredWr> callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			form.AddField("player_id", playerId);
			form.AddField("question_id", questionId);
			form.AddField("option_id", optionId);

			CallWWW_resultData_async("Quiz/" + quizId + "/answer", form, callback, RequestType.QuizAnswer);
		}

		public void Rule(string playerId, string action, OnUserDataResultDelegate<ruleWr> callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			form.AddField("player_id", playerId);
			form.AddField("action", action);

			CallWWW_resultData_async("Engine/rule", form, callback, RequestType.Rule);
		}

		public void Badge(string badgeId, OnUserDataResultDelegate<badgeWr> callback)
		{
			CallWWW_resultData_async("Badge/" + badgeId, null, callback, RequestType.Badge);
		}

		public void Badges(OnUserDataResultDelegate<badgesWr> callback)
		{
			CallWWW_resultData_async("Badges", null, callback, RequestType.Badges);
		}		

		public void GoodsInfo(string goodsId, OnUserDataResultDelegate<goodsInfoWr> callback)
		{
			CallWWW_resultData_async("Goods/" + goodsId, null, callback, RequestType.GoodsInfo);
		}

		public void GoodsInfoList(string playerId, OnUserDataResultDelegate<goodsInfoListWr> callback)
		{
			CallWWW_resultData_async("Goods?player_id="+playerId, null, callback, RequestType.GoodsInfoList);
		}

		public void QuestInfo(string questId, OnUserDataResultDelegate<questInfoWr> callback)
		{
			CallWWW_resultData_async("Quest/" + questId, null, callback, RequestType.QuestInfo);
		}

		public void QuestInfoList(OnUserDataResultDelegate<questInfoListWr> callback)
		{
			CallWWW_resultData_async("Quest", null, callback, RequestType.QuestInfoList);
		}

		public void MissionInfo(string questId, string missionId, OnUserDataResultDelegate<missionInfoWr> callback)
		{
			CallWWW_resultData_async("Quest/" + questId + "/mission/" + missionId, null, callback, RequestType.MissionInfo);
		}

		public void QuestInfoListForPlayer(string playerId, OnUserDataResultDelegate<questInfoListWr> callback)
		{
			CallWWW_resultData_async("Quest/available?player_id=" + playerId, null, callback, RequestType.QuestInfoListForPlayer);
		}

		public void QuestAvailableForPlayer(string questId, string playerId, OnUserDataResultDelegate<questAvailableForPlayerWr> callback)
		{
			CallWWW_resultData_async("Quest/" + questId + "/available?player_id=" + playerId, null, callback, RequestType.QuestAvailable);
		}

		public void JoinQuest(string questId, string playerId, OnUserDataResultDelegate<joinQuestWr> callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			form.AddField("player_id", playerId);
			CallWWW_resultData_async("Quest/" + questId + "/join", form, callback, RequestType.JoinQuest);
		}

		public void JoinAllQuests(string playerId, OnResultDelegate callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			form.AddField("player_id", playerId);
			CallWWW_result_async("Quest/joinAll", form, callback, RequestType.JoinAllQuests);
		}

		public void CancelQuest(string questId, string playerId, OnUserDataResultDelegate<cancelQuestWr> callback)
		{
			WWWForm form = new WWWForm();
			form.AddField("token", token);
			form.AddField("player_id", playerId);
			CallWWW_resultData_async("Quest/" + questId + "/cancel", form, callback, RequestType.CancelQuest);
		}
	}

	#endif
}