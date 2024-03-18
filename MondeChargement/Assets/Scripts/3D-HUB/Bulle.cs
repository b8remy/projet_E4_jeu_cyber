using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    // Nom de la scène vers laquelle vous souhaitez changer
    public string sceneName;

    // Méthode appelée lorsqu'une collision est détectée
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le GameObject en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Charge la nouvelle scène
            SceneManager.LoadScene(sceneName);
        }
    }
}
