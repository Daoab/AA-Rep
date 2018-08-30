using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

    [SerializeField] float loadTime = 7f;

    // Use this for initialization
    void Start () {
        Invoke("LoadLevel", loadTime);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
