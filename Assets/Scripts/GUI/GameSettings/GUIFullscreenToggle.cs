using UnityEngine;
using UnityEngine.UI;

public class GUIFullScreenToggle : MonoBehaviour {
	Toggle mToggle;

	void OnEnable () {
		mToggle = GetComponent<Toggle> ();
		if (mToggle) {
			Messenger.AddListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);
			mToggle.onValueChanged.AddListener (delegate {
				Messenger.Broadcast <bool> (Events.GUI.OnFullScreenToggle, mToggle.isOn);
			});
		}
	}
	void OnDisable () {
		Messenger.RemoveListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);
	}

	void OnLoadSetting (GameSettings _gameSettings) {
		mToggle.isOn = _gameSettings.isFullscreen;
	}
}
