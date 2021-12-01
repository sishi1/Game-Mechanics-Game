using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusic : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioSource musicSource;

    private void Awake()
    {
        musicSource.clip = musicClip;
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.Play();
    }

}
