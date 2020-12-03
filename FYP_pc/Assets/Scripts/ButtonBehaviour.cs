using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class ButtonBehaviour: MonoBehaviour
{
    public NetworkManager networkManager;
    public Text t_ip;

    public void OnClient()
    {
        networkManager.networkAddress = t_ip.text.ToString();
        networkManager.StartClient();
    }
}
