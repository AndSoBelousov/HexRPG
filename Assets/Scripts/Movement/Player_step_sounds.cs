using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace HEXRPG.Movement
{
    public class PlayerSound : MonoBehaviour
    {    
      public AudioClip[] stepSounds_AR; //массив звуков текущий
      
      private AudioSource audioSource;
      
      private void Start()
      {
        audioSource = GetComponent<AudioSource>();
      }
      
      public void Step_sound_play()
      {
        audioSource.PlayOneShot(stepSounds_AR[Random.Range(0, stepSounds_AR.Length)]);
        print("звук шага");
      }
  }
}