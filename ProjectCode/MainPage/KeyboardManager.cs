using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Microsoft.MixedReality.Toolkit.Experimental.UI
{
    /// <summary>
    /// This component links the NonNativeKeyboard to a TMP_InputField
    /// Put it on the TMP_InputField and assign the NonNativeKeyboard.prefab
    /// </summary>
    [RequireComponent(typeof(TMP_InputField))]
    public class KeyboardManager : MonoBehaviour, IPointerDownHandler
    {
        // NonNativeKeyboard 프리팹을 연결할 변수입니다.
        [Experimental]
        [SerializeField] private NonNativeKeyboard keyboard = null;

        // 사용자가 TMP_InputField를 클릭했을 때 호출되는 함수입니다.
        public void OnPointerDown(PointerEventData eventData)
        {
            // NonNativeKeyboard를 활성화하여 키보드를 표시합니다.
            keyboard.PresentKeyboard();

            // NonNativeKeyboard의 이벤트에 대한 핸들러를 설정합니다.
            keyboard.OnClosed += DisableKeyboard;         // 키보드가 닫힐 때 호출될 함수 설정
            keyboard.OnTextSubmitted += DisableKeyboard;  // 텍스트를 제출할 때 호출될 함수 설정
            keyboard.OnTextUpdated += UpdateText;         // 텍스트 업데이트 시 호출될 함수 설정
        }

        // NonNativeKeyboard에서 업데이트된 텍스트를 TMP_InputField에 반영하는 함수입니다.
        private void UpdateText(string text)
        {
            // TMP_InputField의 텍스트를 업데이트된 텍스트로 변경합니다.
            GetComponent<TMP_InputField>().text = text;
        }
        
        // 키보드를 비활성화하는 함수입니다.
        private void DisableKeyboard(object sender, EventArgs e)
        {
            // NonNativeKeyboard의 이벤트 핸들러들을 제거합니다.
            keyboard.OnTextUpdated -= UpdateText;         // 텍스트 업데이트 시 호출될 함수 제거
            keyboard.OnClosed -= DisableKeyboard;         // 키보드가 닫힐 때 호출될 함수 제거
            keyboard.OnTextSubmitted -= DisableKeyboard;  // 텍스트를 제출할 때 호출될 함수 제거

            // NonNativeKeyboard를 닫습니다.
            keyboard.Close();
        }
    }
}