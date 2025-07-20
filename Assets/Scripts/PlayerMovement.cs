using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject birdSprite;
    public Rigidbody2D rigidBody;
    public float jumpPower;
    public InputActionReference jump;
    public LogicScript logic;
    public Camera mainCamera;

    public float maxAngle = 45;
    public float minAngle = -45;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        jump.action.Enable();
    }

    private void Update()
    {
        var viewportY = mainCamera.WorldToViewportPoint(transform.position).y;
        if (viewportY < 0f || viewportY > 1f)
        {
            logic.OnGameOver();
            if (viewportY < -0.1f)
            {
                Destroy(gameObject);
            }
        }
        
        birdSprite.transform.rotation = GetRotation();
        Debug.Log($"Current Rotation: {birdSprite.transform.rotation}");
        Debug.DrawRay(birdSprite.transform.position, birdSprite.transform.up * 2f, Color.red);
        logic.SetDebugText(new LogicScript.DebugTextEntry { currentPositionGame = transform.position.y, currentPositionPixels = (int)mainCamera.WorldToScreenPoint(transform.position).y });
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (!logic.IsAlive)
        {
            return;
        }

        rigidBody.linearVelocity = new Vector2(0f, jumpPower);
        Debug.Log("Jumped!");
    }

    private Quaternion GetRotation()
    {
        float currentZ = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(-10f, 10f, rigidBody.linearVelocity.y));
        Debug.Log(currentZ);
        return Quaternion.Euler(0, 0, currentZ);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.OnGameOver();
    }
}
