using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeSound : MonoBehaviour
{
    AudioSource deathSound;

    public void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (!deathSound.isPlaying) Destroy(this.gameObject);
    }
}
