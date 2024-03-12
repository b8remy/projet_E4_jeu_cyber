using UnityEngine;

public class PasswordInteraction : MonoBehaviour
{
    public GameObject passwordPanel; // Assurez-vous d'assigner le Canvas dans l'inspecteur
    private bool isPlayerNear = false; // Pour suivre si le joueur est près du GameObject spécifique

    void Start()
    {
        // Optionnel: Désactivez le Canvas au début si pas déjà fait dans l'éditeur
        passwordPanel.SetActive(false);
    }

    void Update()
    {
        // Vérifiez si le joueur est près et appuie sur "H"
        if (isPlayerNear && Input.GetKeyDown(KeyCode.H))
        {
            passwordPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assurez-vous que le joueur a le tag "Player"
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            passwordPanel.SetActive(false);
        }
    }

    public void CloseCanvasAndResumeGame()
    {
        passwordPanel.SetActive(false); // Désactive le Canvas
        Time.timeScale = 1f; // Remet le temps à la normale pour reprendre le jeu
    }

}