using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScript : MonoBehaviour
{
    BoxCollider2D stairCollider;
    BoxCollider2D playerCollider;
    GameObject player;

    [SerializeField]
    Vector3 teleportDistance;


    // Start is called before the first frame update
    void Start()
    {
        stairCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stairCollider.IsTouching(playerCollider) && Input.GetKeyDown(KeyCode.E))
            player.transform.position += teleportDistance;
    }
}
