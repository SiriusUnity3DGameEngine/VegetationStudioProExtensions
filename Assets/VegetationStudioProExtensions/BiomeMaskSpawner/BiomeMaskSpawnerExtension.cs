﻿using UnityEngine;
using UnityEditor;
using System;

namespace VegetationStudioProExtensions
{
    public class BiomeMaskSpawnerExtension : MonoBehaviour
    {
        /// <summary>
        /// Settings for Biome Mask creation.
        /// </summary>
        public BiomeSettings biomeSettings = new BiomeSettings();

        /// <summary>
        /// Settings for the Lake creation.
        /// </summary>
        public LakeSettings lakeSettings = new LakeSettings();

        /// <summary>
        /// Settings for Biome Shape creation.
        /// </summary>
        public ShapeSettings shapeSettings = new ShapeSettings();

        /// <summary>
        /// Which bounds to process: all terrains as one combined, every terrain individually
        /// </summary>
        public BoundsProcessingSettings boundsSettings = new BoundsProcessingSettings();

        /// <summary>
        /// Settings for rectangular terrain partitioning
        /// </summary>
        public RectangularPartitionSettings rectangularPartitionSettings = new RectangularPartitionSettings();

        /// <summary>
        /// Settings for Voronoi partitioning
        /// </summary>
        public VoronoiSettings voronoiSettings = new VoronoiSettings();
        
        /// <summary>
        /// Settings for Hexagon partitioning
        /// </summary>
        public HexagonSettings hexagonSettings = new HexagonSettings();

    }
}