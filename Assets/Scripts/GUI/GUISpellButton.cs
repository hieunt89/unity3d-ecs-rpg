using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class GUISpellButton : MonoBehaviour, IPauseListener {

	void Awake () {
//		Pools.sharedInstance.pool.CreateEntity ()
//			.AddPauseListener(this)
//		;
	}

	public void PauseStateChanged (bool isPaused)
	{
		GetComponent <Button> ().enabled = !isPaused;
	}
}
