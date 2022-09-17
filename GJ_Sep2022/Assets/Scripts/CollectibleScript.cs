using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    GameController gameController;
    [SerializeField] bool isDoor;
    bool isPressed = false;
    bool isColliding = false;


    private void Start()
    {
        FindReferences();
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
            gameController.setFoodCount(gameController.getFoodCount() + 1);
            isPressed = false;
        }
        else if(other.gameObject.CompareTag("Player") && isPressed)
        {
            gameController.setFoodCount(gameController.getFoodCount() - 1);
            isPressed = false;
        }
    }

    private void onTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            isColliding = false;
    }
}
