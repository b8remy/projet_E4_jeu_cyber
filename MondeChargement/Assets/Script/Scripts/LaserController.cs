using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LaserMode
{
    CompleteCircle,
    SemiCircle
}

public class LaserController : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public Transform firePoint;

    public float arcRadius = 100f; // Rayon de l'arc de cercle
    public float arcSpeed = 10f; // Vitesse de déplacement le long de l'arc
    private float angle = 0f; // Angle pour calculer la position le long de l'arc
    private bool goingForward = true;

    public float recoilForce;

    public LaserMode laserMode;

    // Start is called before the first frame update
    void Start()
    {
        // DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
         // Calcul de la position le long de l'arc de cercle
        float x = Mathf.Cos(angle) * arcRadius;
        float y = Mathf.Sin(angle) * arcRadius;

        
        lineRenderer.SetPosition(0, firePoint.position);

        if (laserMode == LaserMode.CompleteCircle)
        {
            CompleteCircle();
        }
        else if (laserMode == LaserMode.SemiCircle)
        {
            SemiCircle();
        }

        Vector2 laserEndPosition = new Vector2(x, y) + (Vector2)firePoint.position;       
        lineRenderer.SetPosition(1, laserEndPosition);

        Vector2 direction = laserEndPosition - (Vector2)firePoint.position;
        // Lancer un raycast le long du laser
        RaycastHit2D[] hits = Physics2D.RaycastAll((Vector2)firePoint.position, direction.normalized, direction.magnitude);

        // Le raycast ne fonctionne pas comme prévu quand le personnage est entre le laser et un mur


        if (hits.Length > 0)
        {
            for (int i=0; i<hits.Length; i++) {
                if (hits[i].collider.CompareTag("Player")) {
                    var healthComponent = hits[i].collider.GetComponent<Health>();
                    if (healthComponent != null) {
                        Debug.Log(healthComponent);
                        healthComponent.TakeDamage(1);

                        // Ne fonctionne pas. 
                        healthComponent.Recoil(direction, recoilForce);



                        // // En dessous une tentative d'ajouter du recul quand le player se prend des dégats mais ça marche pas
                        // var playerRigidbody = hits[i].collider.GetComponent<Rigidbody2D>();
                        // Debug.Log(playerRigidbody);
                        // if (playerRigidbody != null) {
                            
                        //     Vector2 recoilDirection = direction;
                        //     Debug.Log("direction : " + direction);

                        //     playerRigidbody.AddForce(recoilDirection.normalized * recoilForce, ForceMode2D.Impulse);
                        // }
                    }
                } else {
                    lineRenderer.SetPosition(1, hits[i].point);
                }
            } 

        }
    }

    void EnableLaser() {
        lineRenderer.enabled = true;
    }

    void DisableLaser() {
        lineRenderer.enabled = false;
    }


    public void CompleteCircle() {
        // Mise à jour de l'angle pour effectuer un mouvement circulaire
        angle += arcSpeed * Time.deltaTime;

        // Si l'angle dépasse 2π (360 degrés), le réinitialiser pour continuer le mouvement circulaire
        if (angle > Mathf.PI * 2f)
        {
            angle -= Mathf.PI * 2f;
        }
    }

    public void SemiCircle() {
        // Mise à jour de l'angle pour effectuer un mouvement le long de l'arc
        if (goingForward)
        {
            angle += arcSpeed * Time.deltaTime;
            if (angle >= Mathf.PI) // Si l'angle atteint ou dépasse 180 degrés (π radians)
            {
                angle = Mathf.PI;
                goingForward = false; // Inverser la direction
            }
        }
        else
        {
            angle -= arcSpeed * Time.deltaTime;
            if (angle <= 0f) // Si l'angle atteint ou descend en dessous de 0
            {
                angle = 0f;
                goingForward = true; // Revenir à la direction initiale
            }
        }
    }

}
