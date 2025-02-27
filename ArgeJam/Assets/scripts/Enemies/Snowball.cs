using UnityEngine;
using UnityEngine.TextCore.Text;

public class Snowball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float lifeTimeOfSnowball;
    [SerializeField] private float damage;
    private float lifeTime = 0f;
    public Vector2 movement;
    public Vector2 direction;
    private bool isHit;

    private CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (isHit || lifeTime > lifeTimeOfSnowball)
        {
            lifeTime = 0f;
            Deactivate();
        }
        transform.position = transform.position + new Vector3(movement.x, movement.y) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Çarpýþan nesne: " + collision.gameObject.name + ", Tag: " + collision.tag);
        string tag = collision.tag;
        string name = collision.name;
        Debug.Log("Çarpýþan nesne: " + tag);

        if (tag == "Player")
        {
            deneme character = null;
            if (collision != null)
            {
                character = collision.GetComponent<deneme>();
            }

            if (character != null)
            {
                character.takedamage(damage);
            }
        }

        if (tag != "Enemy")
        {
            isHit = true;
            circleCollider.enabled = true;
        }
    }

    public void SetDirection(Vector2 _movement)
    {
        gameObject.SetActive(true);
        movement = _movement;
        isHit = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
