using UnityEngine;
using UnityEngine.UI;

public class GUIResolutionDropDown : MonoBehaviour {
	Dropdown mDropDown;
	Resolution[] resolutions;

	void OnEnable () {
		mDropDown = GetComponent <Dropdown> ();
		if (mDropDown) {
			Messenger.AddListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);
			resolutions = Screen.resolutions;
			foreach (var resolution in resolutions) {
				mDropDown.options.Add (new Dropdown.OptionData (resolution.ToString ()));
			}
			mDropDown.RefreshShownValue ();

			mDropDown.onValueChanged.AddListener (delegate {
				Screen.SetResolution (resolutions[mDropDown.value].width, resolutions[mDropDown.value].height, Screen.fullScreen);

				Messenger.Broadcast <int> (Events.GUI.OnResolutionDropDownChange, mDropDown.value);	
			});
		}
	}

	void OnDisable () {
		Messenger.RemoveListener <GameSettings> (Events.GUI.OnLoadSetting, OnLoadSetting);
	}

	void OnLoadSetting (GameSettings _gameSettings) {
		mDropDown.value = _gameSettings.resolutionIndex;
	}
}
