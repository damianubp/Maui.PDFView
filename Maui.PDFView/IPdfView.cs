﻿using System.Windows.Input;

namespace Maui.PDFView
{
    internal interface IPdfView : IView
    {
        string Uri { get; set; }
        bool IsHorizontal { get; set; }
        float MaxZoom { get; set; }
        PageAppearance? PageAppearance { get; set; }
        uint PageIndex { get; set; }

        ICommand PageChangedCommand { get; set; }
    }
}
