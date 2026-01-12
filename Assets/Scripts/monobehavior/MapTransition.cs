using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] private float movePosition = 1;

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("A COLLISION HAS HAPPENED");
       if (collision.gameObject.CompareTag("Player"))
       {
            confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPosition(collision.gameObject);
       }
    }
    
    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += movePosition;
                break;
            case Direction.Down:
                newPos.y -= movePosition;
                break;
            case Direction.Left:
                newPos.x -= movePosition;
                break;
            case Direction.Right:
                newPos.x += movePosition;
                break;
        }
    }
}
