// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.5.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace SimpleBot.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(turnContext.Activity.Text)) {
                await SendActivityAsync(turnContext, MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
            }            
        }


        // Metodo para dar bienvenida a los usuarios
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    //var reply = MessageFactory.Text("This is an inline attachment.");
                    var reply = MessageFactory.Attachment(new List<Attachment>() { GetInlineAttachment() });
                    reply.Text = "This is an inline attachment";
                    await turnContext.SendActivityAsync(reply, cancellationToken);
                }
            }
        }



        private static async Task SendActivityAsync(ITurnContext<IMessageActivity> turnContext, Activity activity, CancellationToken cancellationToken) {
            if (!activity.Equals(null))
            {
                await turnContext.SendActivityAsync(activity, cancellationToken);
            }
        }

        private static Attachment GetInlineAttachment()
        {
            return new Attachment
            {
                Name = @"imagenes-estructura/logo-header-new.png_185036490.png",
                ContentType = "image/png",
                ContentUrl = "https://www.principal.com.mx/export/sites/principal-financial-group/.galleries/imagenes-estructura/logo-header-new.png_185036490.png",
            };
        }
    }
}
