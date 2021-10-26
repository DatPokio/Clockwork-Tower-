using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemActions : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.A))
      {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
      }
      if (Input.GetKeyDown(KeyCode.D))
      {
          rb.velocity = new Vector2(speed, rb.velocity.y);
      }
     
    }


}
