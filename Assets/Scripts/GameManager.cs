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

    private int strength = 10;

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
    // Metode for � se n�v�rende liv
    public int CurrentHealth()
    {
        return currentHealth;
    }

    // Metode for � �ke maks liv
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }


    // Metode for � ta skade
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Metode for � f� tilbake liv
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
    }

    // Currency relaterte metoder
    // Metode for � se hvor mye gull vi har
    public int CurrentGold() 
    {
        return currentGold;
    }

    // Metode for � se om vi har nok gull til � kj�pe det vi �nsker.
    public bool CanBuyItem(int itemPrice)
    {
        if(currentGold >= itemPrice)
        {   
            // Har r�d til � kj�pe det vi �nsker
            canBuy = true;
            return canBuy;
        } else
        {
            // Har ikke r�d til � kj�pe det vi �nsker.
            canBuy = false;
            return canBuy;
        }
    }

    // Metode for � trekke fra gull
    public void DecreaseGold(int amount)
    {
        currentGold -= amount;
    }

    // Metode for � legge til gull
    public void IncreaseGold(int amount)
    {
        currentGold += amount;
    }

    // Styrke relaterte metoder
    // Metode for � se hvor mye styrke vi har
    public int CurrentStrength()
    {
        return strength;
    }

    // Metode for � �ke styrke
    public void IncreaseStrength(int amount)
    {
        strength += amount;
    }
}
