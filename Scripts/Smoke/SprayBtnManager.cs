using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBtnManager : MonoBehaviour
{
   
    [SerializeField] ParticleSystem particle;
    // Start is called before the first frame update
    //public AudioClip sound1;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = sound1;
    }

    // Update is called once per frame
   public void StartSpray()
    {
        particle.Play(true);
        audioSource.Play();
    }
    public void StopSpray()
    {
        particle.Stop(true);
        audioSource.Stop();
    }
}
