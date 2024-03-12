using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{

    bool active = true;

    public AudioClip triggerNoise;
    private AudioSource playerAudio;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (active && collision.gameObject.tag == "Player")
        {
            active = false;
            ScoreManager.score++;
            playerAudio.PlayOneShot(triggerNoise, 1.0F);
        }
    }

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
}
