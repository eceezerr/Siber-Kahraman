using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public enum SoruTipi { Buton, Input }

    [System.Serializable] 
    public struct SoruVerisi { 
        [TextArea] public string soruMetni; 
        [TextArea] public string ipucuMetni; 
        public SoruTipi tipi; 
        public string dogruCevap; 
    }

    [Header("Baglantilar")]
    public PlayerMovement player; 
    public TextMeshProUGUI soruMetni; 
    public TextMeshProUGUI ipucuText; 
    public GameObject ipucuPaneli;    
    public TextMeshProUGUI anahtarSayaciText; 
    public GameObject butonGrubu; 
    public GameObject inputGrubu; 
    public TMP_InputField cevapInput;

    [Header("Ses Ayarlari")]
    public AudioSource sesKaynagi; 
    public AudioClip dogruCevapSesi; 
    public AudioClip yanlisCevapSesi; 

    [Header("Sorular Listesi")]
    public SoruVerisi[] sorular;

    [Header("Oyun Verileri")]
    public int toplananAnahtar = 0; 
    public int hedefAnahtar = 6;
    
    private int suAnkiSoruIndex;
    private GameObject sonDokunulanAnahtar;

    void Start() {
        UpdateUI();
        if (ipucuPaneli != null) ipucuPaneli.SetActive(false);
        gameObject.SetActive(false); 
    }

    public void SoruSor(string anahtarIsmi, GameObject anahtarObjesi) {
        if (ipucuPaneli != null) ipucuPaneli.SetActive(false); 
        gameObject.SetActive(true);
        sonDokunulanAnahtar = anahtarObjesi;
        
        string rakam = System.Text.RegularExpressions.Regex.Match(anahtarIsmi, @"\d+").Value;
        if (!string.IsNullOrEmpty(rakam)) {
            suAnkiSoruIndex = int.Parse(rakam) - 1;
            soruMetni.text = sorular[suAnkiSoruIndex].soruMetni;
            bool isButon = sorular[suAnkiSoruIndex].tipi == SoruTipi.Buton;
            butonGrubu.SetActive(isButon); 
            inputGrubu.SetActive(!isButon);
            if(cevapInput != null) cevapInput.text = "";
        }
    }

    public void IpucuGoster() {
        if (ipucuPaneli != null && ipucuText != null) {
            ipucuPaneli.SetActive(true);
            ipucuText.text = sorular[suAnkiSoruIndex].ipucuMetni;
        }
    }

    public void ButonCevapVer(string cevap) { CevapKontrol(cevap); }
    public void InputCevapVer() { if(cevapInput != null) CevapKontrol(cevapInput.text); }

    private void CevapKontrol(string verilenCevap) {
        string dogru = sorular[suAnkiSoruIndex].dogruCevap.Trim().ToLower();
        
        if (verilenCevap.Trim().ToLower() == dogru) {
            // DOĞRU CEVAP
            if (sesKaynagi != null && dogruCevapSesi != null) 
                sesKaynagi.PlayOneShot(dogruCevapSesi);

            toplananAnahtar++; 
            UpdateUI();
            
            // Doğru bilindiği için anahtarı artık silebiliriz
            if(sonDokunulanAnahtar != null) Destroy(sonDokunulanAnahtar); 
        } else {
            // YANLIŞ CEVAP
            if (sesKaynagi != null && yanlisCevapSesi != null) 
                sesKaynagi.PlayOneShot(yanlisCevapSesi);

            // Oyuncunun canını azalt ve kalpleri güncelle
            if(player != null) {
                player.CanKaybet();
            }
        }

        // Sesin bitmesi için kısa bir bekleme süresi veriyoruz
        Invoke("PaneliKapat", 0.5f); 
    }

    void PaneliKapat() {
        gameObject.SetActive(false);
        if (ipucuPaneli != null) ipucuPaneli.SetActive(false);
    }

    public void UpdateUI() {
        if (anahtarSayaciText != null) 
            anahtarSayaciText.text = toplananAnahtar + " / " + hedefAnahtar;
    }

    public void IpucuKapat() {
        if (ipucuPaneli != null) ipucuPaneli.SetActive(false);
    }
}