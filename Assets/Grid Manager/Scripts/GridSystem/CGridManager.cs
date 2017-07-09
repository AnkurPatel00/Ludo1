using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CGridManager : MonoBehaviour
{
    public GridType m_GridType;
    public GridImage m_GridImage;
    public CDrawGrid m_CDrawGrid;

    public int m_HorizontalGridLength, m_VerticalGridLength;

    private static GameObject m_this; // to create singleton class

    public float offset;   //difference between each grid

    public enum GridType
    {
        NONE,
        SPRITE, // Attached Sprite Renderer and Box collider for Click Events
    }

    public enum GridImage
    {
        NONE,
        SQUARE,
        DOT,
        FRAME,
        RED,
        WOOD,
        OAK,
        GLASS,
        BLACK_DOT,
        WHITE,
    }

    [HideInInspector]
    public List<CGrid> m_GridList = new List<CGrid>();

    public static CGridManager Instance
    {
        get
        {
            return m_this.GetComponent<CGridManager>();
        }
    }

    void Awake()
    {
        m_this = gameObject;
    }

    void Start()
    {

        /* 
         *  For n*n Grid lets create a virtual screen in Game. (i.e. 8*8)
         
         Maximum resolution:
               Resolution 1536*2048 (so orthographic Camera have size will be 10.24 (2048/200))
         * Lets we keep 9:16 (minimum Aspect Ratio)
         * 
         * width will be 11.52 and height will be 20.48 
         * 
         * 
        */

        SetCamera();

        // Will change the orthographic size based on horizontal and vertical grid numbers.
    }

    void SetCamera()
    {
        // will be landscape camera or portrait
        CCameraManager m_currentCamera = CMainMenuManager.Instance.m_CurrentActiveCamera;

        float totalcoveredwidth, totalcoveredheight;

        // will decide to draw grid by horizontall or vertically

        // Considering by width wise
        if ((m_currentCamera.m_Camera.aspect * m_VerticalGridLength / m_HorizontalGridLength) <= 1)
        {
            totalcoveredwidth = m_CDrawGrid.SpriteWidth * m_HorizontalGridLength; // 1.28*8 = 10.24

            totalcoveredwidth += (m_HorizontalGridLength + 1) * offset;

            m_currentCamera.SetOrthoGraphicSize(totalcoveredwidth / (m_currentCamera.m_Camera.aspect * 2));
            m_CDrawGrid.DrawGrid();
        }

        //Considering by height wise
        else
        {
            totalcoveredheight = m_CDrawGrid.SpriteWidth * m_VerticalGridLength; // 1.28*12 = 15.36

            totalcoveredheight += (m_VerticalGridLength + 1) * offset;

            m_currentCamera.SetOrthoGraphicSize(totalcoveredheight / 2);
            m_CDrawGrid.DrawGrid(false);
        }

        LudoManager.Instance.BasicLayOut();
    }
}