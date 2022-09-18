using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    GameController gameController;
    [SerializeField] bool isDoor;
    [SerializeField] int doorNumber;
    bool isPressed = false;
    bool isColliding = false;
    string[] bells;
    UIControl UI;

    private void Start()
    {
        UI = GameObject.Find("Main Camera").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UIControl>();
        FindReferences();
        bells = new string[] {"Bell1", "Bell2", "Bell3"};
    }

    private void Update()
    {
        if(isColliding && Input.GetKeyDown(KeyCode.E))
            isPressed = true;
    }

    void FindReferences()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        isColliding = true;
        if(other.gameObject.CompareTag("Player") && isPressed && !isDoor)
        {
            if(gameController.getFoodCount() < 7)
            {
                gameController.setFoodCount(gameController.getFoodCount() + 1);
                isPressed = false;
                FindObjectOfType<AudioManager>().RandomPlayOneShot(bells);
            }
        }
        else if(other.gameObject.CompareTag("Player") && isPressed)
        {
            if(gameController.getFoodCount() > 0)
            {
                gameController.setFoodCount(gameController.getFoodCount() - 1);
                for(int i = 0; i < UI.getFoodOrders().Length; i++)
                {
                    if(doorNumber == UI.getFoodOrders()[i])
                    {
                        UI.orderFilled(i);
                        FindObjectOfType<AudioManager>().Play("Cash");
                        gameController.setScore(gameController.getScore() + 1);
                    }
                }
            }
            isPressed = false;
        }
    }

    private void onTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            isColliding = false;
    }
}
