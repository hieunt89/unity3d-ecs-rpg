using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIPlayButton : MonoBehaviour {
	Button mButton;

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				SceneManager.LoadSceneAsync ("game");
			});
		}
	}
}
