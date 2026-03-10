using Domain.Entities.Models.ApiNinjasModels;
using DoYouKnowIt.Application.Services.ApiNinjas;
using System.ComponentModel;

namespace DoYouKnowIt.Presentation.Views.ApiNInjas;

public partial class CountrFlagLookupPage : ContentPage, INotifyPropertyChanged
{
    ApiNinjasCountryService _countryFlagService;
    public CountrFlagLookupPage(ApiNinjasCountryService countryFlagService)
    {
        _countryFlagService = countryFlagService;

        InitializeComponent();
        BindingContext = this;
    }

    #region Property Changed
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    private string _countryIso2;
    public string CountryIso2 {
        get { return _countryIso2; }
        set { _countryIso2 = value;
            OnPropertyChanged(nameof(CountryIso2));
        }
    }

    private string _imageSquareUrl;
    public string ImageSquareUrl
    {
        get { return _imageSquareUrl; }
        set
        {
            _imageSquareUrl = value;
            OnPropertyChanged(nameof(ImageSquareUrl));
        }
    }

    private string _imageRectangleUrl;
    public string ImageRectangleUrl
    {
        get { return _imageRectangleUrl; }
        set
        {
            _imageRectangleUrl = value;
            OnPropertyChanged(nameof(ImageRectangleUrl));
        }
    }


    Country? _country;
    Country? Country
    {
        get { return _country; }
        set
        {
            _country = value;
            OnPropertyChanged(nameof(Country));
        }
    }
    
    private async void LoadCountry()
    {
        //Check inputs
        if (string.IsNullOrWhiteSpace(CountryIso2))
        {
            DisplayAlert("Error", "Input is null or empty", "OK");
        }
        //Get country
        else
        {
            Country = await _countryFlagService.GetCountry(CountryIso2) ?? new Country();
            if (Country == null)
                return;

            ImageSquareUrl = Country.SquareImageUrl;
            ImageRectangleUrl = Country.RectangleimageUrl;
        }

       
    }

    private void OnClickedGetCountry(object sender, EventArgs e)
    {
        LoadCountry();
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}