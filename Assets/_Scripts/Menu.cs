using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//class used for buttons
public class Menu : MonoBehaviour {

    public string mainMenuScene;
    public string mainGameScene;
    public string backStoryScene;
    public string controlsScene;
	public string characterScene;
	public string levelsScene;
	public string snowLevelScene;
	public string spaceLevelScene;

    public void MenuScene()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainGameScene);
    }

    public void Controls()
    {
        SceneManager.LoadScene(controlsScene);
    }

    public void BackStory()
    {
        SceneManager.LoadScene(backStoryScene);
    }

	public void characterSelect()
	{
		SceneManager.LoadScene(characterScene);
	}

	public void levelSelect()
	{
		SceneManager.LoadScene(levelsScene);
	}

	public void SnowLevel()
	{
		SceneManager.LoadScene(snowLevelScene);
	}

	public void SpaceLevel()
	{
		SceneManager.LoadScene(spaceLevelScene);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
