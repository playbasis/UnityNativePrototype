using UnityEngine;
using System.Collections;
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
		/// make async request for boolean type result
		private void CallWWW_result_async(string address, WWWForm data, OnResultDelegate callback, RequestType type)
		{
			MonoUtil.GetMainObj().StartCoroutine(CallWWW_result_asyncCR(address, data, callback, type));	
		}
		IEnumerator CallWWW_result_asyncCR(string address, WWWForm data, OnResultDelegate callback, RequestType type)
		{
			string fullAddress = BASE_URL + address + (address.Contains("?") ? "&"+apiKeyParam : "?"+apiKeyParam);
			Debug.Log("Making async request to " + fullAddress);

			WWW client = null;
			if (data != null)
			{
				client = new WWW(fullAddress, data.data, data.headers);
				yield return client;
			}
			else
			{
				client = new WWW(fullAddress);
				yield return client;
			}

			// if there was error then return immediately
			if (IsError(client))
			{
				if (callback != null)
				{
					callback(false);
				}
			}
			else
			{
				// otherwise, check for actual success flag
				bool success = false;

				if (type == RequestType.Auth ||
					type == RequestType.Renew)
				{
					// parse basic result to check its success flag first
					_basicResult result = JsonConvert.DeserializeObject<_basicResult>(client.text, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
					success = result.success;

					// save token if success
					if (success)
					{
						JObject jsonObj = JObject.Parse(client.text);
						_authWr auth = JsonConvert.DeserializeObject<_authWr>(jsonObj["response"].ToString(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
						token = auth.token;
					}
				}
				else
				{
					// parse basic result to check its success flag first
					_basicResult result = JsonConvert.DeserializeObject<_basicResult>(client.text, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
					success = result.success;
				}

				// execute callback
				if (callback != null)
				{
					callback(success);
				}
			}
		}

		/// make async request for data type result
		private void CallWWW_resultData_async<T>(string address, WWWForm data, OnUserDataResultDelegate<T> callback, RequestType type)
			where T : class
		{
			MonoUtil.GetMainObj().StartCoroutine(CallWWW_resultData_asyncCR<T>(address, data, callback, type));
		}
		IEnumerator CallWWW_resultData_asyncCR<T>(string address, WWWForm data, OnUserDataResultDelegate<T> callback, RequestType type)
			where T : class
		{
			string fullAddress = BASE_URL + address + (address.Contains("?") ? "&"+apiKeyParam : "?"+apiKeyParam);
			Debug.Log("Making async request to " + fullAddress);

			WWW client = null;
			if (data != null)
			{
				client = new WWW(fullAddress, data.data, data.headers);
				yield return client;
			}
			else
			{
				client = new WWW(fullAddress);
				yield return client;
			}

			// if there was error then return immediately
			if (IsError(client))
			{
				if (callback != null)
				{
					callback(null, 0);
				}
			}
			else
			{
				T dataReturn = null;
				int errorCode = 0;
				if (HandleRequest<T>(type, ref dataReturn, ref errorCode, client))
				{
					if (callback != null)
					{
						callback<T>(dataReturn, -1);
					}
				}
				else
				{
					if (callback != null)
					{
						callback<T>(null, errorCode);
					}
				}
			}
		}

		/// <summary>Handle data-result request</summary>
		/// <param name="type">Type of request</param>
		/// <param name="data">Data being returned</param>
		/// <param name="errorCode">Error code to be returned</param>
		/// <param name="client">WWW result</param>
		/// <returns>True if request being handled is regarded as success, otherwise return false.</returns>
		private bool HandleRequest<T>(RequestType type, ref T data, ref int errorCode, WWW client)
			where T : class
		{
			_basicResult result = JsonConvert.DeserializeObject<_basicResult>(client.text, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
			if (!result.success)
			{
				// set error code
				errorCode = Int32.Parse(result.error_code);
				return false;
			}
			else
			{
				errorCode = Int32.Parse(result.error_code);
				// set error code to -1 as we use in plugin-wide
				if (errorCode == 0)
					errorCode = -1;
			}

			// message success, then parse json data
			JObject jsonObj = JObject.Parse(client.text);
			// get migrated data
			switch(type)
			{
				case RequestType.PlayerPublic:
					data = (T)(object)DesktopHelper.Migrate<playerPublicWr, _playerPublicWr>(jsonObj["response"]["player"].ToString());
					break;
				case RequestType.Player:
					data = (T)(object)DesktopHelper.Migrate<playerWr, _playerWr>(jsonObj["response"]["player"].ToString());
					break;
				case RequestType.PointOfPlayer:
					data = (T)(object)DesktopHelper.Migrate<pointRWr, _pointRWr>(jsonObj["response"].ToString());
					break;
				case RequestType.QuizList:
					data = (T)(object)DesktopHelper.Migrate<quizListWr, _quizListWr>(jsonObj["response"].ToString());
					break;
				case RequestType.QuizListOfPlayer:
					data = (T)(object)DesktopHelper.Migrate<quizListWr, _quizListWr>(jsonObj["response"].ToString());
					break;
				case RequestType.QuizDetail:
					data = (T)(object)DesktopHelper.Migrate<quizWr, _quizWr>(jsonObj["response"]["result"].ToString());
					break;
				case RequestType.QuizRandom:
					data = (T)(object)DesktopHelper.Migrate<quizBasicWr, _quizBasicWr>(jsonObj["response"]["result"].ToString());
					break;
				case RequestType.QuizDoneList:
					data = (T)(object)DesktopHelper.MigrateList<quizDoneWr, _quizDoneWr>(jsonObj["response"]["result"].ToString());
					break;
				case RequestType.QuizPendingList:
					data = (T)(object)DesktopHelper.MigrateList<quizPendingWr, _quizPendingWr>(jsonObj["response"]["result"].ToString());
					break;
				case RequestType.QuizQuestion:
					data = (T)(object)DesktopHelper.Migrate<questionWr, _questionWr>(jsonObj["response"]["result"].ToString());
					break;
				case RequestType.QuizAnswer:
					data = (T)(object)DesktopHelper.Migrate<questionAnsweredWr, _questionAnsweredWr>(jsonObj["response"]["result"].ToString());
					break;
				case RequestType.Rule:
					data = (T)(object)DesktopHelper.Migrate<ruleWr, _ruleWr>(jsonObj["response"].ToString());
					break;
				case RequestType.Badge:
					data = (T)(object)DesktopHelper.Migrate<badgeWr, _badgeWr>(jsonObj["response"]["badge"].ToString());
					break;
				case RequestType.Badges:
					data = (T)(object)DesktopHelper.Migrate<badgesWr, _badgesWr>(jsonObj["response"].ToString());
					break;
				case RequestType.GoodsInfo:
					data = (T)(object)DesktopHelper.Migrate<goodsInfoWr, _goodsInfoWr>(jsonObj["response"]["goods"].ToString());
					break;
				case RequestType.GoodsInfoList:
					data = (T)(object)DesktopHelper.Migrate<goodsInfoListWr, _goodsInfoListWr>(jsonObj["response"].ToString());
					break;
				case RequestType.QuestInfo:
					data = (T)(object)DesktopHelper.Migrate<questInfoWr, _questInfoWr>(jsonObj["response"]["quest"].ToString());
					break;
				case RequestType.QuestInfoList:
					data = (T)(object)DesktopHelper.Migrate<questInfoListWr, _questInfoListWr>(jsonObj["response"].ToString());
					break;
				case RequestType.MissionInfo:
					data = (T)(object)DesktopHelper.Migrate<missionInfoWr, _missionInfoWr>(jsonObj["response"].ToString());
					break;
				case RequestType.QuestInfoListForPlayer:
					data = (T)(object)DesktopHelper.Migrate<questInfoListWr, _questInfoListWr>(jsonObj["response"].ToString());
					break;
				case RequestType.QuestAvailable:
					data = (T)(object)DesktopHelper.Migrate<questAvailableForPlayerWr, _questAvailableForPlayerWr>(jsonObj["response"].ToString());
					break;
				case RequestType.JoinQuest:
					data = (T)(object)DesktopHelper.Migrate<joinQuestWr, _joinQuestWr>(jsonObj["response"]["events"].ToString());
					break;
				case RequestType.CancelQuest:
					data = (T)(object)DesktopHelper.Migrate<cancelQuestWr, _cancelQuestWr>(jsonObj["response"]["events"].ToString());
					break;
			}

			return true;
		}

		public bool IsError(WWW client)
	    {
	        if (!string.IsNullOrEmpty(client.error))
	            return true;
	        return false;
	    }

		public static T JsonToObject<T>(string json)
		{
			return UnityEngine.JsonUtility.FromJson<T>(json);
		}
	}

	#endif
}