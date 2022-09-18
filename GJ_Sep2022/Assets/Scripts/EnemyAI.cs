using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(gameController.getFoodCount() > 0)
                gameController.setFoodCount(gameController.getFoodCount() - 1);
            FindObjectOfType<AudioManager>().Play("Fall");
        }
    }
}
