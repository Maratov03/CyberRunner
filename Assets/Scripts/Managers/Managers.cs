using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(MissionManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static AudioManager Audio { get; private set; }
    public static MissionManager Mission { get; private set; }
    private List<IGameManager> _startSequense;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Player = GetComponent<PlayerManager>();
        Audio = GetComponent<AudioManager>();
        Mission = GetComponent<MissionManager>();
        _startSequense = new List<IGameManager>();
        _startSequense.Add(Player);
        _startSequense.Add(Audio);
        _startSequense.Add(Mission);


        StartCoroutine(StartupManagers());
    }
    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequense)
        {
            manager.Startup();
        }
        yield return null;
        int numModules = _startSequense.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManager manager in _startSequense)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            yield return null;              
        }
        Debug.Log("All managers are started up");
        Messenger.Broadcast(StartupEvent.MANAGERS_STARTED);
    }
}
