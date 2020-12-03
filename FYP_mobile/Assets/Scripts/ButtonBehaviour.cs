using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ButtonBehaviour: MonoBehaviour
{
    public NetworkManager networkManager;

    public void OnServer()
    {
        networkManager.StartServer();
    }
}
