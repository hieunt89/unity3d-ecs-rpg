using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class GUIPauseButton : MonoBehaviour {
	Button mButton;

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				Pools.sharedInstance.core.isPause = !Pools.sharedInstance.core.isPause;
				GetComponentInChildren <Text>().text = Pools.sharedInstance.core.isPause ? "Resume" : "Pause";
			});
		}
	}

}
