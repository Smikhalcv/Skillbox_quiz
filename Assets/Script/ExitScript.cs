using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Выход нажали!");
    }
}
