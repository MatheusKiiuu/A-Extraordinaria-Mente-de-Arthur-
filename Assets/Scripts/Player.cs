using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerData playerData;

    public float speed = 10f;

    private string playerScene;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveValue;

    private InputAction moveAction;

    private void Awake()
    {
         playerScene = SceneManager.GetActiveScene().name;  
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveAction = InputSystem.actions.FindAction("Move");

        if (playerScene == "Quarto" && playerData.quarto)
        {
            transform.position = new Vector3(8f, -2.2f, 0f);
            spriteRenderer.flipX = false;
            playerData.quarto = false;
        }
        else if(playerScene == "Corredor" && playerData.salaAula)
        {
            transform.position = new Vector3(3.26f, -2.2f, 0f);
            playerData.salaAula = false;
        }
        else if(playerScene == "Corredor" && playerData.biblioteca)
        {
            transform.position = new Vector3(5.57f, -2.2f, 0f);
            playerData.biblioteca = false;
        }
        else if (playerScene == "Corredor" && playerData.cantina)
        {
            transform.position = new Vector3(7.68f, -2.2f, 0f);
            playerData.cantina = false;
        }
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
