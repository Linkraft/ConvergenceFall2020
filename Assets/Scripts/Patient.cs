using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public IEnumerator WaitForEnd(AudioClip audioClip)
    {
        this.audioSource.clip = audioClip;
        //this.animator.SetBool("Talking", true);
        this.audioSource.Play();
        yield return new WaitForSeconds(audioClip.length);
        //this.animator.SetBool("Talking", false);
    }
}
