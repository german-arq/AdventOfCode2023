using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day5
{
    public class Day5Solution() : SolutionBase(5, "If You Give A Seed A Fertilizer")
    {
        public override void Solve()
        {
            // Part 1

            // Get data from input file in blocks
            var path = Path.Combine(Environment.CurrentDirectory, "Day" + Day.ToString(), "input.txt");
            var data = File.ReadAllText(path).Split("\n\n");
            var seeds = data[0];
            var seedToSoil = data[1];
            var soilToFertilizer = data[2];
            var fertilizerToWater = data[3];
            var waterToLight = data[4];
            var lightToTemperature = data[5];
            var temperatureToHumidity = data[6];
            var humidityToLocation = data[7];

            // Parse input
            var seedNumbers = seeds.Replace("seeds:", "").Split(' ').Select(n => n.Trim()).Where(n => !string.IsNullOrEmpty(n)).Select(long.Parse).ToList();
            var seedToSoilRanges = ParseMapString(seedToSoil).Select(GetMapValues);
            var soilToFertilizerRanges = ParseMapString(soilToFertilizer).Select(GetMapValues);
            var fertilizerToWaterRanges = ParseMapString(fertilizerToWater).Select(GetMapValues);
            var waterToLightRanges = ParseMapString(waterToLight).Select(GetMapValues);
            var lightToTemperatureRanges = ParseMapString(lightToTemperature).Select(GetMapValues);
            var temperatureToHumidityRanges = ParseMapString(temperatureToHumidity).Select(GetMapValues);
            var humidityToLocationRanges = ParseMapString(humidityToLocation).Select(GetMapValues);

            // Map seed numbers
            var mappedSeedNumbersToLocation = new List<long>();
            foreach (var seedNumber in seedNumbers)
            {
                var mappedSeedNumberToSoil = GetMappedValueFromRanges(seedNumber, seedToSoilRanges);
                var mappedSoilNumberToFertilizer = GetMappedValueFromRanges(mappedSeedNumberToSoil, soilToFertilizerRanges);
                var mappedFertilizerNumberToWater = GetMappedValueFromRanges(mappedSoilNumberToFertilizer, fertilizerToWaterRanges);
                var mappedWaterNumberToLight = GetMappedValueFromRanges(mappedFertilizerNumberToWater, waterToLightRanges);
                var mappedLightNumberToTemperature = GetMappedValueFromRanges(mappedWaterNumberToLight, lightToTemperatureRanges);
                var mappedTemperatureNumberToHumidity = GetMappedValueFromRanges(mappedLightNumberToTemperature, temperatureToHumidityRanges);
                var mappedHumidityNumberToLocation = GetMappedValueFromRanges(mappedTemperatureNumberToHumidity, humidityToLocationRanges);
                mappedSeedNumbersToLocation.Add(mappedHumidityNumberToLocation);
            }

            Part1Solution = $"{mappedSeedNumbersToLocation.Min()}";

            // Part 2
            long lowestLocation = long.MaxValue;
            var seedNumbersAsRanges = seedNumbers.Chunk(2);

            foreach (var seedNumberRange in seedNumbersAsRanges)
            {
                foreach (var seedNumber in GenerateRange(seedNumberRange[0], seedNumberRange[1]))
                {
                    var mappedSeedNumberToSoil = GetMappedValueFromRanges(seedNumber, seedToSoilRanges);
                    var mappedSoilNumberToFertilizer = GetMappedValueFromRanges(mappedSeedNumberToSoil, soilToFertilizerRanges);
                    var mappedFertilizerNumberToWater = GetMappedValueFromRanges(mappedSoilNumberToFertilizer, fertilizerToWaterRanges);
                    var mappedWaterNumberToLight = GetMappedValueFromRanges(mappedFertilizerNumberToWater, waterToLightRanges);
                    var mappedLightNumberToTemperature = GetMappedValueFromRanges(mappedWaterNumberToLight, lightToTemperatureRanges);
                    var mappedTemperatureNumberToHumidity = GetMappedValueFromRanges(mappedLightNumberToTemperature, temperatureToHumidityRanges);
                    var mappedHumidityNumberToLocation = GetMappedValueFromRanges(mappedTemperatureNumberToHumidity, humidityToLocationRanges);
                    
                    if (mappedHumidityNumberToLocation < lowestLocation)
                    {
                        lowestLocation = mappedHumidityNumberToLocation;
                    }
                }
            }

            Part2Solution = $"{lowestLocation}"; // $"{string.Join("\n", seedNumbersAsRanges.Select(p => string.Join(" - ", p)))}";

        }

        public static List<string> ParseMapString(string map) => map.Split(":")[1].Split("\n").Select(n => n.Trim()).Where(n => !string.IsNullOrEmpty(n)).ToList();

        public static (long destinationRangeStart, long sourceRangeStart, long rangeLenght) GetMapValues(string map)
        {
            List<long> values = map.Split(' ').Select(n => n.Trim()).Select(long.Parse).ToList();

            return (values[0], values[1], values[2]);
        }

        public static IEnumerable<long> GenerateRange(long start, long rangeLenght)
        {
            for (long i = start; i < start + rangeLenght; i ++)
            {
                yield return i;
            }
        }

        public static bool IsValueInRange(long value, long rangeStart, long rangeLenght)
        {
            var rangeEnd = rangeStart + rangeLenght;
            return value >= rangeStart && value < rangeEnd;
        }

        public static long GetMapppedValue(long value, long destRangeStart, long sourceRangeStart, long rangeLenght)
        {
            if(!IsValueInRange(value, sourceRangeStart, rangeLenght)) return value;
            
            var index = value - sourceRangeStart;
            var destinationValue = destRangeStart + index;
            
            return destinationValue;
        }

        public static long GetMappedValueFromRanges(long value, IEnumerable<(long destinationRangeStart, long sourceRangeStart, long rangeLenght)> ranges)
        {
            var mappedValue = value;
            var rangeOfSeedNumber = ranges.Where(range => IsValueInRange(value, range.sourceRangeStart, range.rangeLenght));
            if (rangeOfSeedNumber.Any())
            {
                mappedValue = GetMapppedValue(value, rangeOfSeedNumber.First().destinationRangeStart, rangeOfSeedNumber.First().sourceRangeStart, rangeOfSeedNumber.First().rangeLenght);
            }

            return mappedValue;
        }
    }
}
