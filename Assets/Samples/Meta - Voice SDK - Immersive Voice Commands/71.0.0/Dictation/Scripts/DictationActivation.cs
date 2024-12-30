/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Meta.WitAi.Dictation;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Meta.Voice.Samples.Dictation
{
    public class DictationActivation : MonoBehaviour
    {
        [FormerlySerializedAs("dictation")]
        [SerializeField] private DictationService _dictation;
        public TMP_Text myText;
        public TMP_InputField inputFieldTMP; // Assign your Input Field (TextMeshPro)

        public void PushAndHold()
        {
            _dictation.Activate();
            myText.text = "Bạn đang nói";
            Debug.Log("Input Started");
        }

        public void Release()
        {
            _dictation.Deactivate();
            myText.text = "Đang không nói";
            EndEditing();
        }

        void EndEditing()
        {
            if (inputFieldTMP != null)
            {
                // Deselect the input field (TextMeshPro)
                inputFieldTMP.DeactivateInputField();
                // Or you can use this to force the text to be committed.
                inputFieldTMP.onEndEdit.Invoke(inputFieldTMP.text);
                
            }
            Debug.Log(inputFieldTMP.text);
            // Optionally, you can perform other actions here, like:
            // - Saving the input text
            // - Displaying a message
            // - Disabling the button
            // endEditButton.interactable = false;
            Debug.Log("Input Ended");
        }

        public void ToggleActivation()
        {
            if (_dictation.MicActive)
            {
                _dictation.Deactivate();
                if (inputFieldTMP != null)
                {
                    // Deselect the input field (TextMeshPro)
                    inputFieldTMP.DeactivateInputField();
                    // Or you can use this to force the text to be committed.
                    inputFieldTMP.onEndEdit.Invoke(inputFieldTMP.text);
                }
                
            }
            else
            {
                _dictation.Activate();
            }
        }
    }
}
