using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour {

    public GameObject deathFx;
    public GameObject shipParts;

    [SerializeField][Tooltip("in seconds")] float levelLoadDelay = 1f;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");// on playerMovement script
        deathFx.SetActive(true);
        shipParts.SetActive(false);
        Invoke("reloadLevel", levelLoadDelay);
    }

    private void reloadLevel() {// string referenced
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
