package com.example.nativeprojectlib;

import com.example.nativeprojectlib.R;

import android.util.Log;
import android.app.NativeActivity;
import android.app.Activity;
import android.content.Intent;
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

public class AnotherActivity extends Activity
{
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		int id = getResources().getIdentifier("test_another", "layout", getPackageName());
		setContentView(id);

		Log.i("AnotherActivity", "onCreate, authenticate app...");
		
		// normally it's native app to maintain apikey and apisecret
		// we fix them in this case for demonstration purpose
		Playbasis playbasis = new Playbasis.Builder(this)
			.setApiKey("2410120595")
			.setApiSecret("0b98a945d6ba51153133767a14654c79")
			.build();
		playbasis.getAuthenticator().getAuthToken(new OnResult<AuthToken>() {
			@Override
			public void onSuccess(AuthToken result){
				Log.i("AnotherActivity", "authenticate successfully with " + result.getToken());
			}
			@Override
			public void onError(HttpError error){
				Log.i("AnotherActivity", "authenticate failed");
			}
		});
	}

	public void onPreUnityScreenClicked(View view) {
		Log.i("AnotherActivity", "Show pre-unity screen");
		startActivity(new Intent(AnotherActivity.this, CustomNativeActivity.class));
	}
}
