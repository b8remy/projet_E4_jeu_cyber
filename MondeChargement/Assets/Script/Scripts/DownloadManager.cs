using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadManager : MonoBehaviour
{
    public string downloadURL; // URL du fichier à télécharger

    // Méthode appelée lorsque le bouton de téléchargement est cliqué
    public void OnDownloadButtonClick()
    {
        Application.OpenURL(downloadURL); // Ouvre l'URL dans le navigateur de l'utilisateur
    }
}
