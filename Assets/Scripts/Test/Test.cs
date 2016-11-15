using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	void Start() {
		InvokeRepeating ("DoSomething", 0, 1f);
	}

	void DoSomething () {
		Debug.Log ("second");
	}

	public void PauseBtn () {
		Time.timeScale = 0f;
	}

	public void SetTimeScale () {
		Time.timeScale = 2f;

	}
}
