using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

    public Image JetFill;
    private GameObject dc;
    public GameObject JetFire, Explode;
    private int PlayerCharacter;

    public Text meters;
    public Slider distance;
    public float distnum;
    private const float speed = 1f;
    private float distancemax;

    public Text goldText;
    private int goldNow;

    public AudioClip ItemTake;

	// Use this for initialization
	void Start () {
        dc = GameObject.FindGameObjectWithTag("GameManager");
        PlayerCharacter = dc.GetComponent<Data_Character>().PlayerCharacter;
        goldNow = 0;
        Debug.Log(distancemax);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            JetPush();
        }
        else
        {
            JetDown();
        }

        if (JetFill.fillAmount <= 0)
        {
            death();
        }
        else
        {
            DistanceAdd();
        }

        if (JetFill.fillAmount <= 0.3)
        {
            GasLow();
        }
        else
        {
            GasHigh();
        }

        goldText.text = goldNow.ToString();

	}

    public void JetPush()
    {
        JetFire.SetActive(true);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dc.GetComponent<Data_Character>().PlayerPushed[PlayerCharacter];
        JetFill.fillAmount -= dc.GetComponent<Data_Character>().jetDecrement * Time.deltaTime;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20);
    }

    public void JetDown()
    {
        JetFire.SetActive(false);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dc.GetComponent<Data_Character>().PlayerNormal[PlayerCharacter];
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            death();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Item")
        {
            goldNow += coll.gameObject.GetComponent<ItemInfo>().itemValue;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(ItemTake);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Fuel")
        {
            JetFill.fillAmount += 0.65f;
            Destroy(coll.gameObject);
        }
    }

    public void death()
    {
        Instantiate(Explode, this.gameObject.transform.position, Quaternion.identity);
        SaveGold();
        dc.GetComponent<GameOver>().ItsOver(goldNow, Convert.ToInt32(distnum));
        Destroy(this.gameObject);
    }

    void DistanceAdd()
    {
        distancemax = dc.GetComponent<Data_Character>().distances;
        distnum += Time.deltaTime * speed;
        meters.text = Mathf.Round(distnum).ToString() + " M";
        distance.value = distnum / distancemax;
    }

    void SaveGold()
    {
        int recentGold = PlayerPrefs.GetInt("Gold");
        int gold = recentGold + goldNow;
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.Save();
    }

    void GasLow()
    {
        this.gameObject.GetComponent<Animator>().Play("LowGas");
    }

    void GasHigh()
    {
        this.gameObject.GetComponent<Animator>().Play("HighGas");
    }
}
