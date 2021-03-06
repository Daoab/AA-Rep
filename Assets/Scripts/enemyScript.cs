﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class enemyScript : MonoBehaviour {

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField][Tooltip("Number of hits to die")] int hp = 2;

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
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hit && hp <= 0)
        {
            hit = false;
            KillEnemy();
        }
        else {
            hp --;
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        scoreBoard.ScoreHit(score);

        Destroy(gameObject);
    }
}
