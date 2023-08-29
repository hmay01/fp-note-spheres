using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopulateNotes : MonoBehaviour {


    public List<Note> notes;

    public AudioClip c1Piano;
    public AudioClip c1Fm;
    public AudioClip d1Piano;
    public AudioClip d1Fm;
    public AudioClip e1Piano;
    public AudioClip e1Fm;
    public AudioClip f1Piano;
    public AudioClip f1Fm;
    public AudioClip g1Piano;
    public AudioClip g1Fm;
    public AudioClip a2Piano;
    public AudioClip a2Fm;
    public AudioClip b2Piano;
    public AudioClip b2Fm;
    public AudioClip c2Piano;
    public AudioClip c2Fm;
    public AudioClip d2Piano;
    public AudioClip d2Fm;

    public AudioClip e2Piano;
    public AudioClip e2Fm;

    public AudioClip f2Piano;
    public AudioClip f2Fm;

    public AudioClip g2Piano;
    public AudioClip g2Fm;

    public AudioClip a3Piano;
    public AudioClip a3Fm;

    public AudioClip b3Piano;
    public AudioClip b3Fm;

    public AudioClip c3Piano;
    public AudioClip c3Fm;

    
    void Start(){

        Note c1 = new Note{name = "c1", audioClips = new List<AudioClip>(){c1Fm}, transformScale = 4.3f};
        Note d1 = new Note{name = "d1", audioClips = new List<AudioClip>(){d1Fm}, transformScale = 4f};
        Note e1 = new Note{name = "e1", audioClips = new List<AudioClip>(){e1Fm}, transformScale = 3.7f};
        Note f1 = new Note{name = "f1", audioClips = new List<AudioClip>(){f1Fm}, transformScale = 3.4f};
        Note g1 = new Note{name = "g1", audioClips = new List<AudioClip>(){g1Fm}, transformScale = 3.1f};
        Note a2 = new Note{name = "a2", audioClips = new List<AudioClip>(){a2Fm}, transformScale = 2.8f};
        Note b2 = new Note{name = "b2", audioClips = new List<AudioClip>(){b2Fm}, transformScale = 2.5f};
        Note c2 = new Note{name = "c2", audioClips = new List<AudioClip>(){c2Fm, c2Piano}, transformScale = 2.2f};
        Note d2 = new Note{name = "d2", audioClips = new List<AudioClip>(){d2Piano}, transformScale = 1.9f};
        Note e2 = new Note{name = "e2", audioClips = new List<AudioClip>(){e2Piano}, transformScale = 1.6f};
        Note f2 = new Note{name = "f2", audioClips = new List<AudioClip>(){f2Piano}, transformScale = 1.3f};
        Note g2 = new Note{name = "g2", audioClips = new List<AudioClip>(){g2Piano}, transformScale = 1f};
        Note a3 = new Note{name = "a3", audioClips = new List<AudioClip>(){a3Piano}, transformScale = 0.7f};
        Note b3 = new Note{name = "b3", audioClips = new List<AudioClip>(){b3Piano}, transformScale = 0.5f};
        Note c3 = new Note{name = "c3", audioClips = new List<AudioClip>(){c3Piano}, transformScale = 0.2f};









        notes = new List<Note>(){c1, d1, e1, f1, g1, a2, b2, c2};

    }

    void Update(){

    }

}




