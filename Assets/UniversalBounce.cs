using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalBounce : MonoBehaviour
{

    List<GameObject> balls;

    Spawner spawnerScript;

    MessageUI messageUIScript;
    PhysicMaterial bounceMaterial;

    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        messageUIScript = GameObject.FindGameObjectWithTag("MessageUI").GetComponent<MessageUI>();        
    }

    void Update()
    {
        bounceMaterial = spawnerScript.bounceMaterial;
        balls = spawnerScript.balls;

        if (Input.GetKeyDown(KeyCode.N)) {
            foreach (var ball in balls)
            {
                ball.gameObject.GetComponent<SphereCollider>().material = bounceMaterial;

            }
            messageUIScript.TriggerMessageUpdate("Universal Bounce Mode");
        }
        
    }
}
