using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 2f;

    public Light2D playerLight;

    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

     private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > 0) {
            playerLight.intensity = currentHealth * 2;
        }
        
    }

    public void TakeDamage (int amount) {

        if (!isInvulnerable) {
            currentHealth -= amount;

            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                // Mort
            }
            else
            {
                StartCoroutine(InvulnerabilityCooldown()); // Démarrez le délai d'invulnérabilité
            }
        }

    }

    public void Recoil(Vector2 direction, float force) {

        if (rb != null) {
            Vector2 recoilDirection = direction;
            rb.AddForce(recoilDirection.normalized * force, ForceMode2D.Impulse);
        }
    }

    IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true; // Le joueur est maintenant invulnérable
        yield return new WaitForSeconds(invulnerabilityDuration); // Attendre la durée de l'invulnérabilité
        isInvulnerable = false; // La période d'invulnérabilité est terminée
    }
}
