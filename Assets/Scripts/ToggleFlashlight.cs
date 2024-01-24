using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToggleFlashlight : MonoBehaviour
{
    private GameObject PlayerFlashlight;
    private GameObject PlayerFlashlightInner;
    private Light myLight;
    private Light myInnerLight;
    private AudioSource FlashlightAudioSource;
    public AudioClip FlashlightButtonSFX;


    void Start()
    {
        PlayerFlashlight = GameObject.Find("PlayerFlashlight");
         myLight = PlayerFlashlight.GetComponent<Light>();
        PlayerFlashlightInner = GameObject.Find("PlayerFlashlightInner");
         myInnerLight = PlayerFlashlightInner.GetComponent<Light>();
        FlashlightAudioSource = PlayerFlashlight.GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (!FlashlightAudioSource.isPlaying)
            {
                myLight.enabled = !myLight.enabled;
                myInnerLight.enabled = !myInnerLight.enabled;
                FlashlightAudioSource.clip = FlashlightButtonSFX;
                FlashlightAudioSource.Play();
                Debug.Log("F key was pressed, flashlight toggled and FlashlightAudioSource started playing.");
                return;
            }
            
            if (FlashlightAudioSource.isPlaying)
            {
                Debug.Log("F key was pressed, but FlashlightAudioSource is still playing, so nothing happened.");
                return;
            }
        }
    }
}