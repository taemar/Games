using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private ParticleSystem deathEffect;

    private Rigidbody playerRB;
    private SphereCollider playerCollider;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (StaticElements.PlayerIsDead)
        {
            playerRB.constraints = RigidbodyConstraints.FreezePosition;

            Destroy(playerCollider);

            Destroy(playerMesh);

            deathEffect.gameObject.SetActive(true);

            if (!deathEffect.isEmitting)
            { 
                StaticElements.PlayerIsDead = false;

                deathCanvas.SetActive(true);
            }
        }
    }
}
