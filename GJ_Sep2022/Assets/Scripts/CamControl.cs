using UnityEditor;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    //Delete when debugging is done (ChangeScene Method gets called)
    [SerializeField]
    private bool topFloors;

    [SerializeField]
    private int yDiff, smoothSpeed;

    private void LateUpdate()
    {
        if (topFloors && !(yDiff == (int)transform.position.y))
        {
            transform.position += new Vector3(0, smoothSpeed * Time.deltaTime, 0);
        } else if (!topFloors && !(0 == (int)(transform.position.y + 0.99))) {
            transform.position -= new Vector3(0, smoothSpeed * Time.deltaTime, 0);
        }
    }

    public void ChangeScene()
    {
        topFloors = !topFloors;
    }
}
