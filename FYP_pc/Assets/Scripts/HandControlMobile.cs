using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;

public class HandControlMobile : MonoBehaviour {

	Thread receiveThread;

	UdpClient client;

	private int port = 1999; 

	string[] sArray = new string[352];

	public GameObject rightHandPrefab,leftHandPrefab;

	//private GameObject currentRightHand, currentLeftHand;

	private bool shouldUpdateHands = false;
	private bool shouldDestroyHands = false;

	private bool rightHandExists = false;
	private bool leftHandExists = false;

	private Vector3 position1, position2;
	private Quaternion rotation1, rotation2;

	int arrayLength = 0;


	public void Start()
	{
		Application.targetFrameRate = 60;

		receiveThread = new Thread(new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}

	void Update(){

		/*
		if (shouldDestroyHands) {
			shouldDestroyHands = false;
			if (transform.childCount > 0) {
				DestroyHands ();
			}
		}
		*/

		if (shouldUpdateHands) {
			shouldUpdateHands = false;
			UpdateHands ();
		}
	}

	void UpdateHands(){

		//rightHandExists = false;
		//leftHandExists = false;

		for (int i = 0; i < 352; i++)
        {
			try
			{
				sArray[i] = sArray[i].Trim('(', ')');
			}
            catch
			{
				//sArray[i] = sArray[i];
            }
        }

		if (sArray.Length > 1) {
			for (int i = 1; i < 175; i += 7)
            {
				sArray[i] = sArray[i].TrimStart('(');
                sArray[i + 2] = sArray[i + 2].TrimEnd(')');
				sArray[i + 3] = sArray[i + 3].TrimStart('(');
				sArray[i + 6] = sArray[i + 6].TrimEnd(')');
            }

			position1 = new Vector3(float.Parse(sArray[1]),float.Parse(sArray[2]),float.Parse(sArray[3]));
			rotation1 = new Quaternion(float.Parse(sArray[4]),float.Parse(sArray[5]),float.Parse(sArray[6]),float.Parse(sArray[7]));

			if (sArray [0] == "l") 
			{
				//leftHandExists = true;

				//if (currentLeftHand == null) {
				//	currentLeftHand = Instantiate (leftHandPrefab);

				Transform left = leftHandPrefab.transform.GetChild(0).GetChild(0);

				left.localPosition = position1;
				left.localRotation = rotation1;

				int j = 8;

				for (int i = 0; i < 5; i++)
				{
					Transform currentLeft = left.transform.GetChild(i);
					do
					{
						Vector3 position = new Vector3(float.Parse(sArray[j]), float.Parse(sArray[j + 1]), float.Parse(sArray[j + 2]));
						Quaternion rotation = new Quaternion(float.Parse(sArray[j + 3]), float.Parse(sArray[j + 4]), float.Parse(sArray[j + 5]), float.Parse(sArray[j + 6]));
						currentLeft.localPosition = position;
						currentLeft.localRotation = rotation;

						currentLeft = currentLeft.transform.GetChild(0);
						j += 7;

					} while (currentLeft.transform.childCount > 0);
				}

			}
			else if (sArray [0] == "r") 
			{
				//rightHandExists = true;
				//if (currentRightHand == null) {
				//	currentRightHand = Instantiate (rightHandPrefab, this.transform);
				//}

				//currentRightHand.transform.GetChild(0).GetChild(0).position = position1;
				//currentRightHand.transform.GetChild(0).GetChild(0).rotation = rotation1;

				Transform right = rightHandPrefab.transform.GetChild(0).GetChild(0);

				right.localPosition = position1;
				right.localRotation = rotation1;

				int j = 8;

				for (int i = 0; i < 5; i++)
				{
					Transform currentRight = right.transform.GetChild(i);
					currentRight = currentRight.transform.GetChild(0);
					do
					{
						Vector3 position = new Vector3(float.Parse(sArray[j]), float.Parse(sArray[j + 1]), float.Parse(sArray[j + 2]));
						Quaternion rotation = new Quaternion(float.Parse(sArray[j + 3]), float.Parse(sArray[j + 4]), float.Parse(sArray[j + 5]), float.Parse(sArray[j + 6]));
						currentRight.localPosition = position;
						currentRight.localRotation = rotation;

						currentRight = currentRight.transform.GetChild(0);
						j += 7;

					} while (currentRight.transform.childCount > 0);
				}
			}
		}

		
		if (sArray.Length > 176) {
			for (int i = 177; i < 352; i += 7)
			{
				sArray[i] = sArray[i].TrimStart('(');
				sArray[i + 2] = sArray[i + 2].TrimEnd(')');
				sArray[i + 3] = sArray[i + 3].TrimStart('(');
				sArray[i + 6] = sArray[i + 6].TrimEnd(')');
			}


			position2 = new Vector3(float.Parse(sArray[179]),float.Parse(sArray[180]),float.Parse(sArray[181]));
			rotation2 = new Quaternion(float.Parse(sArray[182]),float.Parse(sArray[183]),float.Parse(sArray[184]),float.Parse(sArray[185]));

			if (sArray[176] == "l")
			{
				//leftHandExists = true;

				//if (currentLeftHand == null) {
				//	currentLeftHand = Instantiate (leftHandPrefab);
				//}

				Transform left = leftHandPrefab.transform.GetChild(0).GetChild(0);

				left.localPosition = position2;
				left.localRotation = rotation2;

				int j = 184;

				for (int i = 0; i < 5; i++)
				{
					Transform currentLeft = left.transform.GetChild(i);
					do
					{
						Vector3 position = new Vector3(float.Parse(sArray[j]), float.Parse(sArray[j + 1]), float.Parse(sArray[j + 2]));
						Quaternion rotation = new Quaternion(float.Parse(sArray[j + 3]), float.Parse(sArray[j + 4]), float.Parse(sArray[j + 5]), float.Parse(sArray[j + 6]));
						currentLeft.localPosition = position;
						currentLeft.localRotation = rotation;

						currentLeft = currentLeft.transform.GetChild(0);
						j += 7;

					} while (currentLeft.transform.childCount > 0);

				}
			}
			else if (sArray[176] == "r")
			{
				//rightHandExists = true;
				//if (currentRightHand == null) {
				//	currentRightHand = Instantiate (rightHandPrefab, this.transform);
				//}

				//currentRightHand.transform.GetChild(0).GetChild(0).position = position1;
				//currentRightHand.transform.GetChild(0).GetChild(0).rotation = rotation1;

				Transform right = rightHandPrefab.transform.GetChild(0).GetChild(0);

				right.localPosition = position2;
				right.localRotation = rotation2;

				int j = 184;

				for (int i = 0; i < 5; i++)
				{
					Transform currentRight = right.transform.GetChild(i);
					currentRight = currentRight.transform.GetChild(0);
					do
					{
						Vector3 position = new Vector3(float.Parse(sArray[j]), float.Parse(sArray[j + 1]), float.Parse(sArray[j + 2]));
						Quaternion rotation = new Quaternion(float.Parse(sArray[j + 3]), float.Parse(sArray[j + 4]), float.Parse(sArray[j + 5]), float.Parse(sArray[j + 6]));
						currentRight.localPosition = position;
						currentRight.localRotation = rotation;

						currentRight = currentRight.transform.GetChild(0);
						j += 7;

					} while (currentRight.transform.childCount > 0);
				}
			}
			/*
			if (sArray [8] == "l") {
				leftHandExists = true;
				if (currentLeftHand == null) {
					currentLeftHand = Instantiate (leftHandPrefab, this.transform);
				}

				currentLeftHand.transform.transform.localPosition = position2;
				currentLeftHand.transform.transform.localRotation = rotation2;

			} else if (sArray [8] == "r") {
				rightHandExists = true;
				if (currentRightHand == null) {
					currentRightHand = Instantiate (rightHandPrefab, this.transform);
				}

				currentRightHand.transform.transform.localPosition = position2;
				currentRightHand.transform.transform.localRotation = rotation2;
			}
			*/
		}
		
		/*
		if (!leftHandExists) {
			Destroy (currentLeftHand);
		}
		if (!rightHandExists) {
			Destroy (currentRightHand);
		}
		*/
	}

	void DestroyHands(){

		foreach (Transform child in gameObject.transform) {

			Destroy (child.gameObject);
		}
	}

	// receive thread
	void ReceiveData()
	{
		client = new UdpClient(port);
		IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);

		while (true)
		{
			byte[] data = client.Receive(ref anyIP);

			if (data.Length != 0)
            {
				string text = Encoding.UTF8.GetString(data);

				// split the items by comma
				sArray = text.Split(',');
				sArray = sArray.Where(i => !string.IsNullOrEmpty(i)).ToArray();
				Debug.Log(sArray.Length);
				shouldUpdateHands = true;
			}
		}
	}
}
