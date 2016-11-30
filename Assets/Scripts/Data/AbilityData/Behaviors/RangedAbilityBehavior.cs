using UnityEngine;
using System.Collections;

public class RangedAbilityBehavior : AbilityBehavior {

	private const string name = "Ranged";
	private const string desc = "A ranged attack";
	private const BehaviorStartTime startTime = BehaviorStartTime.Beginning;

	private float minDistance;
	private float maxDistance;

	public RangedAbilityBehavior (float minDistance, float maxDistance) : base (new BasicInfo (name, desc), startTime)
	{
		this.minDistance = minDistance;
		this.maxDistance = maxDistance;
	}

	public float MinDistance {
		get {
			return this.minDistance;
		}
	}

	public float MaxDistance {
		get {
			return this.maxDistance;
		}
	}
		

}
