using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIPauseButton : MonoBehaviour, IPauseListener {
	Button mButton;

	void Start () {
		mButton = GetComponent <Button> ();
		if (mButton) {
			mButton.onClick.AddListener (() => {
				Debug.Log ("Pause");
			});
		}
	}
	public void TickChanged (long currentTick)
	{
		throw new System.NotImplementedException ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
