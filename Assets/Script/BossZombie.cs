using UnityEngine;

public class BossZombie : Enemy
{
    [SerializeField] private ZombieConfig config;

    protected override void Start()
    {
        hp = config.hp;
        ms = config.ms;
        jarakDeteksi = config.jarakDeteksi;
        jarakSerang = config.jarakSerang;

        base.Start();
    }
}