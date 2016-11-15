using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;

public class GUIPauseButton : MonoBehaviour {
	Button mButton;

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				Debug.Log ("Pause");
				Pools.sharedInstance.core.isPause = !Pools.sharedInstance.core.isPause;
				GetComponentInChildren <Text>().text = Pools.sharedInstance.core.isPause ? "Resume" : "Pause";
			});
		}
	}

}
