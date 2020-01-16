using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, GMInterface
{
    private GameObject nPPrefab;
    private GameObject numberPlate;
    private int lifePoint;

    void Start()
    {
        nPPrefab = Resources.Load("Prefabs/NumberPlate") as GameObject;
        numberPlate = Instantiate(nPPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // displayQuestion();
    }

    void Update()
    {
        // Debug.Log(GameObject.Find("Text_01").GetComponent<Text>().text);
    }

    public void NextQ(int answerFlag)
    {
        Destroy(numberPlate);
        numberPlate = Instantiate(nPPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // ExecuteEvents.Execute<SMInterface>(
        //     target: scoreManager,
        //     eventData: null,
        //     functor: (reciever, eventData) => reciever.UpdateScore(answerFlag)
        // );
    }
}

public interface GMInterface : IEventSystemHandler
{
    void NextQ(int answerFlag);
}
