using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceModeUI : MonoBehaviour
{
    // Start is called before the first frame update
    Spawner spawnerScript;

    string bounceMode;


    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        
    }

    // Update is called once per frame
    void Update()
    {
        bounceMode = spawnerScript.bounceMode;
        GetComponent<TMPro.TextMeshProUGUI>().text = bounceMode;

        
    }
}
