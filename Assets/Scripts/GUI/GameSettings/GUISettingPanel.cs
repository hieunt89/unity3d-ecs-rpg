using UnityEngine;
using UnityEngine.UI;

public class GUISettingPanel : MonoBehaviour {
	CanvasGroup mCanvasGroup;

	void OnEnable () {
		mCanvasGroup = GetComponent <CanvasGroup> ();
		if (mCanvasGroup) {
			Messenger.AddListener (Events.GUI.OnSettingsButtonClick, OnSettingButtonClick);
			Messenger.AddListener (Events.GUI.OnExitSettingsButtonClick, OnExitSettingButtonClick);

		}
	}

	void OnDisable () {
		Messenger.RemoveListener (Events.GUI.OnSettingsButtonClick, OnSettingButtonClick);
		Messenger.RemoveListener (Events.GUI.OnExitSettingsButtonClick, OnExitSettingButtonClick);

	}

	void OnSettingButtonClick() {
		mCanvasGroup.alpha = 1f;
		mCanvasGroup.interactable = true;
		mCanvasGroup.blocksRaycasts = true;

	}

	void OnExitSettingButtonClick() {
		mCanvasGroup.alpha = 0f;
		mCanvasGroup.interactable = false;
		mCanvasGroup.blocksRaycasts = false;
	}
}
