using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public AudioClip collectedClip;
    public ParticleSystem collectedEffect;
    public GameObject Player;
    public PlayerScript PlayerScript;

    public void Collect()
    {
        PlayerScript.scoreValue += 100;
        PlayerScript.score.text = PlayerScript.scoreValue.ToString();
        Destroy(gameObject);
    }
}