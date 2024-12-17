using UnityEngine;

[CreateAssetMenu(fileName = "ShootState", menuName = "StatesSOTurret/Shoot")]
public class ShootState : StatesSOTurret
{
    private float shootCooldown = 1f;
    private float shootTimer;
    public override void OnStateEnter(TurretFSM ec)
    {
        shootTimer = 0f;
    }

    public override void OnStateExit(TurretFSM ec)
    {
        //stop shoot
    }

    public override void OnStateUpdate(TurretFSM ec)
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            ShootPlayer(ec);
            shootTimer = shootCooldown;
        }
        
    }

    private void ShootPlayer(TurretFSM ec)
    {
        GameObject bullet = ec.eBullet.Pop();
        if (bullet != null)
        {
            Vector3 direction = (Character.character.transform.position - ec.gameObject.transform.position).normalized;
            bullet.transform.position = ec.transform.position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
