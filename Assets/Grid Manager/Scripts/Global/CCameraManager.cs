using UnityEngine;
using System.Collections;
using System;

//This things are for Orthographic Camera Only
[RequireComponent(typeof(Camera))]
public class CCameraManager : MonoBehaviour
{
    public Camera m_Camera;

    private float orthosize;
    public float m_orthosize
    {
        get
        {
            return m_Camera.orthographicSize;
        }        
    }

    public float worldScreenHalfWidth
    {
        get
        {
            return CUtility.RoundingTofloat(m_orthosize * m_Camera.aspect);
        }
    }

    public float m_UpY
    {
        get
        {
            return CUtility.RoundingTofloat(m_orthosize + transform.position.y);
        }
    }

    public float m_DownY
    {
        get
        {
            return CUtility.RoundingTofloat(-m_orthosize + transform.position.y);
        }
    }

    public float m_RightX
    {
        get
        {
            return CUtility.RoundingTofloat(worldScreenHalfWidth + transform.position.x);
        }
    }

    public float m_LeftX
    {
        get
        {
            return CUtility.RoundingTofloat(-worldScreenHalfWidth + transform.position.x);
        }
    }

    public float m_Width
    {
        get
        {
            return CUtility.RoundingTofloat(worldScreenHalfWidth * 2);
        }
    }

    public float m_Height
    {
        get
        {
            return CUtility.RoundingTofloat(m_orthosize * 2);
        }
    }

    //we dont want to make it singleton as we have multiple camera and we need their personal values.

    //public static CCameraManager Instance
    //{
    //    get
    //    {
    //        return m_this.GetComponent<CCameraManager>();
    //    }
    //}

    void Awake()
    {
        VariableAssignMent();
        //DebugAllValues();
    }

    void VariableAssignMent()
    {
        m_Camera = gameObject.GetComponent<Camera>();
    }

    public void DebugAllValues()
    {
        DebugUtils.Log("m_orthosize =>" + m_orthosize);
        DebugUtils.Log("m_Width =>" + m_Width);
        DebugUtils.Log("m_Height =>" + m_Height);
        DebugUtils.Log("m_UpY =>" + m_UpY);
        DebugUtils.Log("m_DownY =>" + m_DownY);
        DebugUtils.Log("m_RightX =>" + m_RightX);
        DebugUtils.Log("m_LeftX =>" + m_LeftX);
    }

    public void SetOrthoGraphicSize(float size)
    {
        m_Camera.orthographicSize = size;
    }

    public void IncrementOrthoSize(float Incrementby)
    {
        m_Camera.orthographicSize += Incrementby;
    }
}
