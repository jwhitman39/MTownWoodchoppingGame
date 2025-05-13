//using NUnit.Framework;
using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject ball;
    public GameObject newBall;
    public bool isTired = false;
    public bool isTooTired = false;
    Ball BallLogic = null;
    TreeStump TreeStumpLogic = null;
    Player PlayerLogic = null;
    Paddles PaddlesLogic = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tempObj = GameObject.Find("Ball");
        GameObject tempObj2 = GameObject.Find("TreeStump");
        GameObject tempObj3 = GameObject.Find("Player");
        GameObject tempObj4 = GameObject.Find("Paddles");
        BallLogic = tempObj.GetComponent<Ball>();
        TreeStumpLogic= tempObj2.GetComponent<TreeStump>();
        TreeStumpLogic.ballDetector = true;
        PlayerLogic = tempObj3.GetComponent<Player>();
        PaddlesLogic = tempObj4.GetComponent<Paddles>(); 
        BallLogic.Launch();
    }
    // Update is called once per frame
    void Update()
    {
        if (TreeStumpLogic.ballDetector == false)
        {
            BallLogic.Reset();
            TreeStumpLogic.ballDetector = true;
            return;
        }
        if ((PlayerLogic.Concentration < 50) && (isTired == false))
        {
            Debug.Log("You're getting tired...");
            BallLogic.speed += 1;
            isTired = true;
            return;
        }
        if((PlayerLogic.Concentration < 20) && (isTired == true) && (isTooTired == false))
        {
            Debug.Log("You are barely awake...");
            PaddlesLogic.speed += 100;
            isTooTired = true;
        }
        if ((PlayerLogic.Concentration > 50) && (isTired ==true))
        {
            Debug.Log("You're feeling reenergized!");
            BallLogic.speed -= 1;
            PaddlesLogic.speed -= 100;
            isTired = false;
            isTooTired=false;
            return;
        }
    }
}
