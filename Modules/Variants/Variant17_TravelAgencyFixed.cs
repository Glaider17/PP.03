// <copyright file="Variant17_TravelAgencyFixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants.Fixed;

public class Tour
{
    public string Country { get; }

    public int Nights { get; }

    public decimal Price { get; }

    public Tour(string country, int nights, decimal price)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException("Country cannot be empty", nameof(country));
        }

        if (nights <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nights), "Nights must be positive");
        }

        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative");
        }

        this.Country = country;
        this.Nights = nights;
        this.Price = price;
    }
}

public class TravelAgency
{
    private readonly List<Tour> tours = new();

    public TravelAgency()
    {
        this.tours.Add(new Tour("Turkey", 7, 50000m));
        this.tours.Add(new Tour("Egypt", 10, 70000m));
        this.tours.Add(new Tour("UAE", 5, 90000m));
    }


    public void AddTour(Tour tour)
    {
        this.tours.Add(tour);
    }

    public IReadOnlyList<Tour> FindByBudgetAndNights(decimal maxPrice, int minNights)
    {
        if (maxPrice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxPrice), "Budget cannot be negative.");
        }

        if (minNights <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minNights), "Minimum nights must be positive.");
        }

        var foundTours = new List<Tour>();

        foreach (var tour in this.tours)
        {
            if (tour.Price <= maxPrice && tour.Nights >= minNights)
            {
                foundTours.Add(tour);
            }
        }

        return foundTours.AsReadOnly();
    }
}