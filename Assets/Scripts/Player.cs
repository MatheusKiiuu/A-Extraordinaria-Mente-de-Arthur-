using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveValue;

    private InputAction moveAction;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Movement();
        Animation();
    }

    private void Movement()
    {
        moveValue = moveAction.ReadValue<Vector2>();

        if (moveValue.x > 0f && transform.position.x >= 8f)
            moveValue.x = 0;
        else if(moveValue.x < 0f && transform.position.x <= -8f)
            moveValue.x = 0;
        else
            transform.Translate(new Vector3(moveValue.x * speed * Time.deltaTime, 0, 0));
    }

    private void Animation()
    {
        if(moveValue.x != 0f)
            animator.SetBool("Andar", true);
        else
            animator.SetBool("Andar", false);

        if (moveValue.x < 0f)
            spriteRenderer.flipX = false;
        else if(moveValue.x > 0f)
            spriteRenderer.flipX = true;
    }
}
