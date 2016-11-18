using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class GUISlowMovementButton : MonoBehaviour {
	Button mButton;

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				if (!Pools.sharedInstance.core.characterEntity.hasSlowMovement) {
					Pools.sharedInstance.core.characterEntity.ReplaceSlowMovement(.5f, 10f, 10f);
				} else {
					Pools.sharedInstance.core.characterEntity.RemoveSlowMovement();
				}
			});
		}
	}
}
