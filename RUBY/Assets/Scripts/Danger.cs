using UnityEngine;
/// <summary>
/// �M�I�ϰ�
/// </summary>
public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyMove rubyMove = collision.GetComponent<RubyMove>();
        print(rubyMove + "�I��F���!");
        rubyMove.ChangeHealth(-1);
        Destroy(gameObject);

    }
}