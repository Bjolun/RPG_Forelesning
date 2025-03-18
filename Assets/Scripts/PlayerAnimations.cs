using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Referanse til Player, s� vi f�r tak i boolen vi setter der
    [SerializeField] private PlayerMovement player; 

    // Referanse til Animator komponenten v�r
    private Animator animator;

    // Pek p� riktig Animator
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Hvis isRunning fra Player er true
        if (player.IsRunning())
        {
            // Sett isRunning parameteret til true
            animator.SetBool("isRunning", true);
        }
        // Hvis isRunning fra Player er false
        else
        {
            // Sett isRunning parameteret til false
            animator.SetBool("isRunning", false);
        }



    }
}
