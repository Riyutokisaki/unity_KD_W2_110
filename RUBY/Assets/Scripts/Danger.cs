using UnityEngine;
/// <summary>
/// ¦MÀI°Ï°ì
/// </summary>
public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyMove rubyMove = collision.GetComponent<RubyMove>();
        print(rubyMove + "¸I¨ì¤F¨ë¨ë!");
        rubyMove.ChangeHealth(-1);
        Destroy(gameObject);

    }
}