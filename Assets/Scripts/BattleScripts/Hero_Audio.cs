using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Audio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip _reflectClip;
    [SerializeField] private AudioClip _punchClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ActiveVoice(int action  )
    {
        if (action == 4) {
            audioSource.PlayOneShot(_reflectClip);
        }
        else
        {
            audioSource.PlayOneShot(_punchClip);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
