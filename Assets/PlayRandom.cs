using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    List<GameObject> singleNotes;

    List<List<GameObject>> chords;

    Spawner spawnerScript;

    MessageUI messageUIScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        messageUIScript = GameObject.FindGameObjectWithTag("MessageUI").GetComponent<MessageUI>();

        
    }

    // Update is called once per frame
    void Update()
    {
        singleNotes = spawnerScript.singleNotes;
        chords = spawnerScript.chords;

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R) && chords.Count > 0) {
            PlayRandomChord();
            messageUIScript.TriggerMessageUpdate("Random Chord Played");
        }

        else if (Input.GetKeyDown(KeyCode.R) && singleNotes.Count > 0) {
            PlayRandomSingleNote();
            messageUIScript.TriggerMessageUpdate("Random Note Played");
        }


        
    }

    void PlayRandomSingleNote(){
        int randomIndex  = Random.Range(0, singleNotes.Count);
        GameObject ball = singleNotes[randomIndex];
        ball.GetComponent<AudioSource>().Play();
    }

    void PlayRandomChord(){
        int randomIndex  = Random.Range(0, chords.Count);
        List<GameObject> chord = chords[randomIndex];
        foreach (var ball in chord)
        {
            ball.GetComponent<AudioSource>().Play();

        }
    }
}
