using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity {

    public class AssetMeasurementInfo {

        private AssetInfo assetInfo;
        private List<MeasurementInfo> measurements;

        public AssetInfo AssetInfo {
            get { return this.assetInfo; }
            set { assetInfo = value; }
        }

        public List<MeasurementInfo> Measurements {
            get { return this.measurements; }
            set { measurements = value; }
        }

    }
}
