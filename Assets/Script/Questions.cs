using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public Text textAnswer;
    public AudioSource musicFail;
    public Text buttonAnswer;

    public void ChangeResult ( StateMachine stateMachine )
        /// <summary>
        /// Сравнивает ответ игрока и правильный вариант ответа
        /// если ответ верен вызывает увеличение счётчика
        /// </summary>
    {
        if (textAnswer.text == buttonAnswer.text)
        {
            stateMachine.IncreamentCounter();
        }
        else
        {
            musicFail.Play();
        }
        stateMachine.ChangeScene();
    }
    
}
