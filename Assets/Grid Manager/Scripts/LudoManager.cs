using UnityEngine;
using System.Collections;

public class LudoManager : MBSingleton<LudoManager>
{
    void Awake()
    {

    }

    public void BasicLayOut()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                CGridManager.Instance.m_GridList.Find(x => x.m_Id == "[" + i + "," + j + "]").GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 14; j > 9; j--)
            {
                CGridManager.Instance.m_GridList.Find(x => x.m_Id == "[" + i + "," + j + "]").GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        for (int j = 0; j < 5; j++)
        {
            for (int i = 14; i > 9; i--)
            {
                CGridManager.Instance.m_GridList.Find(x => x.m_Id == "[" + i + "," + j + "]").GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }

        for (int i = 14; i > 9; i--)
        {
            for (int j = 14; j > 9; j--)
            {
                CGridManager.Instance.m_GridList.Find(x => x.m_Id == "[" + i + "," + j + "]").GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
