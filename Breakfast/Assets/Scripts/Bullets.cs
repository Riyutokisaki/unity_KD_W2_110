using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullets : MonoBehaviour
{
    #region 欄位
    [Header("剛體")]
    public Rigidbody2D RB;
    #endregion

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    
    #region 方法

    public void Shoot(Vector2 direction, float force)
    {
        RB.AddForce(direction * force);
    }
    #endregion

}
