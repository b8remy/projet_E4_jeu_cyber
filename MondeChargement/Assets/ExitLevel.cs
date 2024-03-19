using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public GameObject ExitPanel;

    // Start is called before the first frame update
    void Start()
    {
        ExitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // V�rifiez si le joueur est pr�s et appuie sur "H"
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ExitPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseCanvasAndResumeGame()
    {
        ExitPanel.SetActive(false); // D�sactive le Canvas
        Time.timeScale = 1f; // Remet le temps � la normale pour reprendre le jeu
    }

    public void RetourAuHub()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1); // Attendre 2 secondes
        SceneManager.LoadScene("Hub3D"); // Changez "NomDeLaNouvelleScene" par le nom de votre sc�ne
    }
}
