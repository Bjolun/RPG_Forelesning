using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    // Referanse til Canvaset
    [SerializeField] private GameObject shopMenu;

    // Referanse til PlayerMovement for å få tak i eventet vårt
    [SerializeField] private PlayerMovement player;

    // Referanse til shopkeeperen for å se om vi er nære nok til å interagere
    [SerializeField] private ShopkeeperDetectPlayer shopkeeper;

    // En måte å se om shop vinduet er åpent eller ikke.
    private bool isShopMenuActive = false;

    private void Start()
    {
        // Setter en lytter til eventet vårt...
        player.OnInteractAction += Player_OnInteractAction;
    }

    private void Player_OnInteractAction()
    {
        // Alt dette skjer hver gang Interact action blir trigret.
        GameManager.Instance.TakeDamage(10);


        // Hvis spilleren vår er nære shopkeeperen OG menyen ikke er aktiv...
        if(shopkeeper.IsPlayerInRange() && isShopMenuActive == false)
        {
            // Aktivere shopmenyen
            shopMenu.SetActive(true);
            // Vi vil stoppe tiden
            Time.timeScale = 0;
            // Vi vil vi at isShopMenuActive er true
            isShopMenuActive = true;
        }   // Ellers
        else
        {
            // Motsatt av alt ovenfor :)
            shopMenu.SetActive(false);
            Time.timeScale = 1;
            isShopMenuActive = false;
        }

    }
}
