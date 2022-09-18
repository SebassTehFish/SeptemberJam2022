using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public string textValue;
    public TextMeshProUGUI textElement;
    GameController gameController;
    UIControl UI;
    [SerializeField] int foodOrderIndex;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        UI = GameObject.Find("Main Camera").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UI.getFoodOrders()[foodOrderIndex] == 0)
            textValue = "";
        else
            textValue = UI.getFoodOrders()[foodOrderIndex].ToString();
        textElement.text = textValue;
    }
}
