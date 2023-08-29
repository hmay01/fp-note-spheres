using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public float fadeDecrement;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void TriggerMessageUpdate(string message) {
        StopAllCoroutines();
        StartCoroutine(UpdateMessage(message));

    }

    public IEnumerator UpdateMessage(string message){


        GetComponent<TMPro.TextMeshProUGUI>().text = message;
        
        
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
