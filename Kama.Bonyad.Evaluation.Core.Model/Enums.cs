
using System.ComponentModel;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public enum ActionState : byte
    {
        Unknown = 0,
        موارد_در_دست_اقدام = 1,
        موارد_ارسال_شده = 2,
        موارد_نهایی_شده = 3,
        موارد_بایگانی_شده = 4,
        همه_موارد_مربوط_به_کاربر = 10,

        همه_موارد = 20
    }

    public enum DocState : byte
    {
        Unknown = 0,
        انبار = 1
    }
    public enum OpinionType : byte
    {
        Unknown = 0,
        تایید = 1,
        عدم_تایید = 2,
        نیاز_به_اصلاح_دارد = 3,
    }

    public enum SendType : byte
    {
        Unknown = 0,
        ارسال = 1,
        عدم_تایید = 2,

        ارسال_توسط_سیستم = 250
    }

    public enum AttachmentType : byte
    {
        Unknown = 0,
        تصویر_دسته_بندی = 1,
        تصویر_دسته_کالا = 2,
    }

    public enum UnitOfMeasureType : byte
    {
        Unknown = 0,
        عدد = 1,
        بسته = 2,
        کیلو = 3,
        متر = 4,
    }
}
