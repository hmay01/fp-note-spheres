using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVisuals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            // StartCoroutine(GoRed());

        }

        
    }

    IEnumerator GoAlpha(){

        
        
        Color c = GameObject.FindGameObjectWithTag("Ground").GetComponent<MeshRenderer>().material.color;

        MeshRenderer renderer = GameObject.FindGameObjectWithTag("Ground").GetComponent<MeshRenderer>();

        float limit = 0.5f;
        float elapsed = 0;



        while(elapsed < limit)
        {

            c.a = 0;
            print(c);
            renderer.material.color = c;
            elapsed += Time.deltaTime;
            yield return null;


        }
        c.a = 1;
        renderer.material.color = c;

    }
    IEnumerator GoRed(){

        
        
        Color c = GameObject.FindGameObjectWithTag("Ground").GetComponent<MeshRenderer>().material.color;

        MeshRenderer renderer = GameObject.FindGameObjectWithTag("Ground").GetComponent<MeshRenderer>();

        float limit = 0.1f;
        float elapsed = 0;



        while(elapsed < limit)
        {
            c.r = 0.6f;
            c.g = 0.2f;
            c.b = 0.2f;

            renderer.material.color = c;
            elapsed += Time.deltaTime;
            yield return null;


        }
        c.r = 0;
        c.g = 0;
        c.b = 0;
        renderer.material.color = c;

    }
}
