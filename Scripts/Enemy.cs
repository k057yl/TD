
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int healt;
    [SerializeField] int speed;
    int target = 0;
    WayPoint wPoint;
    Transform _transform;
    
    private void Start()
    {
        wPoint = FindObjectOfType<WayPoint>();
        _transform = GetComponent<Transform>();
    }
    void Runway()
    {
        if (target < wPoint.points.Length)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, wPoint.points[target].position, speed * Time.deltaTime);
        }
        else
        {
            _transform.position = Vector2.MoveTowards(_transform.position, wPoint.finish.position, speed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WayPoint")
        {
            target++;
        }
        if (collision.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Runway();
    }
}
