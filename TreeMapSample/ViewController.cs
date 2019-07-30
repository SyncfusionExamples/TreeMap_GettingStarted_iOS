using Foundation;
using Syncfusion.SfTreeMap.iOS;
using System;
using UIKit;

namespace TreeMapSample
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            SFTreeMap treeMap = new SFTreeMap();
            treeMap.WeightValuePath = (NSString)"Population";
            treeMap.ColorValuePath = (NSString)"Growth";

            SFLeafItemSetting leafItemSetting = new SFLeafItemSetting();
            leafItemSetting.Gap = 2;
            leafItemSetting.LabelPath = (NSString)"Region";
            leafItemSetting.BorderColor = UIColor.FromRGB(169, 217, 247);
            leafItemSetting.ShowLabels = true;
            treeMap.LeafItemSettings = leafItemSetting;

            SFTreeMapFlatLevel flatLevel = new SFTreeMapFlatLevel();
            flatLevel.GroupBorderColor = UIColor.Gray;
            flatLevel.GroupBorderWidth = 1;
            flatLevel.GroupBackground = UIColor.White;
            flatLevel.HeaderHeight = 20;
            flatLevel.GroupPath = (NSString)"Continent";
            flatLevel.GroupGap = 5;
            flatLevel.HeaderStyle = new SFStyle() { Color = UIColor.Black };
            flatLevel.ShowHeader = true;
            treeMap.Levels.Add(flatLevel);

            SFLegendSetting legendSetting = new SFLegendSetting();
            legendSetting.ShowLegend = true;
            legendSetting.Size = new CoreGraphics.CGSize(500, 45);
            treeMap.LegendSettings = legendSetting;


            SFRangeColorMapping colorMapping = new SFRangeColorMapping();

            SFRange range1 = new SFRange();
            range1.LegendLabel = (NSString)"1 % Growth";
            range1.From = 0;
            range1.To = 1;
            range1.Color = UIColor.FromRGB(119, 216, 216);

            SFRange range2 = new SFRange();
            range2.LegendLabel = (NSString)"2 % Growth";
            range2.From = 0;
            range2.To = 2;
            range2.Color = UIColor.FromRGB(174, 217, 96);

            SFRange range3 = new SFRange();
            range3.LegendLabel = (NSString)"3 % Growth";
            range3.From = 0;
            range3.To = 3;
            range3.Color = UIColor.FromRGB(255, 175, 81);

            SFRange range4 = new SFRange();
            range4.LegendLabel = (NSString)"4 % Growth";
            range4.From = 0;
            range4.To = 4;
            range4.Color = UIColor.FromRGB(243, 210, 64);

            colorMapping.Ranges.Add(range1);
            colorMapping.Ranges.Add(range2);
            colorMapping.Ranges.Add(range3);
            colorMapping.Ranges.Add(range4);

            treeMap.LeafItemColorMapping = colorMapping;


            GetPopulationData();
            treeMap.DataSource = PopulationDetails;
            treeMap.ShowTooltip = true;
            treeMap.Frame = new CoreGraphics.CGRect(View.Frame.Left, View.Frame.Top + 50, View.Frame.Width, View.Frame.Height - 100);

            this.View.AddSubview(treeMap);
        }

        void GetPopulationData()
        {
            NSMutableArray array = new NSMutableArray();
            array.Add(getDictionary("Asia", "Indonesia", 3, 237641326));
            array.Add(getDictionary("Asia", "Russia", 2, 152518015));
            array.Add(getDictionary("North America", "United States", 4, 315645000));
            array.Add(getDictionary("North America", "Mexico", 2, 112336538));
            array.Add(getDictionary("North America", "Canada", 1, 35056064));
            array.Add(getDictionary("South America", "Colombia", 1, 47000000));
            array.Add(getDictionary("South America", "Brazil", 3, 193946886));
            array.Add(getDictionary("Africa", "Nigeria", 2, 170901000));
            array.Add(getDictionary("Africa", "Egypt", 1, 83661000));
            array.Add(getDictionary("Europe", "Germany", 1, 81993000));
            array.Add(getDictionary("Europe", "France", 1, 65605000));
            array.Add(getDictionary("Europe", "UK", 1, 63181775));
            PopulationDetails = array;
        }

        NSDictionary getDictionary(string continent, string region, double growth, double population)
        {

            object[] objects = new object[4];
            object[] keys = new object[4];
            keys.SetValue("Continent", 0);
            keys.SetValue("Region", 1);
            keys.SetValue("Growth", 2);
            keys.SetValue("Population", 3);
            objects.SetValue((NSString)continent, 0);
            objects.SetValue((NSString)region, 1);
            objects.SetValue(growth, 2);
            objects.SetValue(population, 3);
            return NSDictionary.FromObjectsAndKeys(objects, keys);
        }

        public NSMutableArray PopulationDetails
        {
            get;
            set;
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}