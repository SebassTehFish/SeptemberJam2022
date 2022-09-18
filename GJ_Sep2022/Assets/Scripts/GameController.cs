using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int foodCount = 0;
    public int score = 0;

    //Given in seconds
    [SerializeField]
    private float timeLeft;
    [SerializeField]
    private bool timerOn, gameStart;

    [SerializeField]
    GameObject obj;

    // Generate new order after x seconds
    [SerializeField]
    private float timeGenerateOrder;
    private float timeBetweenOrder;

   // [SerializeField]
    private UIControl uc;

    private void Start()
    {
        //Gets UI Controller
        uc = obj.GetComponent<UIControl>();

        timeBetweenOrder = 0.0f;
    }

    public int getFoodCount()
    {
        return foodCount;
    }

    public void setFoodCount(int newCount)
    {
        foodCount = newCount;
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int newScore)
    {
        score = newScore;
    }

    //Turn the timer on (when game starts)
    public void turnTimerOn()
    {
        timerOn = true;
    }

    public float SecondsLeft()
    {
        return timeLeft;
    }

    // Generate new order
    public int getRoomNumber()
    {
        int number1 = Random.Range(1, 6);
        int number2 = Random.Range(1, 4);

        return number1 * 100 + number2;
    }

    public GameObject getUI()
    {
        return obj;
    }

    private void Update()
    {
        if (gameStart)
        {
            timeBetweenOrder += Time.deltaTime;

            // Put new order when time between order goes over time to generate or order counter is 0
            if (timeBetweenOrder >= timeGenerateOrder || uc.getOrderCounter() == 0)
            {
                //put new order into UI
                uc.putNewOrder(getRoomNumber());
                timeBetweenOrder = 0f;
            }

            // timer countdown
            if (timerOn)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    uc.updateTime(timeLeft);
                }
                else
                {
                    timeLeft = 0;
                    timerOn = false;
                }
            }
        }

        if(SecondsLeft() <= 0)
            Application.Quit();
    }
}
