﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BlockCypher.Api.Extension
{
    internal static class EnumExtensions
    {
        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            Assert.NotNull(value, nameof(value));
            List<string> Messages = new List<string>();

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return Messages[0];

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            return propValue.ToString();
        }
    }
    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}