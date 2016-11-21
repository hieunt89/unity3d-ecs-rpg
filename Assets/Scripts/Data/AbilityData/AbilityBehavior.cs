using UnityEngine;

public enum BehaviorStartTime {
	Beginning,
	Middle,
	End
}

public class AbilityBehavior {
	private BasicInfo basicInfo;	
	private BehaviorStartTime startTime;

	public AbilityBehavior (BasicInfo basicInfo, BehaviorStartTime startTime)
	{
		this.basicInfo = basicInfo;
		this.startTime = startTime;
	}

	public virtual void PerformBehavior () {

	}

	public BasicInfo BasicInfo {
		get {
			return this.basicInfo;
		}
	}

	public BehaviorStartTime StartTime {
		get {
			return this.startTime;
		}
	}

}
