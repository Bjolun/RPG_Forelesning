using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    // Vi �nsker � se n�v�rene liv spilleren har
    private int currentHealth = 100;

    // Vi �nsker � se maks liv spilleren kan ha
    private int maxHealth = 150;

    // Vi �nsker � se hvor mye gull karakteren v�r har
    private int currentGold = 100;

    // N�r vi handler med shopkeeperen v�r m� vi se om vi har nok til � handle eller ikke.
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

    // METODER FOR � PRESENTERE ELLER MANIPULERE DATA...
    // Health relaterte metoder...
    // Returnerer n�v�rende liv
    public int CurrentHealth()
    {
        return currentHealth;
    }

    // Metode for � �ke maks liv


    // Metode for � ta skade
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Metode for � f� tilbake liv

}
