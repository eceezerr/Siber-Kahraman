using UnityEngine;
using UnityEngine.SceneManagement;

public class SandikKontrol : MonoBehaviour
{
    public int gerekenAnahtar = 6;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Panelde kullandığın "Sandik" tag'ine tam uyum için:
        if (collision.gameObject.CompareTag("Player"))
        {
            QuestionManager qm = FindObjectOfType<QuestionManager>();
            
            if (qm != null)
            {
                // Değişken ismini QuestionManager ile eşitledik
                if (qm.toplananAnahtar >= gerekenAnahtar)
                {
                    Debug.Log("Tebrikler! Bolum 2'ye geçiliyor...");
                    SceneManager.LoadScene("Bolum2"); 
                }
                else
                {
                    Debug.Log("Daha fazla anahtar lazım! Şu an: " + qm.toplananAnahtar);
                }
            }
        }
    }
}