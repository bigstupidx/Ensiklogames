using UnityEngine;
using System.Collections;

public class Data_Character : MonoBehaviour {

    public float jetDecrement;
    public Sprite[] PlayerNormal, PlayerPushed;
    public int PlayerCharacter;
    public float distances;
	// Use this for initialization
	void Start () {
        getData();
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void getData()
    {
        //pengurangan jet
        if (PlayerPrefs.HasKey("JetDecrement") == true)
        {
            jetDecrement = PlayerPrefs.GetFloat("JetDecrement");
        }
        else
        {
            jetDecrement = 0.1f;
        }

        //player character
        if (PlayerPrefs.HasKey("PlayerCharacter") == true)
        {
            PlayerCharacter = PlayerPrefs.GetInt("PlayerCharacter");
        }
        else
        {
            PlayerCharacter = 0;
        }

        //distance max
        if (PlayerPrefs.HasKey("Distance") == true)
        {
            distances = PlayerPrefs.GetFloat("Distance");
        }
        else
        {
            distances = 20f;
        }
    }
}
