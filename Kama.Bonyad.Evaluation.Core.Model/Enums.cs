﻿
using System.ComponentModel;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public enum DepoType : byte
    {
        Unknown = 0,
        ورود_انبار_مخزن = 1,
        ورود_انبار_فروش = 2,
        ورود_انبار_ارسال = 3,

        خروج_انبار_مخزن = 10,
        خروج_انبار_فروش = 11,
        خروج_انبار_ارسال = 12,
    }

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
    public enum StockActionState : byte
    {
        Unknown = 0,
        موجودی_انبار = 1,
        هشدار_موجودی = 2,
        انقضا = 3,
        هشدار_انقضا = 4,
    }

    public enum DocState : byte
    {
        Unknown = 0,
        انبار_مخزن = 1,
        انبار_فروش = 2,
        انبار_ارسال = 3,

        درحال_ارسال = 40,
        تحویل_داده_شده = 50,

        مرجوع = 80,

        فروش_حضوری = 100,

        انقضا = 220,
        مرجوع_به_تولید_کننده = 221,
        دورریز = 222
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
        تصویر_کالا = 2,
        تصویر_برند = 3,
        تصاویر_کالا = 4,
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
