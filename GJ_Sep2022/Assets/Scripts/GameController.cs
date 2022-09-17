using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int foodCount = 0;
    public int score = 0;

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

    public int getRoomNumber()
    {
        int number1 = Random.Range(1, 6);
        int number2 = Random.Range(1, 4);

        return number1 * 100 + number2;
    }
}
