using UnityEngine;
using System.Collections;

public class Platform_Spawner : MonoBehaviour {

    public GameObject[] platform;
    public GameObject[] flyingplatform;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnPlatform", 0f, 2.05f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnPlatform()
    {
        int range = Random.Range(0, platform.Length);
        Instantiate(platform[range]);
        if (range >= 6)
        {
            int randomspawn = Random.Range(0, 10);
            if (randomspawn == 0)
            {
                int rangefly = Random.Range(0, flyingplatform.Length);
                Instantiate(flyingplatform[rangefly]);
            }
        }
    }
}
