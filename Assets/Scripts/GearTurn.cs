using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTurn : MonoBehaviour

{
    public float forFix;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(rotationCoroutine());
    }
      IEnumerator rotationCoroutine()
    {
            for(int i = 0; i < 4;){
                yield return new WaitForSeconds(1);
                transform.Rotate (Vector3.forward * -15);
            }
    }

    // Update is called once per frame
    void Update()
    {

  
       
    }
}
