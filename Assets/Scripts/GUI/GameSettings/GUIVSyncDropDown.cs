using UnityEngine;
using UnityEngine.UI;

public class GUIVSyncDropDown : MonoBehaviour {
	Dropdown mDropDown;
	string[] qualities = { "Every Second V Blank", "Every V Blank", "Don't Sync" };

	void OnEnable () {
		mDropDown = GetComponent <Dropdown> ();
		if (mDropDown) {
			Messenger.AddListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);

			foreach (var quality in qualities) {
				mDropDown.options.Add (new Dropdown.OptionData (quality));
			}
			mDropDown.RefreshShownValue ();

			mDropDown.onValueChanged.AddListener (delegate {
				Messenger.Broadcast <int> (Events.GUI.OnVSyncDropDownChange, mDropDown.value);	
			});
		}
	}


	void OnDisable () {
		Messenger.RemoveListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);
	}

	void OnLoadSetting (GameSettings _gameSettings) {
		mDropDown.value = _gameSettings.vSync;
	}
}
