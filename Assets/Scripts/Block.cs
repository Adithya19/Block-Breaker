using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticle;
    [SerializeField] int timesHit; //Debug purposes
    [SerializeField] Sprite [] spriteArray;

    Level level;
    GameStatus status;
    private void Start()
    {
        if (gameObject.tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.IncrementBlocks();
        }
        status = FindObjectOfType<GameStatus>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();

    }

    private void HandleHit()
    {
        if (gameObject.tag == "Breakable")
        {
            timesHit++;
            int maxHits = spriteArray.Length + 1;
            if (timesHit >= maxHits)
                BreakBlock();
            else
            {
                int spriteIndex = timesHit - 1;
                Debug.Log("Changing sprites");
                GetComponent<SpriteRenderer>().sprite = spriteArray[spriteIndex];
            }
        }
    }

    void BreakBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        TriggerParticle();
        level.DecrementBlocks();
        status.AddtoScore();
    }

    void TriggerParticle() {
        GameObject particles = Instantiate(blockParticle, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }

}
