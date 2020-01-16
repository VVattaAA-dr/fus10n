using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberPlate : MonoBehaviour
{
    private GameObject gameManager;
    private int goalNumber; // 目標の数字
    // private GameObject method; // 計算方法
    private int[] generatedNumberList = new int[4]; // ランダムに生成された4つの数字の配列
    private Text[] buttonTextList = new Text[4]; // ボタンに表示するテキストの配列
    // private int elementNumber; // 選択する数字の数
    private int answer; // プレイヤーの解答
    // private List<int> inputNumberList = new List<int>(); // 入力された数字のリスト
    private int answerFlag = 0;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        goalNumber = 10;

        for (int i = 0; i < buttonTextList.Length; i++)
        {
            string buttonTextName = "Canvas/Number_0" + (i + 1).ToString() + "/Text_0" + (i + 1).ToString();
            Debug.Log(buttonTextName);
            buttonTextList[i] = gameObject.transform.Find(buttonTextName).GetComponent<Text>();
            Debug.Log(buttonTextList[i]);
        }

        GenerateNumber();

        for (int i = 0; i < 4; i++)
        {
            buttonTextList[i].text = generatedNumberList[i].ToString();
            Debug.Log(buttonTextList[i].text);
        }
    }

    public void OnClick(int number)
    {
        answer += int.Parse(buttonTextList[number].text);

        if (goalNumber == answer)
        {
            answerFlag = 1;
            Debug.Log(answer);
            Debug.Log("correct");
        }
        else if (goalNumber < answer)
        {
            answerFlag = 2;
            Debug.Log(answer);
            Debug.Log("incorrect");
        }
        else
        {
            Debug.Log(answer);
        }

        if (answerFlag != 0)
        {
            ExecuteEvents.Execute<GMInterface>(
                target: gameManager,
                eventData: null,
                functor: (reciever, eventData) => reciever.NextQ(answerFlag)
            );
        }
    }

    private void GenerateNumber()
    {
        Debug.Log("GenerateNumber is called");
        List<int> possibleNumberList = new List<int>(); // 表示される数字の候補の配列
        List<int> displayNumberList = new List<int>(); // 表示される数字の配列

        for (int i = 0; i < goalNumber - 1; i++)
        {
            possibleNumberList.Add(i + 1);
        }

        // methodが加法なら
        int number1 = Random.Range(1, goalNumber);
        int number2 = goalNumber - number1;
        int number3;
        int number4;

        generatedNumberList[0] = number1;
        generatedNumberList[1] = number2;

        if (number1 == number2)
        {
            possibleNumberList.Remove(number1);
        }
        else
        {
            possibleNumberList.Remove(number1);
            possibleNumberList.Remove(number2);
        }

        number3 = possibleNumberList[Random.Range(0, possibleNumberList.Count)];
        possibleNumberList.Remove(number3);
        number4 = possibleNumberList[Random.Range(0, possibleNumberList.Count)];
        possibleNumberList.Remove(number4);

        generatedNumberList[2] = number3;
        generatedNumberList[3] = number4;

        generatedNumberList = ArrayShuffle(generatedNumberList);
    }

    private int[] ArrayShuffle(int[] array)
    {
        int length = array.Length;
        int[] result = new int[length];
        array.CopyTo(result, 0);

        for (int i = 0; i < length; i++)
        {
            int origin = result[i];
            int randomIndex = Random.Range(i, length);
            result[i] = result[randomIndex];
            result[randomIndex] = origin;
        }

        return result;
    }
}

public interface NPInterface
{

}
