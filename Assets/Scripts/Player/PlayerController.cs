using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public float moveSpeed = 2f;

    private Camera mainCamera;
    private float rightScreenEdge;
    private float leftScreenEdge;
    private float playerSpriteHalfWidth;
    public Vector2 bottomLeftPoint;
    public Vector2 bottomRightPoint;
    public Vector2 upperLeftPoint;
    public Vector2 upperRightPoint;

    public bool canMove=true;


    // Start is called before the first frame update
    void Start()
    {
        // Initialise mainCamera variable with the game's current main camera
        mainCamera = Camera.main;

        // Find the point in game world where the right screen edge touches
        Vector2 screenTopRightCorner = new Vector2(Screen.width, Screen.height);
        Vector2 topRightCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenTopRightCorner);
        rightScreenEdge = bottomRightPoint.x;

        // Find the point in game world where the left screen edge touches
        Vector2 screenBottomLeftCorner = new Vector2(0f, 0f);
        Vector2 bottomLeftCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenBottomLeftCorner);
        leftScreenEdge = bottomLeftPoint.x;

        // Calculate the value of the player sprite's half-width
        playerSpriteHalfWidth = playerSprite.bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            // Store the input value of the left-right direction buttons
            float hlInput = Input.GetAxis("Horizontal");

            // Calculate and store the max limits for the player to move
            float rightLimit = rightScreenEdge - playerSpriteHalfWidth;
            float leftLimit = leftScreenEdge + playerSpriteHalfWidth;

            // Store the player's current position
            Vector2 currentPos = transform.position;

            // If the player pressed right direction AND they're to the left side of the right limit, keep moving
            if (hlInput > 0f && transform.position.x < rightLimit)
            {
                // Calculate the player's new position
                Vector2 newPos = currentPos + new Vector2(1f, 0f);

                // Move the player towards the new position using the given speed
                transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
            }
            // If the player pressed left direction AND they're to the right side of the left limit, keep moving
            else if (hlInput < 0f && transform.position.x > leftLimit)
            {
                // Same as above but new position is the opposite direction
                Vector2 newPos = currentPos - new Vector2(1f, 0f);
                transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.Log("cant move");
        }
    }
       
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the other object is the projectile by its tag
        if (collision.tag == "LaserEnemy")
        {
            // Allows playing an audio clip even if the Alien is destroyed and removed from the scene
            //AudioSource.PlayClipAtPoint(clip, Vector2.zero);
            Health.instance.DecreaseHealth();

            // Destroy the projectile game object
            Destroy(collision.gameObject);
        }
    }
}
