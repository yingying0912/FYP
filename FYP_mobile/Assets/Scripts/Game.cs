using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject seed;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Dialogue;

    [SerializeField] GameObject marker;
    Transform[] markers;
    List<GameObject> markersObj = new List<GameObject>();

    public static int currentMarker = 1;

    [SerializeField] NavMeshAgent nmAgent;

    public static bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameState = GameManager.GameStatus.pause;
        markers = marker.GetComponentsInChildren<Transform>();
        for (int i = 0; i < markers.Length; i++)
        {
            markersObj.Add(markers[i].gameObject);
        }
        StartCoroutine("GameStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            if (currentMarker > 1)
            {
                markersObj[currentMarker - 1].SetActive(false);
            }
            nmAgent.SetDestination(markers[currentMarker].position);

            //seed.transform.position = new Vector3(seed.transform.position.x, seed.transform.position.y, seed.transform.position.z + Time.deltaTime);
            //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, seed.transform.position.z - 1.6f);
        }
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(2);

        Dialogue.SetActive(true);
        Dialogue.GetComponentInChildren<Text>().text = "We reached the\nplayground!";

        yield return new WaitForSeconds(2);
        Dialogue.GetComponentInChildren<Text>().text = "There are a lot\nof virus at\nsurrounding.";
        
        yield return new WaitForSeconds(2);
        Dialogue.GetComponentInChildren<Text>().text = "We need to kill\nthe virus if we\nmeet them.";

        yield return new WaitForSeconds(2);
        Dialogue.GetComponentInChildren<Text>().text = "Come! Follow me.";

        yield return new WaitForSeconds(2);
        Dialogue.SetActive(false);

        gameStart = true;
        seed.transform.rotation = new Quaternion(0, 0, 0, 1);

        yield return null;
    }
}
