using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbPlayer;

    [SerializeField] private float speed;
    [SerializeField] private float speedInJump;
    [SerializeField] private float jump;

    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    public void MoveCharacter(Vector3 movement)
    {
        rbPlayer.AddForce(movement * speed);
    }

    public void MoveCharacterInJump(Vector3 movement)
    {
        rbPlayer.AddForce(movement * speedInJump);
    }

    public void JumpCharacter()
    {
        rbPlayer.AddForce(Vector3.up * jump, ForceMode.Impulse);
    }

}
