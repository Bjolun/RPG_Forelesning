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

    private int strength = 10;

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
    // Metode for å se nåværende liv
    public int CurrentHealth()
    {
        return currentHealth;
    }

    // Metode for å øke maks liv
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }


    // Metode for å ta skade
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Metode for å få tilbake liv
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
    }

    // Currency relaterte metoder
    // Metode for å se hvor mye gull vi har
    public int CurrentGold() 
    {
        return currentGold;
    }

    // Metode for å se om vi har nok gull til å kjøpe det vi ønsker.
    public bool CanBuyItem(int itemPrice)
    {
        if(currentGold >= itemPrice)
        {   
            // Har råd til å kjøpe det vi ønsker
            canBuy = true;
            return canBuy;
        } else
        {
            // Har ikke råd til å kjøpe det vi ønsker.
            canBuy = false;
            return canBuy;
        }
    }

    // Metode for å trekke fra gull
    public void DecreaseGold(int amount)
    {
        currentGold -= amount;
    }

    // Metode for å legge til gull
    public void IncreaseGold(int amount)
    {
        currentGold += amount;
    }

    // Styrke relaterte metoder
    // Metode for å se hvor mye styrke vi har
    public int CurrentStrength()
    {
        return strength;
    }

    // Metode for å øke styrke
    public void IncreaseStrength(int amount)
    {
        strength += amount;
    }
}
