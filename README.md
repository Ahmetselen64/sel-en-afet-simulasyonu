
# Sel-en: Afet Simülasyonu 🌊

Bursa Uludağ Üniversitesi Yönetim Bilişim Sistemleri (YBS) bölümü Dönem Sonu Projesi kapsamında geliştirilmiş, 3D birinci şahıs (FPS) afet yönetimi ve hayatta kalma simülasyonudur.

Bu proje; olası bir sel felaketi anında kısıtlı zaman altında doğru reflekslerin gösterilmesini, kriz yönetimini ve acil durum bilincini oyuncuya interaktif bir şekilde deneyimletmeyi amaçlamaktadır.

---

## 🎥 Tanıtım ve Oynanış Videosu
Projenin detaylı anlatımını, pedagojik altyapısını ve tüm mekaniklerinin oynanışını içeren sunum videosuna aşağıdaki linkten ulaşabilirsiniz:

▶️ **[Sel-en Afet Simülasyonu Sunum ve Oynanış Videosunu İzlemek İçin Tıklayın](BURAYA_YOUTUBE_VİDEO_LİNKİNİ_YAPIŞTIR)**

---

## 🎮 Oyunun Amacı ve Hikayesi
Oyuncu, evinin içinde aniden başlayan bir sel felaketiyle karşı karşıyadır. Sular hızla yükselirken hayatta kalmak ve evi güvene almak için ekranda beliren "Yapılacaklar" listesini saniyeler içinde tamamlaması gerekmektedir. Görevler ne kadar hızlı tamamlanırsa, oyuncu o kadar yüksek bir skor elde ederek kalıcı Liderlik Tablosu'na adını yazdırır.

## ⚙️ Temel Görevler ve Mekanikler
1. **🔌 Elektrik Şalterini Kapat:** Sular yükselmeden önce evdeki ana şalter bulunup indirilmelidir. Oyuncuya fiziksel hissiyatı aktarmak adına şalter koluna özel bir C# rotasyon animasyonu yazılmıştır.
2. **📞 112'yi Ara:** Evdeki telefon kullanılarak acil durum ekiplerine haber verilmelidir. İnteraktif akıllı telefon arayüzü (UI) üzerinden 112 hatasız tuşlanmalıdır.
3. **🎒 Kritik Eşyaları Kurtar:** Evin içine dağılmış olan ilk yardım çantası gibi kritik hayatta kalma nesneleri toplanıp yeşil güvenli bölgeye taşınmalıdır.
4. **🛏️ Kendini Güvene Al:** Tüm görevler bittikten sonra suların ulaşamayacağı yüksek bir noktaya (yatağın üzerine) çıkılarak kurtarma ekipleri beklenmelidir.

## 💻 Teknik Detaylar ve Geliştirme Ortamı
- **Oyun Motoru:** Unity 6 (6000.3.10f1)
- **Programlama Dili:** C#
- **Kullanılan Sistemler ve Algoritmalar:**
  - `PlayerPrefs` tabanlı çalışan, oyun kapatılsa dahi verileri saklayan kalıcı Liderlik Tablosu (Leaderboard).
  - Özel skor hesaplama algoritması: `Skor = 10 + (Kalan Süre * 10)`
  - Dinamik Raycast tabanlı etkileşim sistemi (`PlayerInteract`).
  - Zamanla yükselen su fiziği ve dinamik UI yönetim sistemleri.
- **Travma Duyarlılığı ve Pedagojik Uygunluk:** Projede kesinlikle travma tetikleyici gerçek afet görüntüleri, boğulma veya kan gibi unsurlar kullanılmamıştır. Kaybetme ekranında "Süre Doldu!" uyarısı verilerek her yaş grubuna uygun, güvenli bir alan oluşturulmuştur.

---

## 📸 Oyun İçi Ekran Görüntüleri

| 🔌 Ana Şalter ve Görev Listesi | 📞 112 Acil Çağrı Arayüzü |
|---|---|
| <img width="1916" height="835" alt="Ekran görüntüsü 2026-06-09 204344" src="https://github.com/user-attachments/assets/77cf34e5-bebb-4b5e-9526-f6e97d12a2bd" /> | <img width="1918" height="835" alt="Ekran görüntüsü 2026-06-09 204410" src="https://github.com/user-attachments/assets/b8313872-ae63-40a2-97a8-031cdc166598" />
 |

| 🌊 Yükselen Sular ve Ev Atmosferi | 🏆 Skor ve Liderlik Tablosu |
|---|---|
| <img width="1918" height="837" alt="Ekran görüntüsü 2026-06-09 204457" src="https://github.com/user-attachments/assets/eaafd8e0-43bc-4d9d-8b26-52cef4c0c07d" />
 | <img width="1918" height="835" alt="Ekran görüntüsü 2026-06-09 204605" src="https://github.com/user-attachments/assets/7724e775-f2ee-4a05-8ced-9972c0fdfadd" />|

---

## 👨‍💻 Geliştirici Bilgileri
**Ahmet Selen** – *Öğrenci No:* 132430070  
Bursa Uludağ Üniversitesi, İnegöl İşletme Fakültesi, Yönetim Bilişim Sistemleri Bölümü, 2. Sınıf
