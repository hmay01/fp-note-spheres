using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spotlightPrefab;
    public GameObject spotLight;
    
    void Start()
    {
        spotLight = Instantiate(spotlightPrefab, transform.position, transform.rotation);
        spotLight.transform.Rotate (new Vector3(90f,0f,0f));
        spotLight.GetComponent<Light>().color = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        spotLight.transform.position = transform.position;




        
    }
}
