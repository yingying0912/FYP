using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;

public class IPAddressController : MonoBehaviour
{
    Text t_IP;
    string ip;
    // Start is called before the first frame update
    void Start()
    {
        t_IP = GetComponent<Text>();
        ip = GetLocalIPAddress();
    }

    // Update is called once per frame
    void Update()
    {
        t_IP.text = "IP Address: " + ip;
    }

    string GetLocalIPAddress()
    {
        return Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(
                 f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
             .ToString();
    }
}
