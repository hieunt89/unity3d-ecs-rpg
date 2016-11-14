using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

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
        Time.timeScale = entities.SingleEntity().timeScale.value;
    }
}
