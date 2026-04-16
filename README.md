# Post-transplantAR - Karaciğer Nakli Sonrası AR Rehber Uygulaması

Bu proje, karaciğer nakli sonrası hastalar için geliştirilen bir mobil AR (Augmented Reality) rehber uygulamasıdır. Uygulama tanı koymaz; hastanın günlük takibini, farkındalığını ve tedaviye uyumunu destekler.

## Proje Amacı

- Hastaya AR ile karaciğer anatomisini ve ameliyat sonrası süreci görsel olarak anlatmak
- Günlük checklist ile öz-bakım adımlarını düzenli takip ettirmek
- Riskli semptomları erken fark ettirip doğru yönlendirme yapmak
- İlaç kullanımını düzenli hale getirmek ve uyumu artırmak

## Kritik İlke

Bu uygulama **diagnostic tool değildir**. Sadece rehberlik ve farkındalık asistanıdır. Yüksek risk sinyallerinde hastayı nakil ekibiyle iletişime geçmeye yönlendirir.

## Teknoloji Yığını

- Unity (önerilen: 2022.3 LTS)
- AR Foundation
- ARCore XR Plugin (Android)
- ARKit XR Plugin (iOS)
- C# (modüler clean architecture yaklaşımı)

## Mimari Yaklaşım

Proje, katmanlar ve modüller arası bağımlılığı azaltmak için clean architecture prensibine göre tasarlanmıştır.

### Katmanlar

- `Core`: temel domain ve ortak tanımlar
- `Modules`: uygulama fonksiyonları (AR, Interaction, UI, HealthLogic, Data)
- `Bootstrap`: uygulama başlangıç ve bağlantılama akışı

### Modüller

- `AR Module`: plane algılama, raycast, model yerleştirme
- `Interaction Module`: dokunmatik giriş ve gesture yönetimi
- `UI Module`: ekranlar, durum gösterimi, kullanıcı yönlendirmeleri
- `Health Logic Module`: semptom kuralları ve risk değerlendirme
- `Data Module`: lokal veri kayıt/okuma

## Güncel Klasör Yapısı

```text
Assets/_Project/
├── Bootstrap/
│   └── SceneBootstrap.cs
├── Core/
│   └── Domain/
│       └── RiskLevel.cs
└── Modules/
    ├── AR/
    │   └── Runtime/Controllers/ARPlacementController.cs
    ├── Data/
    │   └── Runtime/Repositories/LocalSymptomRepository.cs
    ├── HealthLogic/
    │   ├── Runtime/Domain/SymptomReport.cs
    │   └── Runtime/UseCases/AssessRiskUseCase.cs
    ├── Interaction/
    │   └── Runtime/Input/TapToPlaceInput.cs
    └── UI/
        └── Runtime/Screens/ARSetupGuide.cs
```

## Script Sorumlulukları

- `ARPlacementController`: ekrana dokunulan noktaya AR raycast yapar, modeli yerleştirir veya taşır.
- `TapToPlaceInput`: mobil touch girdisini dinler, placement controller'a iletir.
- `AssessRiskUseCase`: semptom verisinden düşük/orta/yüksek risk sinyali üretir.
- `LocalSymptomRepository`: son semptom kaydını `PlayerPrefs` üzerinde saklar/okur.
- `SceneBootstrap`: use case ve repository bağlantısını başlatır.
- `ARSetupGuide`: UI tarafında durum metni göstermek için temel adaptör.

## Veri Akışı (Özet)

1. Kullanıcı semptom bilgisini UI üzerinden girer.
2. `SceneBootstrap`, veriyi `LocalSymptomRepository` ile kaydeder.
3. Aynı veri `AssessRiskUseCase` ile değerlendirilir.
4. Risk seviyesi ve mesaj UI katmanına döner.
5. UI, hastaya sade ve aksiyon odaklı yönlendirme verir.

AR akışı:
1. Kullanıcı ekrana dokunur.
2. `TapToPlaceInput` girdiyi yakalar.
3. `ARPlacementController`, plane raycast sonucu liver modelini yerleştirir.

## Kurulum

Detaylı platform kurulumu için:

- `SETUP_ARFOUNDATION_ANDROID_TR.md`

Kısa özet:
- Unity Hub üzerinden editor + Android/iOS modüllerini kur
- Projeyi Unity ile aç
- XR Plug-in Management altında Android için ARCore, iOS için ARKit aç
- Sahneye `AR Session` ve `XR Origin (AR)` ekle
- `AR Plane Manager` ve `AR Raycast Manager` bileşenlerini bağla

## Geliştirme Yol Haritası

1. AR eğitim ekranına hotspot tabanlı anatomi bilgi katmanı ekleme
2. Günlük checklist ekranı ve ilerleme durumu
3. İlaç saat/planı ve doz onay akışı
4. Risk kurallarını klinik geri bildirimle kalibre etme
5. Lokalizasyon (TR/EN) ve erişilebilirlik (büyük font, sade dil)
6. Raporlama ve doktor paylaşım altyapısı (gerektiğinde)

## UX Prensipleri (Sağlık Odaklı)

- Kısa ve net metinler
- Tek ekranda tek kritik aksiyon
- Renklerle risk seviyesi ama panik yaratmayan dil
- Teknik terim yerine hasta dili
- Her zaman "doktorunuza danışın" güvenlik mesajı

## Güvenlik ve Yasal Not

- Uygulama tıbbi tanı veya tedavi kararı vermez.
- Semptom değerlendirmesi farkındalık amaçlıdır.
- Kişisel sağlık verisi için KVKK/GDPR uyumluluğu tasarım aşamasından itibaren dikkate alınmalıdır.

## Ek Dokümanlar

- `swot.md`: ürün için SWOT analizi
- `SETUP_ARFOUNDATION_ANDROID_TR.md`: Android + iOS kurulum adımları
