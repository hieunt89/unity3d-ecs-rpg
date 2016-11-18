using Entitas;
using UnityEngine;
public class CharacterInitializeSystem : ISetPool, IInitializeSystem {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.CreateEntity ()
			.IsActive (true)
			.IsCharacter(true)
			.AddName ("fdj")
			.AddPosition (5f, 0f, 5f)
			.AddBaseHitPoint (100)
			.AddHitPointRegen (Mathf.Clamp (.01f, 0f, 1f), 3f, 3f)
			.AddBaseManaPoint (100)
			.AddCurrentLevel (1)
			.AddCurrentExp (50)	
			.IsMovable (true)
			.AddDestination (5f, 0f, 5f)
			.AddMoveSpeed (10f)
			.AddTurnSpeed (500f)		
			;
		;
	}
}
