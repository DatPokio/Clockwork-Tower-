using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHandTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(SmallHandrotationCoroutine());
    }
     IEnumerator SmallHandrotationCoroutine()
    {
            for(int i = 0; i < 4;){
                yield return new WaitForSeconds(1);
                transform.Rotate (Vector3.forward * -2);
            }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
