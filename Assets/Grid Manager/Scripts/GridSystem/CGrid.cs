using UnityEngine;
using System.Collections;

public class CGrid : MonoBehaviour
{
    public string m_Id;

    void Start()
    {
        gameObject.GetComponent<UIEventListener>().onMouseUpAsButton += OnClick;
    }

    void Update()
    {

    }

    void OnClick()
    {
        DebugUtils.Log("I am clicked");
    }

    public void SetColor(Color a)
    {
        gameObject.GetComponent<SpriteRenderer>().color = a;
    }
}
