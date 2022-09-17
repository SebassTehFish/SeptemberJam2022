using UnityEditor;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    //Delete when debugging is done (ChangeScene Method gets called)
    [SerializeField]
    private bool topFloors;

    // yInitial is starting centered position (centered position of bottom 3 floors
    // yFinal is ending centered position (centered position of top 3 floors)
    [SerializeField]
    private int yInitial, yFinal, smoothSpeed;

    private void LateUpdate()
    {
        // Centers camera y position on yFinal (as close as it will get)
        if (topFloors && !(yFinal == (int)transform.position.y))
        {
            transform.position += new Vector3(0, smoothSpeed * Time.deltaTime, 0);
        } else if (!topFloors && !(yInitial == (int)(transform.position.y + 0.99))) {
            // Centers camera y position on yInitial (as close as it will get)
            transform.position -= new Vector3(0, smoothSpeed * Time.deltaTime, 0);
        }
    }

    public void ChangeScene()
    {
        topFloors = !topFloors;
    }
}
