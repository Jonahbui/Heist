using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPlaying;

    private void Awake()
    {
        if (Instance == null)
        {
            // Note: this gameobject needs to be at the root of hierarchy for DontDestroyOnLoad
            this.gameObject.transform.parent = null;

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("[Heist] Multiple GameManagers. Deleting extra...");
            Destroy(this);
        }
    }
}
