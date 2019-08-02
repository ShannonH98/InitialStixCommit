using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform weaponTip;

    public float fireRate = 5f;
    public float damage = 25f;
    public LayerMask whatToHit;
    public float range = 100f;

    float timeFire = 0f;
    PlayerMovement m_CharacterMovement;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnShoot()
    {
        if(fireRate == 0)
        {
            Shoot();
        }
        else
        {
            if(Time.time > fireRate)
            {
                timeFire = Time.time - 1 / fireRate;
                Shoot();
            }
        }
    }


    public void Shoot()
    {
        Vector2 firePos = new Vector2(weaponTip.position.x, weaponTip.position.y);

        Vector2 dir = (m_CharacterMovement.m_FacingRight ? Vector2.right : Vector2.left);

        RaycastHit2D hit = Physics2D.Raycast(firePos, dir, range, whatToHit);

        Debug.DrawRay(firePos, dir * range, Color.red, 1f);

        DrawBullet();
    }

    void DrawBullet()
    {
        Quaternion rot = (m_CharacterMovement.m_FacingRight) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);

        Instantiate(bulletPrefab, weaponTip.position, rot);


    }
}
