using UnityEngine;

public class ShopkeeperDetectPlayer : MonoBehaviour
{
    // Variabel som forteller om spilleren er nære nok eller ikke
    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        // Hvis spilleren vår går inn i triggeren, sett isPlayerInRange til true
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    public bool IsPlayerInRange()
    {
        return isPlayerInRange;
    }

}
