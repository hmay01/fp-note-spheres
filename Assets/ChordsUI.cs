using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordsUI : MonoBehaviour
{
    Spawner spawnerScript;
    List<List<GameObject>> chords;


    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        
    }

    // Update is called once per frame
    void Update()
    {
        chords = spawnerScript.chords;
        GetComponent<TMPro.TextMeshProUGUI>().text = chords.Count.ToString();


        
    }
}
