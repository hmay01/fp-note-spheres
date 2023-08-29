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





    void Start()
    {
      
        initialScale = transform.localScale.x;
        floorLayer = 6;
        maxCollisionMagnitude = 17;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        float collisionMagnitude = collision.relativeVelocity.magnitude;
        Debug.Log($"collisionMagnitude: {collisionMagnitude}");
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
            yield return null;
        }
        StartCoroutine(MakeUnSquish());

    }
        public IEnumerator MakeUnSquish(){


        float x = transform.localScale.x;
        float z = transform.localScale.z;
        float y = transform.localScale.y;

        while (transform.localScale.x > initialScale && transform.localScale.y < initialScale)
        {

            transform.localScale = new Vector3(x, y, z);
            x -= unSquishIncrement;
            z -= unSquishIncrement;
            y += unSquishIncrement;
            yield return null;

        }

    }


}
