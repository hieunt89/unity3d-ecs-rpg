using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;

public class GUIPauseButton : MonoBehaviour {
	Button mButton;

	void Awake () {
//		Pools.sharedInstance.pool.CreateEntity ().
	}

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				Debug.Log ("Pause");
			});
		}
	}

}
