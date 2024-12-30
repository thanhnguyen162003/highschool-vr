using OpenAI;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ChatGPTManager : MonoBehaviour
{
    public OnResponseEvent OnResponse;
    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { }
    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();

    public async void AskChatGPT(string newText)
    {
        ChatMessage chatMessage = new ChatMessage();
        chatMessage.Content = newText;
        chatMessage.Role = "user";
        Debug.LogError("Bot Response: " + chatMessage.Content);
        messages.Add(chatMessage);
        var transcription = new StringBuilder();
        if (!string.IsNullOrEmpty(chatMessage.Content))
        {
            
             
            transcription.Append(chatMessage.Content);
            transcription.AppendLine();
            transcription.Append(string.Empty);
            transcription.Append("Bot Response: " + chatMessage.Content);
        }
        //detamrequest
        OnResponse.Invoke(transcription.ToString());
        //CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        //request.Messages = messages;
        //request.Model = "gpt-3.5-turbo";

        //var response = await openAI.CreateChatCompletion(request);

        //if (response.Choices != null && response.Choices.Count > 0)
        //{
        //    var chatResponse = response.Choices[0].Message;
        //    messages.Add(chatResponse);

        //    Debug.LogError("Bot Response: "+chatResponse.Content);


        //}


    }

    
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
