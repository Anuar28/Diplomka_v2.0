using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float shootingInterval;

    [Header("Basic Attack")]
    [SerializeField] private Transform basicShootPoint;

    [Header("Upgrade Points")]
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform secondLeftCanon;
    [SerializeField] private Transform secondRightCanon;

    [Header("Upgrade Rotation Points")]
    [SerializeField] private Transform leftRotationCanon;
    [SerializeField] private Transform rightRotationCanon;

    [SerializeField] private AudioSource source;

    private int upgradeLevel = 0;

    private float intervalReset;
    // Start is called before the first frame update
    void Start()
    {
        intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel += increaseAmount;
        if (upgradeLevel>4)
            upgradeLevel = 4;
    }

    public void DecreaseUpgrade() 
    {
        upgradeLevel -= 1;
        if (upgradeLevel<0)
            upgradeLevel = 0;
    }
    private void Shoot()
    {
        source.Play();
        switch (upgradeLevel) 
        {
            case 0:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity); 
                break;
            case 1:
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);

                Instantiate(laserBullet, leftRotationCanon.position, leftRotationCanon.rotation);
                Instantiate(laserBullet, rightRotationCanon.position, rightRotationCanon.rotation);
                break;
            default:
                break;
        }
    }
}
