using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] item;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnItem", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnItem()
    {
        int itemId = Random.Range(0, item.Length);
        Instantiate(item[itemId]);
        Debug.Log("Length : " + item.Length);
    }
}
