using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gnomed : MonoBehaviour
{
	public AudioSource audioData;
	public AudioClip otherClip;
    // Start is called before the first frame update
    void Start()
    {
		audioData.clip = otherClip;
		audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
