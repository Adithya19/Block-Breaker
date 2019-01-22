using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Padel paddle;
    bool locked = true;
    bool launched = false;
    [SerializeField] AudioClip[] ballSounds;
    float tweak;

    //cached components
    AudioSource myAudio;
    Rigidbody2D myRB;
    
	void Start () {
        transform.position = new Vector2(paddle.transform.position.x, transform.position.y );
        myAudio = GetComponent<AudioSource>();
        myRB = GetComponent<Rigidbody2D>();
        tweak = 1f;
    }

    // Update is called once per frame
    void Update () {
        if(locked)
            transform.position = new Vector2(paddle.transform.position.x, transform.position.y );

        if (Input.GetMouseButtonDown(0) && !launched)
        {
            LaunchBall();
        }
	}
    private void LaunchBall() {
        locked = false;
        launched = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launched) {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudio.PlayOneShot(clip);
            myRB.velocity += new Vector2(tweak, 0);
            tweak = -1 * tweak;
        }
    }
}
