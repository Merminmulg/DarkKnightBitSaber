using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ActivateAudio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
