# Unity AR Foundation Android + iOS Kurulum (Hazırlanan Proje)

Bu klasörde AR odaklı temel Unity proje iskeleti ve AR Foundation paket manifesti oluşturuldu.

## Benim yaptıklarım

- `Packages/manifest.json` oluşturuldu.
- `com.unity.xr.arfoundation`, `com.unity.xr.arcore` ve `com.unity.xr.arkit` bağımlılıkları eklendi.
- Modüler klasör yapısı oluşturuldu:
  - `Assets/_Project/Modules/AR`
  - `Assets/_Project/Modules/Interaction`
  - `Assets/_Project/Modules/UI`
  - `Assets/_Project/Bootstrap`
- Başlangıç scriptleri eklendi:
  - `ARPlacementController`
  - `TapToPlaceInput`
  - `ARSetupGuide`
  - `SceneBootstrap`

## Unity Editor'de senin bir kerelik tıklayacağın adımlar

1. Unity Hub ile bu klasörü aç.
2. Eksik editor modülleri varsa Unity Hub'dan kur:
   - Android Build Support
   - Android SDK & NDK Tools
   - OpenJDK
   - iOS Build Support
3. Unity açıldığında:
   - `File > Build Settings > Android > Switch Platform`
4. `Edit > Project Settings > XR Plug-in Management > Android`:
   - `ARCore` seçeneğini işaretle.
5. `Edit > Project Settings > XR Plug-in Management > iOS`:
   - `ARKit` seçeneğini işaretle.
6. Yeni sahne aç ve Hierarchy'ye ekle:
   - `GameObject > XR > AR Session`
   - `GameObject > XR > XR Origin (AR)`
7. `XR Origin (AR)` objesine ekle:
   - `AR Plane Manager`
   - `AR Raycast Manager`
8. Boş bir GameObject oluştur, `TapToPlaceInput` scriptini ekle.
9. Aynı sahnede başka GameObject'e `ARPlacementController` ekle.
   - `Raycast Manager` referansını `XR Origin (AR)` üzerindeki `ARRaycastManager` ile bağla.
   - `Liver Prefab` alanına bir 3D model prefab'ı ver.
10. `TapToPlaceInput` içindeki `Placement Controller` alanına bu controller'i bağla.
11. Android testi için:
   - `File > Build Settings > Android > Build And Run`
12. iOS testi için:
   - `File > Build Settings > iOS > Switch Platform`
   - `Build` al ve Xcode ile cihaza yükle.

## Cross-platform notları

- Kod tabanı aynı kalır, AR Foundation her platformda uygun provider'ı kullanır.
- Android cihazda Google Play Services for AR (ARCore) gerekli olabilir.
- iOS cihazda ARKit destekleyen model (genelde A9 ve üstü) gerekir.

## Not

Bu uygulama AR eğitim amaçlıdır; tıbbi tanı veya tedavi kararı vermez.
