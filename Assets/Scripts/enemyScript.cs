using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class enemyScript : MonoBehaviour {

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;

    BoxCollider collider;

	// Use this for initialization
	void Start () {

        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        collider.size = new Vector3(0.3f, 0.3f, 0.3f);
        collider.center = new Vector3(0f, 0f, 0f);

    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
