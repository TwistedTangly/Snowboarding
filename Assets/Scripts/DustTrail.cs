using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField]ParticleSystem snowParticles;
    [SerializeField]AudioClip snowSFX;
    [SerializeField]float volume = 0.02f;
    AudioSource audioSource;
    CapsuleCollider2D snowboard;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        snowboard = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground" && snowboard.IsTouching(other.collider))
        {
            snowParticles.Play(); 
            audioSource.volume = volume; 
            audioSource.PlayOneShot(snowSFX); 
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        snowParticles.Stop();
        audioSource.Stop(); 
        audioSource.volume = 1; 
    }
}
