using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongAcrossScenes : MonoBehaviour
{
    public AudioSource gameSong;

    // Start is called before the first frame update
    void Start()
    {
        gameSong = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameSong.enabled =
            SceneManager.GetActiveScene().name.Equals("TitleScreen") ||
            SceneManager.GetActiveScene().name.Equals("Help") ||
            SceneManager.GetActiveScene().name.Equals("Credits");
    }
}
