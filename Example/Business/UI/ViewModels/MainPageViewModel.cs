﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Example.Business.Services;
using Maui.PDFView.Events;
using System.Diagnostics;
using System.Windows.Input;

namespace Example.Business.UI.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        private readonly IRepositoryService _repository = new RepositoryService();

        [ObservableProperty] private string _pdfSource;
        [ObservableProperty] private bool _isHorizontal;
        [ObservableProperty] private float _maxZoom = 4;
        [ObservableProperty] private string _pagePosition;
        [ObservableProperty] private uint _pageIndex = 0;
        [ObservableProperty] private uint _maxPageIndex = uint.MaxValue;

        [RelayCommand] private void Appearing()
        {
            ChangeUri();
        }

        [RelayCommand] private void ChangeUri()
        {
            PdfSource = _repository.GetPdfSource();
        }

        [RelayCommand] private void PageChanged(PageChangedEventArgs args)
        {
            MaxPageIndex = (uint)args.TotalPages - 1;
            PagePosition = $"{args.CurrentPage} of {args.TotalPages}";
            Debug.WriteLine($"Current page: {args.CurrentPage} of {args.TotalPages}");
        }

    }
}
