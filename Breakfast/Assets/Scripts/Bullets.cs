using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullets : MonoBehaviour
{
    #region ���
    [Header("����")]
    public Rigidbody2D RB;
    #endregion

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    
    #region ��k

    public void Shoot(Vector2 direction, float force)
    {
        RB.AddForce(direction * force);
    }
    #endregion

}
