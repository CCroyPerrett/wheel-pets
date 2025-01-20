using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwapping : MonoBehaviour
{
    public AudioSource buttonClickSound;

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        PlayButtonClickSound();
        if (buttonClickSound != null)
        {
            yield return new WaitWhile(() => buttonClickSound.isPlaying);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void LoadDrivingGameScene()
    {
        StartCoroutine(LoadSceneWithDelay("DrivingGameScene"));
    //Load GameScene
    public void LoadDrivingGameScene()
    {
        SceneManager.LoadScene("DrivingGameScene");
    }

    public void LoadPetGameScene()
    {
        StartCoroutine(LoadSceneWithDelay("PetGameScene"));
    }
    public void LoadPetStoreScene()
    {
        StartCoroutine(LoadSceneWithDelay("PetStoreScene"));
        SceneManager.LoadScene("PetGameScene");
    }

    public void LoadTitleScene()
    {
        StartCoroutine(LoadSceneWithDelay("TitleScene"));
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadLeaderboardScene()
    {
        StartCoroutine(LoadSceneWithDelay("LeaderboardScene"));
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void LoadOptionsScene()
    {
        StartCoroutine(LoadSceneWithDelay("OptionsScene"));
    }

    public void LoadDogCareScene()
    {
        StartCoroutine(LoadSceneWithDelay("DogWalkScene"));
        SceneManager.LoadScene("OptionsScene");
    }

    public void LoadClosetScene()
    {
        SceneManager.LoadScene("ClosetScene");
    }
    public void LoadMinigameSelectorSecene()
    {
        SceneManager.LoadScene("MinigameSelectorScene");
    }
    public void LoadDogCareScene()
    {
        SceneManager.LoadScene("DogWalkScene");
    }

    public void LoadDogBathScene()
    {
        SceneManager.LoadScene("DogBathScene");
    }

    public void ExitGame()
    {
        PlayButtonClickSound();
        StartCoroutine(ExitGameWithDelay());
    }

    private IEnumerator ExitGameWithDelay()
    {
        if (buttonClickSound != null)
        {
            yield return new WaitWhile(() => buttonClickSound.isPlaying);
        }
        Application.Quit();
    }
        Application.Quit();
    }



}
