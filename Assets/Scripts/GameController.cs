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
	}

	Systems CreateSystems (Pools pools) {
		return new Feature ("Systems")
			// Time 
			.Add (pools.pool.CreateSystem (new IncrementTickSystem ()))

			// Input
			.Add (pools.pool.CreateSystem (new InputSystem()))
			.Add (pools.pool.CreateSystem (new ProcessInputSystem()))


			// Character			
			.Add (pools.pool.CreateSystem(new CharacterInitializeSystem ()))
			.Add (pools.pool.CreateSystem(new CharacterRenderViewSystem ()))


			// Mana
			.Add (pools.pool.CreateSystem (new ProduceManaSystem ()))
			;
	}
}
