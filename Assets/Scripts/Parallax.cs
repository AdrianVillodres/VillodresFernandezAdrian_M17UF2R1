using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float spriteWidth;        
    [SerializeField] private float spriteHeight;        
    [SerializeField] private Vector2 parallaxMultiplier;

    [Header("Parallax Controll")]
    [SerializeField] private bool enableHorizontalParallax = true; 
    [SerializeField] private bool enableVerticalParallax = true;  

    private Vector3 lastCameraPosition;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        lastCameraPosition = cameraTransform.position;

        
        if (spriteWidth <= 0 || spriteHeight <= 0)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteWidth = spriteRenderer.bounds.size.x - 0.1f;
                spriteHeight = spriteRenderer.bounds.size.y;
            }
            else
            {
                Debug.LogError("Sprite Renderer not found");
            }
        }
    }

    private void LateUpdate()
    {

      
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

       
        Vector3 movement = Vector3.zero;

        if (enableHorizontalParallax)
        {
            movement.x = deltaMovement.x * parallaxMultiplier.x;
        }

        if (enableVerticalParallax)
        {
            movement.y = deltaMovement.y * parallaxMultiplier.y;
        }

        transform.position += movement;
        lastCameraPosition = cameraTransform.position;


        if (enableHorizontalParallax)
        {
            if (cameraTransform.position.x - transform.position.x >= spriteWidth)
            {
                transform.position += new Vector3(spriteWidth * 2, 0, 0);
            }
            else if (transform.position.x - cameraTransform.position.x >= spriteWidth)
            {
                transform.position -= new Vector3(spriteWidth * 2, 0, 0);
            }
        }

        
        if (enableVerticalParallax)
        {
            if (cameraTransform.position.y - transform.position.y >= spriteHeight)
            {
                transform.position += new Vector3(0, spriteHeight * 2, 0);
            }
            else if (transform.position.y - cameraTransform.position.y >= spriteHeight)
            {
                transform.position -= new Vector3(0, spriteHeight * 2, 0);
            }
        }
    }
}