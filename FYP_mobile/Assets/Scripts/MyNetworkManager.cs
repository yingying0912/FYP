using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : MonoBehaviour
{
    [SerializeField] NetworkManager networkManager;

    // Start is called before the first frame update
    void Start()
    {
        networkManager.StartServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
