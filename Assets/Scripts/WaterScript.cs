using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
 void OnCollisionEnter2D(Collision2D other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript >();

        if (player != null)
        {
            player.ChangeHealth(-1);

        }
    }
}
