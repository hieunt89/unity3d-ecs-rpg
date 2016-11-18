using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class GUITimeLabel : MonoBehaviour, ITickListerner {
	Text mText;

    void Start () {
		 Pools.sharedInstance.core.CreateEntity().AddTickListener(this);
		mText =GetComponent <Text> ();
	}

    public void TickChanged()
    {
        var totalTick = Pools.sharedInstance.core.tickEntity.totalTick.amount;
		mText.text = totalTick.ToString ("0.00");
		
		// var sec = (Mathf.CeilToInt (totalTick) / 60) % 60;
		// var min = (Mathf.CeilToInt (totalTick) / 3600);
		// var secText = sec > 9 ? "" + sec : "0" + sec;
		// var minText = min > 9 ? "" + min : "0" + min;
		
		// GetComponent<Text>().text = minText + ":" + secText;
    }

}
