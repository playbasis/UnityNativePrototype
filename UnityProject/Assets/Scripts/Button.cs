using UnityEngine;
using System.Collections;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Log;

public class Button : MonoBehaviour
{
	private float m_timer = 0.0f;
	private float buttonHeight;
	private float buttonYGap = 7;

	void Start()
	{
		/** MacOSX **/
		// this is a trick to load Playbasis os x native platform
		// so we can quickly test thing before building for iOS platform
		// step
		// 1. switch to os x and hit play
		// 2. next time you can switch to ios and normally develop on ios platform (libray is loaded)
		#if UNITY_STANDALONE_OSX
		PlaybasisWrapper.loadMacOSXLib();
		#endif
		
		buttonHeight = Screen.height * 0.3f;

		PlaybasisWrapper.initialize();
	}

	void Update()
	{
		m_timer += Time.deltaTime;
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 60;
		GUI.Label(new Rect(0, Screen.height * 0.1f, Screen.width, 20.0f), "This is Unity (" + m_timer.ToString("0.00") + ")!", style);

		if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.2f, Screen.width * 0.5f, buttonHeight), "Switch to native..", style))
		{
			Debug.Log("Switching to native..");
			UnityNativeInterface.SwitchToNative();
		}
		else if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.2f + buttonHeight + buttonYGap, Screen.width * 0.5f, buttonHeight), "Authenticate app", style))
		{
			Debug.Log("Authenticate app");
			#if UNITY_IOS || UNITY_STANDALONE_OSX
			PlaybasisWrapper.auth("1012718250", "a52097fc5a17cb0d8631d20eacd2d9c2", "io.wasin.testplugin", new OnResultDelegate(this.OnAuthResult));
			#elif UNITY_ANDROID
			PlaybasisWrapper.auth("2410120595", "0b98a945d6ba51153133767a14654c79", "io.wasin.testplugin", new OnResultDelegate(this.OnAuthResult));
			#endif
		}
		else if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.2f + buttonHeight*2 + buttonYGap*2, Screen.width * 0.5f, buttonHeight), "Get player info", style))
		{
			Debug.Log("Get player info");
			PlaybasisWrapper.player("jontestuser", new OnUserDataResultDelegate<playerWr>(this.OnPlayerResult));
		}
	}

	// auth()
	private void OnAuthResult(bool success)
	{
		if (success)
		{
			Debug.Log("OnAuthResult succeeded");
		}
		else
		{
			Debug.Log("OnAuthResult failed");
		}
	}

	// player()
	private void OnPlayerResult(playerWr result, int errorCode)
	{
		if (errorCode == -1)
		{
			Printer.print<playerWr>(ref result);
		}
	}
}
