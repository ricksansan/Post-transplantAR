# Post-transplantAR - Karaciğer Nakli Sonrası AR Eğitim Uygulaması

Bu proje, karaciğer nakli sonrası hastaya yalnızca AR destekli görsel eğitim sunmak için tasarlanmıştır.

## Proje Amacı

- Hastaya AR ile karaciğer anatomisini ve ameliyat sonrası süreci görsel olarak anlatmak

## Kapsam

- Tek odak: AR eğitim deneyimi
- Model yerleştirme, döndürme, ölçekleme ve bilgi noktaları
- Android (ARCore) ve iOS (ARKit) desteği

## Teknoloji Yığını

- Unity (önerilen: 2022.3 LTS)
- AR Foundation
- ARCore XR Plugin (Android)
- ARKit XR Plugin (iOS)
- C#

## Güncel Proje Yapısı

```text
Assets/_Project/
├── Bootstrap/
│   └── SceneBootstrap.cs
└── Modules/
    ├── AR/
    │   └── Runtime/Controllers/ARPlacementController.cs
    ├── Interaction/
    │   └── Runtime/Input/TapToPlaceInput.cs
    └── UI/
        └── Runtime/Screens/ARSetupGuide.cs
```

## Modül Sorumlulukları

- `AR`: düzlem algılama, raycast, 3D model yerleştirme
- `Interaction`: dokunma girdisi, kullanıcı etkileşimi
- `UI`: yönlendirme metinleri ve basit eğitim ekranı
- `Bootstrap`: başlangıç performans ayarları ve sahne açılış akışı

## Çalışma Akışı

1. Kullanıcı ekrana dokunur.
2. `TapToPlaceInput` dokunma bilgisini alır.
3. `ARPlacementController` uygun düzleme modeli yerleştirir.
4. `ARSetupGuide` ekranda yönlendirme metni gösterir.

## Kurulum

Detaylar için: `SETUP_ARFOUNDATION_ANDROID_TR.md`

Kısa özet:
- Unity Hub ile editor + Android/iOS modüllerini kur
- Projeyi Unity ile aç
- XR Plug-in Management içinde Android için ARCore, iOS için ARKit aç
- Sahneye `AR Session` ve `XR Origin (AR)` ekle
- `AR Plane Manager` ve `AR Raycast Manager` bileşenlerini bağla

## Not

Bu sürüm yalnızca AR eğitim kapsamındadır.
