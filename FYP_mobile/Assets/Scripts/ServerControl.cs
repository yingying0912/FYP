using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class ServerControl : MonoBehaviour
{
    private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private static Socket clientSocket;
    private const int PORT = 8888;
    private static byte[] buffer;

    private Vector3 vector = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        SetupServer();
        DontDestroyOnLoad(this.gameObject);
        Debug.Log(vector);
    }

    // Update is called once per frame
    void Update()
    {
        ReceiveData();
    }

    private static void SetupServer()
    {
        IPAddress ipAddress = IPAddress.Loopback;
        Debug.Log("IP Address of server: " + ipAddress);

        serverSocket.Bind(new IPEndPoint(ipAddress, PORT));
        serverSocket.Listen(0);
        Debug.Log("Server setup complete");          
    }

    private static void ReceiveData()
    {
        while (clientSocket == null)
        {
            clientSocket = serverSocket.Accept();
        }

        Debug.Log("Client Connected");
        buffer = new byte[clientSocket.ReceiveBufferSize];

        while (clientSocket.Connected)
        {
            int received = clientSocket.Receive(buffer);
            if (received == 0) return;

            Array.Resize(ref buffer, received);
            string receivedMsg = Encoding.ASCII.GetString(buffer);
            Array.Resize(ref buffer, clientSocket.ReceiveBufferSize);
            Debug.Log("Message received: " + receivedMsg);
        }
    }

    private static void closeSocket()
    {
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
        serverSocket.Close();
    }
}
