using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsUI : MonoBehaviour
{
    Spawner spawnerScript;
    List<GameObject> balls;

    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        
    }

    // Update is called once per frame
    void Update()
    {
        balls = spawnerScript.balls;
        GetComponent<TMPro.TextMeshProUGUI>().text = balls.Count.ToString();


        
    }
}
