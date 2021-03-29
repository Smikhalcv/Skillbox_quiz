using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsInput : MonoBehaviour
{
    public InputField inputField;
    public string answer;
    public AudioSource musicFail;

    public void questionInputScene (StateMachine stateMachine)
        /// <summary>
        /// Сравнивает вариант ответа введённый игроком и правильный вариант ответа
        /// если они равно вызывает увеличение счётчика
        /// </summary>
    {
        string inputAnswer = inputField.text.ToString().ToLower();

        if (answer == inputAnswer)
        {
            stateMachine.IncreamentCounter();
        }
        else
        {
            musicFail.Play();
        }
        inputField.Select();
        inputField.text = "";
        Debug.Log("отработал скрипт на увеличение счётчика");
        
    }
}
