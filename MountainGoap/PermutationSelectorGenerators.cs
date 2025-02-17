﻿// <copyright file="PermutationSelectorGenerators.cs" company="Chris Muller">
// Copyright (c) Chris Muller. All rights reserved.
// </copyright>

namespace MountainGoap {
    /// <summary>
    /// Generators for default permutation selectors for convenience.
    /// </summary>
    public static class PermutationSelectorGenerators {
        /// <summary>
        /// Generates a permutation selector that returns all elements of an enumerable.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IEnumerable{T}"/>.</typeparam>
        /// <param name="values">Set of values to be included in permutations.</param>
        /// <returns>A lambda function that returns all elements from the collection passed in.</returns>
        public static PermutationSelectorCallback SelectFromCollection<T>(IEnumerable<T> values) {
            return (Dictionary<string, object> state) => {
                List<object> output = new();
                foreach (var item in values) if (item is not null) output.Add(item);
                return output;
            };
        }

        /// <summary>
        /// Generates a permutation selector that returns all elements of an enumerable within the agent state.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IEnumerable{T}"/>.</typeparam>
        /// <param name="key">Key of the state to check for the collection.</param>
        /// <returns>A lambda function that returns all elements from the collection in the state.</returns>
        public static PermutationSelectorCallback SelectFromCollectionInState<T>(string key) {
            return (Dictionary<string, object> state) => {
                List<object> output = new();
                if (state[key] is not IEnumerable<T> values) return output;
                foreach (var item in values) if (item is not null) output.Add(item);
                return output;
            };
        }

        /// <summary>
        /// Generates a permutation selector that returns all integer elements in a range.
        /// </summary>
        /// <param name="lowerBound">Lower bound from which to start.</param>
        /// <param name="upperBound">Upper bound, non-inclusive.</param>
        /// <returns>A lambda function that returns all elements in the range given.</returns>
        public static PermutationSelectorCallback SelectFromIntegerRange(int lowerBound, int upperBound) {
            return (Dictionary<string, object> state) => {
                List<object> output = new();
                for (int i = lowerBound; i < upperBound; i++) output.Add(i);
                return output;
            };
        }
    }
}
