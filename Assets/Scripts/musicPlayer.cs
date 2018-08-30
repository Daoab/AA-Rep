using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour {

    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<musicPlayer>().Length;

        if (numMusicPlayer > 1) {
            Destroy(gameObject);
        }

        else {
        DontDestroyOnLoad(this.gameObject);
        }
    }
}
