using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalKoin;
    private int koinTerkumpul = 0;
        private int jumlahZombieMati = 0;

    [SerializeField] private int skor = 0;


    private bool sudahMenang = false;  

    void Start()
    {
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void OnEnable()
    {
        Enemy.OnZombieMati += TambahSkorSaatZombieMati;
        Enemy.OnZombieMati += SaatZombieMati;
    }

    void OnDisable()
    {
        Enemy.OnZombieMati -= TambahSkorSaatZombieMati;
        Enemy.OnZombieMati -= SaatZombieMati;
    }   

    void TambahSkorSaatZombieMati(Enemy zombieYangMati)
    {
        skor += 10;
        Debug.Log("Skor: " + skor);
    }

       void SaatZombieMati(Enemy zombie)
    {
        jumlahZombieMati++;
        Debug.Log("GameManager dengar event. Zombie mati: " + jumlahZombieMati + " (" + zombie.name + ")");
    }

    public void AmbilKoin()
    {
        koinTerkumpul++;
        if (koinTerkumpul == totalKoin) Menang();
    }

    void Menang()
    {
        Debug.Log("WOI KAMU MENANG!");

        Enemy[] semuaZombie = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy zombie in semuaZombie)
        {
            zombie.KenaDamage(9999);
        }
    }

        void OnGUI()
    {
        GUI.skin.label.fontSize = 22;
        GUI.Label(new Rect(16, 16, 480, 36), "Koin: " + koinTerkumpul + " / " + totalKoin);
        GUI.Label(new Rect(16, 52, 480, 36), "Zombie mati: " + jumlahZombieMati);
         if (sudahMenang)
        {
            GUI.Label(new Rect(16, 124, 480, 36), "KAMU MENANG!");
        }
    }
}