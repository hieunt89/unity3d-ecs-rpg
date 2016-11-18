using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class GUISelectedLabel : MonoBehaviour, ISelectInputListener {
	Text mText;

	void Start () {
		mText = GetComponent <Text> ();
		Pools.sharedInstance.input.CreateEntity().AddSelectListener (this);
	}

	public void OnSelected ()
	{
		mText.text = Pools.sharedInstance.input.selectInputEntity.selectInput.entity.name.value;
	}
}
