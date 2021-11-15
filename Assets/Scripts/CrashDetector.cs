using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]ParticleSystem bloodPaticles;
    [SerializeField]ParticleSystem crashPaticles;
    [SerializeField] float delay = 0.5f;
    CircleCollider2D head;
    private void Start() 
    {
        head = GetComponent<CircleCollider2D>();
        
    }
  private void OnCollisionEnter2D(Collision2D other) 
  {      
       if(other.gameObject.tag == "Ground" && head.IsTouching(other.collider))
       {
           crashPaticles.Play();
           bloodPaticles.Play();
           Invoke("ReloadScene", delay);
       }
  }
  void ReloadScene()
   {
       SceneManager.LoadScene(0);
   }
   
   
}
