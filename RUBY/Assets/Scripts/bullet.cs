using UnityEngine;

public class bullet : MonoBehaviour
{
    #region 欄位
    [Header("子彈的剛體")]
    public Rigidbody2D bulletRB;
    [Header("位置與幅度'")]
    public float bulletDis;
    [Header("特效")]
    //ParticleSystem粒子系統欄位
    public ParticleSystem Eff;
    #endregion
    
    //因子彈為Instantiate()產生所以不用Start()
    //而使用Awake()喚醒
    private void Awake()
    {
        //在喚醒(射出)時拿到物件剛體與位置訊息
        bulletRB = GetComponent<Rigidbody2D>();
        bulletDis = transform.position.magnitude;
    }
    void Update()
    {
    //每幀判斷如果物件變化的位置>100
    //銷毀物件
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 direction,float force)//公開給RubyMove使用(載入力)
    {
        //剛體.加力(方向*力道)
        bulletRB.AddForce(direction * force);
    }
}
