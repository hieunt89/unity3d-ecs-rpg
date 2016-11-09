using UnityEngine;
using Entitas;
using System;

public class EntityLink : MonoBehaviour {
	Entity _entity;
	public Entity Entity {
		get {
			return this._entity;
		}
	}

	Pool _pool;
	public Pool Pool {
		get {
			return this._pool;
		}
	}

	public void Link (Entity entity, Pool pool) {
		if (_entity != null) {
			throw new Exception("EntityLink is already linked to " + _entity + "!");
		}
		 
		_entity = entity;
		_pool = pool;
		_entity.Retain (this);
	}

	public void UnLink () {
		if (_entity == null) {
			throw new Exception ("EntityLink is already unlinked!");
		}

		_entity.Release (this);
		_entity = null;
		_pool = null;
	}
}

public static class EntityLinkExtension {
	public static EntityLink GetEntityLink (this GameObject gameObject) {
		return gameObject.GetComponent<EntityLink> ();
	}

	public static EntityLink Link (this GameObject gameObject, Entity entity, Pool pool) {
		var entityLink = gameObject.GetComponent<EntityLink> ();
		if (entityLink == null) {
			entityLink = gameObject.AddComponent <EntityLink> ();
		}
		entityLink.Link (entity, pool);
		return entityLink;
	}

	public static void UnLink (this GameObject gameObject) {
		var entityLink = gameObject.GetComponent <EntityLink> ();
		if (entityLink)
			entityLink.UnLink ();
	}
}