using UnityEngine;
using System.Collections;
using DG.Tweening;
public class TurretManagerScript : MonoBehaviour
{
    private Animator _animator;
    const int DirectionCount = 8;
    public Ease RotateEaseFunction;
    public float rotateDuration;
    public Camera GameCamera;
    public float CameraShakeDuration;
    public float CameraShakeStrenth;
    public GameObject bulletCandidate;
    private float bulletOffset = 0.6f;
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }
    public void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
        GameCamera.transform.DOShakePosition(CameraShakeDuration, CameraShakeStrenth);
        GameObject bulletobj = GameObject.Instantiate(bulletCandidate);
        BulletScript bulletScript = bulletobj.GetComponent<BulletScript>();
        bulletScript.transform.position = this.transform.position + bulletOffset * this.gameObject.transform.right;
        bulletScript.transform.rotation = this.transform.rotation;
        Vector3 shootDirection3D = this.gameObject.transform.right;
        Vector2 shootDirection2D = new Vector2(shootDirection3D.x, shootDirection3D.y);
        bulletScript.InitAndShoot(shootDirection2D);
    }
    public void PlayRotateAnimation()
    {
        float targetDegree = 360.0f / DirectionCount * Random.Range(0, DirectionCount);
        this.transform.DORotate(new Vector3(0, 0, targetDegree), rotateDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayShootAnimation();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayRotateAnimation();
        }
    }
}