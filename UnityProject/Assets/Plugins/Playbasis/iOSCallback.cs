using UnityEngine;
using System;
using Playbasis.Wrapper;
using System.Runtime.InteropServices;
using AOT;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper.iOS
{
	#if UNITY_IOS || UNITY_STANDALONE_OSX

	public class Helper<T>
		where T : new()
	{
		public static void resultCallback(OnResultDelegate userCallback, bool success)
		{
			if (userCallback != null)
			{
				userCallback(success);
			}
		}

		public static void dataResultCallback(OnUserDataResultDelegate<T> userCallback, IntPtr result, int errorCode)
		{
			if (result != IntPtr.Zero)
			{
				if (userCallback != null)
				{
					userCallback(onSuccess_user(result), -1);
				}
			}
			else
			{
				if (userCallback != null)
				{
					userCallback(new T(), errorCode);
				}
			}
		}

		private static T onSuccess_user(IntPtr result)
		{
			return (T)Marshal.PtrToStructure(result, typeof(T));
		}
	}

	// auth()
	public class OnAuthResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool>.resultCallback(userCallback, success);
		}
	}

	// renew()
	public class OnRenewResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool>.resultCallback(userCallback, success);
		}
	}

	// login()
	public class OnLoginResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool>.resultCallback(userCallback, success);
		}
	}

	// logout()
	public class OnLogoutResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool>.resultCallback(userCallback, success);
		}
	}

	// register()
	public class OnRegisterResult
	{
		public static OnResultDelegate userCallback;

		[MonoPInvokeCallback(typeof(OnResultDelegate))]
		public static void onResult(bool success)
		{
			Helper<bool>.resultCallback(userCallback, success);
		}
	}

	// playerPublic()
	public class OnPlayerPublicResult
	{
		public static OnUserDataResultDelegate<playerPublicWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<playerPublicWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// player()
	public class OnPlayerResult
	{
		public static OnUserDataResultDelegate<playerWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<playerWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// pointOfPlayer()
	public class OnPointOfPlayerResult
	{
		public static OnUserDataResultDelegate<pointRWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<pointRWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizList()
	public class OnQuizListResult
	{
		public static OnUserDataResultDelegate<quizListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizListOfPlayer()
	public class OnQuizListOfPlayerResult
	{
		public static OnUserDataResultDelegate<quizListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizDetail()
	public class OnQuizDetailResult
	{
		public static OnUserDataResultDelegate<quizWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizRandom()
	public class OnQuizRandomResult
	{
		public static OnUserDataResultDelegate<quizBasicWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizBasicWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizDoneList()
	public class OnQuizDoneListResult
	{
		public static OnUserDataResultDelegate<quizDoneListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizDoneListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizPendingList()
	public class OnQuizPendingListResult
	{
		public static OnUserDataResultDelegate<quizPendingListWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<quizPendingListWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizQuestion()
	public class OnQuizQuestionResult
	{
		public static OnUserDataResultDelegate<questionWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questionWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// quizAnswer()
	public class OnQuizAnswerResult
	{
		public static OnUserDataResultDelegate<questionAnsweredWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<questionAnsweredWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	// rule()
	public class OnRuleResult
	{
		public static OnUserDataResultDelegate<ruleWr> userCallback;

		[MonoPInvokeCallback(typeof(OnDataResultDelegate))]
		public static void onDataResult(IntPtr result, int errorCode)
		{
			Helper<ruleWr>.dataResultCallback(userCallback, result, errorCode);
		}
	}

	#endif
}