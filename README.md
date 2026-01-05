Siber Kahraman: 2D Eğitici Platform Oyunu
Siber Kahraman, oyunculara temel siber güvenlik prensiplerini etkileşimli bir platform deneyimiyle öğretmeyi amaçlayan, Unity motoru ile geliştirilmiş bir ciddi oyun (serious game) projesidir. Oyun, siber güvenlik eğitimini oyunlaştırma teknikleriyle birleştirerek kalıcı öğrenme sağlamak üzere tasarlanmıştır.





Eğitimsel Temel ve Maarif Modeli Uyumu
Bu proje, Türkiye Yüzyılı Maarif Modeli’nin temel aldığı bütüncül eğitim yaklaşımıyla uyumlu olarak geliştirilmiştir. Oyunun her aşaması, öğrencilerin dijital yetkinliklerini ve etik değerlerini geliştirmeye yönelik yapılandırılmıştır:

Kazanım Odaklı Bölümler: Oyunun her bir bölümü, siber güvenliğin belirli bir alt kazanımına (Örn: Dijital Kimlik Güvenliği, Güçlü Parola Oluşturma, Oltalama Saldırı farkındalığı vb.) odaklanmaktadır.





Sarmal Öğrenme Yapısı: Seviyeler ilerledikçe alt kazanımlar birbirini destekleyecek şekilde zorlaşmakta ve bilginin kalıcılığı hedeflenmektedir.

Oyunun Amacı
Oyuncular, dijital dünyayı tehdit eden siber saldırganlar tarafından kilitlenen verileri kurtarmak için aşamalı bölümleri tamamlamalıdır. Her bölüm, siber güvenliğin kritik bir alt kazanımına odaklanarak öğrenciye rehberlik eder.





Oynanış ve Mekanikler
Alt Kazanım Bazlı İlerleme: Her seviye, siber güvenliğin farklı bir boyutunu temsil eden 6 adet altın anahtar içermektedir.


İnteraktif Soru Sistemi: Anahtarlara dokunulduğunda oyuncunun karşısına o bölüme ait alt kazanıma dair sorular çıkmaktadır.




Özel İpucu Desteği: Her soru, Maarif Modeli'nin rehberlik anlayışına uygun olarak, oyuncuyu doğruya yönlendiren özel bir ipucu butonu ile desteklenmiştir.

Öğretici Hata Döngüsü: Yanlış cevap verildiğinde anahtar nesnesi sahnede kalmaya devam eder. Oyuncu doğru bilgiye ulaşana kadar deneme yapabilir, bu da hatanın bir öğrenme basamağı olarak görüldüğü pedagojik yaklaşımı destekler.


Bölüm Sonu Şartı: 6 anahtarın tamamı toplanmadan bölüm sonundaki sandık aktif hale gelmez, bu da kazanımların tam olarak öğrenilmesini garanti altına alır.



Teknik Özellikler
Motor: Unity Engine 

Dil: C# 

Platform: PC 


Görünüm: 2D Side-Scroller 

Kontroller
Yatay Hareket: A - D tuşları veya Yön Tuşları 




Zıplama: W tuşu veya Space (Boşluk) tuşu 



Etkileşim: Fare Sol Tık (UI butonları ve cevap girişleri için) 

Sistem: ESC tuşu veya oyun içi buton ile uygulamadan çıkış 


Proje İçeriği
Bu depoda (repository) aşağıdaki bileşenler yer almaktadır:

/Assets: Kodlar, Sahneler ve Görsel materyaller.

/GDD: Maarif Modeli kazanımları ile ilişkilendirilmiş kapsamlı Game Design Document (Oyun Tasarım Belgesi).


PlayerMovement.cs: Karakter kontrolü, can sistemi ve nesne etkileşimlerini yöneten temel mekanik kodları.



QuestionManager.cs: Dinamik soru sistemi, ipucu mantığı ve görsel/işitsel geri bildirim sistemlerini yöneten script.


Geliştirici Notu: Bu proje, Maarif Modeli çerçevesinde bireyin dijital dünyada kendini koruyabilen, etik değerlere sahip bir "siber vatandaş" olarak yetişmesine katkı sunmak için geliştirilmiştir.
