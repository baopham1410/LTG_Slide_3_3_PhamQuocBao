# Báo cáo thực hành — Slide 3.2 & 3.3

**Môn:** Game Programming (C# & Unity)  
**Nội dung:** Animation Scripting and Interactions (3.2) · User Interface Design (3.3)  
**Project:** `LTG_Tuan2_Bai13_Bai14`

---

## 1. Tóm tắt bài làm

| Slide | Nội dung thực hành | Trạng thái |
|------:|--------------------|------------|
| 3.2 | Animation Event trên Standing Greeting → Log `Hello World!` | Có script + hướng dẫn |
| **3.3** | **Popup UI (Continue / Restart) khi máy bay va Enter Wall** | **Bài nộp chính** |

---

## 2. Practice Slide 3.3 — UI Popup (bài nộp)

### Yêu cầu
1. Thiết kế popup: Title, Message, nút **Continue** và **Restart** (Canvas, Panel, TextMeshPro, Button).
2. Hiện popup khi máy bay cất cánh và va chạm **Enter Wall** (không load scene ngay).
3. Continue → chuyển scene tiếp · Restart → reload scene hiện tại.
4. Nội dung Title / Message / Button text gán từ code.

### Cấu trúc UI trong Scene
```
Canvas
└── GameMenu / Panel
    ├── Title          (TextMeshPro)
    ├── Message        (TextMeshPro)
    ├── ContinueButton (Button - TextMeshPro)
    └── RestartButton  (Button - TextMeshPro)
```

### Script đã viết

| File | Vai trò |
|------|---------|
| `Assets/Slide_3_3_Assets/Scripts/GameManager.cs` | Tắt Canvas mặc định; gán nội dung động; `ShowPopup()`, `NextScene()`, `RestartScene()` |
| `Assets/Slide_3_3_Assets/Scripts/EnterGame.cs` | `OnTriggerEnter` trên Enter Wall → gọi `GameManager.ShowPopup()` |
| `Assets/Slide_3_3_Assets/Scripts/AirplaneTakeOff.cs` | Máy bay bay về phía trước + lên (cất cánh) |

### Cách gắn trong Unity
1. `GameManager` gắn lên **Main Camera** → kéo các UI vào Inspector.
2. Button **Continue** → OnClick → `GameManager.NextScene()`.
3. Button **Restart** → OnClick → `GameManager.RestartScene()`.
4. **EnterWall**: Collider **Is Trigger** + `EnterGame` → kéo Main Camera (GameManager).
5. **Airplane**: Rigidbody + `AirplaneTakeOff`, Tag `Player` (hoặc tên chứa Airplane).

### Scene đề xuất
- `Assets/Slide_3_3_Assets/Scenes/Bai_3_3_UI_Popup.unity`

---

## 3. Practice Slide 3.2 — Animation Event

### Yêu cầu
Khi X Bot (Mixamo) chạy animation **Standing Greeting**, tại frame giơ tay (frame 60) → Console log `"Hello World!"`.

### Script
| File | Vai trò |
|------|---------|
| `Assets/Slide_3_2_Assets/Scripts/AnimationEventScript.cs` | Hàm `AnimationEventFunction(string message)` → `Debug.Log(message)` |

### Các bước chính
1. Tải X Bot + Standing Greeting từ Mixamo → `Assets/Slide_3_2_Assets/Mixamo/`.
2. Duplicate Animation Clip (Mixamo read-only).
3. Animation window → frame 60 → Add Animation Event → gọi `AnimationEventFunction` với parameter `Hello World!`.
4. Gắn `AnimationEventScript` lên X Bot → Play → xem Console.

---

## 4. Thư mục trong repo

```
Assets/
├── Slide_3_2_Assets/
│   ├── Scripts/AnimationEventScript.cs
│   ├── Mixamo/          (FBX từ Mixamo — tự thêm khi làm)
│   └── Animations/
└── Slide_3_3_Assets/
    ├── Scripts/
    │   ├── GameManager.cs
    │   ├── EnterGame.cs
    │   └── AirplaneTakeOff.cs
    └── Scenes/          (scene Bai_3_3_UI_Popup — tạo trong Unity rồi Save)

HUONG_DAN_BAI_THUC_HANH_3_2_VA_3_3.txt   ← hướng dẫn chi tiết từng bước
NOP_BAI_SLIDE_3_2_VA_3_3.md              ← file báo cáo nộp (file này)
```

---

## 5. Checklist trước khi nộp GitHub

- [ ] Đã tạo scene `Bai_3_3_UI_Popup` và Save trong `Slide_3_3_Assets/Scenes/`
- [ ] Đã Import TextMeshPro
- [ ] Popup hiện đúng khi máy bay va Enter Wall
- [ ] Continue / Restart hoạt động
- [ ] (Tuỳ yêu cầu cô) Scene / clip Practice 3.2 đã làm
- [ ] Commit & push repo lên GitHub

---

## 6. Ghi chú nhanh (khi được hỏi)

- **Canvas tắt mặc định** → chỉ `ShowPopup()` mới bật (feedback UI đúng lúc va chạm).
- **EnterGame** dùng Trigger thay vì load scene ngay → đúng yêu cầu slide 3.3.
- **TextMeshPro** thay Legacy Text → UI rõ, dễ chỉnh font/màu.
- **Animation Event (3.2)** đồng bộ logic game với đúng frame animation.

---

*File này dùng để nộp / đính kèm GitHub cùng source Unity.*
