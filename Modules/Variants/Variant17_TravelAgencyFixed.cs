// <copyright file="Variant17_TravelAgencyFixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants.Fixed;

/// <summary>
/// Represents a tourist tour with destination, duration and price.
/// </summary>
public class Tour
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tour"/> class.
    /// </summary>
    /// <param name="country">Destination country (cannot be empty).</param>
    /// <param name="nights">Number of nights (must be positive).</param>
    /// <param name="price">Price in currency (must be non-negative).</param>
    /// <exception cref="ArgumentException">Thrown when country is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when nights. <= 0 or price < 0.</exception>
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

    /// <summary>
    /// Gets the destination country.
    /// </summary>
    public string Country { get; }

    /// <summary>
    /// Gets the number of nights.
    /// </summary>
    public int Nights { get; }

    /// <summary>
    /// Gets the tour price.
    /// </summary>
    public decimal Price { get; }
}

/// <summary>
/// Provides operations for managing tours and searching by budget and nights.
/// </summary>
public class TravelAgency
{
    private readonly List<Tour> tours = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="TravelAgency"/> class with predefined tours.
    /// </summary>
    public TravelAgency()
    {
        this.tours.Add(new Tour("Turkey", 7, 50000m));
        this.tours.Add(new Tour("Egypt", 10, 70000m));
        this.tours.Add(new Tour("UAE", 5, 90000m));
    }

    /// <summary>
    /// Adds a new tour to the agency.
    /// </summary>
    /// <param name="tour">The tour to add.</param>
    public void AddTour(Tour tour)
    {
        this.tours.Add(tour);
    }

    /// <summary>
    /// Finds tours that fit within the budget and have at least the minimum number of nights.
    /// </summary>
    /// <param name="maxPrice">Maximum price (cannot be negative).</param>
    /// <param name="minNights">Minimum number of nights (must be positive).</param>
    /// <returns>A read-only list of tours satisfying the criteria.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when maxPrice is negative or minNights is not positive.</exception>
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