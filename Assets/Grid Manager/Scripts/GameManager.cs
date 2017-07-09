using UnityEngine;
using System.Collections;

public class GameManager : MBSingleton<GameManager>
{
    public string GetGridName(int i, int j)
    {
        return "[" + i + "," + j + "]";
    }
}
