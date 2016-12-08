using Entitas;
using UnityEngine;

public class IndicateObjectSystem : IReactiveSystem {
	
	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		foreach (var entity in entities) {
			if (entity.isSelected) {
				var indicatorPrefab = Resources.Load <GameObject> ("SelectedIndicator");
				GameObject indicatorGo = null;
				try {
					indicatorGo = GameObject.Instantiate (indicatorPrefab);
				} catch (System.Exception) {
					Debug.Log ("Cannot instantiate " + indicatorPrefab);
				}

				if (indicatorGo != null) {
					indicatorGo.transform.SetParent (entity.view.gameObject.transform, false);
					indicatorGo.transform.localPosition = new Vector3 (0f, 1f, 0f);
					indicatorGo.transform.eulerAngles = new Vector3 (90f, 0f, 0f);
				}
				entity.ReplaceIndicator (indicatorGo);
			} else {
				if (entity.indicator.view != null) 
					GameObject.Destroy (entity.indicator.view);
				entity.RemoveIndicator ();
			}
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Selected.OnEntityAddedOrRemoved ();
		}
	}
}
