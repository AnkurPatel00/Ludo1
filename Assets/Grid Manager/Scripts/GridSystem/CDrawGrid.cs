using UnityEngine;
using System.Collections;

public class CDrawGrid : MonoBehaviour
{
    [HideInInspector]
    public GameObject Square;

    [HideInInspector]
    public Sprite m_GridSprite;

    [HideInInspector]
    public float SpriteWidth;

    private float LeftSide
    {
        get
        {
            return CMainMenuManager.Instance.m_CurrentActiveCamera.m_LeftX + (SpriteWidth / 2f);
        }
    }

    private float RightSide
    {
        get
        {
            return CMainMenuManager.Instance.m_CurrentActiveCamera.m_RightX - (SpriteWidth / 2f);
        }
    }

    private float UpSide
    {
        get
        {
            return CMainMenuManager.Instance.m_CurrentActiveCamera.m_UpY - (SpriteWidth / 2f);
        }
    }

    public float DownSide
    {
        get
        {
            return CMainMenuManager.Instance.m_CurrentActiveCamera.m_DownY + (SpriteWidth / 2f);
        }
    }

    void Awake()
    {
        LoadGameObjects();
    }

    void LoadGameObjects()
    {
        Square = DefaultFunction.Instance.LoadPrefab("Square");

        m_GridSprite = DefaultFunction.Instance.LoadSprite(EnumUtility.EnumToString(CGridManager.Instance.m_GridImage));

        SpriteWidth = m_GridSprite.rect.width / m_GridSprite.pixelsPerUnit;
    }

    public void DrawGrid(bool DrawbyWidth = true)
    {
        float x = 0, y = 0;

        int horizontalGrid = CGridManager.Instance.m_HorizontalGridLength;
        int verticalGrid = CGridManager.Instance.m_VerticalGridLength;

        float offset = CGridManager.Instance.offset;

        float downstarter = -(((verticalGrid - 1) * SpriteWidth) + (verticalGrid - 1) * offset) / 2f;
        float leftstarter = -(((horizontalGrid - 1) * SpriteWidth) + (horizontalGrid - 1) * offset) / 2f;

        if (DrawbyWidth)
        {
            for (int i = 0; i < horizontalGrid; i++)
            {
                x = LeftSide + (i * SpriteWidth) + (i + 1) * offset;

                for (int j = 0; j < verticalGrid; j++)
                {
                    y = downstarter + (j * (SpriteWidth + offset));
                    GameObject g = Instantiate(Square, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                    DefaultFunction.Instance.SetParent(g.transform, CGridManager.Instance.transform);
                    g.GetComponent<CGrid>().m_Id = GameManager.Instance.GetGridName(i, j);
                    g.name = g.GetComponent<CGrid>().m_Id;
                    CGridManager.Instance.m_GridList.Add(g.GetComponent<CGrid>());
                }
            }
        }
        else
        {
            for (int i = 0; i < horizontalGrid; i++)
            {
                x = leftstarter + i * (SpriteWidth + offset);

                for (int j = 0; j < verticalGrid; j++)
                {
                    y = DownSide + (j * SpriteWidth) + (j + 1) * offset;
                    GameObject g = Instantiate(Square, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                    DefaultFunction.Instance.SetParent(g.transform, CGridManager.Instance.transform);
                    g.GetComponent<CGrid>().m_Id = GameManager.Instance.GetGridName(i, j);
                    g.name = g.GetComponent<CGrid>().m_Id;
                    CGridManager.Instance.m_GridList.Add(g.GetComponent<CGrid>());
                }
            }
        }
        SetSprite();
    }

    public void SetSprite()
    {
        for (int i = 0; i < CGridManager.Instance.m_GridList.Count; i++)
        {
            CGridManager.Instance.m_GridList[i].GetComponent<SpriteRenderer>().sprite = m_GridSprite;
        }
    }
}
