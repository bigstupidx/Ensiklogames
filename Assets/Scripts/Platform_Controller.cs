using UnityEngine;
using System.Collections;

public class Platform_Controller : MonoBehaviour {

    private const int speed = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
}
