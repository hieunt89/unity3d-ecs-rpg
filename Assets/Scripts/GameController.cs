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

			// Time
			// .Add (pools.core.CreateSystem (new TickUpdateSystem()))
			.Add (pools.core.CreateSystem (new TimeSystem()))
			.Add (pools.core.CreateSystem (new TimeScaleUpdateSystem()))
			
			
			// Input
			.Add (pools.input.CreateSystem (new MoveInputSystem()))
			.Add (pools.input.CreateSystem (new ProcessMoveInputSystem()))

			// Character
			.Add (pools.core.CreateSystem (new CharacterInitializeSystem()))
			.Add (pools.core.CreateSystem (new CharacterRenderViewSystem()))

			// Camera
			.Add (pools.core.CreateSystem (new CameraSystem()))			
			
			// Navigation
			.Add (pools.core.CreateSystem (new NavigationSystem()))
			
			// Hit Point
			.Add (pools.core.CreateSystem (new HitPointUpdateSystem()))
			.Add (pools.core.CreateSystem (new HitPointRegenerationSystem()))
			
			// Level + EXP
			.Add (pools.core.CreateSystem (new LevelSystem()))
			.Add (pools.core.CreateSystem (new LevelUpSystem()))	
			.Add (pools.core.CreateSystem (new ExpUpdateSystem()))		
			;

	}
}
