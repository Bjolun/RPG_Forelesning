using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    // Referanse til Canvaset
    [SerializeField] private GameObject shopMenu;

    // Referanse til PlayerMovement for � f� tak i eventet v�rt
    [SerializeField] private PlayerMovement player;

    // Referanse til shopkeeperen for � se om vi er n�re nok til � interagere
    [SerializeField] private ShopkeeperDetectPlayer shopkeeper;

    // En m�te � se om shop vinduet er �pent eller ikke.
    private bool isShopMenuActive = false;

    private void Start()
    {
        // Setter en lytter til eventet v�rt...
        player.OnInteractAction += Player_OnInteractAction;
    }

    private void Player_OnInteractAction()
    {
        // Alt dette skjer hver gang Interact action blir trigret.
        GameManager.Instance.TakeDamage(10);


        // Hvis spilleren v�r er n�re shopkeeperen OG menyen ikke er aktiv...
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
