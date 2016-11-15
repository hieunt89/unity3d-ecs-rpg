using Entitas; 
using UnityEngine;
using UnityEngine.UI;
public class GUITimeScaleSlider : MonoBehaviour {

	Slider mSlider;
	// Use this for initialization
	void Start () {
		mSlider = GetComponent <Slider> ();
		if (mSlider != null) {
			mSlider.onValueChanged.AddListener ((float value) => {
				Pools.sharedInstance.core.tickEntity.ReplaceTimeScale (value);
			});
		}
	}
}
