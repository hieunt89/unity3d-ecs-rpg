using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

	Systems _systems;

	void Start () {
		var pools = Pools.sharedInstance;
		pools.SetAllPools();

		_systems = CreateSystems (pools);
		_systems.Initialize();
	}

	void Update () {
		_systems.Execute ();
		_systems.Cleanup ();
	}

	void OnDestroy () {
		_systems.TearDown ();
	}
	Systems CreateSystems (Pools pools) {
		return new Feature ("Systems")

			// Input
			.Add (pools.input.CreateSystem (new InputSystem()))
//				.Add (pools.input.CreateSystem (new ProcessInputSystem()))

			// Character
			.Add (pools.core.CreateSystem (new CharacterInitializeSystem()))
			.Add (pools.core.CreateSystem (new CharacterRenderViewSystem()))
			;

	}
}
