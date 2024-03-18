using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    // Nom de la sc�ne vers laquelle vous souhaitez changer
    public string sceneName;

    // M�thode appel�e lorsqu'une collision est d�tect�e
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si le GameObject en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Charge la nouvelle sc�ne
            SceneManager.LoadScene(sceneName);
        }
    }
}
