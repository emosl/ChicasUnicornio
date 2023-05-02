using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerFight : MonoBehaviour
{
    public Toby toby;
    public int mule_strength;
    public int mule_shield;
    public int mule_speed;
    public int mule_agility;
    [SerializeField] APITest api;
    public batteryplayer bp;
    string UN = MenuUser.UiD;

    public TobyBattle tobyBattle;
    public MulaBattle mulaBattle;
    public static int times_played = 0;
    public GameObject canvasFight;
    public int TobySum;
    public int MuleSum;

    public GameObject pushingObject;
    public GameObject receivingObject;
    public float pushForce = 10f;
    private bool isPushing = false;

    private void Awake()
    {
        toby = FindObjectOfType<Toby>();
    }

    private void Start()
    {
        api.GetDataUnity("2");
        TobyStats();
        MuleStats();
        
    }

    void Update()
    {
        TobySum = 0 + APITest.strength + APITest.shield + APITest.speed + APITest.agility;

        if (TobySum < 40)
        {
            Debug.Log("TobySum-40: " + TobySum);
            Debug.Log("Mule-40: " + MuleSum);
        }
        DeterminePushWinner();
    }

    public void GetDataUnity()
    {
        api.GetDataUnity(UN);
    }

    public void MuleStats()
    {
        int rand = Random.Range(5, 12);
        mule_agility = APITest.agility + rand;
        mule_strength = APITest.strength + rand;
        mule_shield = APITest.shield + rand;
        mule_speed = APITest.speed + rand;
        MuleSum = mule_agility + mule_strength + mule_shield + mule_speed;
    }
    public void TobyStats()
    {
        toby.agility = APITest.agility;
        toby.strength = APITest.strength;
        toby.shield = APITest.shield;
        toby.speed = APITest.speed;
        TobySum = 0 + APITest.strength + APITest.shield + APITest.speed + APITest.agility;
    }

    private void FixedUpdate()
    {
        if (isPushing)
        {
            Vector3 pushDirection = (receivingObject.transform.position - pushingObject.transform.position).normalized;
            receivingObject.GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Force);
        }
    }

    public void DeterminePushWinner()
    {

        if (TobySum > MuleSum)
        {
            pushingObject = GameObject.Find("Toby");
            receivingObject = GameObject.FindGameObjectWithTag("Enemy");
            tobyBattle.PushEnemy();
            mulaBattle.Start();
            isPushing = true;
        }
        else
        {
            pushingObject = GameObject.FindGameObjectWithTag("Enemy");
            receivingObject = GameObject.Find("Toby");
            mulaBattle.PushMule();
            isPushing = true;
        }
    }

}
