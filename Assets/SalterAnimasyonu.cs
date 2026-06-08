using UnityEngine;

public class SalterAnimasyonu : MonoBehaviour
{
    [Header("Açı Ayarları (Test Ederek Bul)")]
    // Şalterin açıkken durduğu açı (genelde 0,0,0)
    public Vector3 acikAci = new Vector3(0, 0, 0); 
    
    // Şalter indikçe alacağı hedef açı (örn: X ekseninde 90 derece aşağı)
    public Vector3 kapaliAci = new Vector3(90, 0, 0); 
    
    [Header("İnme Hızı")]
    public float hiz = 5f;

    private bool salterIndiMi = false;

    void Update()
    {
        // Eğer E'ye basılıp şalter indiyse, menteşeyi yumuşakça (Lerp) hedef açıya döndür
        if (salterIndiMi)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(kapaliAci), Time.deltaTime * hiz);
        }
    }

    // E'ye bastığımızda bu fonksiyonu çağıracağız ki süreç başlasın
    public void SalteriIndir()
    {
        salterIndiMi = true;
    }
}