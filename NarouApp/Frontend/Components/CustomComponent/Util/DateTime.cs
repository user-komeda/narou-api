namespace NarouApp.Frontend.Components.CustomComponent.Util;

public sealed class DateTime : IDateTime {

    public System.DateTime GetDateTimeNow() => System.DateTime.Now;
}
