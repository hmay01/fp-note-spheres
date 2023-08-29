using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Glow : MonoBehaviour
{
    // Material material;
    // Color mainColor;

    // Color emissionColor;

    // public float notGlowIntensity;
    // public float glowIntensity;

    // public float timeIncrement;

    // public float glowDecrement;


    // public Texture emissionTexture;



    // // Start is called before the first frame update
    // void Start()
    // {
    //     material = GetComponent<MeshRenderer>().material;
    //     print(material);

    //     material.EnableKeyword("_EMISSION");

    //     material.SetTexture("_EmissionMap", emissionTexture);
        
    //     mainColor = material.color;


    //     emissionColor = mainColor;

    //     material.SetColor("_EmissionColor", emissionColor * notGlowIntensity);

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    // void OnCollisionEnter(Collision collision)
    // {
    //     foreach (ContactPoint contact in collision.contacts)
    //     {
    //         Debug.DrawRay(contact.point, contact.normal, Color.white);
    //     }
    //     if (collision.relativeVelocity.magnitude > 0.1) {
    //         TriggerMakeGlow();
    //     }
    // } 

    // public void TriggerMakeGlow(){
    //     StopAllCoroutines();
    //     StartCoroutine(MakeGlow());
    // }

    // public IEnumerator MakeGlow(){


    //     float limit = 1;
    //     float elapsed = 0;

    //     float intensity = glowIntensity;



    //     while (elapsed < limit)
    //     {
    //         if (intensity > notGlowIntensity) {
    //             intensity -= glowDecrement;
    //         }
    //         material.SetColor("_EmissionColor", emissionColor * intensity);
    //         elapsed += timeIncrement * Time.deltaTime;
    //         yield return null;

    //     }

    //     material.SetColor("_EmissionColor", emissionColor * notGlowIntensity);




    // }
}
