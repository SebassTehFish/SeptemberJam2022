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
}
