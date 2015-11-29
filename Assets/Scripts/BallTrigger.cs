﻿using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {
    private const string LOG_TAG = "BallTrigger - ";


    private GameObject lastPlayerTouched;
    public BonusGenerator manager;

    private const string PLAYER_TAG = "Player";
    private const string BONUS_SHIELD_TAG = "BonusShield";
    private const string BONUS_MAGNET_TAG = "BonusMagnet";
    private bool magnetEnable;
    private GameObject magnetLeft;
    private GameObject magnetRight;
    int rand;

    // Use this for initialization
    void Start () {
        lastPlayerTouched = null;
        magnetEnable = true;
        magnetLeft = GameObject.Find("MagnetLeft");
        magnetRight = GameObject.Find("MagnetRight");

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(BONUS_SHIELD_TAG))
        {
            Debug.Log(LOG_TAG + "Destruction bonus shield");
            Destroy(other.gameObject);
            manager.BonusDestroyed();
            if (lastPlayerTouched != null) {
                Debug.Log(LOG_TAG + "Power shield send to player");
                lastPlayerTouched.GetComponent<BonusPlayerManager>().activateShieldPower();
            }
        }
        else if (other.gameObject.CompareTag(PLAYER_TAG)) {
            Debug.Log(LOG_TAG + "Save last player who touched the ball");
            lastPlayerTouched = other.gameObject;

        }
        if (other.gameObject.CompareTag(BONUS_MAGNET_TAG))
        {
            Debug.Log(LOG_TAG + "Destruction bonus shield");
            Destroy(other.gameObject);
            manager.BonusDestroyed();

            if (magnetEnable)
            {
                rand = Random.Range(0, 2);
                Debug.Log(rand);
                if (rand == 1)
                {
                    magnetLeft.GetComponent<MagnetManager>().setMagnet();
                }
                else
                {
                    magnetRight.GetComponent<MagnetManager>().setMagnet();
                }
                magnetEnable = false;
            }


        }


    }

    public void setMagnetEnable()
    {
        magnetEnable = true;
    }

}
