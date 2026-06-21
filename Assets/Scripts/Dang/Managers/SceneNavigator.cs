using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void GoToCharacterSelect()
    {
        Debug.Log("Going to Character Select Scene");
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void GoToMapSelect()
    {
        Debug.Log("Going to Map Select Scene");
        SceneManager.LoadScene("MapSelectScene");
    }

    public void GoToBattle()
    {
        Debug.Log("Going to Battle Scene");
        SceneManager.LoadScene("Ingame_Demo");
    }

    public void GoToMainMenu()
    {
        Debug.Log("Going to Main Menu Scene");
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit Game");
    }
}
