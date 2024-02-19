using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    public void OnPointerDown()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        m_TextComponent.text = "Test";
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
