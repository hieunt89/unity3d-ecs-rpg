using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class TimeScaleUpdateSystem : IReactiveSystem {

    public TriggerOnEvent trigger
    {
        get
        {
            return CoreMatcher.TimeScale.OnEntityAdded ();
        }
    }

    public void Execute(List<Entity> entities)
    {
        // Debug.Log ("time scale " + entities.SingleEntity().timeScale.value);
        Time.timeScale = entities.SingleEntity().timeScale.value;
    }
}
