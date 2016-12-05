using UnityEngine;
using UnityEngine.UI;

public class GUIResetSettingsButton : MonoBehaviour {
	Button mButton;
	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				Messenger.Broadcast (Events.GUI.OnResetSettingsButtonClick);
			});
		}
	}
}
