using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb2D;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(speed, 0);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }

}
