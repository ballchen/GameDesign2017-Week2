using UnityEngine;
using System.Collections;
public class FollowTheBeat : MonoBehaviour
{
    //節奏時間距離
    private const float beatPeriod = 1.485f;
    //拍點提前0.2s旋轉
    private float rotateCounter = 0.2f;
    //前面三次拍點不做事，延遲0.5秒發射
    private float shootCounter = -0.5f - beatPeriod * 3;
    private TurretManagerScript turret;
    // Use this for initialization
    void Start()
    {
        turret = this.GetComponent<TurretManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        rotateCounter += Time.deltaTime;
        shootCounter += Time.deltaTime;
        if (rotateCounter > beatPeriod)
        {
            turret.PlayRotateAnimation();
            rotateCounter -= beatPeriod;
        }
        if (shootCounter > beatPeriod)
        {
            turret.PlayShootAnimation();
            shootCounter -= beatPeriod;
        }

    }
}