using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleNotesUI : MonoBehaviour
{
    Spawner spawnerScript;
    List<GameObject> singleNotes;

    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        
    }

    // Update is called once per frame
    void Update()
    {
        singleNotes = spawnerScript.singleNotes;
        GetComponent<TMPro.TextMeshProUGUI>().text = singleNotes.Count.ToString();
    }
}
