using UnityEngine;
using System;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Log;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper.Android
{
	#if UNITY_ANDROID

	// base classes
	// 1. result (bool) returning type
	public class OnResult : AndroidJavaProxy
	{
		public OnResultDelegate userCallback;

		public OnResult(OnResultDelegate callback) : base("com.playbasis.android.playbasissdk.api.OnResult") {
			userCallback = callback;
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

	public class OnPlayerPublicResult : OnDataResult<playerPublicWr>
	{
		public OnPlayerPublicResult(OnUserDataResultDelegate<playerPublicWr> callback) : base(callback) {}

		public override playerPublicWr onSuccess_user(AndroidJavaObject result)
		{
			playerPublicWr data = new playerPublicWr();
			AndroidPopulator.PopulatePlayerPublic(ref data, result);
			return data;
		}
	}

	public class OnPlayerResult : OnDataResult<playerWr>
	{
		public OnPlayerResult(OnUserDataResultDelegate<playerWr> callback) : base(callback) {}

		public override playerWr onSuccess_user(AndroidJavaObject result)
		{
			playerWr data = new playerWr();
			AndroidPopulator.PopulatePlayer(ref data, result);
			return data;
		}
	}

	public class OnPointOfPlayerResult : OnDataResult<pointRWr>
	{
		public OnPointOfPlayerResult(OnUserDataResultDelegate<pointRWr> callback) : base(callback) {}

		public override pointRWr onSuccess_user(AndroidJavaObject result)
		{
			pointRWr data = new pointRWr();
			AndroidPopulator.PopulatePointOfPlayer(ref data, result);
			return data;
		}
	}

	#endif
}