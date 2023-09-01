using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    // Start is called before the first frame update

    public float squishIncrement;
    public float unSquishIncrement;
    public float maxSquishAmount;

    public float triggerSquishMagnitude;
    float initialScale;

    float maxCollisionMagnitude;
    int floorLayer;

    AudioSource audioSource;

    public float pitchLow;

    float pitch;
    





    void Start()
    {
      
        initialScale = transform.localScale.x;
        floorLayer = 6;
        maxCollisionMagnitude = 17;
        audioSource = GetComponent<AudioSource>();





    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = pitch;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        float collisionMagnitude = collision.relativeVelocity.magnitude;
        float squishAmount = Mathf.Lerp (1, maxSquishAmount, Mathf.InverseLerp (0, maxCollisionMagnitude, collisionMagnitude));
        
        if (collisionMagnitude > triggerSquishMagnitude && collision.gameObject.layer == floorLayer) {
            TriggerMakeSquish(squishAmount);
        }
    } 

    public void TriggerMakeSquish(float squishAmount){
        StopAllCoroutines();
        StartCoroutine(MakeSquish(squishAmount));
    }

    public IEnumerator MakeSquish(float squishAmount){

        float x = transform.localScale.x;
        float z = transform.localScale.z;
        float y = transform.localScale.y;

        float squishDifference = (initialScale * squishAmount) - initialScale;

        float squishX = initialScale + squishDifference;
        float squishY = initialScale - (squishDifference * 2);


    


        while (transform.localScale.x < squishX && transform.localScale.y > squishY)
        {
            transform.localScale = new Vector3(x, y, z);
            x += squishIncrement;
            z += squishIncrement;
            y -= squishIncrement;
            pitch = Mathf.Lerp (pitchLow, 1, Mathf.InverseLerp (squishX, initialScale, x));

            Debug.Log($"Decreasing pitch: {audioSource.pitch}");
            yield return null;
        }
        StartCoroutine(MakeUnSquish(squishX));

    }
        public IEnumerator MakeUnSquish(float squishX){


        float x = transform.localScale.x;
        float z = transform.localScale.z;
        float y = transform.localScale.y;


        while (transform.localScale.x > initialScale && transform.localScale.y < initialScale)
        {

            transform.localScale = new Vector3(x, y, z);
            x -= unSquishIncrement;
            z -= unSquishIncrement;
            y += unSquishIncrement;
            pitch = Mathf.Lerp (pitchLow, 1, Mathf.InverseLerp (squishX, initialScale, x));

            Debug.Log($"Increasing pitch: {audioSource.pitch}");

            yield return null;

        }
        Debug.Log($"FINISHED pitch: {audioSource.pitch}");


    }


}
