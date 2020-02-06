using UnityEngine;
using System.Collections;

public class EnemyFar : Enemy
{
    [Header("子彈")]
    public GameObject bullet;
    

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(CreateBullet());  //啟動協成
    }
    private IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(data.attackDelay);      //攻擊間隔
        GameObject temp =  Instantiate(bullet, transform.position, transform.rotation );//生出火球(物件,座標,角度)
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletPower);
    }

    private Vector3 posBullet;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;  //子彈顏色
        posBullet = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;   //子彈作標=飛龍.座標+飛龍前方*Z+飛龍上方*Y
        //圖示.繪製球體(中心點,半徑)
        Gizmos.DrawSphere(posBullet, 0.1f);
    }

}
