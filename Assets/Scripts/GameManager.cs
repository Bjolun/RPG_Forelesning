using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    // Vi ønsker å se nåværene liv spilleren har
    private int currentHealth = 100;

    // Vi ønsker å se maks liv spilleren kan ha
    private int maxHealth = 150;

    // Vi ønsker å se hvor mye gull karakteren vår har
    private int currentGold = 100;

    // Når vi handler med shopkeeperen vår må vi se om vi har nok til å handle eller ikke.
    private bool canBuy;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // METODER FOR Å PRESENTERE ELLER MANIPULERE DATA...
    // Health relaterte metoder...
    // Returnerer nåværende liv
    public int CurrentHealth()
    {
        return currentHealth;
    }

    // Metode for å øke maks liv


    // Metode for å ta skade
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Metode for å få tilbake liv

}
