using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    NoteUI noteUIScript;

    public float triggerSoundMagnitude;

    int floorLayer;


    // AudioClip[] audioClips;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        noteUIScript = GameObject.FindGameObjectWithTag("NoteUI").GetComponent<NoteUI>();
        floorLayer = 6;






    }

    // Update is called once per frame
    void Update()
    {



        
    }


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > triggerSoundMagnitude && collision.gameObject.layer == floorLayer) {
            audioSource.Play();
            string noteName = GetComponent<NoteInfo>().note.name;
            noteUIScript.TriggerNoteUpdate(noteName);
        }
    } 



}  
