using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maid : EnemyAI
{
    private Rigidbody2D rgdBdy2D;
    [SerializeField]
    private int xRange;
    [SerializeField]
    private float speed;

    private float dirX;

    private bool faceRight;

    private Vector3 startPosition, localScale;

    // Start is called before the first frame update
    void Start()
    {
        rgdBdy2D = GetComponent<Rigidbody2D>();

        startPosition = transform.position;

        localScale = transform.localScale;

        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - xRange || transform.position.x > startPosition.x + xRange)
        {
            dirX *= -1;
        }
    }

    private void FixedUpdate()
    {
        rgdBdy2D.velocity = new Vector2(dirX * speed, 0);
    }

    private void LateUpdate()
    {
        if (dirX > 0 && localScale.x > 0 || dirX < 0 && localScale.x < 0)
        {
            localScale *= -1;
        }

        transform.localScale = localScale;
    }
}
