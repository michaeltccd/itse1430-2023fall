﻿/*
 * ITSE 1430
 * Fall 2023
 */
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary;

/// <summary>Provides support for validating objects.</summary>
public class ObjectValidator
{
    /// <summary>Tries to validate an object.</summary>
    /// <param name="value">Value to validate.</param>
    /// <param name="results">Validation results.</param>
    /// <returns>true if valid or false otherwise.</returns>
    public bool TryValidate ( IValidatableObject value, out IEnumerable<ValidationResult> results)
    {
        var context = new ValidationContext(value);

        var items = new System.Collections.ObjectModel.Collection<ValidationResult>();

        if (Validator.TryValidateObject(value, context, items, true))
        {
            results = new ValidationResult[0];
            return true;
        };

        results = items;
        return false;
    }
}
