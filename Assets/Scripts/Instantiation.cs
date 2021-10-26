using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject _instance;
    private float gears;
    public Rigidbody2D rb;
  
    [SerializeField] private float gearCap;
    // Start is called before the first frame update
    void Start()
    { 
    gears = 0;
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.V) && gears < gearCap){
      _instance = Instantiate(myPrefab, new Vector2(rb.position.x,rb.position.y), Quaternion.identity);
        gears = gears + 1;
    }
        if (Input.GetKeyDown(KeyCode.F)){
         Destroy(_instance); 
         gears = gears - 1;
            if (gears <= 0)
            {
                gears = 0;
            }
        }
    }
}
