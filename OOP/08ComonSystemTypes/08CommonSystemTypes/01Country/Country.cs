namespace _01Country
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Country : ICloneable, IComparable<Country>
    {
        private string name;

        private long population;

        private double area;

        private HashSet<string> cities;

        public Country(string name, long population, double area)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
        }

        public Country(string name, long population, double area, params string[] cities)
            : this(name, population, area)
        {
            this.Cities = new HashSet<string>(cities);
        }

        public Country(string name, long population, double area, IEnumerable<string> cities)
            : this(name, population, area)
        {
            this.Cities = new HashSet<string>(cities);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public long Population
        {
            get
            {
                return this.population;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Population", "Population cannot be negative");
                }

                this.population = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Area", "Area cannot be negative.");
                }

                this.area = value;
            }
        }

        public HashSet<string> Cities
        {
            get
            {
                return this.cities;
            }

            private set
            {
                if (value.Any(city => value.Any(city2 => city == city2 && city != city2)))
                {
                    throw new ArgumentException("Cities", "Cities must be unique.");
                }

                this.cities = new HashSet<string>(value);
            }
        }

        public static bool operator ==(Country countryA, Country countryB)
        {
            if (Object.Equals(countryA, null))
            {
                return false;
            }
            return countryA.Equals(countryB);
        }

        public static bool operator !=(Country countryA, Country countryB)
        {
            if (Object.Equals(countryA, null))
            {
                return false;
            }
            return !countryA.Equals(countryB);
        }

        public override bool Equals(object other)
        {
            if (other == null || Object.Equals(this, null) || other is Country == false)
            {
                return false;
            }

            var otherCountry = other as Country;

            return this.Name.Equals(otherCountry.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Population.GetHashCode();
        }

        public object Clone()
        {
            return new Country(this.Name, this.Population, this.Area, new HashSet<string>(this.Cities));
        }

        public int CompareTo(Country otherCountry)
        {
            int result = -this.Area.CompareTo(otherCountry.Area);
            if (result == 0)
            {
                result = -this.Population.CompareTo(otherCountry.Population);
            }

            if (result == 0)
            {
                result = this.Name.CompareTo(otherCountry.Name);
            }

            return result;
        }
    }
}