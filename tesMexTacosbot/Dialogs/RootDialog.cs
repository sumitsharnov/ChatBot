using System;
using System.Threading.Tasks;
using ApiAiSDK;
using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using tesMexTacosbot.Helpers;

namespace tesMexTacosbot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string clientAccessToken = "603d04db7581448ea8d7811d28d6581b";
        private static AIConfiguration config = new AIConfiguration(clientAccessToken, SupportedLanguage.English);
        private static ApiAiSDK.ApiAi apiAi = new ApiAiSDK.ApiAi(config);

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var aiResponse = apiAi.TextRequest(activity.Text);
            var commomModel = CommonModelMapper.DialogFlowToCommonModel(aiResponse);
            commomModel = IntentRouter.Process(commomModel);
            await context.PostAsync(commomModel.Response.Text);

            context.Wait(MessageReceivedAsync);
        }
    }
}