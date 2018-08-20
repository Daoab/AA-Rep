using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    [SerializeField] float loadTime = 7f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        Invoke("LoadLevel", loadTime);
    }
	
	// Update is called once per frame
	void Update () {

	}
    void LoadLevel() {
        /*int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);*/

        SceneManager.LoadScene(1);
    }

}
