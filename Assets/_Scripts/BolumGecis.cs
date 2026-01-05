using UnityEngine;
using UnityEngine.SceneManagement;

public class BolumGecis : MonoBehaviour
{
    [Header("Ayarlar")]
    public string sonrakiSahneAdi; 
    public int gerekenAnahtar = 6;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Temas eden objenin Tag'i "Player" mı?
        if (other.CompareTag("Player"))
        {
            // Kapalı olan objeleri de tarayarak QuestionManager'ı bul
            QuestionManager qm = Object.FindFirstObjectByType<QuestionManager>(FindObjectsInactive.Include);

            if (qm != null)
            {
                Debug.Log("Sandık Kontrolü - Toplanan: " + qm.toplananAnahtar + " / Gereken: " + gerekenAnahtar);

                if (qm.toplananAnahtar >= gerekenAnahtar)
                {
                    Debug.Log(sonrakiSahneAdi + " sahnesine zorla geçiliyor...");
                    SceneManager.LoadScene(sonrakiSahneAdi);
                }
                else
                {
                    Debug.Log("GEÇİŞ REDDİ: Anahtar sayısı yetersiz!");
                }
            }
            else
            {
                Debug.LogError("HATA: Sahnede QuestionManager bulunamadı! SoruPanel objesinin hiyerarşide olduğundan emin ol.");
            }
        }
    }
}