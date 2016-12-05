using UnityEngine;
using UnityEngine.UI;

public class GUITextureQualityDropDown : MonoBehaviour {
	Dropdown mDropDown;
	string[] qualities = { "High", "Medium", "Low" };

	void OnEnable () {
		mDropDown = GetComponent <Dropdown> ();
		if (mDropDown) {
			Messenger.AddListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);

			foreach (var quality in qualities) {
				mDropDown.options.Add (new Dropdown.OptionData (quality));
			}
			mDropDown.RefreshShownValue ();

			mDropDown.onValueChanged.AddListener (delegate {
				Messenger.Broadcast <int> (Events.GUI.OnTextureDropDownChange, mDropDown.value);	
			});
		}
	}

	void OnDisable () {
		Messenger.RemoveListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);
	}

	void OnLoadSetting (GameSettings _gameSettings) {
		mDropDown.value = _gameSettings.textureQuality;
	}
}
