using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHandTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(BigHandrotationCoroutine());
    }
     IEnumerator BigHandrotationCoroutine()
    {
            for(int i = 0; i < 4;){
                yield return new WaitForSeconds(1);
                transform.Rotate (Vector3.forward * -10);
            }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
