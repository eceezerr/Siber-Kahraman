using UnityEngine;
using TMPro; // TextMeshPro kullanmak için bu satır şart

public class StoryManager : MonoBehaviour
{
    public GameObject hikayePaneli;
    public GameObject gorevYazisi; // Ekranda duran "Kitaba Dokun" yazısı

    void Start()
    {
        if (hikayePaneli != null) 
            hikayePaneli.SetActive(false);
            
        // Oyun başında yazı açık olsun
        if (gorevYazisi != null)
            gorevYazisi.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hikayePaneli.SetActive(true);
            
            // Kitaba dokunulduğu için yönlendirme yazısını kapat
            if (gorevYazisi != null)
                gorevYazisi.SetActive(false);
        }
    }

    public void HikayeyiKapat()
    {
        hikayePaneli.SetActive(false);
        // Kitabı yok edebilirsin (isteğe bağlı)
        // Destroy(gameObject); 
    }
}