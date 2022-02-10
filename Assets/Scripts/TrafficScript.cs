using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    public float speed;
    public PlayerScript PlayerScript;
    public bool reverse;

    Rigidbody2D rigidbody2D;
    Vector2 originalPos;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalPos = gameObject.transform.position;
        if (reverse)
        {
            direction = -direction;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
            position.x = position.x + Time.deltaTime * speed * direction;

            rigidbody2D.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript >();

        if (player != null)
        {
            player.ChangeHealth(-1);

        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Collider2D>().tag == "Wall")
        {
            transform.position = originalPos;

        }
    }
}
