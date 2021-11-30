
using UnityEngine;

public class barry : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyMove rubyMove = collision.GetComponent<RubyMove>();
        rubyMove.ChangeHealth(1);
        Destroy(gameObject);
    }
   
}
