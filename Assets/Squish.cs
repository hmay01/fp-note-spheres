using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSquishAmount;
    public float triggerSquishMagnitude;
    float maxCollisionMagnitude;
    int floorLayer;

    AudioSource audioSource;

    public float pitchLow;

    float pitch;

    //new
    public float squishTime;
    public float unSquishTime;
    Vector3 initialScale;

    
    void Start()
    {
        initialScale = transform.localScale;
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

        if (collisionMagnitude > triggerSquishMagnitude && collision.gameObject.layer == floorLayer) {
            float squishAmount = Mathf.Lerp (1, maxSquishAmount, Mathf.InverseLerp (0, maxCollisionMagnitude, collisionMagnitude));
            TriggerMakeSquish(squishAmount);
        }
    } 

    public void TriggerMakeSquish(float squishAmount){
        StopAllCoroutines();
        StartCoroutine(MakeSquish(squishAmount));

    }

 
        public  IEnumerator MakeSquish(float squishAmount)
        {
            float elapsedTime = 0;
            float squishDifference = (initialScale.x * squishAmount) - initialScale.x;
            float squishX = initialScale.x + squishDifference;
            float squishY = initialScale.x - (squishDifference * 2);
            float squishZ = initialScale.x + squishDifference;

            Vector3 squishScale = new Vector3(squishX, squishY, squishZ);

            while (elapsedTime < squishTime)
            {
                transform.localScale = Vector3.Lerp(initialScale, squishScale, (elapsedTime / squishTime));
                pitch = Mathf.Lerp (pitchLow, 1, Mathf.InverseLerp (squishX, initialScale.x, transform.localScale.x));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            StartCoroutine(MakeUnSquish());

        }


        public  IEnumerator MakeUnSquish()
    {
        float elapsedTime = 0;

        Vector3 squishScale = transform.localScale;

        while (elapsedTime < unSquishTime)
        {
            transform.localScale = Vector3.Lerp(squishScale, initialScale, (elapsedTime / unSquishTime));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }






}
