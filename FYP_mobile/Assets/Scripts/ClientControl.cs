using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class ClientControl : MonoBehaviour
{
    private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private const int PORT = 8888;
    public string ip;

    [SerializeField] GameObject LeftHand;
    [SerializeField] GameObject RightHand;


    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(SendData());
    }

    private void ConnectToServer()
    {
        while (!clientSocket.Connected)
        {
            try
            {
                clientSocket.Connect(IPAddress.Parse(ip), PORT);
            }
            catch (SocketException ex)
            {
                Debug.LogError(ex.Message);
            }
            Debug.Log("Connected");
        }
    }

    IEnumerator SendData()
    {
        string data = "Sending Data...";
        byte[] buffer = Encoding.ASCII.GetBytes(data);
        clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
         
        while (true)
        {
            string msg = "";

            if (LeftHand.active)
            {
                Transform palm = LeftHand.transform.GetChild(0).GetChild(0);
                Vector3 position = palm.transform.position;
                msg = position.ToString();
                Debug.Log(msg);
                
                
            }

            buffer = Encoding.ASCII.GetBytes(msg);

            clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);



            yield return null;

        }
    }
}
