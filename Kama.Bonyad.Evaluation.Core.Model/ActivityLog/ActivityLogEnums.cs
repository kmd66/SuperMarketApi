
namespace Kama.Bonyad.Evaluation.Core.Model
{
    public enum OS : byte
    {
        unknown = 0,
        windows = 1,
        android = 2,
        ios = 3,
        linux = 4,
        mac = 5,
        blackberry_os = 6,
        سایر = 5
    }

    public enum Browser : byte
    {
        unknown = 0,
        firefox = 1,
        chrome = 2,
        opera = 3,
        internet_explorer = 4,
        سایر = 5
    }

    public enum DeviceType : byte
    {
        unknown = 0,
        mobile = 1,
        desktop = 2,
        smartphone = 3,
        tablet = 4,
        iPhone = 5,
        سایر = 6
    }
}
