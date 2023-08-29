using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBallsUI : MonoBehaviour
{
    // Start is called before the first frame update
    DeSpawner deSpawnerScript;
    List<GameObject> floorBalls;

    void Start()
    {
        deSpawnerScript = GameObject.FindGameObjectWithTag("DeSpawner").GetComponent<DeSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        floorBalls = deSpawnerScript.floorBalls;
        GetComponent<TMPro.TextMeshProUGUI>().text = floorBalls.Count.ToString();

    }
}
