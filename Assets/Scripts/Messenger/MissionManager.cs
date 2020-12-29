using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public int curLevel { get; private set; }
    public int maxLelel { get; private set; }

    public void Startup()
    {
        Debug.Log("Mission manager starting...");
        curLevel = 0;
        maxLelel = 1;
        status = ManagerStatus.Started;
    }
    public void GoToNext()
    {
        if (curLevel > maxLelel)
        {
            curLevel++;
            string name = "Scene" + curLevel;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last level");
        }
    }
}
