using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0.1f, 10f)][SerializeField] float speed = 1f;

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlay = false;

    private void Awake()
    {
        int length = FindObjectsOfType<GameStatus>().Length;
        if(length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //scoreText.text = currentScore.ToString;
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = speed;
	}

    public void AddtoScore() {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public bool isAutoPlay()
    {
        return autoPlay;
    }
}
