# Unity AR Foundation Android + iOS Kurulum (Hazirlanan Proje)

Bu klasorde temel Unity proje iskeleti ve AR Foundation paket manifesti olusturuldu.

## Benim yaptiklarim

- `Packages/manifest.json` olusturuldu.
- `com.unity.xr.arfoundation`, `com.unity.xr.arcore` ve `com.unity.xr.arkit` bagimliliklari eklendi.
- Moduler klasor yapisi olusturuldu:
  - `Assets/_Project/Modules/AR`
  - `Assets/_Project/Modules/Interaction`
  - `Assets/_Project/Modules/UI`
  - `Assets/_Project/Modules/HealthLogic`
  - `Assets/_Project/Modules/Data`
  - `Assets/_Project/Bootstrap`
- Baslangic scriptleri eklendi:
  - `ARPlacementController`
  - `TapToPlaceInput`
  - `AssessRiskUseCase`
  - `LocalSymptomRepository`
  - `SceneBootstrap`

## Unity Editor'de senin bir kerelik tiklayacagin adimlar

1. Unity Hub ile bu klasoru ac.
2. Eksik editor modulleri varsa Unity Hub'dan kur:
   - Android Build Support
   - Android SDK & NDK Tools
   - OpenJDK
   - iOS Build Support
3. Unity acildiginda:
   - `File > Build Settings > Android > Switch Platform`
4. `Edit > Project Settings > XR Plug-in Management > Android`:
   - `ARCore` secenegini isaretle.
5. `Edit > Project Settings > XR Plug-in Management > iOS`:
   - `ARKit` secenegini isaretle.
6. Yeni sahne ac ve Hierarchy'ye ekle:
   - `GameObject > XR > AR Session`
   - `GameObject > XR > XR Origin (AR)`
7. `XR Origin (AR)` objesine ekle:
   - `AR Plane Manager`
   - `AR Raycast Manager`
8. Bos bir GameObject olustur, `TapToPlaceInput` scriptini ekle.
9. Ayni sahnede baska GameObject'e `ARPlacementController` ekle.
   - `Raycast Manager` referansini `XR Origin (AR)` uzerindeki `ARRaycastManager` ile bagla.
   - `Liver Prefab` alanina bir 3D model prefab'i ver.
10. `TapToPlaceInput` icindeki `Placement Controller` alanina bu controller'i bagla.
11. Android testi icin:
   - `File > Build Settings > Android > Build And Run`
12. iOS testi icin:
   - `File > Build Settings > iOS > Switch Platform`
   - `Build` al ve Xcode ile cihaza yukle.

## Cross-platform notlari

- Kod tabani ayni kalir, AR Foundation her platformda uygun provider'i kullanir.
- Android cihazda Google Play Services for AR (ARCore) gerekli olabilir.
- iOS cihazda ARKit destekleyen model (genelde A9 ve ustu) gerekir.

## Not

Bu uygulama tani koymaz. Semptom farkindaligi ve yonlendirme yardimcisi olarak tasarlanmistir.
