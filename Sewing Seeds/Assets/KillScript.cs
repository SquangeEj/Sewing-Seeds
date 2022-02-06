using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class KillScript : MonoBehaviour
{
    public string tagtotedect;
    public AudioSource audios;
    public ParticleSystem parts;

    private void Start()
    {
        audios = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tagtotedect))
        {
            Destroy(other.gameObject);
            audios.Play();
            parts.Play(false);
        }
    }
}
