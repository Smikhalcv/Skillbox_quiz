using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject firstScene;
    [SerializeField] private GameObject finalScene;
    public Text counter;
    public List<GameObject> ListScenes = new List<GameObject>();
    List<GameObject> ListQuestions = new List<GameObject>();
    private static System.Random rng = new System.Random();

    private GameObject currentScene;
    public static int countAnswer = 0;

    private void Start()
    {
        firstScene.SetActive(true);
        currentScene = firstScene;
        Debug.Log("start game");
        Debug.Log(ListScenes.Count);
        Debug.Log(ListQuestions.Count);
        Debug.Log(countAnswer);
        counter.text = countAnswer.ToString();
    }

    
    public void MadeListQuestions()
        /// <summary>
        /// Создаёт список вопросов из списка сцен перетусовывая порядок
        /// до 10 вопросов или пока длина списка вопросов
        /// не сравняется с длиной списка сцен
        /// </summary>
        
    {
        Debug.Log("make list");
        //while (ListQuestions.Count < 11 && ListQuestions.Count <= ListScenes.Count)
        //{
        //    int RandomIndex = rng.Next(ListScenes.Count - 1);
        //    if (!ListQuestions.Contains(ListScenes[RandomIndex]))
        //    {
        //        ListQuestions.Add(ListScenes[RandomIndex]);
        //    }
        //}
        while (ListQuestions.Count < 11)
        {
            int RandomIndex = rng.Next(ListScenes.Count - 1);
            ListQuestions.Add(ListScenes[RandomIndex]);
        }
    }

    public void ChangeScene()
    {
        /// <summary>
        /// 
        /// </summary>
        Debug.Log("нажата смена сцены");
        Debug.Log(countAnswer);
        if (currentScene != null)
        {
            if (ListQuestions.Count > 0)
            {
                firstScene.SetActive(false);
                ListQuestions[0].SetActive(true);
                currentScene = ListQuestions[0];
                ListQuestions.RemoveAt(0);
            }
            else
            {
                finalScene.SetActive(true);
                currentScene = finalScene;
            }

        }

        
    }

    public void IncreamentCounter()
    {
        countAnswer += 1;
        Debug.Log($"Число ответов теперь {countAnswer}");
        counter.text = countAnswer.ToString();
    }
}
