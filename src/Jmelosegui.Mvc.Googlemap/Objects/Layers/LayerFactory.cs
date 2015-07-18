using System;
using Jmelosegui.Mvc.Googlemap.Objects.Layers;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class LayerFactory
    {
        private readonly GoogleMap map;

        public LayerFactory(GoogleMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            this.map = map;
        }

        public HeatLayerBuilder AddHeatmapLayer()
        {
            var heatLayer = new HeatmapLayer(map);

            map.Layers.Add(heatLayer);

            return new HeatLayerBuilder(heatLayer);
        }

        public KmlLayerBuilder AddKmlLayer()
        {
            var kmlLayer = new KmlLayer(map);

            map.Layers.Add(kmlLayer);

            return new KmlLayerBuilder(kmlLayer);
        }

        public LayerBuilder AddTrafficLayer()
        {
            return CreateLayerBuilder(LayerType.Traffic);
        }

        public LayerBuilder AddBicyclingLayer()
        {
            return CreateLayerBuilder(LayerType.Bicycling);
        }

        public LayerBuilder AddTransitLayer()
        {
            return CreateLayerBuilder(LayerType.Transit);
        }

        private LayerBuilder CreateLayerBuilder(LayerType type)
        {
            var layer = new Layer(type.ToString(), map);
            map.Layers.Add(layer);
            return new LayerBuilder(layer);
        }
    }
}