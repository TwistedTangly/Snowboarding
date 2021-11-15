using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]ParticleSystem bloodPaticles;
    [SerializeField]ParticleSystem crashPaticles;
    [SerializeField] float delay = 0.5f;
    [SerializeField]AudioClip crashSFX;
    [SerializeField]float volume = 1;
    CircleCollider2D head;
    AudioSource audioSource;
    bool hasCrashed = false;
    private void Start() 
    {
        head = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
  private void OnCollisionEnter2D(Collision2D other) 
  {      
       if(other.gameObject.tag == "Ground" && head.IsTouching(other.collider) && !hasCrashed)
       {
           hasCrashed = true;
           FindObjectOfType<PlayerController>().DisableControls();
           audioSource.volume = volume;
           crashPaticles.Play();
           bloodPaticles.Play();           
           audioSource.PlayOneShot(crashSFX);
           Invoke("ReloadScene", delay);
       }
  }
  void ReloadScene()
   {
       SceneManager.LoadScene(0);
   }
   
   
}
