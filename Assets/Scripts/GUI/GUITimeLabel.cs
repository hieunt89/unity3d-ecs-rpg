using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class GUITimeLabel : MonoBehaviour, ITickListerner {
    void Start () {
		Pools.sharedInstance.gui.CreateEntity().AddTickListener(this);
	}

    public void TickChanged()
    {
        Debug.Log ("tick changed");
        var tick = Pools.sharedInstance.core.tick.currentTick;
		var sec = (tick / 60) % 60;
		var min = (tick / 3600);
		var secText = sec > 9 ? "" + sec : "0" + sec;
		var minText = min > 9 ? "" + min : "0" + min;
		
		GetComponent<Text>().text = minText + ":" + secText;
    }

}
