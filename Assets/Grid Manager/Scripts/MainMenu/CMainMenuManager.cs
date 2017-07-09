using UnityEngine;
using System.Collections;

public class CMainMenuManager : MonoBehaviour
{
    public Camera m_PortraitCamera, m_LandscapeCamera;

    [HideInInspector]
    public CCameraManager m_CurrentActiveCamera;

    private static GameObject m_this;

    public EOrientationMode EOrientation;

    public enum EOrientationMode
    {
        BOTH,
        PORTRAIT,
        LANDSCAPE,
    }

    void Start()
    {
        m_this = gameObject;
        SwitchCamera();
    }

    // not a singleton class
    public static CMainMenuManager Instance
    {
        get
        {
            return m_this.GetComponent<CMainMenuManager>();
        }
    }

    void Update()
    {

    }

    public void SwitchCamera()
    {
        DecideCurrentOrientation();

        m_LandscapeCamera.gameObject.SetActive(false);
        m_PortraitCamera.gameObject.SetActive(false);
        if (EOrientation == EOrientationMode.BOTH)
        {
            if (CGameSettings.m_EOrientation == CGameSettings.EOrientation.LANDSCAPE)
            {
                EnableLandScapeMode();
            }
            else if (CGameSettings.m_EOrientation == CGameSettings.EOrientation.PORTRAIT)
            {
                EnablePortraitMode();
            }
        }
        else
        {
            if( EOrientation == EOrientationMode.LANDSCAPE)
            {
                EnableLandScapeMode();
            }
            else if(EOrientation== EOrientationMode.PORTRAIT)
            {
                EnableLandScapeMode();
            }
        }
    }

    public void DecideCurrentOrientation()
    {
        if (Camera.main.aspect > 1)
        {
            CGameSettings.m_EOrientation = CGameSettings.EOrientation.LANDSCAPE;
        }
        else
        {
            CGameSettings.m_EOrientation = CGameSettings.EOrientation.PORTRAIT;
        }
    }

    public void EnablePortraitMode()
    {
        m_PortraitCamera.gameObject.SetActive(true);
        m_CurrentActiveCamera = m_PortraitCamera.GetComponent<CCameraManager>();
    }

    public void EnableLandScapeMode()
    {
        m_LandscapeCamera.gameObject.SetActive(true);
        m_CurrentActiveCamera = m_LandscapeCamera.GetComponent<CCameraManager>();
    }
}
