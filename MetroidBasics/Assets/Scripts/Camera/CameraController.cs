using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] BoxCollider2D bounceBox;

    private float halfHeight, halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            
            transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x, bounceBox.bounds.min.x + halfWidth, bounceBox.bounds.max.x - halfWidth),
                Mathf.Clamp(player.transform.position.y, bounceBox.bounds.min.y + halfHeight, bounceBox.bounds.max.y - halfHeight) + 1.5f,
                transform.position.z);
        }
    }
}
