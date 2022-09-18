using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider slide; 
    [SerializeField]
    private TextMeshProUGUI timerText;

    private int maxFoodCarry = 7;

    private int[] foodOrders = new int[7];
    private int currentCount = 0;

    public void updateTime(float curTime)
    {
        int minutes = Mathf.FloorToInt(curTime / 60);
        int seconds = Mathf.FloorToInt(curTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void FoodbarProgress(float val)
    {
        slide.value = val;
    }

    public void putNewOrder(int roomNumber)
    {
        if (foodOrders.Length <= 7)
        {
            foodOrders[currentCount] = roomNumber;

            FoodbarProgress((float)currentCount / maxFoodCarry);

            currentCount++;
        }
    }

    public int getOrderCounter()
    {
        return currentCount;
    }

    public void orderFilled(int index)
    {
        if (currentCount > 0)
        {
            foodOrders[index] = 0;
        }
    }
}
