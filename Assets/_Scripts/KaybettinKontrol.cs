using UnityEngine;
using UnityEngine.SceneManagement;

public class KaybettinKontrol : MonoBehaviour
{
    // siskbuton (Sistemi Kurtar) - Ölünen bölüme geri gönderir
    public void SiskButonTiklandi() {
        string donulecekSahne = PlayerMovement.sonOynananSahne;
        if (!string.IsNullOrEmpty(donulecekSahne)) {
            SceneManager.LoadScene(donulecekSahne);
        } else {
            SceneManager.LoadScene("SampleScene");
        }
    }

    // gcbuton (Güvenli Çıkış) - Ana menüye döner
    public void GcButonTiklandi() {
        SceneManager.LoadScene("AnaMenu");
    }
}