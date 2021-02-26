using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.Sockets;
using System.Text;

public class HandControl : MonoBehaviour {

	private static int localPort;

	private string IP = "127.0.0.1"; //cell

	private int port = 1999;  

	IPEndPoint remoteEndPoint;
	UdpClient client;

	private string strMessage;

	public static Vector3 offSetLeft = Vector3.zero;
	public static Vector3 offSetRight = Vector3.zero;

	[SerializeField] GameObject LeftHand;
	[SerializeField] GameObject RightHand;

	// Use this for initialization
	void Start () {

		Application.runInBackground = true;

		remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
		client = new UdpClient();

		
		//load saved offset data
		if (PlayerPrefs.HasKey ("offsetLeftX")) {
			offSetLeft = new Vector3(PlayerPrefs.GetFloat("offsetLeftX"),PlayerPrefs.GetFloat("offsetLeftY"),PlayerPrefs.GetFloat("offsetLeftZ"));
		}
		if (PlayerPrefs.HasKey ("offsetRightX")) {
			offSetRight = new Vector3(PlayerPrefs.GetFloat("offsetRightX"),PlayerPrefs.GetFloat("offsetRightY"),PlayerPrefs.GetFloat("offsetRightZ"));
		}
		
		

		StartCoroutine (SendData());
	}

	
	void OnApplicationQuit()
	{
		//save offset x
		PlayerPrefs.SetFloat ("offsetLeftX", offSetLeft.x);
		PlayerPrefs.SetFloat ("offsetLeftY", offSetLeft.y);
		PlayerPrefs.SetFloat ("offsetLeftZ", offSetLeft.z);

		//save offset y
		PlayerPrefs.SetFloat ("offsetRightX", offSetRight.x);
		PlayerPrefs.SetFloat ("offsetRightY", offSetRight.y);
		PlayerPrefs.SetFloat ("offsetRightZ", offSetRight.z);
	}
	

	IEnumerator SendData(){

		while (true) 
		{
			strMessage = "";
			if (LeftHand.transform.childCount > 0)
			{
				if (LeftHand.active)
				{
					Transform left = LeftHand.transform.GetChild(0).GetChild(0);
					strMessage += "l," + (left.position + offSetLeft).ToString() + "," + left.rotation.ToString() + ",";
					for (int i = 0; i < 5; i++)
                    {
						Transform currentLeft = left.transform.GetChild(i);
						strMessage += (currentLeft.position + offSetLeft).ToString() + "," + currentLeft.rotation.ToString() + ",";
						do
						{
							currentLeft = currentLeft.transform.GetChild(0);
							strMessage += (currentLeft.position + offSetLeft).ToString() + "," + currentLeft.rotation.ToString() + ",";
						} while (currentLeft.transform.childCount > 0);
					}
				}
			}
			if (RightHand.transform.childCount > 0)
            {
				if (RightHand.active)
				{
					Transform right = RightHand.transform.GetChild(0).GetChild(0);
					strMessage += "r," + (right.position + offSetRight).ToString() + "," + right.rotation.ToString() + ",";
					
					for (int i = 0; i < 5; i++)
					{
						Transform currentRight = right.transform.GetChild(i);
						strMessage += (currentRight.position + offSetLeft).ToString() + "," + currentRight.rotation.ToString() + ",";
						do
						{
							currentRight = currentRight.transform.GetChild(0);
							strMessage += (currentRight.position + offSetLeft).ToString() + "," + currentRight.rotation.ToString() + ",";
						} while (currentRight.transform.childCount > 0);
					}
				}
			}

			byte[] data = Encoding.UTF8.GetBytes(strMessage);

			var message = client.Send(data, data.Length, remoteEndPoint);

			yield return message;
		}
	}
 }
