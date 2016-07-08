using UnityEngine;
using System.Collections;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Model;

public class Button : MonoBehaviour
{
	private float m_timer = 0.0f;
	private float buttonHeight;
	private float buttonYGap = 7;

	void Start()
	{		
		buttonHeight = Screen.height * 0.3f;
		PlaybasisWrapper.Instance.initialize();
	}

	void Update()
	{
		m_timer += Time.deltaTime;
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 30;
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
			PlaybasisWrapper.Instance.auth("1012718250", "a52097fc5a17cb0d8631d20eacd2d9c2", "io.wasin.testplugin", this.OnAuthResult);
			#elif UNITY_ANDROID
			PlaybasisWrapper.Instance.auth("2410120595", "0b98a945d6ba51153133767a14654c79", "io.wasin.testplugin", this.OnAuthResult);
			#endif
		}
		else if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.2f + buttonHeight*2 + buttonYGap*2, Screen.width * 0.5f, buttonHeight), "Get player info", style))
		{
			Debug.Log("Get player info");
			PlaybasisWrapper.Instance.player("jontestuser", this.OnPlayerResult);
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
			Debug.Log(result.toString());
		}
		else
		{
			Debug.Log("failed player api with errorCode [" + errorCode + "]");
		}
	}
}
