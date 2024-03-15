using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string originScene;
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    SaveSystemManager saveSystemManager;

    public GameObject transitionScreen;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        saveSystemManager = FindAnyObjectByType<SaveSystemManager>();

        transitionAnim.SetTrigger("Start");
    }

    public void Update() {
        
    }

    public void NextLevel() {
        StartCoroutine(LoadNextLevel());
    }

    // public void LoadScene(string sceneName) {
    //     SceneManager.LoadSceneAsync(sceneName);
    // }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void GoToTerminal() {


        originScene = GetCurrentScene();

        saveSystemManager.SavePlayer();

        StartCoroutine(LoadAsynchronously("Terminal"));

        
    }

    public void BackFromTerminal()
    {
        StartCoroutine(LoadAsynchronously(originScene));
    }



    IEnumerator LoadNextLevel() {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {

        // yield return new WaitForSeconds(1);

        

        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalise le progrès de chargement
            Debug.Log("Progress : " + progress);
            yield return null; // Attend une frame
        }

        

        if (sceneName != "Terminal") {
            saveSystemManager.LoadPlayer();
        }
        
        
    }


}
