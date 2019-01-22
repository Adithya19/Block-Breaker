using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padel : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;
    GameStatus status;
    // Use this for initialization
    void Start () {
        status = FindObjectOfType<GameStatus>();		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(Input.mousePosition.x / Screen.width * cam.aspect * cam.orthographicSize * 2, transform.position.y);
        //Debug.Log(Input.mousePosition.x/Screen.width * cam.aspect*cam.orthographicSize*2);
        paddlePos.x = Mathf.Clamp(getPaddlePos(paddlePos.x), minX, maxX);
        transform.position = paddlePos;

        //Debug.Log("The mouse position is " + Input.mousePosition.x);
        //Debug.Log("The Screen width is " + Screen.width);

    }

    private float getPaddlePos(float ballX) {
        if (status.isAutoPlay())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        return ballX;
    }
}
