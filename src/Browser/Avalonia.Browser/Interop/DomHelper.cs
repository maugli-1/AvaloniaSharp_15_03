﻿using System;
using System.Runtime.InteropServices.JavaScript;

namespace Avalonia.Browser.Interop;

internal static partial class DomHelper
{
    [JSImport("globalThis.document.getElementById")]
    internal static partial JSObject? GetElementById(string id);

    [JSImport("AvaloniaDOM.createAvaloniaHost", AvaloniaModule.MainModuleName)]
    public static partial JSObject CreateAvaloniaHost(JSObject element);

    [JSImport("AvaloniaDOM.isFullscreen", AvaloniaModule.MainModuleName)]
    public static partial bool IsFullscreen();

    [JSImport("AvaloniaDOM.setFullscreen", AvaloniaModule.MainModuleName)]
    public static partial JSObject SetFullscreen(bool isFullscreen);

    [JSImport("AvaloniaDOM.getSafeAreaPadding", AvaloniaModule.MainModuleName)]
    public static partial byte[] GetSafeAreaPadding();

    [JSImport("AvaloniaDOM.addClass", AvaloniaModule.MainModuleName)]
    public static partial void AddCssClass(JSObject element, string className);

    [JSImport("ResizeHandler.observeSize", AvaloniaModule.MainModuleName)]
    public static partial void ObserveSize(
        JSObject canvas,
        [JSMarshalAs<JSType.Function<JSType.Number, JSType.Number, JSType.Number>>]
        Action<double, double, double> onSizeOrDpiChanged);

    [JSImport("AvaloniaDOM.observeDarkMode", AvaloniaModule.MainModuleName)]
    public static partial JSObject ObserveDarkMode(
        [JSMarshalAs<JSType.Function<JSType.Boolean, JSType.Boolean>>]
        Action<bool, bool> observer);
}
