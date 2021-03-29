using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject firstScene;
    [SerializeField] private GameObject finalScene;
    public AudioSource musicWin;
    public AudioSource musicFail;

    public Text counter;
    public Text finalText;
    public List<GameObject> ListScenes = new List<GameObject>();
    List<GameObject> ListQuestions = new List<GameObject>();
    private static System.Random rng = new System.Random();

    private GameObject currentScene;
    public static int countAnswer;
    

    private void Start()
    {
        // Запускает начальный экран
        firstScene.SetActive(true);
        currentScene = firstScene;
        counter.text = countAnswer.ToString();
    }

    
    public void MadeListQuestions()
        /// <summary>
        /// Создаёт список вопросов из списка сцен перетусовывая порядок
        /// до 10 вопросов, обнуляет счётчик и эпилог
        /// </summary>
    {
        Debug.Log("make list");
        countAnswer = 0;
        finalText.text = "Что? 0? Не можешь даже угадать???";
        while (ListQuestions.Count < 10)
        {
            int RandomIndex = rng.Next(ListScenes.Count);
            if (!ListQuestions.Contains(ListScenes[RandomIndex]))
            {
                ListQuestions.Add(ListScenes[RandomIndex]);
            }
        }
        Debug.Log(ListQuestions.Count);
    }

    public void ChangeScene()
    {
        /// <summary>
        /// Меняет сцену, удаляя предыдущую из списка
        /// если список пуст запускат финальную сцену
        /// </summary>
        Debug.Log("нажата смена сцены");
        Debug.Log(countAnswer);
        if (currentScene != null)
        {
            if (ListQuestions.Count > 0)
            {
                currentScene.SetActive(false);
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
        ///<summary>
        /// Увеличивает счётчик правильных ответов и переопределяет эпилог
        /// </summary>
    {
        countAnswer += 1;
        Debug.Log($"Число ответов теперь {countAnswer}");
        counter.text = countAnswer.ToString();
        musicWin.Play();
        if ((countAnswer >= 1) && (countAnswer <= 5))
        {
            finalText.text = "Слишком!!!\r\nСлишком плохо, чтоб бросать мне вызов!\r\nЖалкий Глупец!!!!!";
        }
        else if ((countAnswer >= 6) && (countAnswer <= 9))
        {
            finalText.text = "Неплохо!\r\nНо не достаточно, чтоб бросать мне вызов!!!";
        }
        else
        {
            finalText.text = "Да как ты смеешь?!\r\nКем ты себя считаешь?!\r\nНичего в следующий раз удача не будет к тебе так благосклонна!!!!";
        }
    }

    public void MainMenu()
        // Запускает главное меню
    {
        currentScene.SetActive(false);
        firstScene.SetActive(true);
        currentScene = firstScene;
    }
}
