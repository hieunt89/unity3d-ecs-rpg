using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class GUIBleedButton : MonoBehaviour {
	Button mButton;

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				if (!Pools.sharedInstance.core.characterEntity.hasBleed) {
					Pools.sharedInstance.core.characterEntity.ReplaceBleed(.1f, 5f, 5f);
				} else {
					Pools.sharedInstance.core.characterEntity.RemoveBleed();
				}
			});
		}
	}
}