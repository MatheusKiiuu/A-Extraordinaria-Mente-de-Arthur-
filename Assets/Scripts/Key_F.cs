using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Key_F : MonoBehaviour
{
    public PlayerData playerData;

    public bool salve;
    public bool menuDrag;
    public bool nextScene;
    public string scene;

    public GameObject canva;
    public GameObject keyF;
    public Animator playerAnimaror;
    public MonoBehaviour playerScript;

    private InputAction keyFAction;

    private void Start()
    {
        keyFAction = InputSystem.actions.FindAction("Player/Interaction");

        keyF.SetActive(false);
        if (menuDrag)
            canva.SetActive(false);
    }
    private void Update()
    {
        if(menuDrag)
            MenuDrag();

        if(nextScene)
            NextScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        keyF.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        keyF.SetActive(false);
    }

    private void MenuDrag()
    {
        if (keyFAction.WasPressedThisFrame() && keyF.activeSelf == true)
        {
            canva.SetActive(true);
            playerScript.enabled = false;
            keyF.SetActive(false);
        }
        else if (keyFAction.WasPressedThisFrame() && canva.activeSelf == true)
        {
            canva.SetActive(false);
            playerScript.enabled = true;
            keyF.SetActive(true);
        }

        if (canva.activeSelf == true)
            playerAnimaror.SetBool("Andar", false);
    }

    private void NextScene()
    {
        if (keyFAction.WasPressedThisFrame() && keyF.activeSelf == true)
        {
            if (salve)
                playerData.VerificarScene(scene);
            SceneManager.LoadScene(scene);
        }
    }
}
