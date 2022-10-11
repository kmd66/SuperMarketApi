using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public interface ISendMessage
    {
        string MessageTitle { get; set; }

        Organization.Core.Model.SendMessageType SendMessageType { get; set; }

        SendMessageReasonType SendMessageReasonType { get; set; }
    }

    public class SendMessageModel : ISendMessage
    {
        // ISendMessage
        public string MessageTitle { get; set; }

        public Organization.Core.Model.SendMessageType SendMessageType { get; set; }

        public SendMessageReasonType SendMessageReasonType { get; set; }
    }

    public enum SendMessageReasonType : byte
    {
        Unknown = 0,

        ComplaintSentByUser = 1,
        ComplaintNotVerifiedByMinister = 2,
        VotePublished = 3,
    }

}
