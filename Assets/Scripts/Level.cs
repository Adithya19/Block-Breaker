using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
	}

    public void IncrementBlocks() {
        breakableBlocks++;
    }
    public void DecrementBlocks()
    {
        breakableBlocks--;
    }
}
