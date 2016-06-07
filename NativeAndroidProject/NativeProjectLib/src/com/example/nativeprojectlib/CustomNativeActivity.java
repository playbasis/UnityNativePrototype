package com.example.nativeprojectlib;

import com.example.nativeprojectlib.R;
import com.unity3d.player.*;

import android.util.Log;
import android.app.NativeActivity;
import android.content.res.Configuration;
import android.graphics.PixelFormat;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

import com.playbasis.android.playbasissdk.core.*;
import com.playbasis.android.playbasissdk.api.AuthToken;
import com.playbasis.android.playbasissdk.api.OnResult;
import com.playbasis.android.playbasissdk.http.HttpError;

public class CustomNativeActivity extends UnityPlayerNativeActivity
{
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		int id = getResources().getIdentifier("test_view", "layout", getPackageName());
		setContentView(id);

		Log.i("UnityPlayerNativeActivity", "onCreate, authenticate app...");
		// normally it's native app to maintain apikey and apisecret
		// we fix them in this case for demonstration purpose
		Playbasis playbasis = new Playbasis.Builder(this)
			.setApiKey("2410120595")
			.setApiSecret("0b98a945d6ba51153133767a14654c79")
			.build();
		playbasis.getAuthenticator().getAuthToken(new OnResult<AuthToken>() {
			@Override
			public void onSuccess(AuthToken result){
				Log.i("UnityPlayerNativeActivity", "authenticate successfully with " + result.getToken());
			}
			@Override
			public void onError(HttpError error){
				Log.i("UnityPlayerNativeActivity", "authenticate failed");
			}
		});
	}

	public void onBackToUnityClicked(View view)
	{
		Log.i("UnityPlayerNativeActivity", "Switching to Unity from Android UI..");
		runOnUiThread(new Runnable()
		{
			@Override public void run()
			{
				switchToUnityImp();
			}
		});
	}

	protected void switchToNative()
	{
		Log.i("UnityPlayerNativeActivity", "Switching to Android UI from Unity..");
		runOnUiThread(new Runnable()
		{
			@Override public void run()
			{
				switchToNativeImp();
			}
		});
	}

	private void switchToNativeImp()
	{
		mUnityPlayer.pause();
		int id = getResources().getIdentifier("test_view", "layout", getPackageName());
		setContentView(id);
	}
	
	private void switchToUnityImp()
	{
		mUnityPlayer.resume();
		setContentView(mUnityPlayer);
	}
}
