using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Text score;
    public GameObject loseTextObject;
    public GameObject winTextObject;

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    public int currentHealth;
    public int scoreValue = 0;
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);
    float horizontal;
    float vertical;
    private float pocketsFilled = 0;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        if (pocketsFilled >=3)
        {
            winTextObject.SetActive(true);
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (currentHealth <= 0)
        {
            loseTextObject.SetActive(true);
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        PickupScript e = other.collider.GetComponent<PickupScript>();
        if (e != null)
        {
            e.Collect();
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Collider2D>().tag == "Pocket")
        {
            transform.position = new Vector2(0, -3.15f);
            pocketsFilled += 1;
            Debug.Log("Pocket Filled!");
            collider.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
