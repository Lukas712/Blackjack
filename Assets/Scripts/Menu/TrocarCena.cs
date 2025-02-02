using System;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{


    public void mudar(String cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void sair()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
