using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class enemyScript : MonoBehaviour {

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;

    [Header("Score Board")]

    [SerializeField] int score = 10;
    ScoreBoard scoreBoard;

    BoxCollider collider;
    bool hit = true;// This prevents the score from increasing twice if 2 particles collide at the same time

	// Use this for initialization
	void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
         
    }

    private void AddBoxCollider()
    {
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        collider.size = new Vector3(0.3f, 0.3f, 0.3f);
        collider.center = new Vector3(0f, 0f, 0f);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hit)
        {
            hit = false;
            GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            scoreBoard.ScoreHit(score);
            Destroy(gameObject);
        }
    }
}
