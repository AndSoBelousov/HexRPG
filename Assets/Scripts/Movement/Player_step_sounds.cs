using UnityEngine;

namespace HEXRPG.Movement
{
    public class PlayerSound : MonoBehaviour
    {
      public AudioClip[] stepSounds_AR; //массив звуков текущий
      public AudioClip[] Player_Death_SoundsAR;
      public AudioClip[] Player_Kick_SoundsAR;
      public AudioClip[] Skeleton_Kick_SoundsAR;
      public AudioClip[] Skeleton_Death_SoundsAR;

      public AudioClip[] MidEn_Kick_SoundsAR;
      public AudioClip[] MidEn_Death_SoundsAR;

      public AudioClip[] Boss_Kick_SoundsAR;
      public AudioClip[] Boss_Death_SoundsAR;


      private AudioSource audioSourceStep;
      private AudioSource audioSourceDeath;
      private AudioSource audioSourceKick;
      private AudioSource audioSourceSkeletDeath;
      private AudioSource audioSourceSkeletKick;

      private AudioSource audioSourceMidEnKick;
      private AudioSource audioSourceMidEnDeath;
      
      private AudioSource audioSourceBossKick;
      private AudioSource audioSourceBossDeath;
      

      private void Start()
      {
        audioSourceStep = GetComponent<AudioSource>();
        audioSourceDeath = GetComponent<AudioSource>();
        audioSourceKick = GetComponent<AudioSource>();
        audioSourceSkeletKick = GetComponent<AudioSource>();
        audioSourceSkeletDeath = GetComponent<AudioSource>();

        audioSourceMidEnKick = GetComponent<AudioSource>();
        audioSourceMidEnDeath = GetComponent<AudioSource>();
        audioSourceBossKick = GetComponent<AudioSource>();
        audioSourceBossDeath = GetComponent<AudioSource>();
      }

      public void Step_sound_play()
      {
        audioSourceStep.PlayOneShot(stepSounds_AR[Random.Range(0, stepSounds_AR.Length)]);
        print("звук шага");
      }

      public void Death_Sound_Play()
      {
        audioSourceDeath.PlayOneShot(Player_Death_SoundsAR[Random.Range(0, Player_Death_SoundsAR.Length)]);
        print("звук смерти");
      }

      public void Kick_Sound_Play()
      {
       audioSourceKick.PlayOneShot(Player_Kick_SoundsAR[Random.Range(0, Player_Kick_SoundsAR.Length)]);
        print("звук удара");
      }

      public void Skelet_Kick_Sound_Play()
      {
        audioSourceSkeletKick.PlayOneShot(Skeleton_Kick_SoundsAR[Random.Range(0, Skeleton_Kick_SoundsAR.Length)]);
        print("звук удара моба");
      }

      public void Skelet_Death_Sound_Play()
      {
        audioSourceSkeletDeath.PlayOneShot(Skeleton_Death_SoundsAR[Random.Range(0, Skeleton_Death_SoundsAR.Length)]);
        print("звук смерти моба");
      }


       public void MidEn_Kick_Sound_Play()
      {
        audioSourceMidEnKick.PlayOneShot(MidEn_Kick_SoundsAR[Random.Range(0, MidEn_Kick_SoundsAR.Length)]);
        print("звук удара среднего моба");
      }

      public void MidEn_Death_Sound_Play()
      {
        audioSourceMidEnDeath.PlayOneShot(MidEn_Death_SoundsAR[Random.Range(0, MidEn_Death_SoundsAR.Length)]);
        print("звук cмерти среднего моба");
      }
      
      public void Boss_Kick_Sound_Play()
      {
        audioSourceBossKick.PlayOneShot(Boss_Kick_SoundsAR[Random.Range(0, Boss_Kick_SoundsAR.Length)]);
        print("звук удара босса");
      }
      
      public void Boss_Death_Sound_Play()
      {
        audioSourceBossDeath.PlayOneShot(Boss_Death_SoundsAR[Random.Range(0, Boss_Death_SoundsAR.Length)]);
        print("звук cмерти босса");
      }
  }
}