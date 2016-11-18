using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class GUIBleedButton : MonoBehaviour {
	Button mButton;
	Pool _pool;


	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				if (!Pools.sharedInstance.input.selectInput.entity.hasBleed) {
					Pools.sharedInstance.input.selectInput.entity.ReplaceBleed(.1f, 5f, 5f);
				} else {
					Pools.sharedInstance.input.selectInput.entity.RemoveBleed();
				}
			});
		}
	}
}