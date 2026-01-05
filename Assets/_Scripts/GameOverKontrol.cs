using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverKontrol : MonoBehaviour {
    
    // Sahne adının Unity'dekiyle (AnaMenu) birebir aynı olduğundan emin ol
    public void AnaMenuDon() {
        Debug.Log("Ana Menüye dönülüyor..."); // Çalışıp çalışmadığını konsoldan görmek için
        SceneManager.LoadScene("AnaMenu"); 
    }

    public void TekrarDene() {
        string donulecekSahne = PlayerMovement.sonOynananSahne;
        if (!string.IsNullOrEmpty(donulecekSahne)) {
            SceneManager.LoadScene(donulecekSahne);
        } else {
            SceneManager.LoadScene("SampleScene"); 
        }
    }
}