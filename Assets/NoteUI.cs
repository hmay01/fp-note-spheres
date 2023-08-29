using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float fadeDecrement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerNoteUpdate(string note) {
        StopAllCoroutines();
        StartCoroutine(UpdateNote(note));

    }
    public IEnumerator UpdateNote(string note){


        GetComponent<TMPro.TextMeshProUGUI>().text = note;
        
        
        Color c = Color.white;

        float limit = 2;
        float elapsed = 0;



        while(elapsed < limit)
        {
            c.a -= fadeDecrement;
        
            GetComponent<TMPro.TextMeshProUGUI>().color = c;
            elapsed += Time.deltaTime;
            yield return null;


        }

        c.a = 0;
        GetComponent<TMPro.TextMeshProUGUI>().color = c;



    }
}
