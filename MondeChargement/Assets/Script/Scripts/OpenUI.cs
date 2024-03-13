using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
        }
    }

    public void Pause () {
        ui.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume () {
        ui.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
