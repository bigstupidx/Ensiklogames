using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldShow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        this.gameObject.GetComponent<Text>().text = "Gold : " + go.GetComponent<GameOver>().goldy;
	}
}
