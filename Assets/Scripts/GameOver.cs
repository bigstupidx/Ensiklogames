using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject gameOver;
    public int goldy, disty;
    Text goldText, distText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ItsOver(int gold, int dist)
    {
        goldy = gold;
        disty = dist;
        Instantiate(gameOver);
    }
}
