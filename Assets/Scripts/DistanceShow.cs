using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceShow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        this.gameObject.GetComponent<Text>().text = "Distance : " + go.GetComponent<GameOver>().disty;
	}
}
